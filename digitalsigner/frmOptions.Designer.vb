<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOptions
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.lnkExcelTemplate = New System.Windows.Forms.LinkLabel()
        Me.chkGenerate = New System.Windows.Forms.CheckBox()
        Me.chkNotify = New System.Windows.Forms.CheckBox()
        Me.btnBrowes = New System.Windows.Forms.Button()
        Me.txtExcelPath = New System.Windows.Forms.TextBox()
        Me.optUnsignedPdf = New System.Windows.Forms.RadioButton()
        Me.optSignedPdf = New System.Windows.Forms.RadioButton()
        Me.optMail = New System.Windows.Forms.RadioButton()
        Me.optSign = New System.Windows.Forms.RadioButton()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlSign = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.optPrintControlLog = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlSendMail = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TLPSign = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlSign.SuspendLayout()
        Me.pnlSendMail.SuspendLayout()
        Me.TLPSign.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lnkExcelTemplate
        '
        Me.lnkExcelTemplate.ActiveLinkColor = System.Drawing.Color.Blue
        Me.lnkExcelTemplate.AutoSize = True
        Me.lnkExcelTemplate.Location = New System.Drawing.Point(144, 0)
        Me.lnkExcelTemplate.Name = "lnkExcelTemplate"
        Me.lnkExcelTemplate.Size = New System.Drawing.Size(90, 14)
        Me.lnkExcelTemplate.TabIndex = 7
        Me.lnkExcelTemplate.TabStop = True
        Me.lnkExcelTemplate.Text = "Email Template"
        Me.lnkExcelTemplate.VisitedLinkColor = System.Drawing.Color.Blue
        '
        'chkGenerate
        '
        Me.chkGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkGenerate.Location = New System.Drawing.Point(54, 3)
        Me.chkGenerate.Name = "chkGenerate"
        Me.chkGenerate.Size = New System.Drawing.Size(642, 13)
        Me.chkGenerate.TabIndex = 67
        Me.chkGenerate.Text = "Generate Control No."
        Me.chkGenerate.UseVisualStyleBackColor = True
        '
        'chkNotify
        '
        Me.chkNotify.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNotify.Location = New System.Drawing.Point(54, 60)
        Me.chkNotify.Name = "chkNotify"
        Me.chkNotify.Size = New System.Drawing.Size(642, 18)
        Me.chkNotify.TabIndex = 66
        Me.chkNotify.Text = "Notify for Every File if already Signed"
        Me.chkNotify.UseVisualStyleBackColor = True
        '
        'btnBrowes
        '
        Me.btnBrowes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBrowes.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowes.BackgroundImage = CType(resources.GetObject("btnBrowes.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowes.ForeColor = System.Drawing.Color.Black
        Me.btnBrowes.Location = New System.Drawing.Point(610, 29)
        Me.btnBrowes.Name = "btnBrowes"
        Me.btnBrowes.Size = New System.Drawing.Size(86, 30)
        Me.btnBrowes.TabIndex = 5
        Me.btnBrowes.Text = "Browse"
        Me.btnBrowes.UseVisualStyleBackColor = False
        '
        'txtExcelPath
        '
        Me.txtExcelPath.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSendMail.SetColumnSpan(Me.txtExcelPath, 2)
        Me.txtExcelPath.Enabled = False
        Me.txtExcelPath.Location = New System.Drawing.Point(54, 33)
        Me.txtExcelPath.Name = "txtExcelPath"
        Me.txtExcelPath.Size = New System.Drawing.Size(497, 22)
        Me.txtExcelPath.TabIndex = 4
        '
        'optUnsignedPdf
        '
        Me.optUnsignedPdf.AutoSize = True
        Me.optUnsignedPdf.Location = New System.Drawing.Point(144, 84)
        Me.optUnsignedPdf.Name = "optUnsignedPdf"
        Me.optUnsignedPdf.Size = New System.Drawing.Size(97, 18)
        Me.optUnsignedPdf.TabIndex = 3
        Me.optUnsignedPdf.Text = "Unsigned Pdf"
        Me.optUnsignedPdf.UseVisualStyleBackColor = True
        '
        'optSignedPdf
        '
        Me.optSignedPdf.AutoSize = True
        Me.optSignedPdf.Checked = True
        Me.optSignedPdf.Location = New System.Drawing.Point(54, 84)
        Me.optSignedPdf.Name = "optSignedPdf"
        Me.optSignedPdf.Size = New System.Drawing.Size(84, 18)
        Me.optSignedPdf.TabIndex = 2
        Me.optSignedPdf.TabStop = True
        Me.optSignedPdf.Text = "Signed Pdf"
        Me.optSignedPdf.UseVisualStyleBackColor = True
        '
        'optMail
        '
        Me.optMail.AutoSize = True
        Me.optMail.Location = New System.Drawing.Point(3, 143)
        Me.optMail.Name = "optMail"
        Me.optMail.Size = New System.Drawing.Size(76, 17)
        Me.optMail.TabIndex = 1
        Me.optMail.Text = "Send Mail"
        Me.optMail.UseVisualStyleBackColor = True
        '
        'optSign
        '
        Me.optSign.AutoSize = True
        Me.optSign.Location = New System.Drawing.Point(3, 3)
        Me.optSign.Name = "optSign"
        Me.optSign.Size = New System.Drawing.Size(109, 18)
        Me.optSign.TabIndex = 0
        Me.optSign.Text = "Sign Document"
        Me.optSign.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.Location = New System.Drawing.Point(432, 10)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(86, 34)
        Me.btnBack.TabIndex = 44
        Me.btnBack.Text = "<<&Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(616, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 43
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnNext.BackColor = System.Drawing.Color.Transparent
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Location = New System.Drawing.Point(524, 10)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(86, 34)
        Me.btnNext.TabIndex = 42
        Me.btnNext.Text = "&Next >>"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'lblDongle
        '
        Me.lblDongle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(3, 66)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(421, 14)
        Me.lblDongle.TabIndex = 46
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(3, 17)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(421, 21)
        Me.lblVersion.TabIndex = 45
        Me.lblVersion.Text = " Version"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 20
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 11)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.96008!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.03992!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(713, 585)
        Me.TableLayoutPanel1.TabIndex = 49
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(707, 91)
        Me.Panel1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.DG2
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(705, 89)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.pnlSign)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(707, 382)
        Me.Panel2.TabIndex = 5
        '
        'pnlSign
        '
        Me.pnlSign.BackColor = System.Drawing.Color.White
        Me.pnlSign.ColumnCount = 1
        Me.pnlSign.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlSign.Controls.Add(Me.optPrintControlLog, 0, 6)
        Me.pnlSign.Controls.Add(Me.Label3, 0, 7)
        Me.pnlSign.Controls.Add(Me.optMail, 0, 3)
        Me.pnlSign.Controls.Add(Me.optSign, 0, 0)
        Me.pnlSign.Controls.Add(Me.TableLayoutPanel9, 0, 5)
        Me.pnlSign.Controls.Add(Me.pnlSendMail, 0, 4)
        Me.pnlSign.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.pnlSign.Controls.Add(Me.TLPSign, 0, 1)
        Me.pnlSign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSign.Location = New System.Drawing.Point(0, 0)
        Me.pnlSign.Name = "pnlSign"
        Me.pnlSign.RowCount = 8
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.43305!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.56695!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.pnlSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.pnlSign.Size = New System.Drawing.Size(705, 380)
        Me.pnlSign.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.DimGray
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 278)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(699, 2)
        Me.TableLayoutPanel9.TabIndex = 4
        '
        'optPrintControlLog
        '
        Me.optPrintControlLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optPrintControlLog.AutoSize = True
        Me.optPrintControlLog.Location = New System.Drawing.Point(3, 298)
        Me.optPrintControlLog.Name = "optPrintControlLog"
        Me.optPrintControlLog.Size = New System.Drawing.Size(699, 18)
        Me.optPrintControlLog.TabIndex = 8
        Me.optPrintControlLog.Text = "Print Control List"
        Me.optPrintControlLog.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 319)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(699, 19)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "On selecting this option it will print the list of PDF files having Control No."
        '
        'pnlSendMail
        '
        Me.pnlSendMail.ColumnCount = 4
        Me.pnlSendMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlSendMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.pnlSendMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 413.0!))
        Me.pnlSendMail.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.pnlSendMail.Controls.Add(Me.btnBrowes, 3, 1)
        Me.pnlSendMail.Controls.Add(Me.lnkExcelTemplate, 2, 0)
        Me.pnlSendMail.Controls.Add(Me.Label1, 1, 0)
        Me.pnlSendMail.Controls.Add(Me.txtExcelPath, 1, 1)
        Me.pnlSendMail.Controls.Add(Me.optSignedPdf, 1, 3)
        Me.pnlSendMail.Controls.Add(Me.optUnsignedPdf, 2, 3)
        Me.pnlSendMail.Controls.Add(Me.Label2, 1, 2)
        Me.pnlSendMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSendMail.Location = New System.Drawing.Point(3, 166)
        Me.pnlSendMail.Name = "pnlSendMail"
        Me.pnlSendMail.RowCount = 4
        Me.pnlSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.pnlSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.pnlSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.pnlSendMail.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlSendMail.Size = New System.Drawing.Size(699, 106)
        Me.pnlSendMail.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(54, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 14)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Template File : "
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSendMail.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(54, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(497, 17)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Use Semicolon (;) to send email to multiple email ID's"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.DimGray
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 135)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(699, 2)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'TLPSign
        '
        Me.TLPSign.ColumnCount = 2
        Me.TLPSign.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPSign.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 648.0!))
        Me.TLPSign.Controls.Add(Me.Label4, 1, 1)
        Me.TLPSign.Controls.Add(Me.chkGenerate, 1, 0)
        Me.TLPSign.Controls.Add(Me.chkNotify, 1, 2)
        Me.TLPSign.Controls.Add(Me.Label5, 1, 3)
        Me.TLPSign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLPSign.Location = New System.Drawing.Point(3, 30)
        Me.TLPSign.Name = "TLPSign"
        Me.TLPSign.RowCount = 4
        Me.TLPSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.32836!))
        Me.TLPSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.67164!))
        Me.TLPSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TLPSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TLPSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLPSign.Size = New System.Drawing.Size(699, 99)
        Me.TLPSign.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(54, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(642, 38)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(54, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(642, 18)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Selecting this option will display the files which are already signed in PDF sign" &
    "ed folder."
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 488)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(707, 94)
        Me.Panel3.TabIndex = 6
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel8.ColumnCount = 4
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.56738!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04965!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.9078!))
        Me.TableLayoutPanel8.Controls.Add(Me.lblDongle, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.btnBack, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.btnNext, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.btnCancel, 3, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.60606!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.39394!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(705, 92)
        Me.TableLayoutPanel8.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.8667389!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.13326!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel1, 1, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.335559!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.66444!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(734, 608)
        Me.TableLayoutPanel4.TabIndex = 50
        '
        'frmOptions
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 608)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selections"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlSign.ResumeLayout(False)
        Me.pnlSign.PerformLayout()
        Me.pnlSendMail.ResumeLayout(False)
        Me.pnlSendMail.PerformLayout()
        Me.TLPSign.ResumeLayout(False)
        Me.TLPSign.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents optMail As System.Windows.Forms.RadioButton
    Friend WithEvents optSign As System.Windows.Forms.RadioButton
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblDongle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents optUnsignedPdf As System.Windows.Forms.RadioButton
    Friend WithEvents optSignedPdf As System.Windows.Forms.RadioButton
    Friend WithEvents chkNotify As System.Windows.Forms.CheckBox
    Friend WithEvents lnkExcelTemplate As System.Windows.Forms.LinkLabel
    Friend WithEvents chkGenerate As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnBrowes As System.Windows.Forms.Button
    Friend WithEvents txtExcelPath As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pnlSign As TableLayoutPanel
    Friend WithEvents TLPSign As TableLayoutPanel
    Friend WithEvents pnlSendMail As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents optPrintControlLog As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
