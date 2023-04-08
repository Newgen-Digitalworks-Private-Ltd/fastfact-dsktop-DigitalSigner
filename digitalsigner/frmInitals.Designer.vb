<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInitals
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInitals))
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.txtSignedPDF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProductPath = New System.Windows.Forms.TextBox()
        Me.lblLicencePath = New System.Windows.Forms.Label()
        Me.txtPdfPath = New System.Windows.Forms.TextBox()
        Me.lblPdfPath = New System.Windows.Forms.Label()
        Me.OpenFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPdfBrowse = New System.Windows.Forms.Button()
        Me.TLPLicense = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLicenceBrowse = New System.Windows.Forms.Button()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSignedPDF = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblOldVersion = New System.Windows.Forms.Label()
        Me.cmslcust = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TLPLicense.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDongle
        '
        Me.lblDongle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(3, 44)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(296, 14)
        Me.lblDongle.TabIndex = 29
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(3, 13)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(296, 14)
        Me.lblVersion.TabIndex = 28
        Me.lblVersion.Text = " Version"
        '
        'txtSignedPDF
        '
        Me.txtSignedPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSignedPDF.BackColor = System.Drawing.SystemColors.Window
        Me.txtSignedPDF.Location = New System.Drawing.Point(3, 40)
        Me.txtSignedPDF.Name = "txtSignedPDF"
        Me.txtSignedPDF.ReadOnly = True
        Me.txtSignedPDF.Size = New System.Drawing.Size(595, 22)
        Me.txtSignedPDF.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(595, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select the path to save the signed PDF folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtProductPath
        '
        Me.txtProductPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProductPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtProductPath.Location = New System.Drawing.Point(3, 37)
        Me.txtProductPath.Name = "txtProductPath"
        Me.txtProductPath.ReadOnly = True
        Me.txtProductPath.Size = New System.Drawing.Size(596, 22)
        Me.txtProductPath.TabIndex = 9
        '
        'lblLicencePath
        '
        Me.lblLicencePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLicencePath.AutoSize = True
        Me.lblLicencePath.Location = New System.Drawing.Point(3, 11)
        Me.lblLicencePath.Name = "lblLicencePath"
        Me.lblLicencePath.Size = New System.Drawing.Size(596, 14)
        Me.lblLicencePath.TabIndex = 8
        Me.lblLicencePath.Text = "Please select ( TdsPac / SalTds / PayPac ) Folder"
        '
        'txtPdfPath
        '
        Me.txtPdfPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPdfPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPdfPath.Location = New System.Drawing.Point(3, 41)
        Me.txtPdfPath.Name = "txtPdfPath"
        Me.txtPdfPath.ReadOnly = True
        Me.txtPdfPath.Size = New System.Drawing.Size(596, 22)
        Me.txtPdfPath.TabIndex = 9
        '
        'lblPdfPath
        '
        Me.lblPdfPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPdfPath.AutoSize = True
        Me.lblPdfPath.Location = New System.Drawing.Point(3, 14)
        Me.lblPdfPath.Name = "lblPdfPath"
        Me.lblPdfPath.Size = New System.Drawing.Size(596, 14)
        Me.lblPdfPath.TabIndex = 8
        Me.lblPdfPath.Text = "Select the Unsigned Pdfs Folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8247423!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.17525!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.333333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.66666!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 608)
        Me.TableLayoutPanel1.TabIndex = 31
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(8, 11)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.23549!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.69966!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.23549!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(714, 586)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel8, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TLPLicense, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 103)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.49383!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.43011!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.04301!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.73913!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(708, 378)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.8075!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.1925!))
        Me.TableLayoutPanel8.Controls.Add(Me.btnPdfBrowse, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.lblPdfPath, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.txtPdfPath, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 214)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.84211!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.15789!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(702, 77)
        Me.TableLayoutPanel8.TabIndex = 3
        '
        'btnPdfBrowse
        '
        Me.btnPdfBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnPdfBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnPdfBrowse.BackgroundImage = CType(resources.GetObject("btnPdfBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnPdfBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPdfBrowse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPdfBrowse.ForeColor = System.Drawing.Color.Black
        Me.btnPdfBrowse.Location = New System.Drawing.Point(613, 35)
        Me.btnPdfBrowse.Name = "btnPdfBrowse"
        Me.btnPdfBrowse.Size = New System.Drawing.Size(86, 34)
        Me.btnPdfBrowse.TabIndex = 1
        Me.btnPdfBrowse.Text = "Browse"
        Me.btnPdfBrowse.UseVisualStyleBackColor = False
        '
        'TLPLicense
        '
        Me.TLPLicense.ColumnCount = 2
        Me.TLPLicense.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.8075!))
        Me.TLPLicense.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.1925!))
        Me.TLPLicense.Controls.Add(Me.btnLicenceBrowse, 1, 1)
        Me.TLPLicense.Controls.Add(Me.lblLicencePath, 0, 0)
        Me.TLPLicense.Controls.Add(Me.txtProductPath, 0, 1)
        Me.TLPLicense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLPLicense.Location = New System.Drawing.Point(3, 137)
        Me.TLPLicense.Name = "TLPLicense"
        Me.TLPLicense.RowCount = 2
        Me.TLPLicense.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.71429!))
        Me.TLPLicense.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.28571!))
        Me.TLPLicense.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPLicense.Size = New System.Drawing.Size(702, 71)
        Me.TLPLicense.TabIndex = 2
        '
        'btnLicenceBrowse
        '
        Me.btnLicenceBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnLicenceBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnLicenceBrowse.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.btnBrowseCSI_BackgroundImage
        Me.btnLicenceBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLicenceBrowse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLicenceBrowse.ForeColor = System.Drawing.Color.Black
        Me.btnLicenceBrowse.Location = New System.Drawing.Point(613, 31)
        Me.btnLicenceBrowse.Name = "btnLicenceBrowse"
        Me.btnLicenceBrowse.Size = New System.Drawing.Size(86, 34)
        Me.btnLicenceBrowse.TabIndex = 0
        Me.btnLicenceBrowse.Text = "Browse"
        Me.btnLicenceBrowse.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.64437!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.35563!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnSignedPDF, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtSignedPDF, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 297)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.57895!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.42105!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(702, 78)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'btnSignedPDF
        '
        Me.btnSignedPDF.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSignedPDF.BackColor = System.Drawing.Color.Transparent
        Me.btnSignedPDF.BackgroundImage = CType(resources.GetObject("btnSignedPDF.BackgroundImage"), System.Drawing.Image)
        Me.btnSignedPDF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSignedPDF.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSignedPDF.ForeColor = System.Drawing.Color.Black
        Me.btnSignedPDF.Location = New System.Drawing.Point(613, 34)
        Me.btnSignedPDF.Name = "btnSignedPDF"
        Me.btnSignedPDF.Size = New System.Drawing.Size(86, 34)
        Me.btnSignedPDF.TabIndex = 1
        Me.btnSignedPDF.Text = "Browse"
        Me.btnSignedPDF.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(702, 128)
        Me.Panel1.TabIndex = 4
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 4
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(700, 126)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(694, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = ">> Digitally Sign Form16 in PDF Format"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(694, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = ">> Email Signed PDFs to Employee  / Deductees"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(694, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = ">> Select Digital Signature from File / USB"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(3, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(694, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = ">> Send File to Email Address"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(708, 94)
        Me.Panel2.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.DigitalSigner.My.Resources.Resources.DG2
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(706, 92)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 487)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(708, 96)
        Me.Panel3.TabIndex = 3
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnOK, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExit, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDongle, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblOldVersion, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.cmslcust, 1, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.68932!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.35922!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(706, 94)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(515, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 34)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&Next >>"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.CausesValidation = False
        Me.btnExit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(617, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 34)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'lblOldVersion
        '
        Me.lblOldVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOldVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldVersion.ForeColor = System.Drawing.Color.Black
        Me.lblOldVersion.Location = New System.Drawing.Point(3, 70)
        Me.lblOldVersion.Name = "lblOldVersion"
        Me.lblOldVersion.Size = New System.Drawing.Size(296, 14)
        Me.lblOldVersion.TabIndex = 28
        Me.lblOldVersion.Text = "[]"
        '
        'cmslcust
        '
        Me.cmslcust.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmslcust.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmslcust.ForeColor = System.Drawing.Color.Black
        Me.cmslcust.Location = New System.Drawing.Point(305, 44)
        Me.cmslcust.Name = "cmslcust"
        Me.cmslcust.Size = New System.Drawing.Size(296, 14)
        Me.cmslcust.TabIndex = 30
        Me.cmslcust.Text = "Customer ID :"
        '
        'frmInitals
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 608)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInitals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Path settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TLPLicense.ResumeLayout(False)
        Me.TLPLicense.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDongle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtProductPath As System.Windows.Forms.TextBox
    Friend WithEvents lblLicencePath As System.Windows.Forms.Label
    Friend WithEvents btnPdfBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPdfPath As System.Windows.Forms.TextBox
    Friend WithEvents lblPdfPath As System.Windows.Forms.Label
    Friend WithEvents OpenFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnSignedPDF As System.Windows.Forms.Button
    Friend WithEvents txtSignedPDF As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents TLPLicense As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents lblOldVersion As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Public WithEvents btnLicenceBrowse As Button
    Friend WithEvents cmslcust As Label
End Class
