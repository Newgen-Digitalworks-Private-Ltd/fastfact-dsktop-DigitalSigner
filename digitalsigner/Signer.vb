Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.IO.Stream
'Ashish Start
Imports System.Net
Imports System.Reflection
'Ashish End

Module Signer

    Public FYear As String
    Public mCocode As String
    Public mCoName As String
    Public mPassword As String

    Public objConSigner As New OleDbConnection
    Public strEmail() As String
    Public strSendEmail() As String
    Public strFileName() As String
    Public strCode() As String

    'Jitendra
    Public emptyEmail() As String
    'Jitendra


    'Ver 1.3-2916 start
    Public FileNames() As String
    Public IsFileNameExists As Boolean
    'Ver 1.3-2916 end
    Public strSourceFolderPath As String
    Public strDestFolderPath As String

    Public blnSplashActive As Boolean
    Public blnNotify As Boolean

    'For Sign or Mail
    Public blnSign As Boolean
    Public blnUnsignedFiles As Boolean

    Public blnSigned As Boolean

    'For Form16,Form12BA
    Public strForm As String

    '
    Public strProduct As String
    Public strProductPath As String
    Public strPdfPath As String
    Dim aryPid As ArrayList

    Public strTableName As String
    Public strSvrName As String
    Public strAuthentication As String
    Public strUserID As String
    Public strPassword As String
    Public strFileConvention As String
    Public strFolderConvention As String

    Public DemoVersion As Boolean
    Public strServerError As String
    Public DongleType As String


    'Ver 1.8 REQ243 start 
    Public strPasswordMail() As String
    Public strPAN() As String
    Public strPartyName() As String
    Public strTdsAmount() As String
    Public strBranch() As String
    'Ver 1.8 REQ243 end 

    Declare Function DogRead Lib "Win32dll" (ByVal DogBytes As Integer, ByVal DogAddr As Integer, ByVal DogData As String) As Integer
    'Ashish Start
    ' Public strVersion As String = "Ver : 1.3" '& My.Application.Info.Version.Major & "." & My.Application.Info.Version.MajorRevision 'Assembly.GetExecutingAssembly.GetName.Version.Major.ToString & "." & [Assembly].GetExecutingAssembly.GetName.Version.Minor.ToString & [Assembly].GetExecutingAssembly.GetName.Version.Build.ToString
    Public strVersion As String = "Ver : " & [Assembly].GetExecutingAssembly.GetName.Version.Major.ToString & "." & [Assembly].GetExecutingAssembly.GetName.Version.Minor.ToString
    'Ashish End
    'Ver 1.7 REQVersion Start
    ' Public strDate As String = "  Dtd : 14/06/2013"
    'Ver 1.9 start
    'Public strDate As String = "  Dtd : 09/07/2015"
    'Public strDate As String = "  Dtd : 07/02/2019"
    'Public strDate As String = "  Dtd : 23/07/2020"
    'Public strDate As String = "  Dtd : 18/05/2021"
    Public strDate As String = "  Dtd : 21/01/2023"
    'Ver 1.9 end
    'Ver 1.7 REQVersion End
    Public strDongleStatus As String

    Public blnGenerateControlNo As Boolean
    'Converts a DataTable to Tab Delimited Format

    Public strPrintDate As String


    '==>Jitendra Integration
    Public strlicense As String
    Public strTxtPdfPath As String
    Public blnTdsPacIntegrate As Boolean
    Public strProductPathIntegrate As String
    Public blnoptSign As Boolean
    Public blnoptMail As Boolean
    Public strIntegrateExcelPath As String
    '<==Jitendra Integration 
    'Ver 2.0 FASTFACTS-673 start
    Public strSignedPdfPath As String
    'Ver 2.0 FASTFACTS-673 end

    Public Function ConvertDtToTDF(ByVal dt As DataTable) As String

        Dim dr As DataRow, ary() As Object, i As Integer

        Dim iCol As Integer
        Dim ExlAppln As New Object
        Dim ts As StreamWriter

        ExlAppln = CreateObject("Excel.Application")

        ts = New StreamWriter(Application.StartupPath & "\ExportP.xls")

        'Output Column Headers

        For iCol = 0 To dt.Columns.Count - 1

            ts.Write(dt.Columns(iCol).ToString & vbTab)

        Next

        ts.Write(vbCrLf)


        'Output Data

        For Each dr In dt.Rows

            ary = dr.ItemArray

            For i = 0 To UBound(ary)

                ts.Write(ary(i).ToString & vbTab)

            Next

            ts.Write(vbCrLf)

        Next
        ts.Close()

        If File.Exists(Application.StartupPath & "\ExportP.xls") = True Then
            Process.Start(Application.StartupPath & "\ExportP.xls")
        End If

    End Function

    Public Function ConvertListToTDF(ByVal dt As ListView) As String

        Dim dr As ListViewItem, ary() As Object, i As Integer

        Dim iCol As Integer
        Dim ExlAppln As New Object
        Dim ts As StreamWriter

        ExlAppln = CreateObject("Excel.Application")

        ts = New StreamWriter(Application.StartupPath & "\ExportP.xls")

        'Output Column Headers

        For iCol = 0 To dt.Columns.Count - 1

            ts.Write(dt.Columns(iCol).Text.ToString & vbTab)

        Next

        ts.Write(vbCrLf)


        'Output Data

        For Each dr In dt.Items

            For i = 0 To dr.SubItems.Count - 1

                ts.Write(dr.SubItems(i).Text.ToString & vbTab)

            Next

            ts.Write(vbCrLf)

        Next
        ts.Close()

        If File.Exists(Application.StartupPath & "\ExportP.xls") = True Then
            Process.Start(Application.StartupPath & "\ExportP.xls")
        End If

    End Function

    Public Function ConvertGridToTDF(ByVal dt As DataGridView) As String

        Dim dr As DataGridViewRow, ary() As Object, i As Integer

        Dim iCol As Integer
        Dim ExlAppln As New Object
        Dim ts As StreamWriter

        ExlAppln = CreateObject("Excel.Application")

        ts = New StreamWriter(Application.StartupPath & "\ExportP.xls")

        'Output Column Headers

        For iCol = 0 To dt.ColumnCount - 1

            ts.Write(dt.Item(iCol, 0).OwningColumn.Name.ToString & vbTab)

        Next

        ts.Write(vbCrLf)


        'Output Data

        For Each dr In dt.Rows

            For i = 0 To dr.Cells.Count - 1
                If dr.DataGridView(i, 0).ValueType.Name = "DateTime" Then
                    ts.Write(CDate(dr.Cells(i).Value).ToShortDateString() & vbTab)
                Else
                    ts.Write(dr.Cells(i).Value.ToString & vbTab)
                End If


            Next

            ts.Write(vbCrLf)

        Next
        ts.Close()

        If File.Exists(Application.StartupPath & "\ExportP.xls") = True Then
            Process.Start(Application.StartupPath & "\ExportP.xls")
        End If

    End Function

    Public Function Server() As Boolean

        Dim ds As New DataSet
        Dim adp As New OleDbDataAdapter
        Dim objCon As New OleDbConnection

        Dim fs As FileInfo
        Try
            If strProductPath = "" Then
                fs = New FileInfo(Application.StartupPath & "\Reg.ccp")
            Else
                fs = New FileInfo(strProductPath & "\Reg.ccp")
            End If

            Dim strPro() As Byte
            Dim strProduct As String

            Server = False
            If fs.Exists() = False Then Exit Function

            If objCon.State = 1 Then objCon.Close()
            objCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & strProductPath & "\Reg.ccp" & ";Persist Security Info=False;Jet OLEDB:Database Password=Ffcs;"
            objCon.Open()

            adp = New OleDbDataAdapter("SELECT * FROM Company", objCon)
            adp.Fill(ds, "Company")

            adp = New OleDbDataAdapter("SELECT * FROM Licence", objCon)

            adp.Fill(ds, "Licence")

            With ds.Tables("Company")
                For intI As Integer = 0 To .Rows.Count - 1
                    strPro = System.Text.Encoding.Default.GetBytes(.Rows(intI).Item("Pac"))
                    'Use BlockCopy method to copy block of bytes array
                    'to integer array of specified length (8)
                    Dim int(2) As Short
                    'Ver 1.5-3153 Start
                    If strPro.Length > 2 Then
                        'Ver 1.5-3153 End
                        Buffer.BlockCopy(strPro, 0, int, 0, 3)
                        'Print to output window 
                        strProduct = ""
                        For i As Integer = 0 To 1
                            strProduct = strProduct & (Chr(int(i)))
                        Next
                        'Ver 1.5-3153 Start
                    Else

                        strProduct = Chr(strPro(0)) & Chr(strPro(1))
                    End If
                    'Ver 1.5-3153 End


                    If strProduct = "DS" Then
                        If Format(.Rows(intI).Item("LogDate"), "dd/MM/yyyy") = Format(Now, "dd/MM/yyyy") Then
                            Server = True
                            If ds.Tables("Licence").Rows.Count > 0 Then
                                DongleType = "Dongle Sr.No: " & ds.Tables("Licence").Rows(0).Item("Licence")
                            End If
                            strServerError = ""
                            Exit For
                        Else
                            strServerError = "Invalid Form16Signer License"
                        End If
                    Else
                        strServerError = "Invalid Product"
                    End If
                Next
            End With

        Catch ex As Exception
            DemoVersion = True
        End Try

    End Function

    Public Sub KillEXCEL()
        Dim AllProcesses() As Process
        Dim CurrProcess As New Process
        Dim blnError As Boolean = False
        Try

            AllProcesses = Process.GetProcessesByName("Excel")
            If AllProcesses.Length > 0 Then
                If MsgBox("Excell Application is Running. Do you want to Close all Excel Applications?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If
            'For Each CurrProcess In AllProcesses
            For intProc As Integer = 0 To AllProcesses.Length - 1
                CurrProcess = AllProcesses(intProc)
                If blnError = False Then
                    blnError = True
                End If
                CurrProcess.Kill()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            MessageBox.Show(ex.StackTrace.ToString)

        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch ex As Exception
        Finally
            o = Nothing
        End Try
    End Sub

    Public Sub KillCurProcess()
        Dim currProcess As New Process
        Try
            currProcess = Process.GetCurrentProcess()
            currProcess.Kill()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Public Sub KillProcess(ByVal strProcessName As String)
        Dim AllProcesses() As Process
        Dim CurrProcess As New Process
        Dim blnError As Boolean = False
        Try

            AllProcesses = Process.GetProcessesByName(strProcessName)
            'For Each CurrProcess In AllProcesses
            For Each CurrProcess In AllProcesses
                If blnError = False Then
                    blnError = True
                End If
                CurrProcess.Kill()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            MessageBox.Show(ex.StackTrace.ToString)
        End Try
    End Sub

    Public Sub CheckDongle()
        Dim DogAddr As Integer
        Dim DogBytes As Integer
        Dim DogData As String
        Dim strValid
        Dim Y As Integer

        'On Error GoTo errhead

        DemoVersion = True
        DogAddr = 8
        DogBytes = 2
        DogData = "AA"

        Try
            Y = DogRead(DogBytes, DogAddr, DogData)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If UCase(DogData) = "DS" Then
            DemoVersion = False
            DogAddr = 60
            DogBytes = 5
            DogData = "AAAAA"
            Y = DogRead(DogBytes, DogAddr, DogData)
            DongleType = "Dongle Sr.No: " & DogData
        Else
            DongleType = "Demo Version"
        End If
        Exit Sub

errhead:
        Exit Sub
    End Sub
End Module
