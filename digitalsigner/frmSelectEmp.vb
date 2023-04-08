Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmSelectEmp

    Dim blnselect As Boolean
    Dim intcount As Integer
    Dim intChkCount As Integer
    Dim appXL As Excel.Application

    Private Sub InitializeForm()

        'Retrieve To Name Addresses from Database
        Dim objAdapter As New OleDbDataAdapter
        Dim objData As New DataSet
        Dim intJ As Integer

        With lstFileList
            .Clear()
            If optExcelRecords.Checked Then
                .Columns.Add("Code", 75, HorizontalAlignment.Left)
                .Columns.Add("Name of the file", 150, HorizontalAlignment.Left)
            Else
                .Columns.Add("Name of the file", 150, HorizontalAlignment.Left)
                .Columns.Add("Code", 75, HorizontalAlignment.Left)
            End If
            .Columns.Add("Email Id", 175, HorizontalAlignment.Left)

            Dim dirPdfs As DirectoryInfo

            dirPdfs = New DirectoryInfo(strPdfPath)



            If dirPdfs.Exists = False Then
                MsgBox("No pdfs found")
                Exit Sub
            End If

            Dim mFiles
            Dim mFile As FileInfo

            Dim mItem As New ListViewItem
            If optExcelRecords.Checked Then
                ProgressBar1.Maximum = strCode.Length
                ProgressBar1.Value = 0
                ProgressBar1.Visible = True

                If chkWithEmail.Checked = True Then
                    For intI As Integer = 0 To strCode.Length - 1
                        ProgressBar1.Value += 1

                        If strEmail(intI) <> "" Then
                            mItem = New ListViewItem
                            mItem.Text = strCode(intI)
                            'Ver 1.3-2916 start
                            If IsFileNameExists = False Then
                                'Ver 1.3-2916 end
                                mFiles = dirPdfs.GetFiles("" & strCode(intI) & "*.pdf")
                                'Ver 1.3-2916 start
                            Else
                                mFiles = dirPdfs.GetFiles("" & FileNames(intI) & "*.pdf")
                            End If
                            'Ver 1.3-2916 end
                            If mFiles.length > 0 Then
                                mItem.SubItems.Add(mFiles(0).Name)
                            Else
                                mItem.SubItems.Add("")
                            End If
                            mItem.SubItems.Add(strEmail(intI))
                            .Items.AddRange(New ListViewItem() {mItem})
                        End If
                    Next
                ElseIf chkWithoutEmail.Checked = True Then
                    For intI As Integer = 0 To strCode.Length - 1
                        ProgressBar1.Value += 1

                        If strEmail(intI) = "" Then
                            mItem = New ListViewItem

                            mItem.Text = strCode(intI)
                            'Ver 1.3-2916 start
                            If IsFileNameExists = False Then
                                'Ver 1.3-2916 end
                                mFiles = dirPdfs.GetFiles("" & strCode(intI) & "*.pdf")
                                'Ver 1.3-2916 start
                            Else
                                mFiles = dirPdfs.GetFiles("" & FileNames(intI) & "*.pdf")
                            End If
                            'Ver 1.3-2916 end
                            If mFiles.length > 0 Then
                                mItem.SubItems.Add(mFiles(0).Name)
                            Else
                                mItem.SubItems.Add("")
                            End If
                            mItem.SubItems.Add(strEmail(intI))
                            .Items.AddRange(New ListViewItem() {mItem})
                        End If

                    Next
                Else
                    For intI As Integer = 0 To strCode.Length - 1
                        ProgressBar1.Value += 1

                        mItem = New ListViewItem

                        mItem.Text = strCode(intI)
                        'Ver 1.3-2916 start
                        If IsFileNameExists = False Then
                            'Ver 1.3-2916 end
                            mFiles = dirPdfs.GetFiles("" & strCode(intI) & "*.pdf")
                            'Ver 1.3-2916 start
                        Else
                            mFiles = dirPdfs.GetFiles("" & FileNames(intI) & "*.pdf")
                        End If
                        'Ver 1.3-2916 end
                        If mFiles.length > 0 Then
                            mItem.SubItems.Add(mFiles(0).Name)
                        Else
                            mItem.SubItems.Add("")
                        End If
                        mItem.SubItems.Add(strEmail(intI))
                        .Items.AddRange(New ListViewItem() {mItem})
                    Next
                End If
            ElseIf optPdfRecords.Checked Then
                If strCode.Length = 0 Then
                    MessageBox.Show("Verify excel file 'EmailList.xls' & try again!", "Digital Signature")
                    btnBack_Click(Nothing, Nothing)
                End If

                ProgressBar1.Maximum = dirPdfs.GetFiles.Length
                ProgressBar1.Value = 0
                ProgressBar1.Visible = True

                mFiles = dirPdfs.GetFiles("*.pdf")
                If chkWithEmail.Checked Then
                    For Each mFile In mFiles
                        ProgressBar1.Value += 1
                        mItem = New ListViewItem

                        mItem.Text = mFile.Name
                        For intI As Integer = 0 To strCode.Length - 1

                            If Mid(mFile.Name, 1, strCode(intI).Length) = strCode(intI) Then
                                If strEmail(intI) <> "" Then
                                    mItem.SubItems.Add(strCode(intI))
                                    mItem.SubItems.Add(strEmail(intI))
                                    .Items.AddRange(New ListViewItem() {mItem})
                                End If
                                Exit For
                            End If
                        Next
                    Next
                ElseIf chkWithoutEmail.Checked Then
                    For Each mFile In mFiles
                        ProgressBar1.Value += 1
                        mItem = New ListViewItem

                        mItem.Text = mFile.Name
                        For intI As Integer = 0 To strCode.Length - 1

                            If Mid(mFile.Name, 1, strCode(intI).Length) = strCode(intI) Then
                                If strCode(intI) <> "" Then
                                    mItem.SubItems.Add(strCode(intI))
                                Else
                                    mItem.SubItems.Add("")
                                End If
                                If strEmail(intI) = "" Then
                                    mItem.SubItems.Add("")
                                    .Items.AddRange(New ListViewItem() {mItem})
                                End If

                                Exit For
                            End If
                        Next
                        If mItem.SubItems.Count = 1 Then .Items.AddRange(New ListViewItem() {mItem})
                    Next
                Else
                    For Each mFile In mFiles
                        ProgressBar1.Value += 1
                        mItem = New ListViewItem

                        mItem.Text = mFile.Name
                        For intI As Integer = 0 To strCode.Length - 1

                            If Mid(mFile.Name, 1, strCode(intI).Length) = strCode(intI) Then
                                mItem.SubItems.Add(strCode(intI))
                                mItem.SubItems.Add(strEmail(intI))
                                .Items.AddRange(New ListViewItem() {mItem})
                                Exit For
                            End If

                        Next
                        If mItem.SubItems.Count = 1 Then .Items.AddRange(New ListViewItem() {mItem})
                    Next
                End If

            End If

            ProgressBar1.Visible = False
            lblNoEmployee.Text = "Total number of records:    " & lstFileList.Items.Count

            If .Items.Count > 0 Then .Items(0).Selected = True
        End With

    End Sub

    Sub SelectListView(ByVal lstView As ListView, ByVal strValue As String)

        Dim mList As ListViewItem
        mList = lstFileList.FindItemWithText(strValue)

        If Not mList Is Nothing Then
            mList.Selected = True
            mList.Focused = True
            mList.EnsureVisible()
        End If

    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If lstFileList.CheckedItems.Count = 0 Then
            MsgBox("Select records from the list ")
            lstFileList.Focus()
            Exit Sub
        End If

        'Retrieve To Name Addresses from Database
        Dim objAdapter As New OleDbDataAdapter
        Dim objData As New DataSet

        ReDim strSendEmail(lstFileList.CheckedItems.Count - 1)
        ReDim strFileName(lstFileList.CheckedItems.Count - 1)

        '--If objConSigner.State = ConnectionState.Closed Then objConSigner.Open()

        For intChecked As Integer = 0 To lstFileList.CheckedItems.Count - 1

            'If strProduct = "SALTDS" Then
            '    If optCode.Checked Then
            '        objAdapter = New OleDbDataAdapter("select EmpCode,[Name],[Email] from EmpMaster where EmpCode='" & lstFileList.CheckedItems(intChecked).Text & "'", objConSigner)
            '    Else
            '        objAdapter = New OleDbDataAdapter("select EmpCode,[Name],[Email] from EmpMaster where EmpCode='" & lstFileList.CheckedItems(intChecked).SubItems(1).Text & "'", objConSigner)
            '    End If
            'Else
            '    If optCode.Checked Then
            '        objAdapter = New OleDbDataAdapter("select GLCD,[ACName],[Email] from PAYEE where GLCD='" & lstFileList.CheckedItems(intChecked).Text & "'", objConSigner)
            '    Else
            '        objAdapter = New OleDbDataAdapter("select GLCD,[ACName],[Email] from PAYEE where GLCD='" & lstFileList.CheckedItems(intChecked).SubItems(1).Text & "'", objConSigner)
            '    End If
            'End If

            'objData.Tables.Clear()
            'objAdapter.Fill(objData, "EmpMaster")

            'If objData.Tables("EmpMaster").Rows.Count > 0 Then

            'If IsDBNull(objData.Tables("EmpMaster").Rows(0).Item("Email")) Then
            '    strEmail(intChecked) = ""
            'Else
            '    strEmail(intChecked) = objData.Tables("EmpMaster").Rows(0).Item("Email")
            'End If

            strSendEmail(intChecked) = lstFileList.CheckedItems(intChecked).SubItems(2).Text
            strFileName(intChecked) = lstFileList.CheckedItems(intChecked).SubItems(1).Text
            If strSendEmail(intChecked).Trim = "" Then
                '--MsgBox("Email Id Not Exists For Employee " & lstFileList.CheckedItems(intMailCnt).SubItems(1).Text)
            End If

            'Else
            '    MsgBox("Employee " & IIf(optCode.Checked, lstFileList.CheckedItems(intChecked).SubItems(1).Text, lstFileList.CheckedItems(intChecked).Text) & " Not Exist in Database.")
            'End If
        Next intChecked

        Me.Close()
        Dim frm1 As Form
        'If blnSign Then
        '    frm1 = New frmMain
        'Else
        frm1 = New frmSendMail
        'End If
        frm1.Show()
        Me.Hide()

    End Sub

    Private Sub frmSelectEmp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If MsgBox("Excell Application is Running. Do you want to Close all Excel Applications?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Call KillEXCEL()
        'End If
        'KillCurProcess()
    End Sub

    Private Sub frmSelectEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            btnBack_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub frmSelectEmp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType
        'Call InitializeForm()
    End Sub

    Private Sub btnSelectAll_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For intI As Integer = 0 To lstFileList.Items.Count - 1
            lstFileList.Items(intI).Checked = True
        Next
    End Sub

    Private Sub btnDeselectAll_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        For intI As Integer = 0 To lstFileList.Items.Count - 1
            lstFileList.Items(intI).Checked = False
        Next
    End Sub

    Private Sub lstFileList_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstFileList.ColumnClick
        If lstFileList.Sorting = SortOrder.Ascending Then
            lstFileList.Sorting = SortOrder.Descending
            lstFileList.ListViewItemSorter = New ListViewComparer(e.Column, SortOrder.Descending)
        Else
            lstFileList.Sorting = SortOrder.Ascending
            lstFileList.ListViewItemSorter = New ListViewComparer(e.Column, SortOrder.Ascending)
        End If
        lstFileList.Sort()
    End Sub

    Private Sub lstFileList_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFileList.GotFocus
        blnselect = True
    End Sub

    Private Sub lstFileList_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lstFileList.ItemChecked
        If e.Item.Checked = True Then
            If intChkCount < lstFileList.Items.Count Then intChkCount = intChkCount + 1
        Else
            If intChkCount > 0 Then intChkCount = intChkCount - 1
        End If
        lblCheckedEmp.Text = "Records selected: " & intChkCount
    End Sub

    Private Sub lstFileList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFileList.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                ProgressBar1.Maximum = lstFileList.Items.Count - lstFileList.FocusedItem.Index
                ProgressBar1.Value = 0
                ProgressBar1.Visible = True
                For intI As Integer = lstFileList.FocusedItem.Index To lstFileList.Items.Count - 1
                    ProgressBar1.Value += 1
                    lstFileList.Items(intI).Checked = lstFileList.FocusedItem.Checked
                Next
                ProgressBar1.Visible = False
        End Select
    End Sub

    Private Sub txtCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.GotFocus
        optExcelRecords.Checked = True
        txtName.Text = String.Empty
    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyValue = 40 Then
            lstFileList.Focus()
            blnselect = True
        End If
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        '--Call SelectListView(lstFileList, txtCode.Text)
        If blnselect = True Then
            Exit Sub
        End If

        intcount = 0

        For Each mList As ListViewItem In lstFileList.Items
            mList.Selected = False
        Next

        If txtCode.Text.Trim = "" Then Exit Sub

        For Each mList As ListViewItem In lstFileList.Items

            If UCase(mList.Text) Like UCase(txtCode.Text) & "*" Then
                mList.Selected = True
                mList.Focused = True

                mList.EnsureVisible()
                Exit For
            Else
                intcount = intcount + 1
            End If

        Next
    End Sub

    Private Sub txtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.GotFocus
        optPdfRecords.Checked = True
        txtCode.Text = String.Empty
    End Sub

    Private Sub txtName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyValue = 40 Then
            lstFileList.Focus()
            blnselect = True
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        '--Call SelectListView(lstFileList, txtName.Text)
        If blnselect = True Then
            Exit Sub
        End If

        intcount = 0

        For Each mList As ListViewItem In lstFileList.Items
            mList.Selected = False
        Next

        If txtName.Text.Trim = "" Then Exit Sub

        For Each mList As ListViewItem In lstFileList.Items

            If UCase(mList.Text) Like UCase(txtName.Text) & "*" Then
                mList.Selected = True
                mList.Focused = True

                mList.EnsureVisible()
                Exit For
            Else
                intcount = intcount + 1
            End If

        Next
    End Sub

    Private Sub chkWithoutEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWithoutEmail.CheckedChanged
        If chkWithoutEmail.Checked = True Then
            chkWithEmail.Checked = False
            Call InitializeForm()
        ElseIf chkWithEmail.Checked = False Then
            Call InitializeForm()
        End If
        btnNext.Enabled = Not chkWithoutEmail.Checked
    End Sub

    Private Sub chkWithEmail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWithEmail.CheckedChanged
        If chkWithEmail.Checked = True Then
            chkWithoutEmail.Checked = False
            Call InitializeForm()
        ElseIf chkWithoutEmail.Checked = False Then
            Call InitializeForm()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Call KillProcess("DigitalSigner")

        Call KillEXCEL()

        MyBase.Dispose(True)
        KillCurProcess()
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Dim frm1 As New frmOptions
        frm1.Show()
        Me.Hide()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim objAdapter As New OleDbDataAdapter
        Dim objData As New DataSet
        Dim strEmployees As String

        strEmployees = ""
        'For intI As Integer = 0 To lstFileList.Items.Count - 1
        '    If optCode.Checked Then
        '        strEmployees = strEmployees & "'" & lstFileList.Items(intI).Text & "',"
        '    Else
        '        strEmployees = strEmployees & "'" & lstFileList.Items(intI).SubItems(1).Text & "',"
        '    End If
        'Next intI

        'If chkWithEmail.Checked = True Then
        '    objAdapter = New OleDbDataAdapter("select EmpCode,[Name],Email from EmpMaster where EmpCode in (" & Mid(strEmployees, 1, strEmployees.Length - 1) & ") and (Email is not null and Email not like'')", objConSigner)
        'ElseIf chkWithoutEmail.Checked = True Then
        '    objAdapter = New OleDbDataAdapter("select EmpCode,[Name],Email from EmpMaster where EmpCode in (" & Mid(strEmployees, 1, strEmployees.Length - 1) & ") and (Email is null or Email like '')", objConSigner)
        'Else
        '    objAdapter = New OleDbDataAdapter("select EmpCode,[Name],Email from EmpMaster where EmpCode in (" & Mid(strEmployees, 1, strEmployees.Length - 1) & ")", objConSigner)
        'End If

        'objData.Tables.Clear()
        'objAdapter.Fill(objData, "EmpMaster")

        Call ConvertListToTDF(lstFileList)
    End Sub

    Private Sub lstFileList_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFileList.LostFocus
        blnselect = False
    End Sub

    Private Sub lstFileList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFileList.SelectedIndexChanged
        If blnselect = False Then
            Exit Sub
        End If
        If lstFileList.Focus() = True Then

            For Each mList As ListViewItem In lstFileList.Items
                If mList.Selected = True Then
                    txtName.Text = mList.Text
                End If
            Next
        End If
    End Sub

    Private Sub optPdfRecords_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPdfRecords.CheckedChanged
        InitializeForm()
    End Sub

    Private Sub optExcelRecords_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optExcelRecords.CheckedChanged
        InitializeForm()
    End Sub

End Class