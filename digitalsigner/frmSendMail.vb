Imports System.Net.Mail
Imports System.Runtime.InteropServices
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel


Public Class frmSendMail

    Private WithEvents EmailServer As System.Net.Mail.SmtpClient
    'Ver 1.06-Ashish Start
    'Private WithEvents poSendMail As New vbSendMail.clsSendMail
    'Ver 1.06-Ashish End

    Public strMessage As String, mEmailId As String
    Dim strSMTPServer, strFrom, StrTo, strSubject As String


    Dim appXL As Excel.Application
    Private oEmailStatus As New EmailStatus
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Cursor = Cursors.Default

        'Ver 1.06-Ashish Start
        'poSendMail = Nothing
        'Ver 1.06-Ashish End
        Call KillEXCEL() 'jitendra
        Call KillProcess("DigitalSigner")  'jitendra

        'If MsgBox("Excell Application is Running. Do you want to Close all Excel Applications?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Call KillEXCEL()
        'End If
        MyBase.Dispose(True)
        ' KillCurProcess()  'jitendra
    End Sub

    Private Sub btnOutlook_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutlook.Click
        If txtSubject.Text.Length > 0 And txtMessage.Text.Length > 0 Then
            'abhay start
            SaveUserSettings()
            'abhay end
            Dim objWriter As StreamWriter
            Try
                Dim ol As New Microsoft.Office.Interop.Outlook.Application
                Dim ns As Microsoft.Office.Interop.Outlook.NameSpace
                Dim fdMail As Microsoft.Office.Interop.Outlook.MAPIFolder

                objWriter = New StreamWriter(Application.StartupPath & "\Status.txt", False)
                objWriter.Write("Sr No" & vbTab)
                objWriter.Write("Party Code" & vbTab)
                objWriter.Write("Email Address " & vbTab)
                objWriter.Write("Status")

                ns = ol.GetNamespace("MAPI")
                ns.Logon(, , True, True)

                prgBusy.Visible = True
                prgBusy.Value = 0
                prgBusy.Maximum = strSendEmail.Length
                btnOutlook.Enabled = False
                For intI As Integer = 0 To strSendEmail.Length - 1
                    If strSendEmail(intI) <> "" Then
                        prgBusy.Value = prgBusy.Value + 1

                        'Creating a new Mail Item Object
                        Dim newMail As Microsoft.Office.Interop.Outlook.MailItem

                        'Gets default Folder for my outllok OutBox
                        fdMail = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderOutbox)

                        'assign values to the newMail MailItem
                        newMail = fdMail.Items.Add(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
                        newMail.Subject = txtSubject.Text
                        newMail.Body = txtMessage.Text
                        'abhay start -validate email list

                        'If ValidEmailId(strSendEmail(intI)) Then
                        '    newMail.To = strSendEmail(intI)
                        'Else
                        '    MsgBox("Invalid To Email Id & " & strSendEmail(intI))
                        '    GoTo NextPosition
                        'End If
                        Dim maillist() As String = strSendEmail(intI).Split(";")
                        For Each strmail As String In maillist
                            If Not ValidEmailId(strmail) Then
                                MsgBox("Invalid To Email Id & " & strmail)
                                GoTo NextPosition
                            End If
                        Next
                        newMail.To = strSendEmail(intI)
                        'abhay end                        
                        If txtCC.Text.Length > 0 Then
                            If ValidEmailId(txtCC.Text) Then newMail.CC = txtCC.Text
                        Else

                        End If

                        'For Attachements
                        If blnUnsignedFiles = True Then
                            strDestFolderPath = strPdfPath & "\"
                        Else
                            strDestFolderPath = strPdfPath & "\SignedFiles\"
                        End If

                        'For Attachements
                        Dim intBodyLen As Integer = newMail.Body.Length
                        Dim oAttachs As Microsoft.Office.Interop.Outlook.Attachments = newMail.Attachments
                        Dim MsgAttach As Microsoft.Office.Interop.Outlook.Attachment
                        MsgAttach = oAttachs.Add(strDestFolderPath & strFileName(intI), , intBodyLen + 1, strFileName(intI)) '
                        '--MsgAttach = New Attachment(strDestFolderPath & strFileName(intI))

                        '--newMail.SaveSentMessageFolder = fdMail

                        Try
                            newMail.Send()
                        Catch ex As Exception

                        End Try

                    End If
NextPosition:
                Next intI
                MsgBox("Mail Sent Successfully.")
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
                MsgBox("Mail not Sent.")
            End Try

            objWriter.Close()
        End If

        prgBusy.Visible = False
        Me.Cursor = Cursors.Default
        btnOutlook.Enabled = True

    End Sub

    Public Function Validata() As Boolean

        Try
            'to check for valid data

            If txtSmtpServer.Text = "" Then
                'to check if SMTPserver is not null
                MsgBox("'SMTP Server' Cannot be empty")
                txtSmtpServer.Focus()
                Return False
            End If

            If txtUserName.Text = "" Then
                'to check whether From field is not null
                'Ver 1.06-Ashish Start
                'MsgBox("'From' email address Cannot be empty")
                MsgBox("UserName can not be empty")
                'Ver 1.06-Ashish end
                txtUserName.Focus()
                Return False
            End If
            'Ver 1.06-Ashish Start
            'If Trim(txtUserName.Text) <> "" Then
            '    If ValidEmailId(txtUserName.Text) = False Then
            '        'to check Email id entered is valid
            '        MsgBox("Invalid Email Id", MsgBoxStyle.Critical, "TdsPac")
            '        txtUserName.Focus()
            '        Return False
            '    End If
            'End If

            If Trim(txtFromId.Text) <> "" Then
                If ValidEmailId(txtFromId.Text) = False Then
                    'to check Email id entered is valid
                    MsgBox("Invalid Sender's Email Id", MsgBoxStyle.Critical, "TdsPac")
                    txtFromId.Focus()
                    Return False
                End If
            Else
                MsgBox("'From' email address Cannot be empty")
                txtFromId.Focus()
                Return False
            End If
            'Ver 1.06-Ashish End


            '<FieldName> Cannot be empty        V005
            'If txtTo.Text = "" Then
            '    'to check whether To field is empty
            '    MsgBox("Recipient 'To' email address Cannot be empty")
            '    txtTo.Focus()
            '    Return False
            'End If
            'If Trim(txtTo.Text) <> "" Then
            '    If ValidEmailId(txtTo.Text) = False Then
            '        'to check Email id entered is valid
            '        MsgBox("Invalid Email Id", MsgBoxStyle.Critical, "TdsPac")
            '        txtTo.Focus()
            '        Return False
            '    End If
            'End If
            If txtSubject.Text = "" Then
                'to check whether Subject is empty
                MsgBox("Email Subject Cannot be empty")
                txtSubject.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Call MsgBox(ex.Message)
        End Try
    End Function

    Public Function ValidEmailId(ByVal strEmailid As String) As Boolean
        Dim AryString As String() = Nothing
        Dim mEmailid As String
        Dim i As Integer
        Try
            'Check Printable chars except space & ^
            If InStr(strEmailid.Trim(), " ", CompareMethod.Text) > 0 Or InStr(strEmailid.Trim(), "^", CompareMethod.Text) > 0 Then Return False
            'Split with @ 
            AryString = strEmailid.Split(New [Char]() {"@"c})
            If (AryString.GetUpperBound(0)) = 1 Then
                ' @ should not preceded by dot without any chars
                If AryString(0).ToString.Trim() = "" Or AryString(0).ToString.Trim() = "." Then Return False
                ' @ preceded & succeeded by atleast one char
                For i = 1 To AryString.GetUpperBound(0)
                    If AryString(i).ToString.Trim() = "" Then
                        Return False
                    End If
                Next
                mEmailid = AryString(1).ToString
                AryString = Nothing
                'Split with . 
                AryString = mEmailid.Split(New [Char]() {"."c})
                If (AryString.GetUpperBound(0)) >= 1 Then
                    If AryString(0).ToString.Trim() = "" Then Return False
                    ' . preceded & succeeded by atleast one char & eMail id should not end with .
                    For i = 1 To AryString.GetUpperBound(0)
                        If AryString(i).ToString.Trim() = "" Then
                            Return False
                        End If
                    Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnTestMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestMail.Click
        Try
            'on click of send button
            If txtSmtpServer.Text.Trim = "" Then
                MessageBox.Show("Please enter smtp server", "Digital Signature")
                txtSmtpServer.Focus()
                Exit Sub
            ElseIf txtUserName.Text.Trim = "" Then
                'Ver 1.06-Ashish start
                'MessageBox.Show("Please enter from address", "Digital Signature")
                MessageBox.Show("Please enter User Name", "Digital Signature")
                'Ver 1.06-Ashish End
                txtUserName.Focus()
                Exit Sub
                'Ver 1.06-Ashish start
            ElseIf txtFromId.Text.Trim = "" Then
                MessageBox.Show("Please enter from address", "Digital Signature")
                txtFromId.Focus()
                Exit Sub
                'Ver 1.06-Ashish End
            ElseIf txtMessage.Text.Trim = "" Then
                If MessageBox.Show("Do you want to Send Empty Message", "Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
            ElseIf txtSubject.Text.Trim = "" Then
                If MessageBox.Show("Do you want to send email without Subject", "Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then Exit Sub
            End If
            'abhay start
            SaveUserSettings()
            'abhay end
            strSMTPServer = txtSmtpServer.Text
            btnTestMail.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim obj As New System.Net.Mail.SmtpClient(strSMTPServer, Val(txtPortNo.Text))

            'Mantis: 0131507
            'other SMTP servers required SSL authentication
            'Start
            If (chkSSL.Checked) Then
                obj.EnableSsl = True
            Else
                obj.EnableSsl = False
            End If
            'Mantis: 0131507
            'End

            'Ver 1.06-Ashish start
            'Dim mail As New MailMessage(txtUserName.Text, txtUserName.Text, txtSubject.Text, txtMessage.Text)
            Dim mail As New MailMessage(txtFromId.Text, txtFromId.Text, txtSubject.Text, txtMessage.Text)
            'Ver 1.06-Ashish start
            obj.UseDefaultCredentials = False
            obj.Credentials = New System.Net.NetworkCredential(txtUserName.Text, txtPassword.Text)
            obj.Send(mail)
            MsgBox("Mail Sent")

            Me.Cursor = Cursors.Default
            btnTestMail.Enabled = True

        Catch ex As Exception
            Call MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    'abhay Start
    Private Sub SaveUserSettings()
        If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then
            Dim dtcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
            Dim dtcmd As New OleDbCommand("update emailsettings set [ServerName]=@ServerName,[SendMailAs]=@SendMailAs,[sendermail]=@sendermail,[username]=@username,[password] =@password,[port]=@Port where id='1'", dtcon)
            Try
                dtcmd.Parameters.Add(New OleDbParameter("@ServerName", frmMain.Encrypt(txtSmtpServer.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@SendMailAs", frmMain.Encrypt(txtSendName.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@sendermail", frmMain.Encrypt(txtFromId.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@username", frmMain.Encrypt(txtUserName.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@password", frmMain.Encrypt(txtPassword.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@port", frmMain.Encrypt(txtPortNo.Text)))

                dtcon.Open()
                dtcmd.ExecuteNonQuery()
            Catch exath As Security.SecurityException
                MessageBox.Show("Not enough permissions to directory")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                dtcon.Close()
            End Try
        End If
    End Sub
    Private Sub GetUserSettings()
        If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then
            Dim dtcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
            Dim dtcmd As New OleDbCommand("select * from emailsettings  where id ='1'", dtcon)
            Try
                dtcon.Open()
                Dim dr As OleDbDataReader = dtcmd.ExecuteReader()
                dr.Read()
                txtSmtpServer.Text = frmMain.Decrypt(dr("ServerName").ToString())
                txtSendName.Text = frmMain.Decrypt(dr("SendMailAs").ToString())
                txtFromId.Text = frmMain.Decrypt(dr("sendermail").ToString())
                txtUserName.Text = frmMain.Decrypt(dr("username").ToString())
                txtPassword.Text = frmMain.Decrypt(dr("password").ToString())
                txtPortNo.Text = frmMain.Decrypt(dr("port").ToString())
            Catch exath As Security.SecurityException
                MessageBox.Show("Not enough permissions to directory")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                dtcon.Close()
            End Try
        End If
    End Sub

    'abhay end
    'Private Sub EmailServer_SendCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles EmailServer.SendCompleted
    '    If e.Error Is Nothing Then
    '        If e.Cancelled Then
    '            MessageBox.Show("Test Email Cancelled", "Email Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Else
    '            MessageBox.Show(String.Concat("Test Email Sent to ", mEmailId), "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If
    '    Else
    '        MessageBox.Show(e.Error.ToString, "Error Sending Email", MessageBoxButtons.OK, MessageBoxIcon.Hand)
    '    End If
    'End Sub
    'Ver 1.06-Ashish Start
    'Private Sub RetrieveSavedValues()
    '    ' *****************************************************************************
    '    ' Retrieve saved values by reading the components 'Persistent' properties
    '    ' *****************************************************************************
    '    poSendMail.PersistentSettings = True
    '    txtSmtpServer.Text = poSendMail.SMTPHost
    '    '--PopServer =  poSendMail.POP3Host)
    '    txtFrom.Text = poSendMail.from
    '    txtSendName.Text = poSendMail.FromDisplayName
    '    txtUserName.Text = poSendMail.Username
    '    txtPassword.Text = poSendMail.Password
    '    txtPortNo.Text = poSendMail.SMTPPort
    '    '--optEncodeType(poSendMail.EncodeType).Value = True
    '    If poSendMail.UseAuthentication Then chkOptionalLogin.Checked = True Else chkOptionalLogin.Checked = False
    'End Sub
    'Ver 1.06-Ashish End

    Private Sub frmSendMail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Call btnExit_Click(Nothing, Nothing)
    End Sub

    Private Sub frmSendMail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            btnBack_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmSendMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'gpSendMail.Enabled = Not DemoVersion
        'gpSendMail.Enabled = True

        'abhay start
        GetUserSettings()
        'abhay end
        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType
        'Ver 1.06-Ashish Start
        'Call RetrieveSavedValues()
        'Ver 1.06-Ashish End
        If txtPortNo.Text = "" Then
            txtPortNo.Text = "25"
        End If
        'strPdfPath
        If strSignedPdfPath.Equals(strPdfPath) = True Or strSignedPdfPath = "" Then
            strPdfPath = strPdfPath
        Else
            strPdfPath = strSignedPdfPath
        End If
    End Sub

    Private Sub chkOptionalLogin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'grpAdvOptions.Enabled = chkOptionalLogin.Checked
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        appXL = CreateObject("Excel.Application")
        Dim objWriter As StreamWriter
        'abhay start
        SaveUserSettings()
        'abhay end

        Dim strSucessPath As String
        Dim strFailedPath As String

        Dim countFail As Integer
        countFail = 0

        Dim countPass As Integer
        countPass = 0
        Dim blnCopy As Boolean
        'objWriter = Nothing
        'objWriter = New StreamWriter(Application.StartupPath & "\Status.txt", False)  'jk

        Try
            'on click of send button
            strSMTPServer = txtSmtpServer.Text
            'strFrom = txtFrom.Text
            'Ver 1.06-Ashish start
            'strFrom = txtUserName.Text
            strFrom = txtFromId.Text
            'Ver 1.06-Ashish End
            '--StrTo = txtTo.Text
            strSubject = txtSubject.Text
            strMessage = txtMessage.Text

            'If chkOptionalLogin.Checked Then
            '    If txtPassword.Text = "" Then
            '        MsgBox("Please Enter the Password")
            '        txtPassword.Focus()
            '        Exit Sub
            '    ElseIf txtUserName.Text <> txtFrom.Text Then
            '        MsgBox("The From Address and UserName not Matching.")
            '        txtFrom.Focus()
            '        Exit Sub
            '    End If
            'End If

            If Validata() Then
                'Ver 1.8 REQ243 start    'jitendra 11/12/2013
                'MessageBox.Show("Validated Successfully-1")
                'MessageBox.Show(strPdfPath)

                If Directory.Exists(strPdfPath & "\SignedFiles\Success") Then
                    Directory.Delete(strPdfPath & "\SignedFiles\Success", True)
                    Directory.CreateDirectory(strPdfPath & "\SignedFiles\Success")
                Else
                    Directory.CreateDirectory(strPdfPath & "\SignedFiles\Success")
                End If

                If Directory.Exists(strPdfPath & "\SignedFiles\Failed") Then
                    Directory.Delete(strPdfPath & "\SignedFiles\Failed", True)
                    Directory.CreateDirectory(strPdfPath & "\SignedFiles\Failed")
                Else
                    Directory.CreateDirectory(strPdfPath & "\SignedFiles\Failed")
                End If

                strSucessPath = strPdfPath & "\SignedFiles\Success"
                strFailedPath = strPdfPath & "\SignedFiles\Failed"

                Dim mail As New MailMessage()
                Dim MsgAttach As Net.Mail.Attachment
                'Ver 1.8 REQ243 end 

                prgBusy.Value = 0
                prgBusy.Maximum = strSendEmail.Length

                prgBusy.Visible = True
                btnSend.Enabled = False

                objWriter = Nothing
                objWriter = New StreamWriter(Application.StartupPath & "\Status.txt", False)

                'Ver 1.09-QC827 start
                If blnUnsignedFiles = True Then
                    strDestFolderPath = strPdfPath
                Else
                    strDestFolderPath = strPdfPath & "\SignedFiles\"
                End If
                'Ver 1.09-QC827 end

                For intI As Integer = 0 To strSendEmail.Length - 1
                    'For intI As Integer = 0 To strCode.Length - 1
                    prgBusy.Value = prgBusy.Value + 1

                    'objWriter.Write("Sr No" & vbTab)
                    'objWriter.Write("Party Code" & vbTab)
                    'objWriter.Write("Email Address " & vbTab)
                    'objWriter.Write("Status")
                    'If strEmail(intI) <> "" Then
                    ' If strSendEmail(intI) <> "" Then '29/01/2013
                    'If intI = "82" Then
                    '    MsgBox("Stop")
                    'End If

                    blnCopy = False
                    oEmailStatus.date = Format(Now.Date, "ddMMMyyyy")
                    oEmailStatus.DeducteeCode = strCode(intI).ToString
                    oEmailStatus.Files = strFileName(intI).ToString
                    oEmailStatus.EmailId = strSendEmail(intI).ToString
                    Try

                        'Send Email from VB.NET using the equivalent of the ShellExecute API
                        'Use the System.Diagnostics.Process.Start namespace. 

                        'objWriter.Write(intI + 1 & vbTab)
                        'objWriter.Write(strCode(intI) & vbTab)
                        'objWriter.Write(strSendEmail(intI) & vbTab)

                        Me.Cursor = Cursors.WaitCursor
                        EmailServer = New System.Net.Mail.SmtpClient(strSMTPServer, Val(txtPortNo.Text))
                        mail.From = New MailAddress(strFrom, txtSendName.Text)
                        'abhay start
                        'mail.To.Add(New MailAddress(strSendEmail(intI)))

                        Dim strmaillist() As String = strSendEmail(intI).Split(";")

                        'Ver 1.09-QC826 start
                        If strmaillist(0) = "" Then
                            Throw New Exception()
                        End If
                        'Ver 1.09-QC826 end

                        'Dim strmaillist() As String = strEmail(intI).Split(";")
                        mail.To.Clear()
                        For Each st As String In strmaillist
                            mail.To.Add(New MailAddress(st))
                        Next

                        'abhay end
                        If (EmailServer.Host.Contains("gmail")) Then
                            EmailServer.EnableSsl = True
                        Else
                            EmailServer.EnableSsl = False
                        End If

                        'Mantis: 0131507
                        'other SMTP servers required SSL authentication
                        'Start
                        If (chkSSL.Checked) Then
                            EmailServer.EnableSsl = True
                        Else
                            EmailServer.EnableSsl = False
                        End If

                        'Mantis: 0131507
                        'End
                        If txtCC.Text.Trim <> String.Empty Then
                            mail.CC.Clear()
                            mail.CC.Add(New MailAddress(txtCC.Text.Trim))
                        End If
                        mail.Subject = strSubject
                        mail.Body = strMessage
                        'Ver 1.8 REQ243 start 
                        'mail.BodyEncoding = MailEncoding.Base64
                        ''If chkFormat.Checked = True Then
                        ''    mail.BodyFormat = MailFormat.Html   'Send the mail in HTML Format
                        ''Else
                        ''    mail.BodyFormat = MailFormat.Text
                        'Ver 1.8 REQ243 end 
                        'For Attachements

                        'Ver 1.09-QC827 start the following code is placed above for loop
                        'If blnUnsignedFiles = True Then
                        '    strDestFolderPath = strPdfPath
                        'Else
                        '    strDestFolderPath = strPdfPath & "\SignedFiles\"
                        'End If
                        'Ver 1.09-QC827 end

                        'Ver 1.8 REQ243 start 


                        'Dim strFile As New FileInfo(strDestFolderPath & "\" & strFileName(intI))
                        'If strFile.Exists() Then
                        '    Dim MsgAttach As New Attachment(strDestFolderPath & "\" & strFileName(intI))
                        '    mail.Attachments.Add(MsgAttach)
                        'Else
                        '    objWriter.Write("File not found")
                        'End If
                        File.Copy(strDestFolderPath & "\" & strFileName(intI), strSucessPath & "\" & strFileName(intI))
                        blnCopy = True
                        Dim strFile As New FileInfo(strSucessPath & "\" & strFileName(intI))

                        If strFile.Exists() Then
                            ' mail.Attachments.Clear()
                            ' Dim MsgAttach As New Attachment(strSucessPath & "\" & strFileName(intI))
                            MsgAttach = New Attachment(strSucessPath & "\" & strFileName(intI))
                            mail.Attachments.Add(MsgAttach)
                        Else
                            objWriter.Write("File not found")
                        End If
                        'Ver 1.8 REQ243 end

                        'Try  jitendra
                        'Ver 1.06-Ashish start
                        EmailServer.UseDefaultCredentials = False
                        EmailServer.Credentials = New System.Net.NetworkCredential(strFrom, txtPassword.Text)
                        'EmailServer.Credentials = New System.Net.NetworkCredential(txtUserName.Text, txtPassword.Text)
                        'EmailServer.UseDefaultCredentials = True
                        'Ver 1.06-Ashish End
                        EmailServer.Send(mail)
                        'EmailServer.SendAsync( mail, True)

                        objWriter.Write("Mail Sent Successfully")
                        oEmailStatus.Status = "Success"
                        oEmailStatus.CreateTxtFile()
                        Call createXls(strSucessPath, strDestFolderPath, strCode(intI), strSendEmail(intI), strFileName(intI), countPass, strPasswordMail(intI), strPAN(intI), strPartyName(intI), strTdsAmount(intI), strBranch(intI))
                        countPass = countPass + 1
                        'MsgBox("Mail sent successfully.")
                        mail.Attachments.Clear()

                    Catch ex As Exception
                        'Ver 1.8 REQ243 start 
                        EmailServer.Dispose()
                        ' mail.Attachments.Dispose()
                        ' MsgBox(ex.Message)  'jitendra
                        'Ver 1.8 REQ243 end 

                        objWriter.Write("Mail Sent Failed")
                        oEmailStatus.Status = "Failed"
                        oEmailStatus.CreateTxtFile()
                        ' MsgBox("Mail Sent Failed.")
                        'Ver 1.8 REQ243 start 


                        If blnCopy = True Then
                            MsgAttach.Dispose()
                            'mail.Attachments.Clear()
                            'mail.Attachments.Dispose()
                            ' File.Copy(strPdfPath & "\" & strFileName(intI), strFailedPath & "\" & strFileName(intI))
                            File.Move(strSucessPath & "\" & strFileName(intI), strFailedPath & "\" & strFileName(intI))
                        Else
                            mail.Attachments.Clear()
                            'Ver 1.09-QC827 start
                            'File.Copy(strPdfPath & "\" & strFileName(intI), strFailedPath & "\" & strFileName(intI))
                            File.Copy(strDestFolderPath & "\" & strFileName(intI), strFailedPath & "\" & strFileName(intI))
                            'Ver 1.09-QC827 end
                        End If

                        'File.Copy(strPdfPath & "\" & strFileName(intI), strFailedPath & "\" & strFileName(intI))
                        Call createXls(strFailedPath, strDestFolderPath, strCode(intI), strSendEmail(intI), strFileName(intI), countFail, strPasswordMail(intI), strPAN(intI), strPartyName(intI), strTdsAmount(intI), strBranch(intI))
                        countFail = countFail + 1
                        'mail.Attachments.Clear()
                        'Ver 1.8 REQ243 end
                    End Try
                    ' End If  '29/01/2013
                    ' End If
NextPosition:
                Next intI
                'Ver 1.8 REQ243 start  'Mail sent successfully   
                ''==>jitendra               
                'For intI As Integer = 0 To strCode.Length - 1
                '    If strEmail(intI) = "" Then
                '        File.Copy(strPdfPath & "\" & (FileNames(intI) & ".pdf"), strFailedPath & "\" & (FileNames(intI) & ".pdf"))
                '        Call createXls(strFailedPath, strDestFolderPath, strCode(intI), strEmail(intI), FileNames(intI), countFail, strPasswordMail(intI), strPAN(intI), strPartyName(intI), strTdsAmount(intI), strBranch(intI))
                '        countFail = countFail + 1
                '    End If
                'Next
                ' ''<==jitendra
                MsgBox("Mail sent successfully: " & countPass & vbCrLf & "Mail sent Failed: " & countFail)
                MsgBox("Mail sent finished.")
                'Ver 1.8 REQ243 end 
                prgBusy.Visible = False
                Me.Cursor = Cursors.Default
                btnSend.Enabled = True
                objWriter.Close()
                objWriter = Nothing
            End If
        Catch ex As Exception
            'Exception occurs at the next when object not closed if it is not done
            'objWriter.Close()
            'objWriter = Nothing
            prgBusy.Visible = False
            Me.Cursor = Cursors.Default
            btnSend.Enabled = True
            Call MsgBox(ex.Message)
            MsgBox("Mail not Sent.")
        End Try
        appXL.Quit()
        appXL = Nothing
        ReleaseExcelObject(appXL)

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Dim frm1 As New frmSelectEmp
        frm1.Show()
        Me.Hide()
    End Sub

    'abhay start
    Private Sub ChkPreSetting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPreSetting.CheckedChanged
        If ChkPreSetting.Checked Then
            GetUserSettings()
        Else
            txtSmtpServer.Text = ""
            txtSendName.Text = ""
            txtFromId.Text = ""
            txtUserName.Text = ""
            txtPassword.Text = ""
            txtPortNo.Text = ""
        End If
    End Sub

    Private Sub btnstatusreport_Click(sender As Object, e As EventArgs) Handles btnstatusreport.Click
        Try
            Dim oFrmValidTCSDetails As New FrmEmailStatus
            Dim oDialogResult As DialogResult = oFrmValidTCSDetails.ShowDialog
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'abhay end
    'Ver 1.8 REQ243 start Jitendra
    Private Sub createXls(ByVal strSucessPath As String, ByVal strDestFolderPath As String, ByVal strPartyCode As String, ByVal strEmail As String, ByVal StrFileName As String, ByVal intNum As Integer, ByVal StrPasswordMail As String, ByVal StrPAN As String, ByVal strPartyName As String, ByVal strTdsAmount As String, ByVal StrBranch As String)

        ' Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        Try
            ' appXL = CreateObject("Excel.Application")
            ' appXL.Visible = True
            If IO.File.Exists(strSucessPath & "\EmailList.xls") Then
                wbXl = appXL.Workbooks.Open(strSucessPath & "\EmailList.xls")
            Else
                ' Add a new workbook.
                wbXl = appXL.Workbooks.Add
                CType(appXL.Workbooks(1).Worksheets("Sheet1"), Microsoft.Office.Interop.Excel.Worksheet).Name = "EmailList"
                shXL = wbXl.ActiveSheet


                ' Add table headers going cell by cell.
                shXL.Cells(1, 1).Value = "PartyCode"
                shXL.Cells(1, 2).Value = "Email"
                shXL.Cells(1, 3).Value = "File Name"
                shXL.Cells(1, 4).Value = "Password"
                shXL.Cells(1, 5).Value = "PAN"
                shXL.Cells(1, 6).value = "PartyName"
                shXL.Cells(1, 7).value = "TdsAmount"
                shXL.Cells(1, 8).value = "Branch"

                ' Format A1:D1 as bold, vertical alignment = center.
                With shXL.Range("A1", "H1")
                    .Font.Bold = True
                    .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                End With
            End If

            shXL = wbXl.ActiveSheet

            With shXL
                .Cells(intNum + 2, 1).value = strPartyCode
                .Cells(intNum + 2, 2).value = strEmail
                .Cells(intNum + 2, 3).value = StrFileName
                .Cells(intNum + 2, 4).value = StrPasswordMail
                .Cells(intNum + 2, 5).value = StrPAN
                .Cells(intNum + 2, 6).value = strPartyName
                .Cells(intNum + 2, 7).value = strTdsAmount
                .Cells(intNum + 2, 8).value = StrBranch
            End With


            raXL = shXL.Range("A1", "H1")
            raXL.EntireColumn.AutoFit()
            ' Make sure Excel is visible and give the user control
            ' of Excel's lifetime.
            ' appXL.Visible = True
            appXL.UserControl = True
            If IO.File.Exists(strSucessPath & "\EmailList.xls") Then
                wbXl.Save()
            Else
                wbXl.SaveAs(strSucessPath & "\EmailList.xls")
            End If

            wbXl.Close()
            ' Release object references.
            raXL = Nothing
            shXL = Nothing
            wbXl = Nothing
            'appXL.Quit()
            'appXL = Nothing
            '=>30/01/2014
            ReleaseExcelObject(raXL)
            ReleaseExcelObject(shXL)
            ReleaseExcelObject(wbXl)
            '<=30/01/2014
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'Ver 1.8 REQ243 end  

    '==>Jitendra 30/01/2014
    Private Sub ReleaseExcelObject(ByVal oEcel As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oEcel)
            oEcel = Nothing
        Catch ex As Exception
            oEcel = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    '<==Jitendra 30/01/2014


    Private Sub ttCN_MouseEnter(sender As Object, e As EventArgs)
        'ToolTip1.SetToolTip(ttCN, "On using google SMTP, Please refer thi link to config your SMTP details. https://myaccount.google.com/lesssecureapps")
    End Sub

    Private Sub frmSendMail_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub
End Class
