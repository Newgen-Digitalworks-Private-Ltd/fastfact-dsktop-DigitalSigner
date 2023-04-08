Imports System.IO
Public Class EmailStatus
    Public Declare Function GetDesktopWindow Lib "user32" () As Long
#Region "Variables"
    Private _Date As Date = Nothing
    Private _DeducteeCode As String = String.Empty
    Private _Files As String = String.Empty
    Private _EmailId As String = String.Empty
    Private _Status As String = String.Empty
    Private _EmailStatusData As New DataTable
#End Region
#Region "Property"
    Public Property [date] As Date
        Get
            Return _Date
        End Get
        Set(value As Date)
            _Date = value
        End Set
    End Property
    Public Property DeducteeCode As String
        Get
            Return _DeducteeCode
        End Get
        Set(value As String)
            _DeducteeCode = value
        End Set
    End Property
    Public Property Files As String
        Get
            Return _Files
        End Get
        Set(value As String)
            _Files = value
        End Set
    End Property
    Public Property EmailId As String
        Get
            Return _EmailId
        End Get
        Set(value As String)
            _EmailId = value
        End Set
    End Property
    Public Property Status As String
        Get
            Return _Status
        End Get
        Set(value As String)
            _Status = value
        End Set
    End Property
    Public Property EmailStatusData As DataTable
        Get
            Return _EmailStatusData
        End Get
        Set(value As DataTable)
            _EmailStatusData = value
        End Set
    End Property
#End Region
    Sub New()
        Try

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub CreateTxtFile()
        Try
            Dim FileName As String = Application.StartupPath & "\EmailStatus\EmailStatus_" & Format(Now.Date, "ddMMMyyyy") & ".txt"
            If Not FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\EmailStatus") Then FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\EmailStatus")

            Dim sw As StreamWriter = Nothing
            If (Not File.Exists(FileName)) Then
                'fs = File.Create(FileName)
                sw = File.CreateText(FileName)
                sw.WriteLine(Format([date], "ddMMMyyyy") & "^" & DeducteeCode & "^" & Files & "^" & EmailId & "^" & Status)
            Else
                sw = File.AppendText(FileName)
                sw.WriteLine(Format([date], "ddMMMyyyy") & "^" & DeducteeCode & "^" & Files & "^" & EmailId & "^" & Status)
            End If
            sw.Dispose()
            sw.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CreateDataStruct()
        Try
            EmailStatusData = New DataTable
            With EmailStatusData
                .Columns.Add("EmailDate", GetType(String)).DefaultValue = String.Empty
                .Columns.Add("DeducteeCode", GetType(String)).DefaultValue = String.Empty
                .Columns.Add("FileName", GetType(String)).DefaultValue = String.Empty
                .Columns.Add("EmailID", GetType(String)).DefaultValue = String.Empty
                .Columns.Add("Status", GetType(String)).DefaultValue = String.Empty
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub GenerateStatusReport()
        Try
            Dim FileName As String = Application.StartupPath & "\EmailStatus\EmailStatus_" & Format([date], "ddMMMyyyy") & ".txt"
            Dim DV As New DataView
            If (Not File.Exists(FileName)) Then Throw New Exception("No Information to View.")
            CreateDataStruct()
            GetStatusData(FileName)
            If EmailStatusData.Rows.Count <= 0 Then Throw New Exception("No Information to View.")
            If Status = "Success" Then
                If EmailStatusData.Select("Status = 'Success'").Length = 0 Then Throw New Exception("No Information to View.")
                DV = New DataView(EmailStatusData, "Status = 'Success'", String.Empty, DataViewRowState.CurrentRows)
            ElseIf Status = "Failed" Then
                If EmailStatusData.Select("Status = 'Failed'").Length = 0 Then Throw New Exception("No Information to View.")
                DV = New DataView(EmailStatusData, "Status = 'Failed'", String.Empty, DataViewRowState.CurrentRows)
            Else
                DV = EmailStatusData.DefaultView
            End If
            Dim XL As String = Application.StartupPath & "\EmailStatus\EmailStatus_" & Format([date], "ddMMMyyyy") & "." & IIf(DV.Count > 65500, "xlsx", "xls")
            If FileIO.FileSystem.FileExists(XL) Then FileIO.FileSystem.DeleteFile(XL)
            Call ExportToExcelNew(DV, XL)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GetStatusData(FileName As String)
        Try
            Dim StrAlllines() As String = File.ReadAllLines(FileName)
            For Each line As String In StrAlllines
                Dim StrArray() As String = line.Split("^")
                EmailStatusData.Rows.Add(Format(Date.Parse(StrArray(0)), "dd-MMM-yyyy"), StrArray(1), StrArray(2), StrArray(3), StrArray(4))
                EmailStatusData.AcceptChanges()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ExportToExcelNew(ByVal dsExport As DataView, StrExcel As String)
        Try
            Dim IEProcess As Process = New Process

            Dim hWndDesk
            Dim params
            Dim mFile As File
            Dim rs As Long
            params = vbNullString
            hWndDesk = GetDesktopWindow()

            Dim ts As StreamWriter
            Dim i, j As Integer
            Dim mExpText As String
            Dim mStr As String
            Dim mPos As Integer

            Dim ExlAppln As New Object
            Dim ExlBook As New Object

            ExlAppln = CreateObject("Excel.Application")

            ts = New StreamWriter(StrExcel)

            mExpText = ""
            mStr = ""

            For k As Integer = 0 To dsExport.Table.Columns.Count - 1
                mStr = dsExport.Table.Columns(k).ColumnName.ToString
                If mExpText = "" Then
                    mExpText = IIf(mStr = "", Space(1), mStr)

                Else
                    mExpText = mExpText & Chr(9) & IIf(mStr = "", Space(1), mStr)
                End If

            Next
            ts.WriteLine(mExpText)

            mExpText = ""
            mStr = ""


            For i = 0 To dsExport.Count - 1
                mStr = ""
                For j = 0 To dsExport.Table.Columns.Count - 1
                    If mExpText = "" Then

                        If IsDBNull(dsExport.Item(i)(j)) = False Then

                            mExpText = IIf((Convert.ToString(dsExport.Item(i)(j)) = ""), Space(1), Convert.ToString(dsExport.Item(i)(j)))

                        End If

                        mExpText = IIf(Mid(mExpText, 1, 1) = "0", "'" & mExpText, mExpText)
                    Else

                        If IsDBNull(dsExport.Item(i)(j)) = False Then
                            mPos = InStr(1, dsExport.Item(i)(j), Chr(13))

                            mStr = Convert.ToString(dsExport.Item(i)(j))

                        Else
                            mStr = vbNullString
                        End If


                        Do While mPos > 0
                            mStr = Mid(mStr, 1, Val(mPos) - 1) & " " & Mid(mStr, Val(mPos) + 2)
                            mPos = InStr(1, mStr, Chr(13))
                        Loop

                        mExpText = mExpText & Chr(9) & mStr
                    End If
                Next
                ts.WriteLine(mExpText)
                mExpText = ""
            Next
            ts.Close()

            If mFile.Exists(StrExcel) = True Then
                IEProcess.Start(StrExcel)
            End If
        Catch ex As Exception
            MsgBox("The process cannot access the file " & StrExcel & " because it is being used by another process.")
            If ex.Message = "The process cannot access the file " & StrExcel & " because it is being used by another process." Then
                MsgBox("Close file 'ExportP.xls' and then try again!")
            Else
                Call ErrHandler(ex)
            End If
        End Try
    End Sub
    Public Sub ErrHandler(ByVal strErr As Exception)
        MsgBox(strErr.Message)
        MsgBox(strErr.StackTrace)
    End Sub
End Class
