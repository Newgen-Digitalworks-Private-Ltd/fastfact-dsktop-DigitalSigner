<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSendMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendMail))
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnOutlook = New System.Windows.Forms.Button()
        Me.prgBusy = New System.Windows.Forms.ProgressBar()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.chkSSL = New System.Windows.Forms.CheckBox()
        Me.ChkPreSetting = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFromId = New System.Windows.Forms.TextBox()
        Me.txtPortNo = New System.Windows.Forms.TextBox()
        Me.lblPortNo = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.btnTestMail = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtCC = New System.Windows.Forms.TextBox()
        Me.lblSenderName = New System.Windows.Forms.Label()
        Me.txtSmtpServer = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.lblCC = New System.Windows.Forms.Label()
        Me.lblSmtpServer = New System.Windows.Forms.Label()
        Me.lblForAdv = New System.Windows.Forms.Label()
        Me.txtSendName = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnstatusreport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel16 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel20 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel21 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel22 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel19 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.TableLayoutPanel16.SuspendLayout()
        Me.TableLayoutPanel17.SuspendLayout()
        Me.TableLayoutPanel15.SuspendLayout()
        Me.TableLayoutPanel21.SuspendLayout()
        Me.TableLayoutPanel22.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel19.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(514, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(86, 34)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "E&xit"
        '
        'btnOutlook
        '
        Me.btnOutlook.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnOutlook.BackgroundImage = CType(resources.GetObject("btnOutlook.BackgroundImage"), System.Drawing.Image)
        Me.btnOutlook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnOutlook.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOutlook.ForeColor = System.Drawing.Color.Black
        Me.btnOutlook.Location = New System.Drawing.Point(319, 5)
        Me.btnOutlook.Name = "btnOutlook"
        Me.btnOutlook.Size = New System.Drawing.Size(86, 36)
        Me.btnOutlook.TabIndex = 10
        Me.btnOutlook.Text = "Send To MS OutLook"
        '
        'prgBusy
        '
        Me.prgBusy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prgBusy.Location = New System.Drawing.Point(10, 601)
        Me.prgBusy.Name = "prgBusy"
        Me.prgBusy.Size = New System.Drawing.Size(712, 4)
        Me.prgBusy.TabIndex = 26
        Me.prgBusy.Visible = False
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.Location = New System.Drawing.Point(212, 6)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(86, 34)
        Me.btnBack.TabIndex = 43
        Me.btnBack.Text = "<<&Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSend.BackgroundImage = CType(resources.GetObject("btnSend.BackgroundImage"), System.Drawing.Image)
        Me.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSend.ForeColor = System.Drawing.Color.Black
        Me.btnSend.Location = New System.Drawing.Point(421, 6)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(86, 34)
        Me.btnSend.TabIndex = 42
        Me.btnSend.Text = "&Send"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(3, 16)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(193, 14)
        Me.lblVersion.TabIndex = 44
        Me.lblVersion.Text = " Version"
        '
        'chkSSL
        '
        Me.chkSSL.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSSL.AutoSize = True
        Me.chkSSL.Location = New System.Drawing.Point(353, 4)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Size = New System.Drawing.Size(185, 18)
        Me.chkSSL.TabIndex = 45
        Me.chkSSL.Text = "Authentication Required SSL"
        Me.chkSSL.UseVisualStyleBackColor = True
        '
        'ChkPreSetting
        '
        Me.ChkPreSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkPreSetting.AutoSize = True
        Me.ChkPreSetting.Checked = True
        Me.ChkPreSetting.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPreSetting.Location = New System.Drawing.Point(178, 4)
        Me.ChkPreSetting.Name = "ChkPreSetting"
        Me.ChkPreSetting.Size = New System.Drawing.Size(169, 18)
        Me.ChkPreSetting.TabIndex = 44
        Me.ChkPreSetting.Text = "Use previous settings"
        Me.ChkPreSetting.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "UserName"
        '
        'txtFromId
        '
        Me.txtFromId.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFromId.Location = New System.Drawing.Point(178, 107)
        Me.txtFromId.Name = "txtFromId"
        Me.txtFromId.Size = New System.Drawing.Size(169, 22)
        Me.txtFromId.TabIndex = 11
        '
        'txtPortNo
        '
        Me.txtPortNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPortNo.Location = New System.Drawing.Point(544, 29)
        Me.txtPortNo.Name = "txtPortNo"
        Me.txtPortNo.Size = New System.Drawing.Size(153, 22)
        Me.txtPortNo.TabIndex = 4
        '
        'lblPortNo
        '
        Me.lblPortNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPortNo.AutoSize = True
        Me.lblPortNo.Location = New System.Drawing.Point(353, 32)
        Me.lblPortNo.Name = "lblPortNo"
        Me.lblPortNo.Size = New System.Drawing.Size(185, 14)
        Me.lblPortNo.TabIndex = 10
        Me.lblPortNo.Text = "Port No.:"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(178, 160)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(169, 22)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserName.Location = New System.Drawing.Point(178, 133)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(169, 22)
        Me.txtUserName.TabIndex = 2
        '
        'lblPassword
        '
        Me.lblPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(3, 164)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(169, 14)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "Password:"
        '
        'lblUserName
        '
        Me.lblUserName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(3, 110)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(169, 14)
        Me.lblUserName.TabIndex = 6
        Me.lblUserName.Text = "Sender's EmailId:"
        '
        'btnTestMail
        '
        Me.btnTestMail.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnTestMail.BackgroundImage = CType(resources.GetObject("btnTestMail.BackgroundImage"), System.Drawing.Image)
        Me.btnTestMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTestMail.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnTestMail.ForeColor = System.Drawing.Color.Black
        Me.btnTestMail.Location = New System.Drawing.Point(611, 118)
        Me.btnTestMail.Name = "btnTestMail"
        Me.btnTestMail.Size = New System.Drawing.Size(86, 36)
        Me.btnTestMail.TabIndex = 35
        Me.btnTestMail.Text = "Send Test Mail"
        '
        'txtMessage
        '
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Location = New System.Drawing.Point(176, 29)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.TableLayoutPanel21.SetRowSpan(Me.txtMessage, 2)
        Me.txtMessage.Size = New System.Drawing.Size(348, 137)
        Me.txtMessage.TabIndex = 41
        '
        'txtSubject
        '
        Me.txtSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubject.Location = New System.Drawing.Point(176, 3)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(348, 22)
        Me.txtSubject.TabIndex = 40
        '
        'txtCC
        '
        Me.txtCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCC.Location = New System.Drawing.Point(178, 81)
        Me.txtCC.Name = "txtCC"
        Me.txtCC.Size = New System.Drawing.Size(169, 22)
        Me.txtCC.TabIndex = 39
        '
        'lblSenderName
        '
        Me.lblSenderName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSenderName.AutoSize = True
        Me.lblSenderName.Location = New System.Drawing.Point(3, 58)
        Me.lblSenderName.Name = "lblSenderName"
        Me.lblSenderName.Size = New System.Drawing.Size(169, 14)
        Me.lblSenderName.TabIndex = 42
        Me.lblSenderName.Text = "Senders Name"
        '
        'txtSmtpServer
        '
        Me.txtSmtpServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSmtpServer.Location = New System.Drawing.Point(178, 29)
        Me.txtSmtpServer.Name = "txtSmtpServer"
        Me.txtSmtpServer.Size = New System.Drawing.Size(169, 22)
        Me.txtSmtpServer.TabIndex = 28
        Me.txtSmtpServer.Text = "smtp.rediffmailpro.com"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(3, 58)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(167, 14)
        Me.lblMessage.TabIndex = 34
        Me.lblMessage.Text = "Message:"
        '
        'lblSubject
        '
        Me.lblSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(3, 6)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(167, 14)
        Me.lblSubject.TabIndex = 33
        Me.lblSubject.Text = "Subject:"
        '
        'lblCC
        '
        Me.lblCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCC.AutoSize = True
        Me.lblCC.Location = New System.Drawing.Point(3, 84)
        Me.lblCC.Name = "lblCC"
        Me.lblCC.Size = New System.Drawing.Size(169, 14)
        Me.lblCC.TabIndex = 32
        Me.lblCC.Text = "CC To"
        '
        'lblSmtpServer
        '
        Me.lblSmtpServer.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSmtpServer.AutoSize = True
        Me.lblSmtpServer.Location = New System.Drawing.Point(3, 32)
        Me.lblSmtpServer.Name = "lblSmtpServer"
        Me.lblSmtpServer.Size = New System.Drawing.Size(169, 14)
        Me.lblSmtpServer.TabIndex = 29
        Me.lblSmtpServer.Text = "Smtp Server"
        '
        'lblForAdv
        '
        Me.lblForAdv.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblForAdv.AutoSize = True
        Me.lblForAdv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForAdv.Location = New System.Drawing.Point(353, 58)
        Me.lblForAdv.Name = "lblForAdv"
        Me.lblForAdv.Size = New System.Drawing.Size(185, 13)
        Me.lblForAdv.TabIndex = 43
        Me.lblForAdv.Text = "For Advanced Users"
        Me.lblForAdv.Visible = False
        '
        'txtSendName
        '
        Me.txtSendName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSendName.Location = New System.Drawing.Point(178, 55)
        Me.txtSendName.Name = "txtSendName"
        Me.txtSendName.Size = New System.Drawing.Size(169, 22)
        Me.txtSendName.TabIndex = 36
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 20
        '
        'btnstatusreport
        '
        Me.btnstatusreport.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnstatusreport.BackgroundImage = CType(resources.GetObject("btnstatusreport.BackgroundImage"), System.Drawing.Image)
        Me.btnstatusreport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnstatusreport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnstatusreport.ForeColor = System.Drawing.Color.Black
        Me.btnstatusreport.Location = New System.Drawing.Point(615, 5)
        Me.btnstatusreport.Name = "btnstatusreport"
        Me.btnstatusreport.Size = New System.Drawing.Size(86, 36)
        Me.btnstatusreport.TabIndex = 42
        Me.btnstatusreport.Text = "Status Report"
        '
        'TableLayoutPanel16
        '
        Me.TableLayoutPanel16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel16.ColumnCount = 3
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.065246!))
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.93475!))
        Me.TableLayoutPanel16.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel16.Controls.Add(Me.TableLayoutPanel17, 1, 1)
        Me.TableLayoutPanel16.Controls.Add(Me.prgBusy, 1, 2)
        Me.TableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel16.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel16.Name = "TableLayoutPanel16"
        Me.TableLayoutPanel16.RowCount = 3
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.24031!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.75969!))
        Me.TableLayoutPanel16.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel16.Size = New System.Drawing.Size(734, 608)
        Me.TableLayoutPanel16.TabIndex = 48
        '
        'TableLayoutPanel17
        '
        Me.TableLayoutPanel17.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel17.ColumnCount = 1
        Me.TableLayoutPanel17.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel17.Controls.Add(Me.TableLayoutPanel15, 0, 1)
        Me.TableLayoutPanel17.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel17.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel17.Location = New System.Drawing.Point(10, 10)
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        Me.TableLayoutPanel17.RowCount = 3
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.4359!))
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.1282!))
        Me.TableLayoutPanel17.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.4359!))
        Me.TableLayoutPanel17.Size = New System.Drawing.Size(712, 585)
        Me.TableLayoutPanel17.TabIndex = 0
        '
        'TableLayoutPanel15
        '
        Me.TableLayoutPanel15.ColumnCount = 1
        Me.TableLayoutPanel15.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel15.Controls.Add(Me.TableLayoutPanel20, 0, 1)
        Me.TableLayoutPanel15.Controls.Add(Me.TableLayoutPanel21, 0, 2)
        Me.TableLayoutPanel15.Controls.Add(Me.TableLayoutPanel22, 0, 0)
        Me.TableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel15.Location = New System.Drawing.Point(3, 105)
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        Me.TableLayoutPanel15.RowCount = 3
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.69421!))
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.305785!))
        Me.TableLayoutPanel15.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174.0!))
        Me.TableLayoutPanel15.Size = New System.Drawing.Size(706, 374)
        Me.TableLayoutPanel15.TabIndex = 2
        '
        'TableLayoutPanel20
        '
        Me.TableLayoutPanel20.BackColor = System.Drawing.Color.DimGray
        Me.TableLayoutPanel20.ColumnCount = 1
        Me.TableLayoutPanel20.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel20.Location = New System.Drawing.Point(3, 196)
        Me.TableLayoutPanel20.Name = "TableLayoutPanel20"
        Me.TableLayoutPanel20.RowCount = 1
        Me.TableLayoutPanel20.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel20.Size = New System.Drawing.Size(700, 1)
        Me.TableLayoutPanel20.TabIndex = 0
        '
        'TableLayoutPanel21
        '
        Me.TableLayoutPanel21.ColumnCount = 3
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.85795!))
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.71023!))
        Me.TableLayoutPanel21.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.57386!))
        Me.TableLayoutPanel21.Controls.Add(Me.txtMessage, 1, 1)
        Me.TableLayoutPanel21.Controls.Add(Me.txtSubject, 1, 0)
        Me.TableLayoutPanel21.Controls.Add(Me.lblMessage, 0, 1)
        Me.TableLayoutPanel21.Controls.Add(Me.lblSubject, 0, 0)
        Me.TableLayoutPanel21.Controls.Add(Me.btnTestMail, 2, 2)
        Me.TableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel21.Location = New System.Drawing.Point(3, 202)
        Me.TableLayoutPanel21.Name = "TableLayoutPanel21"
        Me.TableLayoutPanel21.RowCount = 3
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461!))
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15385!))
        Me.TableLayoutPanel21.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.23529!))
        Me.TableLayoutPanel21.Size = New System.Drawing.Size(700, 169)
        Me.TableLayoutPanel21.TabIndex = 1
        '
        'TableLayoutPanel22
        '
        Me.TableLayoutPanel22.ColumnCount = 4
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.42857!))
        Me.TableLayoutPanel22.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.57143!))
        Me.TableLayoutPanel22.Controls.Add(Me.txtPassword, 1, 6)
        Me.TableLayoutPanel22.Controls.Add(Me.txtUserName, 1, 5)
        Me.TableLayoutPanel22.Controls.Add(Me.lblPassword, 0, 6)
        Me.TableLayoutPanel22.Controls.Add(Me.txtFromId, 1, 4)
        Me.TableLayoutPanel22.Controls.Add(Me.lblUserName, 0, 4)
        Me.TableLayoutPanel22.Controls.Add(Me.txtCC, 1, 3)
        Me.TableLayoutPanel22.Controls.Add(Me.lblCC, 0, 3)
        Me.TableLayoutPanel22.Controls.Add(Me.chkSSL, 2, 0)
        Me.TableLayoutPanel22.Controls.Add(Me.txtSendName, 1, 2)
        Me.TableLayoutPanel22.Controls.Add(Me.lblSenderName, 0, 2)
        Me.TableLayoutPanel22.Controls.Add(Me.txtPortNo, 3, 1)
        Me.TableLayoutPanel22.Controls.Add(Me.lblPortNo, 2, 1)
        Me.TableLayoutPanel22.Controls.Add(Me.txtSmtpServer, 1, 1)
        Me.TableLayoutPanel22.Controls.Add(Me.lblSmtpServer, 0, 1)
        Me.TableLayoutPanel22.Controls.Add(Me.ChkPreSetting, 1, 0)
        Me.TableLayoutPanel22.Controls.Add(Me.lblForAdv, 2, 2)
        Me.TableLayoutPanel22.Controls.Add(Me.Label1, 0, 5)
        Me.TableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel22.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel22.Name = "TableLayoutPanel22"
        Me.TableLayoutPanel22.RowCount = 7
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel22.Size = New System.Drawing.Size(700, 187)
        Me.TableLayoutPanel22.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(706, 96)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.DG2
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(704, 94)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TableLayoutPanel19)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 485)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(706, 97)
        Me.Panel2.TabIndex = 4
        '
        'TableLayoutPanel19
        '
        Me.TableLayoutPanel19.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel19.ColumnCount = 6
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.26705!))
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.48864!))
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.19886!))
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.48864!))
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.21023!))
        Me.TableLayoutPanel19.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.20455!))
        Me.TableLayoutPanel19.Controls.Add(Me.lblDongle, 0, 1)
        Me.TableLayoutPanel19.Controls.Add(Me.btnBack, 1, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.btnstatusreport, 5, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.btnOutlook, 2, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.btnExit, 4, 0)
        Me.TableLayoutPanel19.Controls.Add(Me.btnSend, 3, 0)
        Me.TableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel19.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel19.Name = "TableLayoutPanel19"
        Me.TableLayoutPanel19.RowCount = 2
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel19.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel19.Size = New System.Drawing.Size(704, 95)
        Me.TableLayoutPanel19.TabIndex = 0
        '
        'lblDongle
        '
        Me.lblDongle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDongle.AutoSize = True
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(3, 64)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(193, 14)
        Me.lblDongle.TabIndex = 46
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'frmSendMail
        '
        Me.AcceptButton = Me.btnSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 608)
        Me.Controls.Add(Me.TableLayoutPanel16)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSendMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send mail configuration"
        Me.TableLayoutPanel16.ResumeLayout(False)
        Me.TableLayoutPanel17.ResumeLayout(False)
        Me.TableLayoutPanel15.ResumeLayout(False)
        Me.TableLayoutPanel21.ResumeLayout(False)
        Me.TableLayoutPanel21.PerformLayout()
        Me.TableLayoutPanel22.ResumeLayout(False)
        Me.TableLayoutPanel22.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel19.ResumeLayout(False)
        Me.TableLayoutPanel19.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnOutlook As System.Windows.Forms.Button
    Friend WithEvents prgBusy As System.Windows.Forms.ProgressBar
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblForAdv As System.Windows.Forms.Label
    Friend WithEvents btnTestMail As System.Windows.Forms.Button
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtCC As System.Windows.Forms.TextBox
    Friend WithEvents txtSendName As System.Windows.Forms.TextBox
    Friend WithEvents lblSenderName As System.Windows.Forms.Label
    Friend WithEvents txtSmtpServer As System.Windows.Forms.TextBox
    Friend WithEvents txtPortNo As System.Windows.Forms.TextBox
    Friend WithEvents lblPortNo As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents lblSmtpServer As System.Windows.Forms.Label
    Friend WithEvents txtFromId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkPreSetting As System.Windows.Forms.CheckBox
    Friend WithEvents chkSSL As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnstatusreport As Button
    Friend WithEvents TableLayoutPanel16 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel17 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel19 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel21 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel15 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel20 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel22 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblDongle As Label
End Class
