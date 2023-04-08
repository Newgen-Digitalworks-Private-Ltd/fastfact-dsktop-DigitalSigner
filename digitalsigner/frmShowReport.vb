Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.OleDb

Public Class frmShowReport

    Private Sub frmShowReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim param1Fields As New ParameterFields
        'Dim oRpt As New ReportDocument
        ''Dim margins As PageMargins

        'Dim ds As New DataSet
        'Dim oleCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
        'Dim oleAdp As New OleDbDataAdapter("select * from ControlLog", oleCon)
        'oleAdp.Fill(ds, "SignDates")

        'Dim myParam As New ParameterField
        'Dim myDiscreteValue As New ParameterDiscreteValue
        'Dim myParaValue As New ParameterValues
        'Dim myParamDefs As FormulaFieldDefinitions
        'Dim myParamDef As FormulaFieldDefinition

        ''myParam.Name = "@SignDate"
        ''myDiscreteValue.Value = strPrintDate
        ''myParam.CurrentValues.Add(myDiscreteValue)
        ''param1Fields.Add(myParam)

        'oRpt.Load(Application.StartupPath & "\rptControlList.rpt", OpenReportMethod.OpenReportByDefault)

        'myParamDefs = oRpt.DataDefinition.FormulaFields
        'myParamDef = myParamDefs.Item("StrDate")
        ''myParaValue = myParamDef.CurrentValues
        'myDiscreteValue.Value = strPrintDate
        'myParaValue.Add(myDiscreteValue)
        ''myParamDef.ApplyCurrentValues(myParaValue)
        'myParamDef.Text = strPrintDate

        'oRpt.SetDataSource(ds)
        'oRpt.SetDatabaseLogon("Admin", "Ffcs", Application.StartupPath() & "\DigitalSignatureLog.mdb", Application.StartupPath() & "\DigitalSignatureLog.mdb")
        'oRpt.VerifyDatabase()

        ''oRpt.ParameterFields.Add("@SignDate", ParameterValueKind.DateParameter, DiscreteOrRangeKind.DiscreteValue)
        ''oRpt.SetParameterValue(0, myDiscreteValue)
        'CrystalReportViewer1.ReportSource = Nothing
        'CrystalReportViewer1.ReportSource = oRpt
        'If strPrintDate = "ALL" Then
        '    CrystalReportViewer1.SelectionFormula = ""
        'Else
        '    CrystalReportViewer1.SelectionFormula = "{ControlLog.SigningDate} = Date(""" & strPrintDate & """)"
        'End If

        ''CrystalReportViewer1.ParameterFieldInfo = param1Fields
        ''CrystalReportViewer1.ParameterFieldInfo.Add("SignDate", ParameterValueKind.DateParameter, DiscreteOrRangeKind.DiscreteValue, "rptControlList.rpt")
        'CrystalReportViewer1.ShowRefreshButton = False
        'CrystalReportViewer1.Zoom(1)
        'CrystalReportViewer1.RefreshReport()
    End Sub
End Class