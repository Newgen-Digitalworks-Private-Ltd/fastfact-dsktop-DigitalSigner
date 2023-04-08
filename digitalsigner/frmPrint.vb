Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPrint

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Dim mform As New frmOptions
        mform.Show()
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call KillCurProcess()
        Call KillEXCEL()
        MyBase.Dispose(True)
        KillCurProcess()
    End Sub

    Private Sub frmPrint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            btnBack_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'pnlSignDate.Enabled = Not DemoVersion
        TLPSign.Enabled = Not DemoVersion
        btnNext.Enabled = Not DemoVersion

        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType

        Dim intI As Integer
        Dim ds As New DataSet
        Dim oleCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
        Dim oleAdp As New OleDbDataAdapter("select distinct SigningDate from ControlLog", oleCon)

        oleAdp.Fill(ds, "SignDates")

        cboSignDates.Items.Clear()
        cboSignDates.Items.Add("ALL")
        For intI = 0 To ds.Tables(0).Rows.Count - 1
            cboSignDates.Items.Add(ds.Tables(0).Rows(intI).Item(0))
        Next intI
        cboSignDates.SelectedIndex = 0
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        strPrintDate = cboSignDates.Text
        'GetReport()
        GridFill()

    End Sub

    Private Sub GridFill()
        Dim ds As New DataSet
        Dim oleCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
        Dim oleAdp As OleDbDataAdapter

        If cboSignDates.Text = "ALL" Then
            oleAdp = New OleDbDataAdapter("select SigningDate, Batch, ControlNo, FileName from ControlLog", oleCon)
        Else
            oleAdp = New OleDbDataAdapter("select SigningDate, Batch, ControlNo, FileName from ControlLog where SigningDate=#" & cboSignDates.Text & "#", oleCon)
        End If
        oleAdp.Fill(ds, "SignDates")
        dgControlLog.DataSource = ds.Tables(0)

    End Sub

    Private Sub GetReport()
        Dim mForm As New frmShowReport
        Dim param1Field As New ParameterField
        Dim oRpt As New ReportDocument
        'Dim margins As PageMargins

        Dim ds As New DataSet
        Dim sqlCon As New SqlClient.SqlConnection("Data Source=" & Application.StartupPath & "\DigitalSignatureLog.mdb;Initial Catalog=" & Application.StartupPath & "\DigitalSignatureLog.mdb;Integrated Security=SSPI;User ID=Admin;Password=Ffcs;")
        Dim sqlCmd As New SqlClient.SqlCommand("select * from ControlLog For XMl RAW, XMLDATA", sqlCon)
        Dim xmlRd As System.Xml.XmlReader

        Dim oleCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")

        sqlCmd.CommandTimeout = 0
        sqlCon.Open()
        xmlRd = sqlCmd.ExecuteXmlReader
        ds.ReadXml(xmlRd, XmlReadMode.Fragment)
        sqlCon.Close()
        ds.WriteXml("C:\SignDates.xml", XmlWriteMode.WriteSchema)

        'Dim oleAdp As New OleDbDataAdapter("select * from ControlLog For XMl RAW, XMLDATA", oleCon)
        'oleAdp.Fill(ds, "SignDates")

        'oRpt.Load(Application.StartupPath & "\rptControlList.rpt", OpenReportMethod.OpenReportByDefault)
        'oRpt.FileName = Application.StartupPath & "\rptControlList.rpt"
        oRpt = New rptControlList
        oRpt.SetDataSource(ds)
        'oRpt.SetDatabaseLogon("Admin", "Ffcs", Application.StartupPath() & "\DigitalSignatureLog.mdb", Application.StartupPath() & "\DigitalSignatureLog.mdb")
        'oRpt.VerifyDatabase()
        mForm.CrystalReportViewer1.ReportSource = oRpt
        mForm.CrystalReportViewer1.ShowRefreshButton = False
        mForm.CrystalReportViewer1.Zoom(1)
        mForm.Show()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Call ConvertGridToTDF(dgControlLog)
    End Sub
End Class