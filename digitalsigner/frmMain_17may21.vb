Imports SBPDF
Imports SBPDFSecurity
Imports SBCustomCertStorage
Imports SBWinCertStorage
Imports SBX509
Imports SBTSPCommon
Imports SBTSPClient
Imports SBHTTPSClient
Imports SBHTTPTSPClient
Imports System.IO
Imports System.Runtime.InteropServices.COMException
Imports System.Data
Imports System.Data.OleDb
Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private Signatures As ArrayList
    'Ver 1.7-E387 Start
    Private encryption As TElPDFPasswordSecurityHandler
    'Ver 1.7-E387 End
    ' SecureBlackbox objects
    Private Document As TElPDFDocument
    Private PublicKeyHandler As TElPDFPublicKeySecurityHandler
    Private CertStorage As TElMemoryCertStorage
    Private SystemStore As TElWinCertStorage
    Private Cert As TElX509Certificate
    Private HTTPClient As TElHTTPSClient
    Friend WithEvents openDialogPDF As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents TElSBLicenseManager1 As SBLicenseManager.TElSBLicenseManager
    Friend WithEvents gbSigProps As System.Windows.Forms.GroupBox
    Friend WithEvents cbPosition As System.Windows.Forms.ComboBox
    Friend WithEvents lblPos As System.Windows.Forms.Label
    Friend WithEvents cbPrintOn As System.Windows.Forms.ComboBox
    Friend WithEvents lblPage As System.Windows.Forms.Label
    Friend WithEvents cbFont As System.Windows.Forms.ComboBox
    Friend WithEvents lFont As System.Windows.Forms.Label
    Friend WithEvents tbTimestampServer As System.Windows.Forms.TextBox
    Friend WithEvents cbReason As System.Windows.Forms.ComboBox
    Friend WithEvents lReason As System.Windows.Forms.Label
    Friend WithEvents tbAuthor As System.Windows.Forms.TextBox
    Friend WithEvents lAuthor As System.Windows.Forms.Label
    Friend WithEvents cbSignatureType As System.Windows.Forms.ComboBox
    Friend WithEvents lSignatureType As System.Windows.Forms.Label
    Friend WithEvents cbTimestamp As System.Windows.Forms.CheckBox
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnFindFiles As System.Windows.Forms.Button
    Friend WithEvents lblNoEmployee As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDongle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents txtSignersName As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthorsName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkHideBackground As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSystemCerts As System.Windows.Forms.ComboBox
    Friend WithEvents rbUseSystemCert As System.Windows.Forms.RadioButton
    Friend WithEvents btnBrowseCert As System.Windows.Forms.Button
    Friend WithEvents tbCertPassword As System.Windows.Forms.TextBox
    Friend WithEvents tbCert As System.Windows.Forms.TextBox
    Friend WithEvents lCertPassword As System.Windows.Forms.Label
    Friend WithEvents rbUseCertFile As System.Windows.Forms.RadioButton
    Friend WithEvents lnkOption2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkOption1 As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbCustom As System.Windows.Forms.RadioButton
    Friend WithEvents cmbTypical As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private TSPClient As TElHTTPTSPClient
    Friend WithEvents grpSignPic As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents picSign As System.Windows.Forms.PictureBox
    Friend WithEvents chkPwdProtect As System.Windows.Forms.CheckBox
    Friend WithEvents ttReasonforsig As System.Windows.Forms.PictureBox
    Friend WithEvents lblRotation As System.Windows.Forms.Label
    Friend WithEvents cmbRotation As System.Windows.Forms.ComboBox
    Friend WithEvents chkArchive As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

    'Ashish start for Custom Sign
    Public blnCustom As Boolean
    'Ashish End for Custom Sign

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Initialize SecureBlackBox
        ' Calling SetLicenseKey
        'SBUtils.Unit.SetLicenseKey(SBUtils.Unit.BytesOfString("7576BCFBA97C13045C35AE52934D2217F721DE2FC168E266BA433FFCE44E954D61C228487E74179C2C681F7D000AFF07F7A3C670F7E58976CBD393EAC08AE7F0AFE2D1C9BE0997A116B0319B1177FDA229162DFA01EEB2792004C2989155AFB7CEB177C22A4F14CB566F6CCF170AF14D1C1C62166ECD15B03D783B706D2566772F51B5BE5775341DE7E196CF5030E47EE63739DE2BA350CD48E4EE3EA78FF91BFBA9F7DA2767857EFB7D4922689BC7551A48DD0095499A844BF98D1DA7B32C32541AB696157A2BF5CDDBBD4AD721E26FFDA1B03EDA9B34E729211868BBB0F2EAE1D73F9C0DAC91AE865C1D38E6C2A7A81252EA170B401C0B359B66FCED1EC51E"))
        SBUtils.Unit.SetLicenseKey("C0E26748DF470A75CB4B78B475E6BF984D7879C8FD8BD7BD4E03A099BA28A9FB5A4DDBB90291ADE034BF84D956D2057841D937B2AD0F9F4D4AD585DF7C36064B920F166730DC633EFD9AF0451BE03A4BA440AB43D3AAB32C4C5ADA29FAAE9D2C4D4934D8874486F4CC51D43A9636ED0F9F0461C6664FB771AFEF6FA64E9C2B58DDD87DF57D2B5F8C4CD3562FBC42AA21FD32114710AB79507BAC1390DBC4F50D07C5094FF8DE9474E108D8AAEEF631E526BB08FA20FE5D951048361F99FA6DD9ACC304AFDBF720F11AB6CAD62D330814637F97D207F8940E63DFD62006EBE20935943C045AAEFD839C239AF0E020E8E02F2BF4604AB33037E102FB8C26EEA70C")
        ' Both initialization function *must* be called before using PDFBlackbox:
        SBPDF.Unit.Initialize()
        SBPDFSecurity.Unit.Initialize()
        ' Initialize classes
        ' Document = New TElPDFDocument  'jitendra
        PublicKeyHandler = New TElPDFPublicKeySecurityHandler
        CertStorage = New TElMemoryCertStorage
        SystemStore = New TElWinCertStorage
        Cert = New TElX509Certificate
        HTTPClient = New TElHTTPSClient
        TSPClient = New TElHTTPTSPClient
        ' Loading Win32 certificates
        RefreshSystemCertificates()

        'SecureBlackbox Signatures initialization
        Signatures = New ArrayList
    End Sub

#Region " Windows Form Designer generated code "
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents saveDialogPDF As System.Windows.Forms.SaveFileDialog
    Friend WithEvents openDialogPDFFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents openDialogCert As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.saveDialogPDF = New System.Windows.Forms.SaveFileDialog()
        Me.openDialogPDFFile = New System.Windows.Forms.OpenFileDialog()
        Me.openDialogCert = New System.Windows.Forms.OpenFileDialog()
        Me.openDialogPDF = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblDestination = New System.Windows.Forms.Label()
        Me.TElSBLicenseManager1 = New SBLicenseManager.TElSBLicenseManager()
        Me.gbSigProps = New System.Windows.Forms.GroupBox()
        Me.chkArchive = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpSignPic = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.picSign = New System.Windows.Forms.PictureBox()
        Me.lblRotation = New System.Windows.Forms.Label()
        Me.cmbRotation = New System.Windows.Forms.ComboBox()
        Me.ttReasonforsig = New System.Windows.Forms.PictureBox()
        Me.lnkOption2 = New System.Windows.Forms.LinkLabel()
        Me.lnkOption1 = New System.Windows.Forms.LinkLabel()
        Me.cmbCustom = New System.Windows.Forms.RadioButton()
        Me.cmbTypical = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbSystemCerts = New System.Windows.Forms.ComboBox()
        Me.rbUseSystemCert = New System.Windows.Forms.RadioButton()
        Me.btnBrowseCert = New System.Windows.Forms.Button()
        Me.tbCertPassword = New System.Windows.Forms.TextBox()
        Me.tbCert = New System.Windows.Forms.TextBox()
        Me.lCertPassword = New System.Windows.Forms.Label()
        Me.rbUseCertFile = New System.Windows.Forms.RadioButton()
        Me.chkHideBackground = New System.Windows.Forms.CheckBox()
        Me.txtSignersName = New System.Windows.Forms.TextBox()
        Me.lblAuthorsName = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblNoEmployee = New System.Windows.Forms.Label()
        Me.cbPosition = New System.Windows.Forms.ComboBox()
        Me.lblPos = New System.Windows.Forms.Label()
        Me.cbPrintOn = New System.Windows.Forms.ComboBox()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.cbFont = New System.Windows.Forms.ComboBox()
        Me.lFont = New System.Windows.Forms.Label()
        Me.cbReason = New System.Windows.Forms.ComboBox()
        Me.lReason = New System.Windows.Forms.Label()
        Me.tbAuthor = New System.Windows.Forms.TextBox()
        Me.lAuthor = New System.Windows.Forms.Label()
        Me.lSignatureType = New System.Windows.Forms.Label()
        Me.cbSignatureType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.chkPwdProtect = New System.Windows.Forms.CheckBox()
        Me.tbTimestampServer = New System.Windows.Forms.TextBox()
        Me.cbTimestamp = New System.Windows.Forms.CheckBox()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnFindFiles = New System.Windows.Forms.Button()
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.gbSigProps.SuspendLayout()
        Me.grpSignPic.SuspendLayout()
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ttReasonforsig, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'saveDialogPDF
        '
        Me.saveDialogPDF.Filter = "PDF document (*.pdf)|*.pdf|All files (*.*)|*.*"
        Me.saveDialogPDF.InitialDirectory = "."
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
        'lblDestination
        '
        Me.lblDestination.AutoSize = True
        Me.lblDestination.Location = New System.Drawing.Point(12, 118)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(0, 15)
        Me.lblDestination.TabIndex = 19
        '
        'TElSBLicenseManager1
        '
        Me.TElSBLicenseManager1.LicenseKey = ""
        Me.TElSBLicenseManager1.LicenseKeyFile = ""
        Me.TElSBLicenseManager1.RegistryKey = Nothing
        Me.TElSBLicenseManager1.Tag = Nothing
        '
        'gbSigProps
        '
        Me.gbSigProps.Controls.Add(Me.chkArchive)
        Me.gbSigProps.Controls.Add(Me.Label4)
        Me.gbSigProps.Controls.Add(Me.grpSignPic)
        Me.gbSigProps.Controls.Add(Me.lblRotation)
        Me.gbSigProps.Controls.Add(Me.cmbRotation)
        Me.gbSigProps.Controls.Add(Me.ttReasonforsig)
        Me.gbSigProps.Controls.Add(Me.lnkOption2)
        Me.gbSigProps.Controls.Add(Me.lnkOption1)
        Me.gbSigProps.Controls.Add(Me.cmbCustom)
        Me.gbSigProps.Controls.Add(Me.cmbTypical)
        Me.gbSigProps.Controls.Add(Me.Label1)
        Me.gbSigProps.Controls.Add(Me.GroupBox1)
        Me.gbSigProps.Controls.Add(Me.chkHideBackground)
        Me.gbSigProps.Controls.Add(Me.txtSignersName)
        Me.gbSigProps.Controls.Add(Me.lblAuthorsName)
        Me.gbSigProps.Controls.Add(Me.lblStatus)
        Me.gbSigProps.Controls.Add(Me.lblNoEmployee)
        Me.gbSigProps.Controls.Add(Me.cbPosition)
        Me.gbSigProps.Controls.Add(Me.lblPos)
        Me.gbSigProps.Controls.Add(Me.cbPrintOn)
        Me.gbSigProps.Controls.Add(Me.lblPage)
        Me.gbSigProps.Controls.Add(Me.cbFont)
        Me.gbSigProps.Controls.Add(Me.lFont)
        Me.gbSigProps.Controls.Add(Me.cbReason)
        Me.gbSigProps.Controls.Add(Me.lReason)
        Me.gbSigProps.Controls.Add(Me.tbAuthor)
        Me.gbSigProps.Controls.Add(Me.lAuthor)
        Me.gbSigProps.Controls.Add(Me.lSignatureType)
        Me.gbSigProps.Controls.Add(Me.cbSignatureType)
        Me.gbSigProps.Controls.Add(Me.Label3)
        Me.gbSigProps.Controls.Add(Me.Label2)
        Me.gbSigProps.Controls.Add(Me.txtY)
        Me.gbSigProps.Controls.Add(Me.txtX)
        Me.gbSigProps.Controls.Add(Me.chkPwdProtect)
        Me.gbSigProps.Location = New System.Drawing.Point(5, 1)
        Me.gbSigProps.Name = "gbSigProps"
        Me.gbSigProps.Size = New System.Drawing.Size(575, 381)
        Me.gbSigProps.TabIndex = 1
        Me.gbSigProps.TabStop = False
        '
        'chkArchive
        '
        Me.chkArchive.AutoSize = True
        Me.chkArchive.Location = New System.Drawing.Point(501, 359)
        Me.chkArchive.Name = "chkArchive"
        Me.chkArchive.Size = New System.Drawing.Size(15, 14)
        Me.chkArchive.TabIndex = 78
        Me.chkArchive.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(327, 358)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 15)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Archive Unsigned PDF files "
        '
        'grpSignPic
        '
        Me.grpSignPic.Controls.Add(Me.btnClose)
        Me.grpSignPic.Controls.Add(Me.picSign)
        Me.grpSignPic.Location = New System.Drawing.Point(191, 135)
        Me.grpSignPic.Name = "grpSignPic"
        Me.grpSignPic.Size = New System.Drawing.Size(330, 210)
        Me.grpSignPic.TabIndex = 72
        Me.grpSignPic.TabStop = False
        Me.grpSignPic.Visible = False
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Location = New System.Drawing.Point(254, 179)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 24)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "C&lose"
        '
        'picSign
        '
        Me.picSign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSign.InitialImage = Nothing
        Me.picSign.Location = New System.Drawing.Point(6, 20)
        Me.picSign.Name = "picSign"
        Me.picSign.Size = New System.Drawing.Size(316, 156)
        Me.picSign.TabIndex = 0
        Me.picSign.TabStop = False
        '
        'lblRotation
        '
        Me.lblRotation.Location = New System.Drawing.Point(36, 356)
        Me.lblRotation.Name = "lblRotation"
        Me.lblRotation.Size = New System.Drawing.Size(109, 16)
        Me.lblRotation.TabIndex = 76
        Me.lblRotation.Text = "Signature Rotation"
        '
        'cmbRotation
        '
        Me.cmbRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRotation.FormattingEnabled = True
        Me.cmbRotation.Items.AddRange(New Object() {"90", "180", "270", "360"})
        Me.cmbRotation.Location = New System.Drawing.Point(243, 354)
        Me.cmbRotation.Name = "cmbRotation"
        Me.cmbRotation.Size = New System.Drawing.Size(74, 23)
        Me.cmbRotation.TabIndex = 75
        '
        'ttReasonforsig
        '
        Me.ttReasonforsig.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.ToolTip
        Me.ttReasonforsig.Location = New System.Drawing.Point(151, 269)
        Me.ttReasonforsig.Name = "ttReasonforsig"
        Me.ttReasonforsig.Size = New System.Drawing.Size(16, 16)
        Me.ttReasonforsig.TabIndex = 74
        Me.ttReasonforsig.TabStop = False
        '
        'lnkOption2
        '
        Me.lnkOption2.AutoSize = True
        Me.lnkOption2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lnkOption2.Location = New System.Drawing.Point(400, 331)
        Me.lnkOption2.Name = "lnkOption2"
        Me.lnkOption2.Size = New System.Drawing.Size(108, 14)
        Me.lnkOption2.TabIndex = 68
        Me.lnkOption2.TabStop = True
        Me.lnkOption2.Text = "Click for Sample Sign"
        '
        'lnkOption1
        '
        Me.lnkOption1.AutoSize = True
        Me.lnkOption1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lnkOption1.Location = New System.Drawing.Point(242, 331)
        Me.lnkOption1.Name = "lnkOption1"
        Me.lnkOption1.Size = New System.Drawing.Size(108, 14)
        Me.lnkOption1.TabIndex = 67
        Me.lnkOption1.TabStop = True
        Me.lnkOption1.Text = "Click for Sample Sign"
        '
        'cmbCustom
        '
        Me.cmbCustom.AutoSize = True
        Me.cmbCustom.Location = New System.Drawing.Point(402, 309)
        Me.cmbCustom.Name = "cmbCustom"
        Me.cmbCustom.Size = New System.Drawing.Size(68, 19)
        Me.cmbCustom.TabIndex = 66
        Me.cmbCustom.Text = "Option2"
        Me.cmbCustom.UseVisualStyleBackColor = True
        '
        'cmbTypical
        '
        Me.cmbTypical.AutoSize = True
        Me.cmbTypical.Checked = True
        Me.cmbTypical.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbTypical.Location = New System.Drawing.Point(239, 309)
        Me.cmbTypical.Name = "cmbTypical"
        Me.cmbTypical.Size = New System.Drawing.Size(68, 19)
        Me.cmbTypical.TabIndex = 65
        Me.cmbTypical.TabStop = True
        Me.cmbTypical.Text = "Option1"
        Me.cmbTypical.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Signature Style"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSystemCerts)
        Me.GroupBox1.Controls.Add(Me.rbUseSystemCert)
        Me.GroupBox1.Controls.Add(Me.btnBrowseCert)
        Me.GroupBox1.Controls.Add(Me.tbCertPassword)
        Me.GroupBox1.Controls.Add(Me.tbCert)
        Me.GroupBox1.Controls.Add(Me.lCertPassword)
        Me.GroupBox1.Controls.Add(Me.rbUseCertFile)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Signature properties"
        '
        'cbSystemCerts
        '
        Me.cbSystemCerts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSystemCerts.Enabled = False
        Me.cbSystemCerts.Location = New System.Drawing.Point(239, 70)
        Me.cbSystemCerts.Name = "cbSystemCerts"
        Me.cbSystemCerts.Size = New System.Drawing.Size(321, 23)
        Me.cbSystemCerts.TabIndex = 5
        '
        'rbUseSystemCert
        '
        Me.rbUseSystemCert.Location = New System.Drawing.Point(4, 69)
        Me.rbUseSystemCert.Name = "rbUseSystemCert"
        Me.rbUseSystemCert.Size = New System.Drawing.Size(241, 24)
        Me.rbUseSystemCert.TabIndex = 4
        Me.rbUseSystemCert.Text = "Certificate from system certificate store:"
        '
        'btnBrowseCert
        '
        Me.btnBrowseCert.Location = New System.Drawing.Point(509, 16)
        Me.btnBrowseCert.Name = "btnBrowseCert"
        Me.btnBrowseCert.Size = New System.Drawing.Size(63, 23)
        Me.btnBrowseCert.TabIndex = 2
        Me.btnBrowseCert.Text = "Browse..."
        '
        'tbCertPassword
        '
        Me.tbCertPassword.Location = New System.Drawing.Point(239, 43)
        Me.tbCertPassword.Name = "tbCertPassword"
        Me.tbCertPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbCertPassword.Size = New System.Drawing.Size(321, 21)
        Me.tbCertPassword.TabIndex = 3
        '
        'tbCert
        '
        Me.tbCert.Location = New System.Drawing.Point(239, 17)
        Me.tbCert.Name = "tbCert"
        Me.tbCert.Size = New System.Drawing.Size(270, 21)
        Me.tbCert.TabIndex = 1
        '
        'lCertPassword
        '
        Me.lCertPassword.Location = New System.Drawing.Point(33, 45)
        Me.lCertPassword.Name = "lCertPassword"
        Me.lCertPassword.Size = New System.Drawing.Size(151, 16)
        Me.lCertPassword.TabIndex = 8
        Me.lCertPassword.Text = "Certificate password:"
        '
        'rbUseCertFile
        '
        Me.rbUseCertFile.Checked = True
        Me.rbUseCertFile.Location = New System.Drawing.Point(4, 15)
        Me.rbUseCertFile.Name = "rbUseCertFile"
        Me.rbUseCertFile.Size = New System.Drawing.Size(175, 24)
        Me.rbUseCertFile.TabIndex = 0
        Me.rbUseCertFile.TabStop = True
        Me.rbUseCertFile.Text = "Certificate from file:"
        '
        'chkHideBackground
        '
        Me.chkHideBackground.AutoSize = True
        Me.chkHideBackground.Checked = True
        Me.chkHideBackground.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideBackground.Location = New System.Drawing.Point(239, 158)
        Me.chkHideBackground.Name = "chkHideBackground"
        Me.chkHideBackground.Size = New System.Drawing.Size(147, 19)
        Me.chkHideBackground.TabIndex = 10
        Me.chkHideBackground.Text = "Hide Background Icon"
        Me.chkHideBackground.UseVisualStyleBackColor = True
        '
        'txtSignersName
        '
        Me.txtSignersName.BackColor = System.Drawing.SystemColors.Window
        Me.txtSignersName.Location = New System.Drawing.Point(239, 212)
        Me.txtSignersName.Name = "txtSignersName"
        Me.txtSignersName.Size = New System.Drawing.Size(321, 21)
        Me.txtSignersName.TabIndex = 12
        '
        'lblAuthorsName
        '
        Me.lblAuthorsName.Location = New System.Drawing.Point(34, 241)
        Me.lblAuthorsName.Name = "lblAuthorsName"
        Me.lblAuthorsName.Size = New System.Drawing.Size(100, 16)
        Me.lblAuthorsName.TabIndex = 55
        Me.lblAuthorsName.Text = "Author's Name"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(242, 287)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblStatus.TabIndex = 52
        '
        'lblNoEmployee
        '
        Me.lblNoEmployee.AutoSize = True
        Me.lblNoEmployee.Location = New System.Drawing.Point(325, 355)
        Me.lblNoEmployee.Name = "lblNoEmployee"
        Me.lblNoEmployee.Size = New System.Drawing.Size(0, 15)
        Me.lblNoEmployee.TabIndex = 54
        Me.lblNoEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbPosition
        '
        Me.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPosition.Items.AddRange(New Object() {"Top Left ", "Top Right", "Bottom Left", "Bottom Right"})
        Me.cbPosition.Location = New System.Drawing.Point(239, 129)
        Me.cbPosition.Name = "cbPosition"
        Me.cbPosition.Size = New System.Drawing.Size(128, 23)
        Me.cbPosition.TabIndex = 7
        '
        'lblPos
        '
        Me.lblPos.AutoSize = True
        Me.lblPos.Location = New System.Drawing.Point(34, 133)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(101, 15)
        Me.lblPos.TabIndex = 22
        Me.lblPos.Text = "Print Signature at"
        '
        'cbPrintOn
        '
        Me.cbPrintOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrintOn.Items.AddRange(New Object() {"Last Page", "First Page", "Each Page"})
        Me.cbPrintOn.Location = New System.Drawing.Point(239, 100)
        Me.cbPrintOn.Name = "cbPrintOn"
        Me.cbPrintOn.Size = New System.Drawing.Size(321, 23)
        Me.cbPrintOn.TabIndex = 6
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Location = New System.Drawing.Point(34, 104)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(107, 15)
        Me.lblPage.TabIndex = 20
        Me.lblPage.Text = "Print Signature On"
        '
        'cbFont
        '
        Me.cbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFont.Items.AddRange(New Object() {"Helvetica", "Times-Roman", "Courier"})
        Me.cbFont.Location = New System.Drawing.Point(239, 183)
        Me.cbFont.Name = "cbFont"
        Me.cbFont.Size = New System.Drawing.Size(321, 23)
        Me.cbFont.TabIndex = 11
        '
        'lFont
        '
        Me.lFont.Location = New System.Drawing.Point(34, 186)
        Me.lFont.Name = "lFont"
        Me.lFont.Size = New System.Drawing.Size(160, 16)
        Me.lFont.TabIndex = 18
        Me.lFont.Text = "Font:"
        '
        'cbReason
        '
        Me.cbReason.Items.AddRange(New Object() {"I am the author of this document", "I agree to the terms defined by placement of my signature on this document", "I have reviewed this document", "I attest to the accuracy and integrity of this document", "I am approving this document", "Control No. will be updated"})
        Me.cbReason.Location = New System.Drawing.Point(239, 266)
        Me.cbReason.Name = "cbReason"
        Me.cbReason.Size = New System.Drawing.Size(321, 23)
        Me.cbReason.TabIndex = 14
        Me.cbReason.Text = "<none>"
        '
        'lReason
        '
        Me.lReason.Location = New System.Drawing.Point(34, 269)
        Me.lReason.Name = "lReason"
        Me.lReason.Size = New System.Drawing.Size(115, 20)
        Me.lReason.TabIndex = 9
        Me.lReason.Text = "Reason for signing:"
        '
        'tbAuthor
        '
        Me.tbAuthor.Location = New System.Drawing.Point(239, 239)
        Me.tbAuthor.Name = "tbAuthor"
        Me.tbAuthor.Size = New System.Drawing.Size(321, 21)
        Me.tbAuthor.TabIndex = 13
        '
        'lAuthor
        '
        Me.lAuthor.Location = New System.Drawing.Point(34, 214)
        Me.lAuthor.Name = "lAuthor"
        Me.lAuthor.Size = New System.Drawing.Size(100, 16)
        Me.lAuthor.TabIndex = 7
        Me.lAuthor.Text = "Signer's Name"
        '
        'lSignatureType
        '
        Me.lSignatureType.Location = New System.Drawing.Point(7, 129)
        Me.lSignatureType.Name = "lSignatureType"
        Me.lSignatureType.Size = New System.Drawing.Size(160, 16)
        Me.lSignatureType.TabIndex = 5
        Me.lSignatureType.Text = "Signature type:"
        Me.lSignatureType.Visible = False
        '
        'cbSignatureType
        '
        Me.cbSignatureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSignatureType.Items.AddRange(New Object() {"Invisible document signature", "Visible document signature", "Certification (MDP) signature"})
        Me.cbSignatureType.Location = New System.Drawing.Point(16, 182)
        Me.cbSignatureType.Name = "cbSignatureType"
        Me.cbSignatureType.Size = New System.Drawing.Size(384, 23)
        Me.cbSignatureType.TabIndex = 6
        Me.cbSignatureType.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(478, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Vertical"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(374, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Horizontal"
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(527, 130)
        Me.txtY.MaxLength = 3
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(33, 21)
        Me.txtY.TabIndex = 9
        Me.txtY.Text = "50"
        Me.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(438, 130)
        Me.txtX.MaxLength = 3
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(33, 21)
        Me.txtX.TabIndex = 8
        Me.txtX.Text = "450"
        Me.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkPwdProtect
        '
        Me.chkPwdProtect.AutoSize = True
        Me.chkPwdProtect.Location = New System.Drawing.Point(420, 158)
        Me.chkPwdProtect.Name = "chkPwdProtect"
        Me.chkPwdProtect.Size = New System.Drawing.Size(140, 19)
        Me.chkPwdProtect.TabIndex = 73
        Me.chkPwdProtect.Text = "Password Protection"
        Me.chkPwdProtect.UseVisualStyleBackColor = True
        Me.chkPwdProtect.Visible = False
        '
        'tbTimestampServer
        '
        Me.tbTimestampServer.Location = New System.Drawing.Point(64, 473)
        Me.tbTimestampServer.Name = "tbTimestampServer"
        Me.tbTimestampServer.Size = New System.Drawing.Size(328, 21)
        Me.tbTimestampServer.TabIndex = 13
        Me.tbTimestampServer.Text = "http://"
        Me.tbTimestampServer.Visible = False
        '
        'cbTimestamp
        '
        Me.cbTimestamp.Location = New System.Drawing.Point(23, 452)
        Me.cbTimestamp.Name = "cbTimestamp"
        Me.cbTimestamp.Size = New System.Drawing.Size(338, 16)
        Me.cbTimestamp.TabIndex = 14
        Me.cbTimestamp.Text = "Request a timestamp from server:"
        Me.cbTimestamp.Visible = False
        '
        'btnSign
        '
        Me.btnSign.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSign.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSign.Location = New System.Drawing.Point(303, 411)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(80, 23)
        Me.btnSign.TabIndex = 16
        Me.btnSign.Text = "&Start Signing"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(509, 409)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(68, 24)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "E&xit"
        '
        'btnBack
        '
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBack.Location = New System.Drawing.Point(220, 410)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(74, 23)
        Me.btnBack.TabIndex = 15
        Me.btnBack.Text = "<<&Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(2, 385)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(575, 10)
        Me.ProgressBar1.TabIndex = 50
        Me.ProgressBar1.Visible = False
        '
        'btnFindFiles
        '
        Me.btnFindFiles.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFindFiles.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindFiles.Location = New System.Drawing.Point(399, 410)
        Me.btnFindFiles.Name = "btnFindFiles"
        Me.btnFindFiles.Size = New System.Drawing.Size(98, 24)
        Me.btnFindFiles.TabIndex = 17
        Me.btnFindFiles.Text = "Find Pdfs Fi&les"
        '
        'lblDongle
        '
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(1, 422)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(200, 15)
        Me.lblDongle.TabIndex = 56
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(1, 408)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(200, 15)
        Me.lblVersion.TabIndex = 55
        Me.lblVersion.Text = " Version"
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnSign
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(687, 570)
        Me.Controls.Add(Me.btnFindFiles)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbSigProps)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.lblDestination)
        Me.Controls.Add(Me.cbTimestamp)
        Me.Controls.Add(Me.tbTimestampServer)
        Me.Controls.Add(Me.lblDongle)
        Me.Controls.Add(Me.lblVersion)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Options to Sign"
        Me.gbSigProps.ResumeLayout(False)
        Me.gbSigProps.PerformLayout()
        Me.grpSignPic.ResumeLayout(False)
        CType(Me.picSign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ttReasonforsig, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim intMailCnt As Integer
    Dim blnSelectAll As Boolean

    Dim intTimer As Integer

    Sub AddTrueTypeFont(ByVal FontName As String, ByVal Wid As TElPDFSignatureWidgetProps)
        Dim Font0 As TElPDFCompositeFont = New TElPDFCompositeFont
        Dim CIDFont As TElPDFCIDFont = New TElPDFCIDFont
        Dim SystemInfo As TElPDFCIDSystemInfo = New TElPDFCIDSystemInfo
        Dim FontDescriptor As TElPDFCIDFontDescriptor = New TElPDFCIDFontDescriptor
        Dim FontsFolder As String = Application.StartupPath + "\..\Fonts\"
        Dim Buf As Byte()

        ' Reading ttf file
        Dim Stream As FileStream = New FileStream(FontsFolder + FontName + ".ttf", FileMode.Open, FileAccess.Read)
        Try
            Buf = New Byte(Stream.Length) {}
            Stream.Read(Buf, 0, Buf.Length)
        Finally
            Stream.Close()
        End Try
        FontDescriptor.FontFile2 = Buf

        ' Free UCS Outline Fonts: http://savannah.gnu.org/projects/freefont
        ' To embed .TTF files, you need to extract the font metrics
        If File.Exists(FontsFolder + FontName + ".ufm") Then
            ' Extracting font metrics using TTF2UFM utility
            ' ttf2ufm.exe -a -F FreeSerif.ttf
            ' the following code parse .ufm file

            Dim CIDToGIDMap(256 * 256 * 2) As Byte
            FontDescriptor.Flags = 32

            Dim nfi As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo
            nfi.NumberDecimalSeparator = "."
            Dim sr As StreamReader = New StreamReader(FontsFolder + FontName + ".ufm")
            While True
                Dim s As String = sr.ReadLine
                If s Is Nothing Then
                    Exit While
                End If
                s = s.Trim
                Dim t As String() = s.Split(" "c)
                If s <> "" AndAlso t.Length >= 2 Then
                    If t(0) = "U" Then
                        If t.Length >= 11 Then
                            Dim CID As Integer = Integer.Parse(t(1))
                            Dim Width As Integer = Integer.Parse(t(4))
                            If CID >= 0 Then
                                Dim GID As Integer = Integer.Parse(t(10))
                                If (CID >= 0) AndAlso (CID < 65535) AndAlso (GID > 0) Then
                                    CIDToGIDMap(CID * 2) = CType((GID >> 8), Byte)
                                    CIDToGIDMap(CID * 2 + 1) = CType((GID And 255), Byte)
                                    CIDFont.W.Add(CID, Width)
                                End If
                                If (t.Length > 13) AndAlso (CID = Microsoft.VisualBasic.AscW("X")) Then
                                    FontDescriptor.XHeight = Integer.Parse(t(13))
                                End If
                            End If
                            If (t(7) = ".notdef") AndAlso (FontDescriptor.MissingWidth = 0) Then
                                FontDescriptor.MissingWidth = Width
                            End If
                        End If
                    Else
                        If t(0) = "FontName" Then
                            FontDescriptor.FontName = t(1)
                        Else
                            If t(0) = "Weight" Then
                                If FontDescriptor.StemV = 0 Then
                                    s = t(1).ToLower
                                    If (s = "bold") OrElse (s = "black") Then
                                        FontDescriptor.StemV = 120
                                    Else
                                        FontDescriptor.StemV = 70
                                    End If
                                End If
                            Else
                                If t(0) = "ItalicAngle" Then
                                    FontDescriptor.ItalicAngle = CType(Double.Parse(t(1), nfi), Integer)
                                    If Not (FontDescriptor.ItalicAngle = 0) Then
                                        FontDescriptor.Flags = FontDescriptor.Flags Or 64
                                    End If
                                Else
                                    If t(0) = "Ascender" Then
                                        FontDescriptor.Ascent = Integer.Parse(t(1))
                                    Else
                                        If t(0) = "Descender" Then
                                            FontDescriptor.Descent = Integer.Parse(t(1))
                                        Else
                                            If t(0) = "IsFixedPitch" Then
                                                If t(1) = "true" Then
                                                    FontDescriptor.Flags = FontDescriptor.Flags Or 1
                                                End If
                                            Else
                                                If t(0) = "FontBBox" Then
                                                    If t.Length >= 5 Then
                                                        FontDescriptor.FontBBoxX1 = Integer.Parse(t(1))
                                                        FontDescriptor.FontBBoxY1 = Integer.Parse(t(2))
                                                        FontDescriptor.FontBBoxX2 = Integer.Parse(t(3))
                                                        FontDescriptor.FontBBoxY2 = Integer.Parse(t(4))
                                                    End If
                                                Else
                                                    If t(0) = "CapHeight" Then
                                                        FontDescriptor.CapHeight = Integer.Parse(t(1))
                                                    Else
                                                        If t(0) = "StdVW" Then
                                                            FontDescriptor.StemV = Integer.Parse(t(1))
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End While
            sr.Close()
            If FontDescriptor.MissingWidth = 0 Then
                FontDescriptor.MissingWidth = 600
            End If
            CIDFont.CIDToGIDMapData = CIDToGIDMap
        Else
            If FontName = "FreeSerif" Then
                ' simply set font metrics data
                FontDescriptor.FontName = FontName
                FontDescriptor.Ascent = 1166
                FontDescriptor.Descent = -446
                FontDescriptor.CapHeight = 1166
                FontDescriptor.Flags = 32
                FontDescriptor.FontBBoxX1 = -672
                FontDescriptor.FontBBoxY1 = -446
                FontDescriptor.FontBBoxX2 = 1588
                FontDescriptor.FontBBoxY2 = 1166
                FontDescriptor.ItalicAngle = 0
                FontDescriptor.StemV = 70
                FontDescriptor.MissingWidth = 700
                CIDFont.DW = 700
                Dim sr As StreamReader = New StreamReader(FontsFolder + FontName + ".w")
                While True
                    Dim s As String = sr.ReadLine
                    If s Is Nothing Then
                        Exit While
                    End If
                    s = s.Trim

                    If s <> "" Then
                        Dim i As Integer = s.IndexOf(" "c)
                        If i >= 0 Then
                            Dim CIDFirst As Integer = Integer.Parse(s.Substring(0, i))
                            s = s.Substring(i + 1).Trim
                            i = s.IndexOf(" "c)
                            If i >= 0 Then
                                Dim CIDLast As Integer = Integer.Parse(s.Substring(0, i))
                                Dim Width As Integer = Integer.Parse(s.Substring(i + 1))
                                CIDFont.W.AddRange(CIDFirst, CIDLast, Width)
                            Else
                                Dim Width As Integer = Integer.Parse(s)
                                CIDFont.W.Add(CIDFirst, Width)
                            End If
                        End If
                    End If
                End While

                sr.Close()
                Stream = New FileStream(FontsFolder + FontName + ".ctg", FileMode.Open, FileAccess.Read)
                Buf = New Byte(Stream.Length) {}
                Stream.Read(Buf, 0, Buf.Length)
                Stream.Close()
                CIDFont.CIDToGIDMapData = Buf
            End If
        End If

        Font0.BaseFont = FontDescriptor.FontName
        Font0.Encoding = "Identity-H"
        ' the name of font resource used by default signature widget
        Font0.ResourceName = "T1_0"
        Font0.DescendantFonts = CIDFont
        SystemInfo.Registry = "Adobe"
        SystemInfo.Ordering = "UCS"
        CIDFont.Subtype = "CIDFontType2"
        CIDFont.BaseFont = FontDescriptor.FontName
        CIDFont.CIDSystemInfo = SystemInfo
        CIDFont.FontDescriptor = FontDescriptor

        Wid.AddFont(Font0)
        Wid.AddFont(CIDFont)
        Wid.AddFontObject(SystemInfo)
        Wid.AddFontObject(FontDescriptor)
    End Sub

    Private Sub RefreshSystemCertificates()
        Dim i As Integer
        SystemStore.SystemStores.BeginUpdate()
        Try
            SystemStore.SystemStores.Clear()
            SystemStore.SystemStores.Add("MY")
        Finally
            SystemStore.SystemStores.EndUpdate()
        End Try
        cbSystemCerts.Items.Clear()
        For i = 0 To SystemStore.Count - 1
            cbSystemCerts.Items.Add(SystemStore.Certificates(i).SubjectName.CommonName)
        Next
    End Sub

    Private Function UTF16ToWin1252(ByVal sender As Object, ByVal str As String) As Byte()
        Dim Enc As System.Text.Encoding = System.Text.Encoding.GetEncoding(1252)
        Return Enc.GetBytes(str)
    End Function

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call KillEXCEL()
        'KillCurProcess()
    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            btnBack_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Ver 1.7-E387 start
        chkPwdProtect.Visible = False
        Try
            If File.Exists(Application.StartupPath() & "\EmailList.xls") Then

                Dim conExcel1 As OleDb.OleDbConnection
                'gajanan start changes

                If File.Exists(Application.StartupPath() & "\conExcel.txt") Then
                    conExcel1 = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath() & "\EmailList.xls;Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
                Else
                    conExcel1 = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath() & "\EmailList.xls;Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
                End If

                'gajanan end
                conExcel1.Open()

                Dim cmdExcel1 As New OleDbCommand("Select * from [EmailList$]", conExcel1)
                Dim dr1 As OleDbDataReader = cmdExcel1.ExecuteReader

                dr1.Read()
                ' Ver 2.2 FASTFACT 1048 start
                ' If (dr1.FieldCount) = 4 Or (dr1.FieldCount) = 8 Then 'Jitendra
                '    chkPwdProtect.Visible = True
                ' End If
                chkPwdProtect.Visible = True
                '  Ver 2.2 FASTFACT 1048 end


                dr1.Close()
                conExcel1.Close()
            End If
        Catch ex As Exception
            MsgBox("Please check the format of the EmailList.xls")
        Finally

        End Try

        'Ver 1.7-E387 end


        gbSigProps.Enabled = Not DemoVersion

        'Setting Destination Folder Path on which the Signed Pdfs will be.
        strDestFolderPath = strPdfPath & "\SignedFiles\"

        lblVersion.Text = strVersion & strDate
        lblDongle.Text = DongleType
        cbPosition.Text = "Bottom Right"
        cbPrintOn.Text = "Last Page"
        cbFont.SelectedIndex = 0

        cbReason.Enabled = Not blnGenerateControlNo
        cbReason.Text = IIf(blnGenerateControlNo, "Control No. will be updated", "I am the author of this document")

        'abhay start
        GetUserSettings()
        'abhay end

        If File.Exists(strDestFolderPath) = False Then Exit Sub
        '--lblNoEmployee.Text = "Number of Files to be Signed: " & strFileName.Length

        'Ashish Start
        blnCustom = False
        'Ashish End

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If lstFileList.CheckedItems.Count = 0 Then
        '    MsgBox("Please select an Employee from the list.")
        '    lstFileList.Focus()
        '    Exit Sub
        'End If
        ''Retrieve To Name Addresses from Database
        'Dim objAdapter As New OleDbDataAdapter
        'Dim objData As New DataSet

        'ReDim strEmail(lstFileList.CheckedItems.Count - 1)
        'ReDim strFileName(lstFileList.CheckedItems.Count - 1)

        'If objConSigner.State = ConnectionState.Closed Then objConSigner.Open()

        'For intMailCnt = 0 To lstFileList.CheckedItems.Count - 1
        '    If optCode.Checked Then
        '        objAdapter = New OleDbDataAdapter("select [Email] from EmpMaster where EmpCode='" & lstFileList.CheckedItems(intMailCnt).Text & "'", objConSigner)
        '    Else
        '        objAdapter = New OleDbDataAdapter("select [Email] from EmpMaster where EmpCode='" & lstFileList.CheckedItems(intMailCnt).SubItems(1).Text & "'", objConSigner)
        '    End If
        '    objData.Tables.Clear()
        '    objAdapter.Fill(objData, "EmpMaster")

        '    If objData.Tables("EmpMaster").Rows.Count > 0 Then
        '        If IsDBNull(objData.Tables("EmpMaster").Rows(0).Item("Email")) Then
        '            strEmail(intMailCnt) = ""
        '        Else
        '            strEmail(intMailCnt) = objData.Tables("EmpMaster").Rows(0).Item("Email")
        '        End If

        '        strFileName(intMailCnt) = lstFileList.CheckedItems(intMailCnt).SubItems(2).Text
        '        If strEmail(intMailCnt).Trim = "" Then
        '            '--MsgBox("Email Id Not Exists For Employee " & lstFileList.CheckedItems(intMailCnt).SubItems(1).Text)
        '        End If
        '    Else
        '        MsgBox("Employee " & lstFileList.CheckedItems(intMailCnt).SubItems(1).Text & " Not Exist in Database.")
        '    End If
        'Next intMailCnt

        'Dim frmMail As New frmSendMail
        'frmMail.Show()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call KillCurProcess()
        Call KillEXCEL()
        MyBase.Dispose(True)
        KillCurProcess()
    End Sub

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        Dim TempPath As String = ""
        Dim Success As Boolean
        Dim F, CertF As FileStream
        Dim index, CertFormat As Integer
        Dim Sig As TElPDFSignature
        Dim sigInfo As TElClientTSPInfo

        Dim intI As Integer
        Dim intErrCount As Integer
        Dim intSuccessCount As Integer
        Dim intNotSigned As Integer
        Dim intAlreadySigned As Integer

        'Ver 1.7 REQ-237 Start
        Dim blnSkipMsg As Boolean
        blnSkipMsg = False
        'Ver 1.7 REQ-237 end 

        If (rbUseSystemCert.Checked) And (cbSystemCerts.SelectedIndex < 0) Then
            MessageBox.Show("Please select signing certificate", "Digital Signature")
            Exit Sub
        End If

        If rbUseCertFile.Checked Then
            If tbCert.Text = "" Then
                MsgBox("Select a Certificate File & Try again!")
                btnBrowseCert.Focus()
                Exit Sub
            ElseIf tbCertPassword.Text = "" Then
                MsgBox("Enter the Password for the Certificate File & Try again!")
                tbCertPassword.Focus()
                Exit Sub
            End If
        ElseIf rbUseCertFile.Checked Then
            If cbSystemCerts.Text = "" Then
                MsgBox("Select a Certificate & Try again!")
                cbSystemCerts.Focus()
                Exit Sub
            End If
        ElseIf txtX.Text = "" Then
            MsgBox("Please Enter the Horizontal Position of Signature")
            Exit Sub
        ElseIf txtY.Text = "" Then
            MsgBox("Please Enter the Vertical Position of Signature")
            Exit Sub
        End If

        'abhay start
        SaveUserSettings()
        'abhay end
        If blnGenerateControlNo Then
            Dim MainControlDirectory As New DirectoryInfo(strPdfPath)

            '19-05-2010 Start
            Dim strCurrentFile As String
            Dim strControlNo As String
            Dim intOldBatch As Integer
            Dim intControlNo As Integer

            If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then

                Dim oleCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")

                Dim oleCmd As New OleDbCommand
                oleCmd.CommandText = "select max(Batch) from ControlLog"
                oleCmd.Connection = oleCon
                oleCon.Open()
                intOldBatch = Convert.ToInt32(IIf(IsDBNull(oleCmd.ExecuteScalar()), 0, oleCmd.ExecuteScalar())) + 1

                oleCmd.CommandText = "select max(right(ControlNo,4)) from ControlLog where SigningDate=#" + Date.Today().ToShortDateString() + "#"
                oleCmd.Connection = oleCon
                intControlNo = Convert.ToInt32(IIf(IsDBNull(oleCmd.ExecuteScalar()), 0, oleCmd.ExecuteScalar()))
                oleCon.Close()

                Dim objControlFile As FileInfo
                Dim intFileCount As Integer

                For Each objControlFile In MainControlDirectory.GetFiles("*.pdf")
                    intFileCount += 1
                    strControlNo = "CN" & Replace(Now.ToShortDateString, "/", "") & Format(intFileCount + intControlNo, "0000") 'Format(intFileCount + intOldBatch, "0000")
                    strCurrentFile = objControlFile.Name.ToString
                    oleCmd.CommandText = "insert into ControlLog (FileName, SigningDate, ControlNo, Batch) values('" & strCurrentFile & "','" & Now.ToShortDateString & "','" & strControlNo & "', " & intOldBatch & ")"
                    oleCmd.Connection = oleCon
                    oleCon.Open()
                    oleCmd.ExecuteNonQuery()
                    oleCon.Close()
                Next

                oleCmd.Dispose()
            End If
            '19-05-2010 End

        End If

        'Setting Destination Folder Path on which the Signed Pdfs will be.
        'Ver 2.0 FASTFACTS-673 start
        ' strDestFolderPath = strPdfPath & "\SignedFiles\"
        If strSignedPdfPath.Equals(strPdfPath) = True Or strSignedPdfPath = "" Then
            strDestFolderPath = strPdfPath & "\SignedFiles\"
        Else
            strDestFolderPath = strSignedPdfPath & "\SignedFiles\"
        End If


        'Ver 2.0 FASTFACTS-673 end 

        Dim MainDirectory As DirectoryInfo = New DirectoryInfo(strPdfPath)
        Dim DestDirectory As DirectoryInfo = New DirectoryInfo(strDestFolderPath)
        Dim objFile As FileInfo

        'FASTFACTS-467 start

        Dim strArchievePath As String
        Dim strArchieveFileName As String = DateTime.Now.ToString("dd-MM-yyyy-(hh-mm-ss)")
        strArchievePath = Application.StartupPath & "\Archieve\" & strArchieveFileName
        Dim archiveDirectory As DirectoryInfo = New DirectoryInfo(Application.StartupPath & "\Archieve\")
        Dim FileArchieveDirectory As DirectoryInfo = New DirectoryInfo(strArchievePath)

        'FASTFACTS-467 end 

        ProgressBar1.Maximum = MainDirectory.GetFiles.Length
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True


        If MainDirectory.Exists = False Then
            MessageBox.Show("Specified Directory Not Exist", "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            If DestDirectory.Exists = False Then
                DestDirectory.Create()
            End If
            If MainDirectory.GetFiles("*.pdf").Length = 0 Then
                MessageBox.Show("no pdf files found in the selected folder", "Digital Signature")
                Exit Sub
            End If
            'For intI As Integer = 0 To MainDirectory.GetFiles.Length - 1
            'Application.DoEvents()
            'ProgressBar1.Value += 1

            Dim objWriter As New StreamWriter(Application.StartupPath & "\Error.txt")
            objWriter.Write("FileNames With Errors" & vbNewLine)

            Dim objWriter1 As New StreamWriter(Application.StartupPath & "\AlreadySigned.txt")
            objWriter1.Write("FileNames Which already Signed" & vbTab & "No. of times signed" & vbNewLine)
            'FASTFACTS-467 start
            If chkArchive.Checked Then
                If archiveDirectory.Exists = False Then
                    archiveDirectory.Create()
                End If
                FileArchieveDirectory.Create()
            End If

            'FASTFACTS-467 end 
            For Each objFile In MainDirectory.GetFiles("*.pdf")
                Dim strControlNo As String
                Application.DoEvents()
                ProgressBar1.Value = intI + 1
                lblStatus.Text = "Signing " & objFile.Name.ToString
                Application.DoEvents()
                '19-05-2010 Start
                strControlNo = ""



                If blnGenerateControlNo Then
                    If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then

                        Dim oleCon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
                        Dim oleCmd As New OleDbCommand
                        Dim objReader As OleDbDataReader
                        Dim intFileCount As Integer

                        oleCmd.CommandText = "Select count(FileName) as cntFileName from ControlLog where FileName = '" & objFile.Name & "'"
                        oleCmd.Connection = oleCon

                        oleCon.Open()
                        intFileCount = Convert.ToInt32(IIf(IsDBNull(oleCmd.ExecuteScalar()), 0, oleCmd.ExecuteScalar()))
                        oleCon.Close()



                        If (intFileCount > 1) Then
                            objWriter1.Write(objFile.Name & vbTab & vbTab & intFileCount - 1 & vbNewLine)
                            intAlreadySigned += 1
                            'Ver 1.7 REQ237 Start
                            'If blnNotify Then
                            '    MsgBox(objFile.Name & " file is already Signed " & intFileCount - 1 & " times, Latest Control No. will be considered.", MsgBoxStyle.OkOnly)
                            'End If

                            If blnSkipMsg = False Then
                                If blnNotify Then
                                    If MessageBox.Show(objFile.Name & " file is already Signed " & intFileCount - 1 & " times, Latest Control No. will be considered. " & vbCrLf & " Do you wish to skip this message for remaining files?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                                        blnSkipMsg = True
                                    End If
                                End If
                            End If
                            'ver 1.7 REQ237 End
                        ElseIf (intFileCount = 0) Then
                            If blnNotify Then
                                MsgBox("Control No. not updated for the file " & objFile.Name)
                            End If
                            strControlNo = "not updated"
                            objWriter.Write(objFile.Name & vbNewLine)
                            intNotSigned += 1
                        End If

                        oleCmd.CommandText = "select * from ControlLog where FileName='" & objFile.Name & "'"
                        oleCmd.Connection = oleCon
                        oleCon.Open()
                        objReader = oleCmd.ExecuteReader()

                        If objReader.HasRows Then
                            While objReader.Read()
                                strControlNo = objReader("ControlNo")
                            End While
                        End If
                        oleCon.Close()
                    End If
                End If

                If strControlNo <> "not updated" Then
                    '19-05-2010 End
                    Try
                        ' creating a temporary file copy
                        TempPath = Path.GetTempFileName()

                        If objFile.IsReadOnly Then
                            MessageBox.Show("Please Close the " & objFile.Name & " Pdf and then try again.", "Digital Signature")
                            Exit Sub
                        End If

                        System.IO.File.Copy(objFile.FullName, TempPath, True)
                        ' opening the temporary file
                        Success = False

                        F = New FileStream(TempPath, FileMode.Open, FileAccess.ReadWrite)
                        Try
                            Document = New TElPDFDocument  'jitendra Appolo munich 28/05/2015
                            Document.Open(F)

                            'Ver 1.7-E387 start
                            If chkPwdProtect.Checked = True Then
                                If File.Exists(Application.StartupPath() & "\EmailList.xls") Then
                                    Dim strPwd As String = ""
                                    Dim conExcel1 As OleDb.OleDbConnection
                                    conExcel1 = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath() & "\EmailList.xls;Extended Properties=""Excel 8.0; HDR=No; IMEX=1""")
                                    conExcel1.Open()
                                    Dim cmdExcel1 As New OleDbCommand("Select * from [EmailList$]", conExcel1)
                                    Dim dr1 As OleDbDataReader = cmdExcel1.ExecuteReader
                                    dr1.Read()

                                    Do Until dr1.Read = False
                                        'If blnTdsPacIntegrate = False Then
                                        If Mid(objFile.Name.ToUpper, 1, objFile.Name.Length - 4) = (dr1.Item(2).ToString().ToUpper) Then
                                            strPwd = dr1.Item(3).ToString()
                                            Exit Do
                                        End If
                                        ' Else
                                        '    If (objFile.Name.ToUpper) = (dr1.Item(2).ToString().ToUpper) Then
                                        'strPwd = dr1.Item(3).ToString()
                                        'Exit Do
                                        'End If
                                        ' End If

                                    Loop

                                    dr1.Close()
                                    conExcel1.Close()

                                    If chkPwdProtect.Checked = True And strPwd <> "" Then

                                        encryption = New TElPDFPasswordSecurityHandler
                                        Document.EncryptionHandler = encryption
                                        encryption.OwnerPassword = Decrypt(strPwd.ToString) '"1234"
                                        encryption.UserPassword = strPwd.ToString '"10101" ' "4321"
                                        encryption.StreamEncryptionAlgorithm = SBConstants.Unit.SB_ALGORITHM_CNT_RC4
                                        encryption.StreamEncryptionKeyBits = 128
                                        encryption.StringEncryptionAlgorithm = encryption.StreamEncryptionAlgorithm
                                        encryption.StringEncryptionKeyBits = encryption.StreamEncryptionKeyBits
                                        Document.Encrypt()
                                        Document.Close(True)
                                        Document.Open(F)
                                        Dim x As TElPDFPasswordSecurityHandler = New TElPDFPasswordSecurityHandler
                                        Document.EncryptionHandler = x
                                        x.OwnerPassword = Decrypt(strPwd.ToString) '"1234"
                                        x.UserPassword = "10101"
                                        Document.DecryptionMode = SBPDF.Unit.dmSign
                                        Document.Decrypt()
                                    End If
                                End If

                            End If
                            'Ver 1.7-E387 end

                            Try
                                ' checking if the document is already encrypted
                                If (Document.Encrypted) Then
                                    MessageBox.Show("The document is encrypted and cannot be signed", "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Return
                                End If

                                Dim intPageCount As Integer = Document.PageInfoCount

                                ' adding the signature and setting up property values
                                index = Document.AddSignature()
                                Sig = Document.Signatures(index)
                                Sig.Handler = PublicKeyHandler
                                Sig.AuthorName = tbAuthor.Text
                                Sig.SignatureName = txtSignersName.Text

                                Sig.MDPHashAlgorithm = TSBPDFSecurityHandlerEncryptionMethod.emUnknown

                                If chkHideBackground.Checked Then
                                    Sig.WidgetProps.BackgroundStyle = TSBPDFWidgetBackgroundStyle.pbsNoBackground
                                End If


                                ' Sig.WidgetProps.NoRotate = True
                                ' Sig.WidgetProps.Rotate = RotateFlipType.RotateNoneFlipNone

                                'Ashish start for Custom Sign
                                If blnCustom = True Then
                                    'Ashish end for Custom Sign
                                    'Ashish Start
                                    'If txtSignersName.Text.Trim = String.Empty Then
                                    '    Sig.WidgetProps.AutoText = True
                                    'Else
                                    Sig.WidgetProps.AutoText = False
                                    'End If


                                    'Sig.WidgetProps.Header = txtSignersName.Text
                                    'Sig.WidgetProps.SignerCaption = tbAuthor.Text
                                    'Sig.WidgetProps.SignerInfo = Sig.WidgetProps.SignerInfo
                                    'Ashish End

                                    'MsgBox(Sig.SignatureName)
                                    'MsgBox(Sig.WidgetProps.SignerCaption)
                                    'MsgBox(Sig.WidgetProps.SignerInfo)

                                    'Ashish Start
                                    'Sig.SigningTime = DateTime.Now.ToUniversalTime()
                                    'Ashish End
                                    'Ashish start for Custom Sign
                                Else
                                    If txtSignersName.Text.Trim = String.Empty Then
                                        Sig.WidgetProps.AutoText = True
                                    Else
                                        Sig.WidgetProps.AutoText = False
                                    End If


                                    Sig.WidgetProps.Header = txtSignersName.Text

                                    Sig.WidgetProps.SignerCaption = tbAuthor.Text
                                    Sig.WidgetProps.SignerInfo = Sig.WidgetProps.SignerInfo
                                    'Ver 1.7 QC 363 start

                                    Sig.SigningTime = DateTime.Now.ToUniversalTime()

                                    'Sig.SigningTime = DateTime.Now()

                                    'Ver 1.7 QC 363 end 

                                End If
                                'Ashish end for Custom Sign
                                Sig.WidgetProps.AutoPos = False

                                If cbPrintOn.Text = "First Page" Then
                                    Sig.WidgetProps.ShowOnAllPages = False
                                    'Ashish Start
                                    'txtY.Text = 135
                                    'txtY.Text = 170
                                    'txtX.Text = 325
                                    'Ashish End
                                ElseIf cbPrintOn.Text = "Last Page" Then
                                    Sig.WidgetProps.ShowOnAllPages = False
                                    Sig.Page = intPageCount - 1
                                Else
                                    Sig.WidgetProps.ShowOnAllPages = True
                                End If

                                'If cbPosition.Text = "Bottom Right" Then
                                Sig.WidgetProps.OffsetY = Val(txtY.Text)
                                Sig.WidgetProps.OffsetX = Val(txtX.Text)
                                'ElseIf cbPosition.Text = "Top Left " Then
                                '    Sig.WidgetProps.OffsetY = 750
                                '    Sig.WidgetProps.OffsetX = 5
                                'ElseIf cbPosition.Text = "Bottom Left" Then
                                '    Sig.WidgetProps.OffsetY = 50
                                '    Sig.WidgetProps.OffsetX = 50
                                'Else
                                '    Sig.WidgetProps.OffsetY = 750
                                '    Sig.WidgetProps.OffsetX = 500
                                'End If

                                If (String.Compare(cbReason.Text, "<none>") <> 0) Then
                                    If cbReason.Text = "Control No. will be updated" Then
                                        Sig.Reason = strControlNo.ToString
                                        Sig.WidgetProps.AlgorithmCaption = "Control No.: " & strControlNo.ToString
                                    Else
                                        Sig.Reason = cbReason.Text
                                        Sig.WidgetProps.AlgorithmCaption = cbReason.Text

                                    End If
                                Else
                                    Sig.Reason = ""
                                End If

                                ' configuring signature type
                                'Select Case (cbSignatureType.SelectedIndex)
                                '    Case 0
                                '        Sig.Invisible = True
                                '    Case 1
                                Sig.Invisible = False
                                '    Case 2
                                '        Sig.Invisible = False
                                '        Sig.SignatureType = SBPDF.Unit.stMDP
                                'End Select
                                ' loading certificate

                                If (rbUseCertFile.Checked) Then

                                    CertF = New FileStream(tbCert.Text, FileMode.Open)
                                    Try
                                        CertFormat = TElX509Certificate.DetectCertFileFormat(CertF)
                                        CertF.Position = 0
                                        Select Case (CertFormat)
                                            Case SBX509.Unit.cfDER
                                                Cert.LoadFromStream(CertF, 0)
                                            Case SBX509.Unit.cfPEM
                                                Cert.LoadFromStreamPEM(CertF, tbCertPassword.Text, 0)
                                            Case SBX509.Unit.cfPFX
                                                Cert.LoadFromStreamPFX(CertF, tbCertPassword.Text, 0)
                                            Case Else
                                                MessageBox.Show("Failed to load certificate", "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                Return
                                        End Select
                                    Finally
                                        CertF.Close()
                                    End Try
                                Else
                                    Cert = SystemStore.Certificates(cbSystemCerts.SelectedIndex)

                                End If

                                If Not Sig.Invisible Then
                                    If cbFont.Text = "Free Serif, Unicode" Then
                                        AddTrueTypeFont("FreeSerif", Sig.WidgetProps)
                                    Else
                                        If (cbFont.Text = "") OrElse (cbFont.Text = "Helvetica") Then
                                            ' Helvetica font is default
                                        Else
                                            If cbFont.Text = "Helvetica, Win-1252" Then
                                                ' Adding Type 1 font
                                                Dim SimpleFont As New TElPDFSimpleFont()
                                                SimpleFont.BaseFont = "Helvetica"
                                                Sig.WidgetProps.AddFont(SimpleFont)

                                                ' "A fonts encoding is the association between character codes and glyph descriptions."
                                                ' "Some character sets consist of more than 256 characters, including ligatures, accented characters,"
                                                ' "and other symbols required for high-quality typography or non-Latin writing systems."
                                                ' "Different encodings may select different subsets of the same character set."
                                                ' Adding encoding object
                                                SimpleFont.EncodingObject = New TElPDFEncoding()
                                                Sig.WidgetProps.AddFontObject(SimpleFont.EncodingObject)
                                                ' You can use one of predefined pdf encodings: StandardEncoding, MacRomanEncoding, WinAnsiEncoding or nothing
                                                SimpleFont.EncodingObject.BaseEncoding = "WinAnsiEncoding"
                                                ' Use Differences property to remap a code to the name of any glyph description that exists in the font
                                                ' Uncomment following line to change a Euro character (0x80 in Win-1252) to Pound Sign (Sterling)
                                                'SimpleFont.EncodingObject.Differences[128] := 'sterling';

                                                ' for fun adding Euro character (U+20AC) to Signer Caption

                                                ' Define callback routine that will convert UTF16 strings to our encoding (Win-1252)
                                                AddHandler Sig.WidgetProps.OnConvertStringToAnsi, AddressOf UTF16ToWin1252
                                            Else
                                                ' Adding Type 1 font
                                                Dim SimpleFont As TElPDFSimpleFont = New TElPDFSimpleFont
                                                SimpleFont.BaseFont = cbFont.Text
                                                Sig.WidgetProps.AddFont(SimpleFont)
                                            End If
                                        End If
                                    End If
                                End If

                                'Ashish start for Custom Sign
                                If blnCustom = True Then
                                    'Ashish end for Custom Sign
                                    'Ashish start
                                    'Sig.WidgetProps.SignerCaption = "Signer (" + Microsoft.VisualBasic.ChrW(8364) + ")"
                                    Sig.WidgetProps.Header = ""
                                    Sig.WidgetProps.SignerCaption = "   Digitally signed by"
                                    Sig.WidgetProps.SignerInfo = "Name      : " & IIf(txtSignersName.Text = "", Cert.SubjectName.CommonName, txtSignersName.Text) & vbCrLf & "Date        : " & DateTime.Now() &
                                        vbCrLf & "Reason   : " & Sig.Reason &
                                        vbCrLf & IIf(Sig.AuthorName = "", "", "Author's Name : " & Sig.AuthorName) ''FASTFACTS-523                                    
                                    Sig.WidgetProps.ShowTimestamp = False
                                    Sig.WidgetProps.AlgorithmCaption = ""
                                    'Ashish End
                                    'Ashish start for Custom Sign
                                Else


                                    Sig.WidgetProps.SignerCaption = "Signer (" + Microsoft.VisualBasic.ChrW(8364) + ")" & "                                                            " & DateTime.Now()
                                    ' Sig.WidgetProps.SignerInfo = "Date  : " & DateTime.Now()
                                    'Sig.WidgetProps.ShowTimestamp = True
                                    Sig.WidgetProps.ShowTimestamp = False
                                    'FASTFACTS-523 start
                                    If Sig.AuthorName <> "" Then
                                        Sig.WidgetProps.AlgorithmInfo = "Author's Name : " & Sig.AuthorName
                                    End If
                                    'FASTFACTS-523  end 
                                End If
                                'Ashish end for Custom Sign
                                Sig.WidgetProps.AutoFontSize = False
                                Sig.WidgetProps.TitleFontSize = 7 '8.77
                                Sig.WidgetProps.SectionTitleFontSize = 6.5 '7
                                'Ashish Start
                                'Sig.WidgetProps.SectionTextFontSize = 4.5 '5
                                Sig.WidgetProps.SectionTextFontSize = 6.5 '5
                                'Ashish End

                                Sig.WidgetProps.TimestampFontSize = 4.89

                                Sig.WidgetProps.AutoSize = False
                                'Ashish Start
                                'Sig.WidgetProps.Width += 60 '20
                                'Ver 1.08-3779 start
                                'Sig.WidgetProps.Width += 100 '20
                                Sig.WidgetProps.Width += 160 '20
                                'Ver 1.08-3779 end
                                'Sig.WidgetProps.Height += 15
                                Sig.WidgetProps.Height += 20
                                'Ashish End
                                'gajanan start
                                'Ver 1.09-REQ810 start 
                                If cmbRotation.Text.ToString().Trim() <> "" Then
                                    Sig.WidgetProps.Rotate = cmbRotation.Text
                                End If
                                ''Ver 1.09-REQ810 end

                                ' adding certificate to certificate storage
                                CertStorage.Clear()

                                CertStorage.Add(Cert, True)

                                PublicKeyHandler.CertStorage = CertStorage
                                PublicKeyHandler.SignatureType = TSBPDFPublicKeySignatureType.pstPKCS7SHA1

                                'Ashish start for Custom Sign

                                If blnCustom = True Then
                                    'Ashish end for Custom Sign
                                    'Ashish start
                                    Dim t As TimeZone
                                    Dim tm As Date

                                    t = TimeZone.CurrentTimeZone
                                    tm = t.ToUniversalTime(Date.Now)
                                    Sig.SigningTime = tm
                                    PublicKeyHandler.Certificates.Validate(Cert, 0, tm)
                                    'Ashish End
                                    'Ashish start for Custom Sign
                                End If

                                'Ashish end for Custom Sign
                                PublicKeyHandler.CustomName = "Adobe.PPKMS"

                                ' timestamping the signature
                                If cbTimestamp.Checked Then

                                    TSPClient.URL = tbTimestampServer.Text

                                    TSPClient.HashAlgorithm = SBConstants.Unit.SB_ALGORITHM_DGST_SHA1

                                    TSPClient.HTTPClient = HTTPClient

                                    PublicKeyHandler.TSPClient = TSPClient

                                End If
                                ' allowing to save the document

                                'Ashish New                              
                                'encryption = New TElPDFPasswordSecurityHandler
                                'Document.EncryptionHandler = encryption
                                'encryption.OwnerPassword = "1234"
                                'encryption.UserPassword = "4321"
                                'Document.Encrypt()
                                'Ashish End

                                Success = True




                                'MsgBox("1")
                            Finally
                                ' closing the document
                                'MsgBox("2")
                                Document.Close(Success)

                                'MsgBox("3")
                                blnSigned = True

                            End Try
                        Finally
                            'MsgBox("4")
                            F.Close()
                            'MsgBox("5")
                            '==>Jitendra Applo munich
                            F.Dispose()
                            Document.Dispose()


                        End Try
                        'Catch exp As EElPDFPasswordSecurityHandlerError
                        'MsgBox("6")
                    Catch exep As EElPDFPublicKeySecurityHandlerError
                        MessageBox.Show("Error : " & exep.Message.ToString, "Digital Signature")
                        Success = False
                        ProgressBar1.Visible = False
                        lblStatus.Text = ""
                        objWriter = Nothing
                        objWriter1 = Nothing
                        Exit Sub
                    Catch ex As Exception
                        ' MsgBox("11")
                        MessageBox.Show("Error: " + ex.Message, "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Success = False
                        ProgressBar1.Visible = False
                        lblStatus.Text = ""

                    End Try

                    If (Success) Then
                        intSuccessCount += 1
                        Try
                            File.Copy(TempPath, strDestFolderPath & objFile.Name, True)
                            'FASTFACTS-467 start
                            If chkArchive.Checked Then
                                File.Move(strPdfPath & "\" & objFile.Name, strArchievePath & "\" & objFile.Name)
                            End If

                            'FASTFACTS-467 end 
                        Catch ex As Exception
                            MessageBox.Show("Please Close the " & objFile.Name & " Pdf and then try again to sign this document.", "Digital Signature")
                        End Try

                    End If
                    ' Deleting the temporary file
                    File.Delete(TempPath)
                    intI = intI + 1
                    lblNoEmployee.Text = "Number of files Processed: " & intI
                    '--Me.Close()
                    'Exit For
                End If
                ' if encryption process succeeded, moving the temporary file to the place
                ' of destination file
                If (Success) = False Then
                    intErrCount += 1
                    'MessageBox.Show("Signing failed", "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Application.DoEvents()
            Next
            objWriter.Close()
            objWriter1.Close()

            If Not blnNotify Then
                If intNotSigned > 0 Then
                    MsgBox("Control No. not updated for some files" & vbNewLine & " See Error.txt for details.")
                End If
                If intAlreadySigned > 0 Then
                    MsgBox("Some files are already Signed, Latest Control No. considered." & vbNewLine & " See AlreadySigned.txt for details.", MsgBoxStyle.OkOnly)
                End If
            End If

            ProgressBar1.Visible = False
            tbCertPassword.Text = ""
            tbCert.Text = ""
            cbSystemCerts.SelectedIndex = -1
        End If



        If (Success) Then
            lblStatus.Text = ""
            MessageBox.Show("Signing process completed successfully" & vbNewLine & " Signed Files: " & intSuccessCount & vbNewLine & " Failed to sign: " & intNotSigned, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub

    'abhay Start
    Private Sub SaveUserSettings()
        If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then
            Dim dtcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")
            'FASTFACTS-467 start
            'Dim dtcmd As New OleDbCommand("update UserSettings set PrintCertOn=@PrintCertOn,PrintCertAt=@PrintCertAt,H= @H,V=@V,Font=@Font,Signer=@Signer,Author=@Author  where id ='1'", dtcon)
            Dim dtcmd As New OleDbCommand("update UserSettings set PrintCertOn=@PrintCertOn,PrintCertAt=@PrintCertAt,H= @H,V=@V,Font=@Font,Signer=@Signer,Author=@Author,Archieve=@Archieve  where id ='1'", dtcon)
            'FASTFACTS-467 end 
            Try

                dtcmd.Parameters.Add(New OleDbParameter("@PrintCertOn", AddQuotes(cbPrintOn.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@PrintCertAt", AddQuotes(cbPosition.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@H", AddQuotes(txtX.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@V", AddQuotes(txtY.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@Font", AddQuotes(cbFont.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@Signer", AddQuotes(txtSignersName.Text)))
                dtcmd.Parameters.Add(New OleDbParameter("@Author", AddQuotes(tbAuthor.Text)))
                Dim strArchieve As String
                'FASTFACTS-467 start
                strArchieve = False
                If chkArchive.Checked Then
                    strArchieve = True
                Else
                    strArchieve = False
                End If
                dtcmd.Parameters.Add(New OleDbParameter("@Archieve", AddQuotes(strArchieve)))
                'FASTFACTS-467 end 

                dtcon.Open()
                dtcmd.ExecuteNonQuery()
            Catch exath As System.Security.SecurityException
                MessageBox.Show("Not enough permissions to directory")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                dtcmd.Dispose() ' 'FASTFACTS-467 start
                dtcon.Close()
            End Try
        End If
    End Sub
    Private Sub GetUserSettings()

        If File.Exists(Application.StartupPath & "\DigitalSignatureLog.mdb") Then
            Dim dtcon As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;data source=" & Application.StartupPath & "\DigitalSignatureLog.mdb; Jet Oledb:Database Password=Ffcs")

            Dim dtcmd As New OleDbCommand("select * from UserSettings  where id ='1'", dtcon)

            Try
                dtcon.Open()
                Dim dr As OleDbDataReader = dtcmd.ExecuteReader()
                dr.Read()
                cbPrintOn.Text = RemoveQuotes(dr("PrintCertOn").ToString())
                cbPosition.Text = RemoveQuotes(dr("PrintCertAt").ToString())
                txtX.Text = RemoveQuotes(dr("H").ToString())
                txtY.Text = RemoveQuotes(dr("V").ToString())
                cbFont.Text = RemoveQuotes(dr("Font").ToString())
                txtSignersName.Text = RemoveQuotes(dr("Signer").ToString())
                tbAuthor.Text = RemoveQuotes(dr("Author").ToString())
                'FASTFACTS-467 start
                If RemoveQuotes(dr("Archieve").ToString()) = "True" Then
                    chkArchive.Checked = True
                Else
                    chkArchive.Checked = False
                End If
                'FASTFACTS-467 end 
            Catch exath As System.Security.SecurityException
                MessageBox.Show("Not enough permissions to directory")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                dtcon.Close()
            End Try

        End If
    End Sub
    Private Function RemoveQuotes(ByRef str As String) As String
        Return str.Replace("''", "'")
    End Function
    Private Function AddQuotes(ByRef str As String) As String
        Return str.Replace("'", "''")
    End Function
    'abhay end

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.Close()
        Dim mform As New frmOptions
        mform.Show()
        Me.Hide()
    End Sub

    Private Sub btnFindFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindFiles.Click
        '--Dim strSource As String = strSourceFolderPath
        '--Dim strDestination As String = strDestFolderPath
        Try
            Process.Start(strDestFolderPath)
        Catch ex As Exception
            MessageBox.Show("Signed Files Not Found", "Digital Signature")
            Exit Sub
        End Try

    End Sub

    Private Sub cbPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPosition.SelectedIndexChanged
        If cbPosition.Text = "Bottom Right" Then
            txtY.Text = 50
            txtX.Text = 450
        ElseIf cbPosition.Text = "Top Left " Then
            txtY.Text = 750
            txtX.Text = 5
        ElseIf cbPosition.Text = "Bottom Left" Then
            txtY.Text = 50
            txtX.Text = 50
        Else
            txtY.Text = 750
            txtX.Text = 500
        End If
    End Sub

    Private Sub btnBrowseCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCert.Click
        If (openDialogCert.ShowDialog() = Windows.Forms.DialogResult.OK) Then tbCert.Text = openDialogCert.FileName
    End Sub

    Private Sub rbUseCertFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUseCertFile.CheckedChanged
        cbSystemCerts.SelectedIndex = -1
        btnBrowseCert.Enabled = rbUseCertFile.Checked
        tbCert.Enabled = rbUseCertFile.Checked
        tbCertPassword.Enabled = rbUseCertFile.Checked
    End Sub

    Private Sub rbUseSystemCert_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUseSystemCert.CheckedChanged
        tbCert.Text = String.Empty
        tbCertPassword.Text = String.Empty
        cbSystemCerts.Enabled = rbUseSystemCert.Checked
    End Sub

    'Ashish Start for Custom Sign
    Private Sub cmbTypical_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTypical.CheckedChanged
        If cmbTypical.Checked = True Then
            blnCustom = False
        Else
            blnCustom = True
        End If

    End Sub
    'Ashish End for Custom Sign

    'Ashish Start for Custom Sign
    Private Sub cmbCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustom.CheckedChanged
        If cmbCustom.Checked = True Then
            blnCustom = True
        Else
            blnCustom = False
        End If
    End Sub
    'Ashish End for Custom Sign

    'Ashish Start for Custom Sign
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        grpSignPic.Visible = False
        picSign.ImageLocation = ""
    End Sub
    'Ashish End for Custom Sign


    'Ashish Start for Custom Sign
    Private Sub lnkOption2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOption2.LinkClicked
        grpSignPic.Visible = True
        picSign.ImageLocation = Application.StartupPath & "\New.png"
    End Sub
    'Ashish end for Custom Sign


    'Ashish Start for Custom Sign
    Private Sub lnkOption1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOption1.LinkClicked
        grpSignPic.Visible = True
        picSign.ImageLocation = Application.StartupPath & "\OLD.png"
    End Sub
    'Ashish end for Custom Sign
    'Ver 1.7-E387  start
    Public Function Decrypt(ByVal OutPutTxt As String) As String
        Dim ctr As Double
        Dim Decrypt1 As String = ""
        For ctr = Len(OutPutTxt) To 1 Step -1
            Decrypt1 = Decrypt1 & Chr(Asc(Mid(OutPutTxt, ctr, 1)) - (30))
        Next ctr
        Return Decrypt1
    End Function
    'Ver 1.7-E387  end
    'Ver 1.7-E387  start
    Public Function Encrypt(ByVal InputTxt As String) As String
        Dim Encrypt1 As String = ""
        Dim ctr As Double
        For ctr = Len(InputTxt) To 1 Step -1
            Encrypt1 = Encrypt1 & Chr(Asc(Mid(InputTxt, ctr, 1)) + (30))
        Next ctr
        Return Encrypt1
    End Function
    'Ver 1.7-E387 end    
    Private Sub ttReasonforsig_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttReasonforsig.MouseEnter
        Dim t As New ToolTip()
        t.IsBalloon = True
        t.SetToolTip(ttReasonforsig, "The sentence is displayed in Digital Signer properties , it is to Certify / Authenticate of document")
    End Sub

End Class
