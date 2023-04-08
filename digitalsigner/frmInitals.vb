Imports System.IO
Imports System.Data
Imports System.Data.OleDb
'Ver 1.4-E314 Start
Imports System.Net
Imports System.Reflection
'Ver 1.4-E314 End

Public Class frmInitals


    Public cmsl_licno As String
    Public cmsl_custcode As String

    Dim strIniPath As String
    'Ver 1.7 REQ-236 start 
    Public strPdfFolderPath As String
    'Ver 1.7 REQ-236 end 
    'Ver 2.0 FASTFACTS-673 start
    Public strSignedPdfFolderPath As String
    'Ver 2.0 FASTFACTS-673 end

    'Ver 1.4-E314 Start
    Private Sub frmInitals_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim strUrl As String
        Dim strContent As String
        strUrl = "http://www.fastfacts.co.in/DIGSIGN.htm"
        Dim instream As StreamReader
        Dim webrq As WebRequest
        Dim webres As WebResponse
        Try
            webrq = WebRequest.Create(strUrl)
            webres = webrq.GetResponse()
            instream = New StreamReader(webres.GetResponseStream())
            strContent = instream.ReadToEnd().ToString
            Dim ver As String
            ver = [Assembly].GetExecutingAssembly.GetName.Version.Major.ToString & "." & [Assembly].GetExecutingAssembly.GetName.Version.Minor.ToString
            If ver < strContent Then
                lblOldVersion.Text = "You are using old version. Please download " & strContent
                lblOldVersion.Visible = True
            Else
                lblOldVersion.Text = ""
                lblOldVersion.Visible = False
            End If
        Catch ex As Exception
            lblOldVersion.Text = ""
            lblOldVersion.Visible = False
        End Try
    End Sub
    'Ver 1.4-E314 End

    Private Sub frmInitals_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'KillCurProcess()
    End Sub

    Private Sub frmInitals_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '==>Jitendra
        Dim strParameter() As String
        strParameter = Command.Split("~")
        If strParameter.Length = 7 Then
            strlicense = strParameter(0)
            strProductPathIntegrate = strParameter(1)
            strTxtPdfPath = strParameter(2)
            blnTdsPacIntegrate = strParameter(3)
            blnoptSign = strParameter(4)
            blnoptMail = strParameter(5)
            strIntegrateExcelPath = strParameter(6)
            'MsgBox("1" & strlicense)
            'MsgBox("2" & strProductPathIntegrate)
            'MsgBox("3" & strTxtPdfPath)
            'MsgBox("4" & blnoptSign)
            'MsgBox("5" & blnoptMail)
            'MsgBox("6" & strIntegrateExcelPath)

        End If
        'strlicense = True
        'strProductPathIntegrate = "C:\Working Dir\FF-TFS\DotNet Projects\Window Based\TdsPAcSql_DNF\bin"
        'strTxtPdfPath = "C:\Working Dir\FF-TFS\DotNet Projects\Window Based\Traces-From16_DigSigner\Traces-From16\bin\PdfFolder\MUMR17001F_2013-14\Q4\MUMR17001F_2013-14_Final16A"
        ' blnTdsPacIntegrate = True
        'blnoptSign = False
        'blnoptMail = True
        'strIntegrateExcelPath = "C:\Working Dir\FF-TFS\DotNet Projects\Window Based\Traces-From16_DigSigner\Traces-From16\bin\PdfFolder\MUMR17001F_2013-14\Q4\MUMR17001F_2013-14_Final16A\EmailList.xls"
        '<==Jitendra
        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType

        '==>JItendra Integration

        If blnTdsPacIntegrate = False Then
            txtPdfPath.Text = strPdfPath
            strIniPath = Application.StartupPath & "\Path.ini"

            'If File.Exists(strIniPath) = True Then
            '    Dim objFile As StreamReader
            '    objFile = New StreamReader(strIniPath)
            '    objFile.Read()
            '    Dim strMsg As String = Replace(Replace(Replace(objFile.ReadLine, """", "'"), "True", "1"), "False", "0")
            '    'Dim strMsg As String = Decrypt(strIniPath)
            '    '--Dim mline() As String = strmsg.Split(Chr(13))
            '    '--strLine = mline(0)
            '    strProductPath = Mid(strMsg, InStr(1, strMsg, "=") + 1)
            '    objFile.Close()
            '    objFile = Nothing
            'End If
            '<==Jitendra Integration
            txtPdfPath.Text = strPdfPath
            strIniPath = Application.StartupPath & "\Path.ini"

            If File.Exists(strIniPath) = True Then
                Dim objFile As StreamReader
                objFile = New StreamReader(strIniPath)
                objFile.Read()
                Dim strMsg As String = Replace(Replace(Replace(objFile.ReadLine, """", "'"), "True", "1"), "False", "0")
                'Dim strMsg As String = Decrypt(strIniPath)
                '--Dim mline() As String = strmsg.Split(Chr(13))
                '--strLine = mline(0)
                strProductPath = Mid(strMsg, InStr(1, strMsg, "=") + 1)
                objFile.Close()
                objFile = Nothing
            End If
        Else
            strProductPath = strProductPathIntegrate
        End If
        If strProductPath <> "" Then
            txtProductPath.Text = strProductPath.Trim
        End If

        'Ver 1.7 REQ-236 start 
        'code review pending for 'strPdfPath' veriable

        '==>JItendra Integration

        If blnTdsPacIntegrate = False Then
            strPdfFolderPath = Application.StartupPath & "\PDFPath.ini"
            'If File.Exists(strPdfFolderPath) = True Then
            '    Dim objFile As StreamReader
            '    objFile = New StreamReader(strPdfFolderPath)
            '    'objFile.Read()
            '    '  Dim strMsg As String = Replace(Replace(Replace(objFile.ReadLine, """", "'"), "True", "1"), "False", "0")
            '    ' strsavedpath = Mid(strMsg, InStr(1, strMsg, "=") + 1)
            '    txtPdfPath.Text = objFile.ReadToEnd()
            '    objFile.Close()
            '    objFile = Nothing
            'End If
            '<==Jitendra Integration

            strPdfFolderPath = Application.StartupPath & "\PDFPath.ini"
            If File.Exists(strPdfFolderPath) = True Then
                Dim objFile As StreamReader
                objFile = New StreamReader(strPdfFolderPath)
                'objFile.Read()
                '  Dim strMsg As String = Replace(Replace(Replace(objFile.ReadLine, """", "'"), "True", "1"), "False", "0")
                ' strsavedpath = Mid(strMsg, InStr(1, strMsg, "=") + 1)
                txtPdfPath.Text = objFile.ReadToEnd()
                objFile.Close()
                objFile = Nothing
            End If
            'check table exsist or not
        Else
            txtPdfPath.Text = strTxtPdfPath
        End If  'jitendra

        'Ver 2.0 FASTFACTS-673 start

        If blnTdsPacIntegrate = False Then
            strSignedPdfFolderPath = Application.StartupPath & "\SignedPDFPath.ini"
            If File.Exists(strSignedPdfFolderPath) = True Then
                Dim objFile As StreamReader
                objFile = New StreamReader(strSignedPdfFolderPath)
                txtSignedPDF.Text = objFile.ReadToEnd()
                objFile.Close()
                objFile = Nothing
            End If
            If txtSignedPDF.Text.Trim = "" Then
                txtSignedPDF.Text = txtPdfPath.Text
            End If
            'check table exsist or not
        Else
            txtPdfPath.Text = strTxtPdfPath
        End If  'jitendra

        'Ver 2.0 FASTFACTS-673 end


        If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then

            Dim dtcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")

            Dim dtcmd As New OleDbCommand("select * from UserSettings", dtcon)
            Dim objRead As OleDbDataReader  'Ver 1.8 REQ243 start 
            Try
                dtcon.Open()
                'Ver 1.7 Req-28112013 start
                'dtcmd.ExecuteScalar()
                objRead = dtcmd.ExecuteReader()
                'FASTFACTS-467 start
                Dim isArchievePresent As Boolean
                isArchievePresent = False
                If objRead.HasRows Then
                    Do While objRead.Read
                        For i As Integer = 0 To objRead.FieldCount - 1
                            If "Archieve" = objRead.GetName(i) Then
                                isArchievePresent = True
                            End If
                        Next
                    Loop
                    objRead.Close()
                    If isArchievePresent = False Then
                        dtcmd.CommandText = "Alter table UserSettings add Archieve varchar(10)"
                        dtcmd.ExecuteNonQuery()
                    End If
                End If
                'FASTFACTS-467 end 
                objRead = dtcmd.ExecuteReader() 'FASTFACTS-467 end 
                If objRead.HasRows Then
                    objRead.Close() ''FASTFACTS-467 end 
                    dtcmd.ExecuteScalar()
                Else
                    Dim dtcmd1 As New OleDbCommand("insert into UserSettings(id) values ('1') ", dtcon)
                    dtcmd1.ExecuteNonQuery()
                End If
                'Ver 1.7 Req-28112013 end 
            Catch ex As Exception
                If ex.Message.Contains("The Microsoft Jet database engine cannot find the input table or query 'UserSettings'") Then
                    'FASTFACTS-467 start
                    'dtcmd.CommandText = "create table UserSettings ( id char(1),PrintCertOn varchar(50),PrintCertAt varchar(50),H number,V number,Font varchar(50),Signer varchar(50),Author varchar(50) )"
                    dtcmd.CommandText = "create table UserSettings ( id char(1),PrintCertOn varchar(50),PrintCertAt varchar(50),H number,V number,Font varchar(50),Signer varchar(50),Author varchar(50),Archieve varchar(10) )"
                    'FASTFACTS-467 end 
                    dtcmd.ExecuteNonQuery()
                    dtcmd.CommandText = "insert into UserSettings(id) values ('1') "
                    dtcmd.ExecuteNonQuery()
                End If
            Finally
                dtcon.Close()
            End Try

            Try
                dtcon.Open()
                dtcmd.CommandText = "select * from emailsettings"
                'Ver 1.7 Req-28112013 start
                ' dtcmd.ExecuteScalar()
                objRead = dtcmd.ExecuteReader()
                If objRead.HasRows Then
                    dtcmd.ExecuteScalar()
                Else
                    Dim dtcmd1 As New OleDbCommand("insert into emailsettings(id) values ('1') ", dtcon)
                    dtcmd1.ExecuteNonQuery()
                End If
                'Ver 1.7 Req-28112013 end 
            Catch ex As Exception
                If ex.Message.Contains("The Microsoft Jet database engine cannot find the input table") Then
                    dtcmd.CommandText = "create table emailsettings ( id char(1),[ServerName] varchar(50), [SendMailAs] varchar(50),[sendermail] varchar(50),[username] varchar(50),[password] varchar(50),[port] varchar(50) )"
                    dtcmd.ExecuteNonQuery()
                    dtcmd.CommandText = "insert into emailsettings(id) values ('1') "
                    dtcmd.ExecuteNonQuery()
                End If
            Finally
                dtcon.Close()
            End Try

        End If
        '==>Jitendra Integration

        If blnTdsPacIntegrate = True Then
            Call btnOK_Click(sender, e)
        End If
        '<==Jitendra Integration
        'Ver 1.7 REQ-236 end 

        getCMSL()
    End Sub
    Public Function getCMSL()
        cmslcust.Text = ""

        Dim strLICDetailXMLFile As String = Application.StartupPath + "\\C4E1-E2B2-F0B8-A9E0_SLDetails.xml"
        If (File.Exists(strLICDetailXMLFile) = True) Then
            Using ds_LIC = New DataSet()
                ds_LIC.ReadXml(strLICDetailXMLFile)
                If (ds_LIC.Tables(0).Rows.Count > 0) Then
                    If ds_LIC.Tables(0).Rows(0)("RegKey").ToString() <> "" Then
                        cmsl_licno = ds_LIC.Tables(0).Rows(0)("RegKey").ToString().Substring(ds_LIC.Tables(0).Rows(0)("RegKey").ToString().Length - 4)
                    End If
                End If
            End Using
        End If

        Dim web As New ffcsCMSL.UpgradeLicense

        Try
            cmsl_custcode = web.GetCustSerialNoByLicNo(cmsl_licno)
        Catch ex As Exception

        End Try

        If cmsl_custcode <> "NO RECORD FOUND" Then
            cmslcust.Text = "Customer ID : " & cmsl_custcode
        Else
            cmslcust.Text = ""
        End If


    End Function



    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'MyBase.Dispose(True)
        KillCurProcess()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If lblOldVersion.Visible = True Then
            If txtProductPath.Text.Trim = String.Empty Then
                MessageBox.Show("Please select product folder", "Digital Signature")
                btnLicenceBrowse.Focus()
                Exit Sub
            End If
        End If

        If txtPdfPath.Text.Trim = String.Empty Then
            MessageBox.Show("Please select a folder", "Digital Signature")
            btnPdfBrowse.Focus()
            Exit Sub
        End If

        strPdfPath = txtPdfPath.Text.Trim
        'Ver 2.0 FASTFACTS-673 start
        strSignedPdfPath = txtSignedPDF.Text.Trim
        'Ver 2.0 FASTFACTS-673 end 

        Dim MainDirectory As New DirectoryInfo(strPdfPath)
        'Ver 2.0 FASTFACTS-673 start
        ' Dim SignedDir As New DirectoryInfo(strPdfPath & "\SignedFiles")
        Dim ChangedPath As String
        If strSignedPdfPath.Equals(strPdfPath) = True Or strSignedPdfPath = "" Then
            ChangedPath = strPdfPath
        Else
            ChangedPath = strSignedPdfPath
        End If
        Dim SignedDir As New DirectoryInfo(ChangedPath & "\SignedFiles")
        'Ver 2.0 FASTFACTS-673 end 


        If MainDirectory.Exists = False Then
            MessageBox.Show("Invalid path! select the proper path", "Digital Signature")
            Exit Sub
        End If

        If MainDirectory.GetFiles("*.pdf").Length = 0 Then
            MessageBox.Show("No pdf files found in the selected folder", "Digital Signature")
            Exit Sub
        ElseIf SignedDir.Exists = True Then
            If SignedDir.GetFiles("*.pdf").Length = 0 Then
                blnSigned = False
            Else
                blnSigned = True
            End If
        End If

        Dim frm As New frmOptions
        Me.Close()
        frm.Show()
        'Me.Hide()

    End Sub

    Private Sub btnLicenceBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLicenceBrowse.Click

        If (OpenFolder.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtProductPath.Text = OpenFolder.SelectedPath

            Dim objWriter As StreamWriter

            objWriter = Nothing

            objWriter = New StreamWriter(strIniPath)
            objWriter.WriteLine("LicencePath=" & txtProductPath.Text.Trim)
            objWriter.Close()
            objWriter = Nothing

            'EnCrypt(strIniPath)
            strProductPath = txtProductPath.Text.Trim

            If DemoVersion = True Then Call CheckDongle()

            If DemoVersion = True Then
                DemoVersion = Not Server()
            End If
            '
            If DemoVersion Then DongleType = "Dongle Not found - Demo Copy"

            'Ver 1.09-REQ676-----------------SL Functionality Start--------------------------------
            If DemoVersion = True Then
                Dim RandomNum As Random = New Random
                Dim strTxtFileName As String
                Dim strYYMM As String
                Dim sr As StreamReader
                Dim strFileValue As String
                Dim arrParameter() As String

                strTxtFileName = "StatusActivationFile" & Val(RandomNum.Next()) & ".txt"
                strYYMM = CDate(strDate.Replace(" Dtd : ", "").Trim()).Year.ToString.Substring(2, 2) & Format(CDate(strDate.Replace(" Dtd : ", "").Trim()).Month, "00")

                If File.Exists(Application.StartupPath & "\ACF.dll") Then
                    ''Process.Start(Application.StartupPath & "\SoftLicenses.exe ", """" & Application.StartupPath & "\ACF.dll""~" & strTxtFileName & "~" & strYYMM)
                    Dim myProcess As System.Diagnostics.Process = New System.Diagnostics.Process()
                    Dim strTital As String = "DIGITALSIGNER"

                    myProcess.StartInfo.FileName = Application.StartupPath & "\SoftLicenses.exe "
                    myProcess.StartInfo.Arguments = """" & Application.StartupPath & "\ACF.dll""~" & strTxtFileName & "~" & strYYMM & "~" & strTital
                    myProcess.Start()
                    myProcess.WaitForExit()

                    If File.Exists(Application.StartupPath & "\" & strTxtFileName) = True Then
                        sr = New StreamReader(Application.StartupPath & "\" & strTxtFileName)
                        Do While sr.EndOfStream = False
                            strFileValue = sr.ReadLine()
                            arrParameter = strFileValue.Split("~")
                        Loop
                        sr.Dispose()

                        File.Delete(Application.StartupPath & "\" & strTxtFileName)
                        DemoVersion = Convert.ToBoolean(arrParameter(0).ToString)
                        If DemoVersion = False Then
                            If arrParameter(1) = False Then
                                MessageBox.Show("Upgrade Licence Not Valid For Product." & vbCrLf & "Please Get Your Yearly Upgrade Licence." & vbCrLf & "Contact Support HelpDesk :- 022-40557033", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Application.Exit()
                                'End
                            Else
                                DongleType = "Online Activation"
                            End If
                        End If
                    End If
                End If
            End If
            ''Ver 1.09-REQ676-----------------SL Functionality End  --------------------------------
        End If

    End Sub

    Private Sub btnPdfBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdfBrowse.Click

        If strProductPath <> "" Then OpenFolder.SelectedPath = strProductPath.Trim
        If (OpenFolder.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtPdfPath.Text = OpenFolder.SelectedPath
            strSelectedPdfFolderPath = OpenFolder.SelectedPath
            'Ver 1.7 REQ-236 start 
            Dim objWriter As StreamWriter
            objWriter = Nothing
            objWriter = New StreamWriter(strPdfFolderPath)
            objWriter.WriteLine(txtPdfPath.Text.Trim)
            objWriter.Close()
            objWriter = Nothing
            'Ver 1.7 REQ-236 end 
        End If

    End Sub

    Private Sub GrpLogin_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'Ver 2.0 FASTFACTS-673 start
    Private Sub btnSignedPDF_Click(sender As Object, e As EventArgs) Handles btnSignedPDF.Click
        If strProductPath <> "" Then OpenFolder.SelectedPath = strProductPath.Trim
        If (OpenFolder.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtSignedPDF.Text = OpenFolder.SelectedPath
            strSelectedPdfFolderPath = OpenFolder.SelectedPath
            Dim objWriter As StreamWriter
            objWriter = Nothing
            objWriter = New StreamWriter(strSignedPdfFolderPath)
            objWriter.WriteLine(txtSignedPDF.Text.Trim)
            objWriter.Close()
            objWriter = Nothing

        End If

    End Sub
    'Ver 2.0 FASTFACTS-673 end
End Class