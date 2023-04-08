<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectEmp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectEmp))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.chkWithoutEmail = New System.Windows.Forms.CheckBox()
        Me.chkWithEmail = New System.Windows.Forms.CheckBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.optPdfRecords = New System.Windows.Forms.RadioButton()
        Me.optExcelRecords = New System.Windows.Forms.RadioButton()
        Me.lstFileList = New System.Windows.Forms.ListView()
        Me.TElSBLicenseManager1 = New SBLicenseManager.TElSBLicenseManager()
        Me.saveDialogPDF = New System.Windows.Forms.SaveFileDialog()
        Me.lblDestination = New System.Windows.Forms.Label()
        Me.openDialogPDFFile = New System.Windows.Forms.OpenFileDialog()
        Me.openDialogPDF = New System.Windows.Forms.FolderBrowserDialog()
        Me.openDialogCert = New System.Windows.Forms.OpenFileDialog()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblNoEmployee = New System.Windows.Forms.Label()
        Me.lblCheckedEmp = New System.Windows.Forms.Label()
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 603)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(711, 2)
        Me.ProgressBar1.TabIndex = 49
        Me.ProgressBar1.Visible = False
        '
        'btnExport
        '
        Me.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExport.BackColor = System.Drawing.Color.Transparent
        Me.btnExport.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.btnBrowseCSI_BackgroundImage
        Me.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExport.ForeColor = System.Drawing.Color.Black
        Me.btnExport.Location = New System.Drawing.Point(431, 9)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(85, 36)
        Me.btnExport.TabIndex = 48
        Me.btnExport.Text = "Export To Excel"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeselectAll.Location = New System.Drawing.Point(3, 34)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(148, 25)
        Me.btnDeselectAll.TabIndex = 47
        Me.btnDeselectAll.Text = "Deselect All"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAll.Location = New System.Drawing.Point(3, 3)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(148, 25)
        Me.btnSelectAll.TabIndex = 46
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'chkWithoutEmail
        '
        Me.chkWithoutEmail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkWithoutEmail.AutoSize = True
        Me.chkWithoutEmail.Location = New System.Drawing.Point(235, 38)
        Me.chkWithoutEmail.Name = "chkWithoutEmail"
        Me.chkWithoutEmail.Size = New System.Drawing.Size(201, 18)
        Me.chkWithoutEmail.TabIndex = 45
        Me.chkWithoutEmail.Text = "Select Records without Email ID"
        Me.chkWithoutEmail.UseVisualStyleBackColor = True
        '
        'chkWithEmail
        '
        Me.chkWithEmail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkWithEmail.AutoSize = True
        Me.chkWithEmail.Checked = True
        Me.chkWithEmail.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWithEmail.Location = New System.Drawing.Point(235, 6)
        Me.chkWithEmail.Name = "chkWithEmail"
        Me.chkWithEmail.Size = New System.Drawing.Size(182, 18)
        Me.chkWithEmail.TabIndex = 44
        Me.chkWithEmail.Text = "Select Records with Email ID"
        Me.chkWithEmail.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(673, 3)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(14, 20)
        Me.txtName.TabIndex = 31
        Me.txtName.Visible = False
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(653, 3)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(12, 20)
        Me.txtCode.TabIndex = 30
        Me.txtCode.Visible = False
        '
        'optPdfRecords
        '
        Me.optPdfRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optPdfRecords.AutoSize = True
        Me.optPdfRecords.Location = New System.Drawing.Point(328, 10)
        Me.optPdfRecords.Name = "optPdfRecords"
        Me.optPdfRecords.Size = New System.Drawing.Size(319, 18)
        Me.optPdfRecords.TabIndex = 43
        Me.optPdfRecords.Text = "Folder based display"
        Me.optPdfRecords.UseVisualStyleBackColor = True
        '
        'optExcelRecords
        '
        Me.optExcelRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optExcelRecords.AutoSize = True
        Me.optExcelRecords.Checked = True
        Me.optExcelRecords.Location = New System.Drawing.Point(3, 10)
        Me.optExcelRecords.Name = "optExcelRecords"
        Me.optExcelRecords.Size = New System.Drawing.Size(319, 18)
        Me.optExcelRecords.TabIndex = 42
        Me.optExcelRecords.TabStop = True
        Me.optExcelRecords.Text = "Excel based display"
        Me.optExcelRecords.UseVisualStyleBackColor = True
        '
        'lstFileList
        '
        Me.lstFileList.CheckBoxes = True
        Me.lstFileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFileList.GridLines = True
        Me.lstFileList.HideSelection = False
        Me.lstFileList.Location = New System.Drawing.Point(3, 3)
        Me.lstFileList.MultiSelect = False
        Me.lstFileList.Name = "lstFileList"
        Me.lstFileList.Size = New System.Drawing.Size(691, 249)
        Me.lstFileList.TabIndex = 32
        Me.lstFileList.UseCompatibleStateImageBehavior = False
        Me.lstFileList.View = System.Windows.Forms.View.Details
        '
        'TElSBLicenseManager1
        '
        Me.TElSBLicenseManager1.LicenseKey = ""
        Me.TElSBLicenseManager1.LicenseKeyFile = ""
        Me.TElSBLicenseManager1.RegistryKey = Nothing
        Me.TElSBLicenseManager1.Tag = Nothing
        '
        'saveDialogPDF
        '
        Me.saveDialogPDF.Filter = "PDF document (*.pdf)|*.pdf|All files (*.*)|*.*"
        Me.saveDialogPDF.InitialDirectory = "."
        '
        'lblDestination
        '
        Me.lblDestination.AutoSize = True
        Me.lblDestination.Location = New System.Drawing.Point(12, 133)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(0, 14)
        Me.lblDestination.TabIndex = 41
        '
        'openDialogPDFFile
        '
        Me.openDialogPDFFile.Filter = "PDF document (*.pdf)|*.pdf|All files (*.*)|*.*"
        Me.openDialogPDFFile.InitialDirectory = "."
        '
        'openDialogCert
        '
        Me.openDialogCert.Filter = "PKCS#12 certificate (*.pfx)|*.pfx|All files (*.*)|*.*"
        Me.openDialogCert.InitialDirectory = "."
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.Location = New System.Drawing.Point(339, 10)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(86, 34)
        Me.btnBack.TabIndex = 52
        Me.btnBack.Text = "<<Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExit.CausesValidation = False
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(614, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 34)
        Me.btnExit.TabIndex = 51
        Me.btnExit.Text = "&Cancel"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnNext.BackColor = System.Drawing.Color.Transparent
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Location = New System.Drawing.Point(522, 10)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(85, 34)
        Me.btnNext.TabIndex = 50
        Me.btnNext.Text = "&Next >>"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'lblNoEmployee
        '
        Me.lblNoEmployee.AutoSize = True
        Me.lblNoEmployee.Location = New System.Drawing.Point(288, 246)
        Me.lblNoEmployee.Name = "lblNoEmployee"
        Me.lblNoEmployee.Size = New System.Drawing.Size(0, 14)
        Me.lblNoEmployee.TabIndex = 53
        '
        'lblCheckedEmp
        '
        Me.lblCheckedEmp.AutoSize = True
        Me.lblCheckedEmp.Location = New System.Drawing.Point(290, 270)
        Me.lblCheckedEmp.Name = "lblCheckedEmp"
        Me.lblCheckedEmp.Size = New System.Drawing.Size(0, 14)
        Me.lblCheckedEmp.TabIndex = 54
        '
        'lblDongle
        '
        Me.lblDongle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(3, 67)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(330, 14)
        Me.lblDongle.TabIndex = 56
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(3, 20)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(330, 14)
        Me.lblVersion.TabIndex = 55
        Me.lblVersion.Text = " Version"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.230769!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.76923!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.333333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.66666!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 608)
        Me.TableLayoutPanel1.TabIndex = 57
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(11, 11)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.57679!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.52901!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.06485!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(711, 586)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(705, 96)
        Me.Panel1.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.DigitalSigner.My.Resources.Resources.DG2
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(703, 94)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 488)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(705, 95)
        Me.Panel2.TabIndex = 6
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.79516!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.08677!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.94452!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.94452!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.94452!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnExit, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnNext, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExport, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBack, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDongle, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.77011!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.22989!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(703, 93)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 105)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(705, 377)
        Me.Panel3.TabIndex = 7
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel7, 0, 2)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.74654!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.25346!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(703, 375)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 4
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.optExcelRecords, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.optPdfRecords, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCode, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtName, 3, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(697, 39)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.lstFileList, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 48)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(697, 255)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnSelectAll, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnDeselectAll, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.chkWithEmail, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.chkWithoutEmail, 1, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 309)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(697, 63)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'frmSelectEmp
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 608)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblCheckedEmp)
        Me.Controls.Add(Me.lblNoEmployee)
        Me.Controls.Add(Me.lblDestination)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSelectEmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receivers List"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents chkWithoutEmail As System.Windows.Forms.CheckBox
    Friend WithEvents chkWithEmail As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents optPdfRecords As System.Windows.Forms.RadioButton
    Friend WithEvents optExcelRecords As System.Windows.Forms.RadioButton
    Friend WithEvents lstFileList As System.Windows.Forms.ListView
    Friend WithEvents TElSBLicenseManager1 As SBLicenseManager.TElSBLicenseManager
    Friend WithEvents saveDialogPDF As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents openDialogPDFFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents openDialogPDF As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents openDialogCert As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblNoEmployee As System.Windows.Forms.Label
    Friend WithEvents lblCheckedEmp As System.Windows.Forms.Label
    Friend WithEvents lblDongle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
