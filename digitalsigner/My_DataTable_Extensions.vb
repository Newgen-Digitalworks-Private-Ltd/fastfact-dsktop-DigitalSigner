

Public Class My_DataTable_Extensions
    Private Sub New()
    End Sub
    Public Shared Sub ExportToExcel(ByVal Tbl As DataTable, Optional ByVal ExcelFilePath As String = Nothing)
        Try
            If Tbl Is Nothing OrElse Tbl.Columns.Count = 0 Then
                Throw New System.Exception("ExportToExcel: Null or empty input table!" & vbLf)
            End If

            ' load excel, and create a new workbook
            Dim excelApp As New Object()
            excelApp = CreateObject("Excel.Application")
            excelApp.Workbooks.Add()

            ' single worksheet
            Dim workSheet As Object = excelApp.ActiveSheet

            ' column headings
            For i As Integer = 0 To Tbl.Columns.Count - 1
                workSheet.Cells(1, (i + 1)) = Tbl.Columns(i).ColumnName
            Next

            ' rows
            For i As Integer = 0 To Tbl.Rows.Count - 1
                ' to do: format datetime values before printing
                For j As Integer = 0 To Tbl.Columns.Count - 1
                    workSheet.Cells((i + 2), (j + 1)) = Tbl.Rows(i)(j)
                Next
            Next

            ' check fielpath
            If ExcelFilePath IsNot Nothing AndAlso ExcelFilePath <> "" Then
                Try
                    workSheet.SaveAs(ExcelFilePath)
                    excelApp.Quit()
                    MessageBox.Show("Excel file saved!")
                Catch ex As System.Exception
                    Throw New System.Exception("ExportToExcel: Excel file could not be saved! Check filepath." & vbLf + ex.Message)
                End Try
            Else
                ' no filepath is given
                excelApp.Visible = True
            End If
        Catch ex As System.Exception
            Throw New System.Exception("ExportToExcel: " & vbLf + ex.Message)
        End Try
    End Sub
End Class