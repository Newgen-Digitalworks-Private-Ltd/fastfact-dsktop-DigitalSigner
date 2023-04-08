Imports System.IO
Imports System.Data
Imports System.Data.OleDb


Public Class frmSplash

    Dim intTime As Integer
    Dim blnListOver As Boolean
    Dim intStopTime As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

            intTime = intTime + 1
            If blnListOver = True Then
                If intTime > intStopTime Then
                    Me.Hide()
                    Timer1.Enabled = False
                    Dim frm As New frmInitals
                    frm.Show()
                End If
            End If
            Exit Sub

        Catch ex As Exception
            Me.Close()
            blnSplashActive = False
            frmInitals.Show()
        End Try

    End Sub


    Private Sub frmSplash_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        intTime = 3
    End Sub

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim strLine As String

        Timer1.Enabled = False
        tmrStart.Enabled = False
        DemoVersion = True

        Dim strIniPath As String
        strIniPath = Application.StartupPath & "\Path.ini"
        If File.Exists(strIniPath) = True Then
            'Dim strMsg As String = Decrypt(strIniPath)

            Dim objFile As StreamReader
            objFile = New StreamReader(strIniPath)
            objFile.Read()

            Dim strMsg As String = Replace(Replace(Replace(objFile.ReadLine, """", "'"), "True", "1"), "False", "0")
            strProductPath = Mid(strMsg, InStr(1, strMsg, "=") + 1).Trim

            objFile.Close()
            objFile = Nothing

            If File.Exists(Application.StartupPath & "\win32dll.dll") = False Then
                If File.Exists(strProductPath & "\win32dll.dll") = False Then
                    MessageBox.Show("Win32dll.dll not exist in Product Folder")
                    End
                Else
                    File.Copy(strProductPath & "\win32dll.dll", Application.StartupPath & "\win32dll.dll", False)
                End If
            End If
        End If

        If DemoVersion = True Then Call CheckDongle()

        If DemoVersion = True Then
            DemoVersion = Not Server()
        End If

        'Ver 1.2-E88 start
        If DemoVersion = True Then
            If File.Exists(strProductPath & "\TdsPacSQL.key") = True Then
                DemoVersion = False
                DongleType = "TdsPacSQL.key Licence"
            End If
        End If
        'Ver 1.2-E88 end
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
                            MessageBox.Show("Upgrade Licence Not Valid For Product." & vbCrLf & "Please Get Your Yearly Upgrade Licence File." & vbCrLf & "Contact Support HelpDesk :- 022-40557033", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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


        Dim appName As String = Process.GetCurrentProcess.ProcessName
        'Dim strProcess As String = "taskkill /F /FI """"IMAGENAME eq Digitalsigner.exe"""

        Dim sameProcessTotal As Integer = Process.GetProcessesByName(appName).Length
        If sameProcessTotal > 1 Then
            Call KillProcess("DigitalSigner")
        End If

        Timer1.Enabled = True
        tmrStart.Enabled = True
        appName = Nothing

        sameProcessTotal = Nothing
        Dim SysDate As Date

        blnSplashActive = True
        intStopTime = 2
        intTime = 0
        blnListOver = False

        tmrStart.Enabled = True

    End Sub

    Private Sub tmrStart_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrStart.Tick

        tmrStart.Enabled = False
        Dim frm As New frmLogin

        If intTime > intStopTime Then
            Timer1.Enabled = False
            tmrStart.Enabled = False
            Me.Hide()
        Else
            blnListOver = True
            Exit Sub
        End If

        frm.Show()

    End Sub

    '    Private Sub CheckDongle()
    '        Dim DogAddr As Long
    '        Dim DogBytes As Long
    '        Dim DogData As String
    '        Dim strValid

    '        Dim Y As Long

    '        On Error GoTo ErrHead

    '        DemoVersion = True
    '        blnWebDemo = True

    '        DogAddr = 10
    '        DogBytes = 2
    '        DogData = "AAAAAAA"

    '        Y = DogRead(DogBytes, DogAddr, DogData)
    '        If DogData = "PayPacE" Then
    '            DemoVersion = False
    '            'Ver 4.73-NetDog start
    '            DongleType = "Licence activated by DongleSU"
    '            'Ver 4.73-NetDog end
    '        ElseIf DogData = "PayPacS" Then
    '            DemoVersion = False
    '            DongleType = "Licence activated by DongleSQL"
    '        End If

    '        DogAddr = 18
    '        DogBytes = 1
    '        DogData = "A"

    '        Y = DogRead(DogBytes, DogAddr, DogData)
    '        If DogData = "W" Then
    '            blnWebDemo = False
    '        End If


    '        Exit Sub
    'ErrHead:
    '        Exit Sub
    '    End Sub

End Class