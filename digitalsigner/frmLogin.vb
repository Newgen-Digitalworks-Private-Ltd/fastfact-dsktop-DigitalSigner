Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class frmLogin

    Dim blnselect As Boolean
    Dim intcount As Integer
    Dim strTextFileName As String

    Private Sub AddList()

        Dim mFiles
        Dim FileName
        Dim mFile As FileInfo

        Dim MainDirectory As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
        Dim i As Integer
        Dim mext As String
        Dim strName As String

        Dim mOpYear As String
        Dim mClYear As String
        Dim YearCode As String

        Dim objConTemp As New OleDbConnection
        Dim objAdapter As New OleDbDataAdapter()
        Dim objDataset As New DataSet

        Dim mCompanyName As String

        'Set mFiles = fs.GetFolder(App.Path).Files()
        mFiles = MainDirectory.GetFiles()

        If blnSplashActive = True Then
            frmSplash.PB1.Value = 0
            frmSplash.PB1.Minimum = 0
            frmSplash.PB1.Maximum = MainDirectory.GetFiles.Length + 2
            frmSplash.PB1.Visible = True
        Else
            pb1.Value = 0
            pb1.Minimum = 0
            pb1.Maximum = MainDirectory.GetFiles.Length + 2
            pb1.Visible = True
        End If

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        i = 1
        pb1.Value = 0
        pb1.Minimum = 0
        pb1.Maximum = MainDirectory.GetFiles().Length + 2
        pb1.Visible = True

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        'Dim dbOms As New ADODB.Connection
        'Dim rsDB As New ADODB.Recordset
        Try
            With lstCompany
                .Columns.Add("Name of the Company", 150, HorizontalAlignment.Left)
                .Columns.Add("Code", 100, HorizontalAlignment.Right)
                .Columns.Add("Year", 100, HorizontalAlignment.Right)

                'Storing the Product By the Application Path
                strProduct = StrConv(MainDirectory.Name, VbStrConv.Uppercase)

                If strProduct = "PAYPAC" Then
                    strProduct = "SALTDS"
                Else
                    strProduct = StrConv(MainDirectory.Name, VbStrConv.Uppercase)
                End If

                If DemoVersion = False Then
                    If InStr(1, strProduct, "SALTDS") > 0 Or InStr(1, strProduct, "TDSPAC") > 0 Or StrConv(MainDirectory.Name, VbStrConv.Uppercase) = "BIN" Then
                        For Each mFile In MainDirectory.GetFiles()
                            If blnSplashActive = True Then
                                frmSplash.PB1.Value = frmSplash.PB1.Value + 1
                                Application.DoEvents()
                            Else
                                pb1.Value = pb1.Value + 1
                            End If
                            FileName = mFile.Name
                            mext = mFile.Extension
                            If Len(FileName) > 9 Then
                                If Mid(UCase(FileName), FileName.length - 7, 4) = "DATA" And UCase(mext) = ".MDB" And IsNumeric((Mid(UCase(FileName), (FileName.length - 9), 2))) = True Then

                                    mCompanyName = String.Empty

                                    If objConTemp.State = 1 Then objConTemp.Close()
                                    objConTemp.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & Application.StartupPath & "\" & FileName & ";Persist Security Info=False;Jet OLEDB:Database Password=Ffcs;"
                                    objConTemp.Open()

                                    If InStr(1, strProduct, "TDSPACSQL") > 0 Then
                                        objAdapter = New OleDbDataAdapter("select * from Deductor", objConTemp)
                                    Else
                                        objAdapter = New OleDbDataAdapter("select * from Parameter", objConTemp)
                                    End If
                                    objAdapter.Fill(objDataset, "Parameter")

                                    If objDataset.Tables("Parameter").Rows.Count > 0 Then
                                        If InStr(1, strProduct, "SALTDS") > 0 Then
                                            mCompanyName = objDataset.Tables("Parameter").Rows(0).Item("Name")
                                        ElseIf InStr(1, strProduct, "TDSPAC") > 0 Then
                                            mCompanyName = objDataset.Tables("Parameter").Rows(0).Item("CoName")
                                        Else
                                            mCompanyName = objDataset.Tables("Parameter").Rows(0).Item("Name")
                                        End If
                                    End If
                                    objDataset.Tables.Clear()

                                    YearCode = (Mid(UCase(FileName), (Len(FileName) - 9), 2))
                                    If Val(YearCode) > 90 Then
                                        mOpYear = Format(YearCode, "1900")
                                    Else
                                        mOpYear = "20" & YearCode
                                    End If
                                    mClYear = Val(mOpYear) + 1

                                    strName = StrConv(mCompanyName, VbStrConv.ProperCase)
                                    Dim mItem As New ListViewItem(strName)

                                    mItem.SubItems.Add(Mid(UCase(FileName), 1, (Len(FileName) - 10)))
                                    mItem.SubItems.Add(mOpYear & "-" & mClYear)
                                    .Items.AddRange(New ListViewItem() {mItem})
                                    
                                    .Refresh()
                                    i = i + 1

                                End If
                            End If
                        Next
                    End If
                    txtCompName.Enabled = True
                    txtPassword.Enabled = True
                Else
                    strName = "Demo Company"
                    Dim mItem1 As New ListViewItem(strName)
                    mItem1.Text = strName
                    mItem1.SubItems.Add("DEMO")
                    mItem1.SubItems.Add("2009-2010")
                    .Items.AddRange(New ListViewItem() {mItem1})

                    txtCompName.Text = "Demo Company"
                    txtPassword.Text = "909"
                    txtCompName.Enabled = False
                    txtPassword.Enabled = False
                End If

                .Sort()
                .Sorting = SortOrder.Descending

                If .Items.Count > 0 Then .Items(0).Selected = True
                pb1.Visible = False
                Me.Cursor = Cursors.Default

                'If .Items.Count = 0 Then
                '    cmdOpen.Enabled = False
                '    cmdDelete.Enabled = False
                '    cmdBackUp.Enabled = False
                'Else
                '    cmdOpen.Enabled = True
                '    cmdDelete.Enabled = True
                '    cmdBackUp.Enabled = True
                '    cmdRestore.Enabled = True
                'End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType
        Call AddList()
    End Sub

    Private Sub txtCompName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompName.KeyDown
        Select Case e.KeyCode
            Case Keys.Down
                lstCompany.Focus()
                blnselect = True
        End Select
    End Sub

    Private Sub txtCompName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompName.LostFocus
        txtCompName.BackColor = Color.White
        For Each mList As ListViewItem In lstCompany.Items
            If mList.Selected = True Then
                txtCompName.Text = mList.Text
            End If
        Next
    End Sub

    Private Sub txtCompName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompName.TextChanged
        If blnselect = True Then
            Exit Sub
        End If

        intcount = 0
        For Each mList As ListViewItem In lstCompany.Items
            mList.Selected = False
        Next

        If txtCompName.Text.Trim = "" Then Exit Sub

        For Each mList As ListViewItem In lstCompany.Items

            If UCase(mList.Text) Like UCase(txtCompName.Text) & "*" Then
                mList.Selected = True
                mList.Focused = True
                'txtCompName.Focus()
                mList.EnsureVisible()
                Exit For
            Else
                intcount = intcount + 1
            End If

        Next
    End Sub

    Private Sub txtPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.BackColor = Color.Cyan
    End Sub

    Private Sub txtPassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassword.LostFocus
        txtPassword.BackColor = Color.White
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        MyBase.Dispose(True)
        KillCurProcess()
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim objAdapter As New OleDbDataAdapter()
        Dim objDataset As New DataSet

        If lstCompany.Items.Count = 0 Then
            MsgBox("Company Not Exist!", vbExclamation)
            Exit Sub
        End If

        If lstCompany.SelectedItems.Count = 0 Then
            MsgBox("Please select one company form the list", vbInformation)
            lstCompany.Focus()
            Exit Sub
        End If

        If TypeName(lstCompany.FocusedItem) = "Nothing" Then
            lstCompany.SelectedItems(0).Selected = True
            'lstCompany.FocusedItem = lstCompany.Items(0)
            MsgBox("Select a Company")
            lstCompany.Focus()
            Exit Sub
        Else
            txtCompName.Text = lstCompany.FocusedItem.Text
        End If


        FYear = lstCompany.Items(lstCompany.FocusedItem.Index).SubItems(2).Text()
        mCocode = lstCompany.Items(lstCompany.FocusedItem.Index).SubItems(1).Text()
        mCoName = lstCompany.Items(lstCompany.FocusedItem.Index).SubItems(0).Text()

        If objConSigner.State = 1 Then objConSigner.Close()
        If strProduct = "TDSPAC" Then
            objConSigner.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & _
                                            Application.StartupPath & "\" & mCocode & Mid(FYear, 3, 2) & _
                                            "DATA.mdb" & ";Persist Security Info=False;Jet OLEDB:Database Password=Ffcs;"
        ElseIf strProduct = "TDSPACSQL" Then
            '--We Need to Connect to the SQL Server Database
        Else
            objConSigner.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & _
                                            Application.StartupPath & "\" & mCocode & Mid(FYear, 3, 2) & _
                                            ".mdb" & ";Persist Security Info=False;Jet OLEDB:Database Password=Code;"
        End If

        Try
            objConSigner.Open()
            If strProduct = "TDSPAC" Then
                objAdapter = New OleDbDataAdapter("select * from parameter where Cocode ='" & mCocode & "' and (userpwd ='" & txtPassword.Text & "' or SupPwd ='" & txtPassword.Text & "')", objConSigner)
            ElseIf strProduct = "TDSPACSQL" Then
                'objAdapter = New OleDbDataAdapter("select * from Deductor where PassWord='" & txtPassword.Text & "'", objConSigner)
            Else
                objAdapter = New OleDbDataAdapter("select * from Company where PassWord='" & txtPassword.Text & "'", objConSigner)
            End If
            objAdapter.Fill(objDataset, "Login")

            If txtPassword.Text <> "B10sai" Then
                If objDataset.Tables("Login").Rows.Count = 0 Then
                    If MsgBox("Invalid Password.", vbRetryCancel + vbInformation) = vbCancel Then Exit Sub
                    txtPassword.Text = ""
                    txtPassword.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            End
        End Try

        mPassword = txtPassword.Text

        'Setting the Folder Path
        If InStr(1, strProduct, "TDSPAC") > 0 Then
            strSourceFolderPath = Application.StartupPath & "\" & mCocode & Mid(FYear, 3, 2) & "-Form16A"
        Else
            strSourceFolderPath = Application.StartupPath & "\" & mCocode & Mid(FYear, 3, 2) & "-Form16"
        End If

        Dim PdfLocation As DirectoryInfo = New DirectoryInfo(strSourceFolderPath)

        'check whether CompanyCode-Form16 Folder Exists
        If PdfLocation.Exists() = False Then
            MsgBox("no pdf files found in the selected folder.")
            End
        ElseIf PdfLocation.GetFiles().Length = 0 Then
            MsgBox("no pdf files found in the selected folder.")
            End
        Else
            Me.Hide()

            Dim frmMain As New frmOptions
            frmMain.Show()
        End If

    End Sub

    Private Sub lstCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCompany.Click
        For Each mList As ListViewItem In lstCompany.Items
            If mList.Selected = True Then
                txtCompName.Text = mList.Text
            End If
        Next
    End Sub

    Private Sub lstCompany_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstCompany.ColumnClick
        If lstCompany.Sorting = SortOrder.Ascending Then
            lstCompany.Sorting = SortOrder.Descending
            lstCompany.ListViewItemSorter = New ListViewComparer(e.Column, SortOrder.Descending)
        Else
            lstCompany.Sorting = SortOrder.Ascending
            lstCompany.ListViewItemSorter = New ListViewComparer(e.Column, SortOrder.Ascending)
        End If
        lstCompany.Sort()
    End Sub

    Private Sub lstCompany_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCompany.DoubleClick
        Call btnOpen_Click(Nothing, Nothing)
    End Sub

    Private Sub lstCompany_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCompany.GotFocus
        blnselect = True
        If lstCompany.Items.Count = 0 Then Exit Sub
        'txtCompany.Text = lstCompany.SelectedItem.Text
    End Sub

    Private Sub lstCompany_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCompany.LostFocus
        blnselect = False
    End Sub

    Private Sub lstCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCompany.SelectedIndexChanged
        If blnselect = False Then Exit Sub

        For Each mList As ListViewItem In lstCompany.Items
            If mList.Index = -1 Then Exit For
            If mList.Selected = True Then
                txtCompName.Text = mList.Text
            End If
        Next
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click

    End Sub
End Class

Public Class ListViewComparer
    Implements IComparer

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) _
     As Integer Implements System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x, ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y, ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If

        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            Return String.Compare(string_x, string_y)
        Else
            Return String.Compare(string_y, string_x)
        End If
    End Function
End Class