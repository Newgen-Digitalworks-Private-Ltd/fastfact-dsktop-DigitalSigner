Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles

Public Class frmOptions

    Dim objExcel As Object
    Dim objWorkBook As Object
    Dim objWorksheet As Object
    Dim objRange As Object

    Public strColCount As String
    Public strRowCount As String

    Dim EmailPos As Integer
    Dim CodePos As Integer
    'Ver 1.3-2916 start
    Dim FileNamePos As Integer
    'Ver 1.3-2916 end
    'Ver 1.8 REQ243 start 
    Dim PassPos As Integer
    Dim PANPos As Integer
    Dim PartyNamePos As Integer
    Dim TdsAmountPos As Integer
    Dim BranchPos As Integer

    'Ver 1.8 REQ243 end

    'Abhay start
    Dim strExcelPath As String
    'abhay end
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        Dim frm1 As New frmInitals
        frm1.Show()
        Me.Close()
        'Me.Hide()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        Dim dirPdfs As DirectoryInfo
        Dim frm1 As Form

        If chkGenerate.Checked = True Then
            If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") = False Then
                If MsgBox("Control MDB does not exists, Continue? ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    frm1 = New frmInitals
                    Me.Close()
                    frm1.Show()
                    Exit Sub
                Else
                    chkGenerate.Checked = False
                End If
            End If
        End If

        If optPrintControlLog.Checked Then
            blnSign = False
            frm1 = New frmPrint
        ElseIf optSign.Checked Then
            blnSign = True
            blnGenerateControlNo = chkGenerate.Checked

            frm1 = New frmMain
        ElseIf optMail.Checked Then
            blnSign = False
            blnUnsignedFiles = optUnsignedPdf.Checked
            Call KillEXCEL()
            If GetExcelValues() = False Then Exit Sub
            frm1 = New frmSelectEmp
        End If
        'Ashish New VS2010 Issue
        'Me.Close()
        Me.Hide()
        'Ashish New
        frm1.Show()

    End Sub

    Private Function GetExcelValues() As Boolean
        'abhay start
        strExcelPath = Application.StartupPath & "\EmailList.xls"
        If File.Exists(strSelectedPdfFolderPath) Then
            strExcelPath = strSelectedPdfFolderPath
        End If
        If Not txtExcelPath.Text = "" Then
            strExcelPath = txtExcelPath.Text
        End If
        'abhay end
        Dim intRow As Integer
        If optMail.Checked Then
            GetExcelValues = True
            Try
                Dim intExcelSearch As Integer
                objExcel = CreateObject("Excel.Application")
                'abhay start
                'objWorkBook = objExcel.Workbooks.Open(Application.StartupPath & "\EmailList.xls", , True)
                objWorkBook = objExcel.Workbooks.Open(strExcelPath, , True)
                'abhay end

                For Each objWorksheet In objExcel.ActiveWorkbook.Worksheets
                    If objWorksheet.Name = "EmailList" Then
                        Call FindRowColCount(objWorksheet, objRange)
                        Exit For
                    Else
                        intExcelSearch += 1
                    End If

                Next

                If intExcelSearch >= objExcel.activeworkbook.worksheets.count Then
                    MessageBox.Show("EmailList sheet not found", "Digital Signature")
                    'abhay start
                    ' Exit Function
                    Return False
                    'abhay end
                End If

                ReDim strCode(strRowCount - 2)
                ReDim strEmail(strRowCount - 2)
                'Ver 1.3-2916 start
                ReDim FileNames(strRowCount - 2)
                'Ver 1.3-2916 end
                'Ver 1.8 REQ243 start 
                ReDim strPasswordMail(strRowCount - 2)
                ReDim strPAN(strRowCount - 2)
                ReDim strPartyName(strRowCount - 2)
                ReDim strTdsAmount(strRowCount - 2)
                ReDim strBranch(strRowCount - 2)
                'Ver 1.8 REQ243 end 
                Dim conExcel As OleDb.OleDbConnection
                'abhay start
                'conExcel = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath() & "\EmailList.xls;Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
                conExcel = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strExcelPath & ";Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
                'abhay start
                conExcel.Open()
                Dim cmdExcel As New OleDbCommand("Select * from [EmailList$]", conExcel)
                Dim dr As OleDbDataReader = cmdExcel.ExecuteReader
                dr.Read()
                'For intRow = 2 To strRowCount
                intRow = 0

                If strRowCount = 1 Or strRowCount = 0 Then
                    MessageBox.Show("Verify excel file 'EmailList.xls' & try again!", "Digital Signature")
                    Return False
                End If

                Do Until dr.Read = False
                    For intCol As Integer = 0 To strColCount - 1
                        If IsDBNull(dr.Item(intCol)) = False Then
                            'MsgBox(dr.Item(intCol))
                            If CodePos = intCol + 1 Then
                                strCode(intRow) = dr.Item(intCol)
                            End If

                            If EmailPos = intCol + 1 Then
                                strEmail(intRow) = dr.Item(intCol)
                            End If
                            'Ver 1.3-2916 start
                            If FileNamePos = intCol + 1 Then
                                FileNames(intRow) = dr.Item(intCol)
                            End If
                            'Ver 1.3-2916 end
                            'Ver 1.8 REQ243 start 
                            If PassPos = intCol + 1 Then
                                strPasswordMail(intRow) = dr.Item(intCol)
                            End If
                            If PANPos = intCol + 1 Then
                                strPAN(intRow) = dr.Item(intCol)
                            End If
                            If PartyNamePos = intCol + 1 Then
                                strPartyName(intRow) = dr.Item(intCol)
                            End If
                            If TdsAmountPos = intCol + 1 Then
                                strTdsAmount(intRow) = dr.Item(intCol)
                            End If
                            If BranchPos = intCol + 1 Then
                                strBranch(intRow) = dr.Item(intCol)
                            End If
                            'Ver 1.8 REQ243 end 
                        End If
                    Next
                    If intRow = strRowCount Then
                        Exit Do
                    Else
                        intRow += 1
                    End If
                Loop
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Digital Signature")
            End Try
        Else

        End If
    End Function

    Public Sub FindRowColCount(ByVal objworksheet As Object, ByVal objRange As Object)
        Dim i, j, h As Integer
        Dim i2 As Integer
        Dim str, str1 As String
        'Ver 1.3-2916 start
        IsFileNameExists = False
        'Ver 1.3-2916 end
        strColCount = 0
        strRowCount = 0
        For i = 1 To 65535
            j = 65
            str1 = Chr(j) & i

            objRange = objworksheet.Range(str1)
            If Format(objRange.Value, "string") = "" Then
                Exit For
            End If
            strRowCount = strRowCount + 1
        Next
        For h = 1 To 200
            For i = 64 To 90
                str = Chr(i)
                For j = 65 To 90
                    If i = 64 Then str = ""
                    str1 = str & Chr(j) & h
                    objRange = objworksheet.Range(str1)
                    If UCase(objRange.value) = "PARTYCODE" Then
                        CodePos = j - 64
                    ElseIf UCase(objRange.value) = "EMAIL" Then
                        EmailPos = j - 64
                        'Ver 1.3-2916 start
                    ElseIf UCase(objRange.value) = "FILENAME" Then
                        IsFileNameExists = True
                        FileNamePos = j - 64
                        'Ver 1.3-2916 end
                        ''Ver 1.8 REQ243 start 
                    ElseIf UCase(objRange.value) = "PASSWORD" Then
                        PassPos = j - 64
                    ElseIf UCase(objRange.value) = "PAN" Then
                        PANPos = j - 64
                    ElseIf UCase(objRange.value) = "PARTYNAME" Then
                        PartyNamePos = j - 64
                    ElseIf UCase(objRange.value) = "TDSAMOUNT" Then
                        TdsAmountPos = j - 64
                    ElseIf UCase(objRange.value) = "BRANCH" Then
                        BranchPos = j - 64
                        ''Ver 1.8 REQ243 end 
                    End If


                    If Format(objRange.Value, "string") = "" Then
                        Exit Sub
                    End If
                    strColCount = strColCount + 1
                Next
            Next
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Call KillProcess("DigitalSigner")
        'If MsgBox("Excell Application is Running. Do you want to Close all Excel Applications?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Call KillEXCEL()
        'End If
        MyBase.Dispose(True)
        KillCurProcess()
    End Sub

    Private Sub frmOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If MsgBox("Excel Application is Running. Do you want to Close all Excel Applications?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Call KillEXCEL()
        'End If
        'KillCurProcess()
    End Sub

    Private Sub frmOptions_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            btnBack_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType
        'lblCompanyName.Text = mCoName & " "

        optSignedPdf.Checked = blnSigned
        optSignedPdf.Enabled = blnSigned
        optUnsignedPdf.Checked = Not blnSigned

        '--optUnsignedPdf.Checked = blnUnsignedFiles

        'If strProduct <> "SALTDS" Then
        '    cboForm.Visible = False
        '    lblSelection.Visible = False
        'Else
        '    cboForm.Visible = True
        '    lblSelection.Visible = True
        '    cboForm.SelectedIndex = 0
        'End If

        '==>Jitendra Integration

        If blnTdsPacIntegrate = True Then

            If blnoptSign = True Then
                optSign.Checked = True
            Else
                optSign.Checked = False
            End If

            If blnoptMail = True Then
                optMail.Checked = True
            Else
                optMail.Checked = False
            End If
            If optMail.Checked = True Then
                txtExcelPath.Text = strIntegrateExcelPath
                ' MsgBox("strExcelPath=" & strIntegrateExcelPath)
            End If
            'MsgBox("strExcelPath1=" & strIntegrateExcelPath)
        Else
            optSign.Checked = True
        End If
        If blnTdsPacIntegrate = True Then
            Me.Close()
            Call btnNext_Click(e, e)
        End If


        '<==Jitendra Integration.
    End Sub

    Private Sub optMail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMail.CheckedChanged
        'If optMail.Checked = True Then
        '    optSign.Checked = False
        '    optPrintControlLog.Checked = False
        'End If
        pnlSendMail.Enabled = optMail.Checked
        'pnlSign.Enabled = optSign.Checked
        TLPSign.Enabled = optSign.Checked
    End Sub

    Private Sub chkNotify_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNotify.CheckedChanged
        blnNotify = chkNotify.Checked
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkExcelTemplate.LinkClicked
        System.Diagnostics.Process.Start("EmailList.xls")
    End Sub

    Private Sub chkGenerate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGenerate.CheckedChanged
        chkNotify.Enabled = chkGenerate.Checked
        If chkGenerate.Checked = False Then chkNotify.Checked = False
    End Sub

    'Abhay start
    Private Sub ttCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ToolTip1.SetToolTip(ttCN, "on selecting this option ‘a Unique Control No of each certificate will maintained as per CIRCULAR NO.\r\n 2/2007, DATED 21-5-2007: The deductors will have to ensure that TDS certificates in Form No.16/16A " & vbCrLf & " bearing digital signatures have a control No. with log to be maintained by the employer (deductor)")
        ' lblnotifytext.Text = "on selecting this option ‘a Unique Control No of each certificate will maintained as per CIRCULAR NO.\r\n 2/2007, DATED 21-5-2007: The deductors will have to ensure that TDS certificates in Form No.16/16A " & vbCrLf & " bearing digital signatures have a control No. with log to be maintained by the employer (deductor)"

    End Sub

    Private Sub ttCN_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  ToolTip1.SetToolTip(ttCN, "on selecting this option ‘a Unique Control No of each certificate will maintained as per CIRCULAR NO. 2/2007, DATED 21-5-2007: The deductors will have to ensure that TDS certificates in Form No.16/16A bearing digital signatures have a control No. with log to be maintained by the employer (deductor)")
        'Ver 1.7 REQ-237 start
        ' lblnotifytext.Text = "on selecting this option ‘a Unique Control No of each certificate will maintained as per CIRCULAR NO.\r\n 2/2007, DATED 21-5-2007: The deductors will have to ensure that TDS certificates in Form No.16/16A " & vbCrLf & " bearing digital signatures have a control No. with log to be maintained by the employer (deductor)"
        ' lblnotifytext.Text = "on selecting this option ‘a Unique Control No of each certificate will maintained as per CIRCULAR NO.\r\n 2/2007, DATED 21-5-2007: " & vbCrLf & " The deductors will have to ensure that TDS certificates in Form No.16/16A " & vbCrLf & " bearing digital signatures have a control No. with log to be maintained by the employer (deductor)"
        'ToolTip1.SetToolTip(ttCN, "On selecting this option ‘a Unique Control No of each certificate will maintained as per CIRCULAR NO.\r\n 2/2007, DATED 21-5-2007: " & vbCrLf & "The deductors will have to ensure that TDS certificates in Form No.16/16A bearing digital signatures have a control No. with log to " & vbCrLf & "be maintained by the employer (deductor)")
        'Ver 1.7 REQ-237 end 
        ' pnlnotify.Visible = True
    End Sub

    Private Sub ttNotify_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ToolTip1.SetToolTip(ttNotify, "selecting this option will display the files which are already signed in PDF signed folder")
    End Sub

    Private Sub ttPrintControl_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ToolTip1.SetToolTip(ttPrintControl, "On selecting this option it will print the list of PDF files having control no.")

    End Sub
    Private Sub btnBrowes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowes.Click
        Dim dig As New OpenFileDialog()
        dig.Filter = "Excel Files (*.xls)|*.xls"
        dig.ShowDialog()
        txtExcelPath.Text = dig.FileName
    End Sub
    Private Sub ttEmail_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ToolTip1.SetToolTip(ttEmail, "use semicolon to send emails to multiple email IDs")
        'Ver 1.7 REQ-240 start
        ToolTip1.SetToolTip(lnkExcelTemplate, "use semicolon to send emails to multiple email IDs")
        'Ver 1.7 REQ-240 end 
    End Sub
    Private Sub ttbrExcel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Ver 1.7 REQ-237 start
        ' ToolTip1.SetToolTip(ttbrExcel, "EmailList.xls file will be used from PDF folder selected, if file does not exisits then file present in Digital Signer will be used," & Environment.NewLine & " if any other file is use then browse the same")
        'ToolTip1.SetToolTip(ttbrExcel, "EmailList.xls file present in Digital Signer will be used by default. To pick the file from another location browse now")
        'Ver 1.7 REQ-237 end 
    End Sub
    'abhay end

    Private Sub ttCN_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  pnlnotify.Visible = False
    End Sub

    Private Sub lblCompanyName_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub optSign_CheckedChanged(sender As Object, e As EventArgs) Handles optSign.CheckedChanged
        Try
            If optSign.Checked = True Then
                optMail.Checked = False
                optPrintControlLog.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub optPrintControlLog_CheckedChanged(sender As Object, e As EventArgs) Handles optPrintControlLog.CheckedChanged
        If optPrintControlLog.Checked = True Then
            optSign.Checked = False
            optMail.Checked = False
        End If
    End Sub
End Class