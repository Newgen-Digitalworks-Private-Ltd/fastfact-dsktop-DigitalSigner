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
Imports iTextSharpSign

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
    Friend WithEvents cbPosition As System.Windows.Forms.ComboBox
    Friend WithEvents lblPos As System.Windows.Forms.Label
    Friend WithEvents cbPrintOn As System.Windows.Forms.ComboBox
    Friend WithEvents lblPage As System.Windows.Forms.Label
    Friend WithEvents cbFont As System.Windows.Forms.ComboBox
    Friend WithEvents lFont As System.Windows.Forms.Label
    Friend WithEvents cbReason As System.Windows.Forms.ComboBox
    Friend WithEvents lReason As System.Windows.Forms.Label
    Friend WithEvents tbAuthor As System.Windows.Forms.TextBox
    Friend WithEvents lAuthor As System.Windows.Forms.Label
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnFindFiles As System.Windows.Forms.Button
    Friend WithEvents lblDongle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents txtSignersName As System.Windows.Forms.TextBox
    Friend WithEvents lblAuthorsName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkHideBackground As System.Windows.Forms.CheckBox
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
    Friend WithEvents chkPwdProtect As System.Windows.Forms.CheckBox
    Friend WithEvents lblRotation As System.Windows.Forms.Label
    Friend WithEvents cmbRotation As System.Windows.Forms.ComboBox
    Friend WithEvents chkArchive As System.Windows.Forms.CheckBox

    'Ashish start for Custom Sign
    Public blnCustom As Boolean
    Private oForm1 As New Form1
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TLP1 As TableLayoutPanel
    Friend WithEvents TLP2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbforms As ComboBox
    Friend WithEvents chkvalidsymbol As CheckBox
    Private autopos As Boolean = False
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

        'RefreshSystemCertificates()
        oForm1.LoadCertificates(cbSystemCerts)
        If File.Exists(Path.Combine(Application.StartupPath, "autopos.txt")) Then
            autopos = True
            cbPosition.Enabled = False
        Else
            autopos = False
            cbPosition.Enabled = True
        End If
        'SecureBlackbox Signatures initialization
        Signatures = New ArrayList
        FillForms() : cmbforms.Enabled = autopos
    End Sub
    Private Function FillForms() As Boolean
        Try
            Dim dt As New DataTable
            dt.Columns.Add("Name", GetType(String)).DefaultValue = String.Empty
            dt.Columns.Add("Value", GetType(String)).DefaultValue = String.Empty

            dt.Rows.Add("Wizard_Form_27D", "20,5,170,55")
            dt.Rows.Add("Wizard_Form_12BA", "20,5,170,55")
            dt.Rows.Add("Wizard_Form_16", "20,5,170,55")
            dt.Rows.Add("Wizard_Form_27D_partB", "20,5,170,55")

            dt.Rows.Add("Form_16_1st_Page", "370,170,520,220")

            dt.Rows.Add("TdsPac_Access_16A", "20,5,170,55")
            dt.Rows.Add("TdsPac_Access_26Q", "20,5,170,55")

            dt.Rows.Add("Traces_Form16A_1st_Page", "350,240,500,290")
            dt.Rows.Add("Traces_Form_16_PartA", "20,5,170,55")
            dt.Rows.Add("Traces_Form_16_PartB", "20,5,170,55")
            dt.Rows.Add("Traces_Form_16A", "20,5,170,55")

            cmbforms.DataSource = Nothing : cmbforms.DataSource = dt
            cmbforms.DisplayMember = "Name" : cmbforms.ValueMember = "Value"

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
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
        Me.chkArchive = New System.Windows.Forms.CheckBox()
        Me.lblRotation = New System.Windows.Forms.Label()
        Me.cmbRotation = New System.Windows.Forms.ComboBox()
        Me.lnkOption2 = New System.Windows.Forms.LinkLabel()
        Me.lnkOption1 = New System.Windows.Forms.LinkLabel()
        Me.cmbCustom = New System.Windows.Forms.RadioButton()
        Me.cmbTypical = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkHideBackground = New System.Windows.Forms.CheckBox()
        Me.cbSystemCerts = New System.Windows.Forms.ComboBox()
        Me.rbUseSystemCert = New System.Windows.Forms.RadioButton()
        Me.btnBrowseCert = New System.Windows.Forms.Button()
        Me.tbCertPassword = New System.Windows.Forms.TextBox()
        Me.tbCert = New System.Windows.Forms.TextBox()
        Me.lCertPassword = New System.Windows.Forms.Label()
        Me.rbUseCertFile = New System.Windows.Forms.RadioButton()
        Me.txtSignersName = New System.Windows.Forms.TextBox()
        Me.lblAuthorsName = New System.Windows.Forms.Label()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.chkPwdProtect = New System.Windows.Forms.CheckBox()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnFindFiles = New System.Windows.Forms.Button()
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TLP2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbforms = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkvalidsymbol = New System.Windows.Forms.CheckBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TLP1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TLP2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TLP1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
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
        Me.lblDestination.Size = New System.Drawing.Size(0, 14)
        Me.lblDestination.TabIndex = 19
        '
        'TElSBLicenseManager1
        '
        Me.TElSBLicenseManager1.LicenseKey = ""
        Me.TElSBLicenseManager1.LicenseKeyFile = ""
        Me.TElSBLicenseManager1.RegistryKey = Nothing
        Me.TElSBLicenseManager1.Tag = Nothing
        '
        'chkArchive
        '
        Me.chkArchive.Location = New System.Drawing.Point(273, 172)
        Me.chkArchive.Name = "chkArchive"
        Me.chkArchive.Size = New System.Drawing.Size(102, 32)
        Me.chkArchive.TabIndex = 78
        Me.chkArchive.Text = "Archive Unsigned PDF Files"
        Me.chkArchive.UseVisualStyleBackColor = True
        '
        'lblRotation
        '
        Me.lblRotation.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRotation.AutoSize = True
        Me.lblRotation.Location = New System.Drawing.Point(3, 182)
        Me.lblRotation.Name = "lblRotation"
        Me.lblRotation.Size = New System.Drawing.Size(113, 14)
        Me.lblRotation.TabIndex = 76
        Me.lblRotation.Text = "Signature Rotation"
        '
        'cmbRotation
        '
        Me.cmbRotation.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRotation.FormattingEnabled = True
        Me.cmbRotation.Items.AddRange(New Object() {"90", "180", "270", "360"})
        Me.cmbRotation.Location = New System.Drawing.Point(122, 178)
        Me.cmbRotation.Name = "cmbRotation"
        Me.cmbRotation.Size = New System.Drawing.Size(145, 22)
        Me.cmbRotation.TabIndex = 75
        '
        'lnkOption2
        '
        Me.lnkOption2.AutoSize = True
        Me.lnkOption2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lnkOption2.Location = New System.Drawing.Point(36, 15)
        Me.lnkOption2.Name = "lnkOption2"
        Me.lnkOption2.Size = New System.Drawing.Size(32, 16)
        Me.lnkOption2.TabIndex = 68
        Me.lnkOption2.TabStop = True
        Me.lnkOption2.Text = "Click for Sample Sign"
        '
        'lnkOption1
        '
        Me.lnkOption1.AutoSize = True
        Me.lnkOption1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lnkOption1.Location = New System.Drawing.Point(3, 15)
        Me.lnkOption1.Name = "lnkOption1"
        Me.lnkOption1.Size = New System.Drawing.Size(24, 16)
        Me.lnkOption1.TabIndex = 67
        Me.lnkOption1.TabStop = True
        Me.lnkOption1.Text = "Click for Sample Sign"
        '
        'cmbCustom
        '
        Me.cmbCustom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbCustom.AutoSize = True
        Me.cmbCustom.Location = New System.Drawing.Point(36, 3)
        Me.cmbCustom.Name = "cmbCustom"
        Me.cmbCustom.Size = New System.Drawing.Size(33, 9)
        Me.cmbCustom.TabIndex = 66
        Me.cmbCustom.Text = "Option2"
        Me.cmbCustom.UseVisualStyleBackColor = True
        '
        'cmbTypical
        '
        Me.cmbTypical.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbTypical.AutoSize = True
        Me.cmbTypical.Checked = True
        Me.cmbTypical.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmbTypical.Location = New System.Drawing.Point(3, 3)
        Me.cmbTypical.Name = "cmbTypical"
        Me.cmbTypical.Size = New System.Drawing.Size(27, 9)
        Me.cmbTypical.TabIndex = 65
        Me.cmbTypical.TabStop = True
        Me.cmbTypical.Text = "Option1"
        Me.cmbTypical.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 15)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Signature Style"
        '
        'chkHideBackground
        '
        Me.chkHideBackground.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkHideBackground.AutoSize = True
        Me.chkHideBackground.Checked = True
        Me.chkHideBackground.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideBackground.Location = New System.Drawing.Point(381, 14)
        Me.chkHideBackground.Name = "chkHideBackground"
        Me.chkHideBackground.Size = New System.Drawing.Size(5, 18)
        Me.chkHideBackground.TabIndex = 10
        Me.chkHideBackground.Text = "Hide Background Icon"
        Me.chkHideBackground.UseVisualStyleBackColor = True
        Me.chkHideBackground.Visible = False
        '
        'cbSystemCerts
        '
        Me.cbSystemCerts.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TLP1.SetColumnSpan(Me.cbSystemCerts, 2)
        Me.cbSystemCerts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSystemCerts.Enabled = False
        Me.cbSystemCerts.Location = New System.Drawing.Point(3, 46)
        Me.cbSystemCerts.Name = "cbSystemCerts"
        Me.cbSystemCerts.Size = New System.Drawing.Size(595, 22)
        Me.cbSystemCerts.TabIndex = 5
        '
        'rbUseSystemCert
        '
        Me.rbUseSystemCert.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbUseSystemCert.Location = New System.Drawing.Point(236, 7)
        Me.rbUseSystemCert.Name = "rbUseSystemCert"
        Me.rbUseSystemCert.Size = New System.Drawing.Size(241, 24)
        Me.rbUseSystemCert.TabIndex = 4
        Me.rbUseSystemCert.Text = "Certificate from system certificate store:"
        '
        'btnBrowseCert
        '
        Me.btnBrowseCert.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBrowseCert.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowseCert.BackgroundImage = CType(resources.GetObject("btnBrowseCert.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowseCert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBrowseCert.Location = New System.Drawing.Point(612, 79)
        Me.btnBrowseCert.Name = "btnBrowseCert"
        Me.btnBrowseCert.Size = New System.Drawing.Size(86, 34)
        Me.btnBrowseCert.TabIndex = 2
        Me.btnBrowseCert.Text = "Browse..."
        Me.btnBrowseCert.UseVisualStyleBackColor = False
        '
        'tbCertPassword
        '
        Me.tbCertPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCertPassword.Location = New System.Drawing.Point(3, 123)
        Me.tbCertPassword.Name = "tbCertPassword"
        Me.tbCertPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbCertPassword.Size = New System.Drawing.Size(227, 22)
        Me.tbCertPassword.TabIndex = 3
        '
        'tbCert
        '
        Me.tbCert.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TLP1.SetColumnSpan(Me.tbCert, 2)
        Me.tbCert.Location = New System.Drawing.Point(3, 85)
        Me.tbCert.Name = "tbCert"
        Me.tbCert.Size = New System.Drawing.Size(595, 22)
        Me.tbCert.TabIndex = 1
        '
        'lCertPassword
        '
        Me.lCertPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lCertPassword.Location = New System.Drawing.Point(236, 126)
        Me.lCertPassword.Name = "lCertPassword"
        Me.lCertPassword.Size = New System.Drawing.Size(151, 16)
        Me.lCertPassword.TabIndex = 8
        Me.lCertPassword.Text = "Enter password"
        '
        'rbUseCertFile
        '
        Me.rbUseCertFile.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.rbUseCertFile.Checked = True
        Me.rbUseCertFile.Location = New System.Drawing.Point(3, 7)
        Me.rbUseCertFile.Name = "rbUseCertFile"
        Me.rbUseCertFile.Size = New System.Drawing.Size(175, 24)
        Me.rbUseCertFile.TabIndex = 0
        Me.rbUseCertFile.TabStop = True
        Me.rbUseCertFile.Text = "Certificate from file:"
        '
        'txtSignersName
        '
        Me.txtSignersName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSignersName.BackColor = System.Drawing.SystemColors.Window
        Me.txtSignersName.Location = New System.Drawing.Point(3, 32)
        Me.txtSignersName.Name = "txtSignersName"
        Me.txtSignersName.Size = New System.Drawing.Size(292, 22)
        Me.txtSignersName.TabIndex = 12
        '
        'lblAuthorsName
        '
        Me.lblAuthorsName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAuthorsName.Location = New System.Drawing.Point(3, 71)
        Me.lblAuthorsName.Name = "lblAuthorsName"
        Me.lblAuthorsName.Size = New System.Drawing.Size(292, 16)
        Me.lblAuthorsName.TabIndex = 55
        Me.lblAuthorsName.Text = "Author's Name"
        '
        'cbPosition
        '
        Me.cbPosition.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPosition.Items.AddRange(New Object() {"Top Left ", "Top Right", "Bottom Left", "Bottom Right"})
        Me.cbPosition.Location = New System.Drawing.Point(122, 94)
        Me.cbPosition.Name = "cbPosition"
        Me.cbPosition.Size = New System.Drawing.Size(145, 22)
        Me.cbPosition.TabIndex = 7
        '
        'lblPos
        '
        Me.lblPos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPos.AutoSize = True
        Me.lblPos.Location = New System.Drawing.Point(3, 97)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(113, 14)
        Me.lblPos.TabIndex = 22
        Me.lblPos.Text = "Print Signature at"
        '
        'cbPrintOn
        '
        Me.cbPrintOn.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbPrintOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrintOn.Items.AddRange(New Object() {"Last Page", "First Page", "Each Page"})
        Me.cbPrintOn.Location = New System.Drawing.Point(122, 13)
        Me.cbPrintOn.Name = "cbPrintOn"
        Me.cbPrintOn.Size = New System.Drawing.Size(145, 22)
        Me.cbPrintOn.TabIndex = 6
        '
        'lblPage
        '
        Me.lblPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPage.AutoSize = True
        Me.lblPage.Location = New System.Drawing.Point(3, 16)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(113, 14)
        Me.lblPage.TabIndex = 20
        Me.lblPage.Text = "Print Signature On"
        '
        'cbFont
        '
        Me.cbFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFont.Items.AddRange(New Object() {"Helvetica", "Times-Roman", "Courier"})
        Me.cbFont.Location = New System.Drawing.Point(122, 56)
        Me.cbFont.Name = "cbFont"
        Me.cbFont.Size = New System.Drawing.Size(145, 22)
        Me.cbFont.TabIndex = 11
        '
        'lFont
        '
        Me.lFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lFont.AutoSize = True
        Me.lFont.Location = New System.Drawing.Point(3, 59)
        Me.lFont.Name = "lFont"
        Me.lFont.Size = New System.Drawing.Size(113, 14)
        Me.lFont.TabIndex = 18
        Me.lFont.Text = "Font:"
        '
        'cbReason
        '
        Me.cbReason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbReason.Items.AddRange(New Object() {"I am the author of this document", "I agree to the terms defined by placement of my signature on this document", "I have reviewed this document", "I attest to the accuracy and integrity of this document", "I am approving this document", "Control No. will be updated"})
        Me.cbReason.Location = New System.Drawing.Point(3, 148)
        Me.cbReason.Name = "cbReason"
        Me.cbReason.Size = New System.Drawing.Size(292, 22)
        Me.cbReason.TabIndex = 14
        Me.cbReason.Text = "<none>"
        '
        'lReason
        '
        Me.lReason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lReason.Location = New System.Drawing.Point(3, 125)
        Me.lReason.Name = "lReason"
        Me.lReason.Size = New System.Drawing.Size(292, 20)
        Me.lReason.TabIndex = 9
        Me.lReason.Text = "Reason for signing:"
        '
        'tbAuthor
        '
        Me.tbAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAuthor.Location = New System.Drawing.Point(3, 90)
        Me.tbAuthor.Name = "tbAuthor"
        Me.tbAuthor.Size = New System.Drawing.Size(292, 22)
        Me.tbAuthor.TabIndex = 13
        '
        'lAuthor
        '
        Me.lAuthor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lAuthor.Location = New System.Drawing.Point(3, 13)
        Me.lAuthor.Name = "lAuthor"
        Me.lAuthor.Size = New System.Drawing.Size(292, 16)
        Me.lAuthor.TabIndex = 7
        Me.lAuthor.Text = "Signer's Name"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(518, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 14)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Vertical"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(326, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Horizontal"
        Me.Label2.Visible = False
        '
        'txtY
        '
        Me.txtY.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtY.Location = New System.Drawing.Point(610, 62)
        Me.txtY.MaxLength = 3
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(88, 22)
        Me.txtY.TabIndex = 9
        Me.txtY.Text = "50"
        Me.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtY.Visible = False
        '
        'txtX
        '
        Me.txtX.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtX.Location = New System.Drawing.Point(427, 62)
        Me.txtX.MaxLength = 3
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(85, 22)
        Me.txtX.TabIndex = 8
        Me.txtX.Text = "450"
        Me.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtX.Visible = False
        '
        'chkPwdProtect
        '
        Me.chkPwdProtect.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkPwdProtect.Location = New System.Drawing.Point(273, 7)
        Me.chkPwdProtect.Name = "chkPwdProtect"
        Me.chkPwdProtect.Size = New System.Drawing.Size(102, 32)
        Me.chkPwdProtect.TabIndex = 73
        Me.chkPwdProtect.Text = "Password Protection"
        Me.chkPwdProtect.UseVisualStyleBackColor = True
        Me.chkPwdProtect.Visible = False
        '
        'btnSign
        '
        Me.btnSign.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnSign.BackColor = System.Drawing.Color.Transparent
        Me.btnSign.BackgroundImage = CType(resources.GetObject("btnSign.BackgroundImage"), System.Drawing.Image)
        Me.btnSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSign.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSign.Location = New System.Drawing.Point(427, 10)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(85, 34)
        Me.btnSign.TabIndex = 16
        Me.btnSign.Text = "&Start Signing"
        Me.btnSign.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(612, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "E&xit"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBack.Location = New System.Drawing.Point(335, 10)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(86, 34)
        Me.btnBack.TabIndex = 15
        Me.btnBack.Text = "<<&Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 602)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(709, 3)
        Me.ProgressBar1.TabIndex = 50
        Me.ProgressBar1.Visible = False
        '
        'btnFindFiles
        '
        Me.btnFindFiles.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnFindFiles.BackColor = System.Drawing.Color.Transparent
        Me.btnFindFiles.BackgroundImage = CType(resources.GetObject("btnFindFiles.BackgroundImage"), System.Drawing.Image)
        Me.btnFindFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnFindFiles.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnFindFiles.Location = New System.Drawing.Point(518, 9)
        Me.btnFindFiles.Name = "btnFindFiles"
        Me.btnFindFiles.Size = New System.Drawing.Size(86, 36)
        Me.btnFindFiles.TabIndex = 17
        Me.btnFindFiles.Text = "Find Pdfs Fi&les"
        Me.btnFindFiles.UseVisualStyleBackColor = False
        '
        'lblDongle
        '
        Me.lblDongle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(3, 66)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(317, 15)
        Me.lblDongle.TabIndex = 56
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(3, 19)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(317, 15)
        Me.lblVersion.TabIndex = 55
        Me.lblVersion.Text = " Version"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.9302326!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 99.06977!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ProgressBar1, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.335559!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.66444!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(734, 608)
        Me.TableLayoutPanel1.TabIndex = 57
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TLP2, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel3, 0, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(9, 11)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.27615!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.26556!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.53942!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(709, 585)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TLP2
        '
        Me.TLP2.ColumnCount = 2
        Me.TLP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.48148!))
        Me.TLP2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.51852!))
        Me.TLP2.Controls.Add(Me.Panel4, 0, 0)
        Me.TLP2.Controls.Add(Me.Panel5, 1, 0)
        Me.TLP2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP2.Location = New System.Drawing.Point(3, 264)
        Me.TLP2.Name = "TLP2"
        Me.TLP2.RowCount = 1
        Me.TLP2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLP2.Size = New System.Drawing.Size(703, 217)
        Me.TLP2.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TableLayoutPanel6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(391, 211)
        Me.Panel4.TabIndex = 1
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel6.ColumnCount = 4
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.69054!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.87468!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.87724!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.061856!))
        Me.TableLayoutPanel6.Controls.Add(Me.lblPage, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cmbforms, 1, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.cbPrintOn, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.cmbRotation, 1, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.lblRotation, 0, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.lFont, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.cbFont, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.lblPos, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.cbPosition, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.chkArchive, 2, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.chkHideBackground, 3, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.chkPwdProtect, 2, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel8, 2, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.chkvalidsymbol, 2, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 5
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.59615!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.75!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.78846!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.11539!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.26923!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(389, 209)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'cmbforms
        '
        Me.cmbforms.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbforms.FormattingEnabled = True
        Me.cmbforms.Location = New System.Drawing.Point(122, 135)
        Me.cmbforms.Name = "cmbforms"
        Me.cmbforms.Size = New System.Drawing.Size(145, 22)
        Me.cmbforms.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 14)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Select Form : "
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.66038!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.33962!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.cmbTypical, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.cmbCustom, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.lnkOption1, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.lnkOption2, 1, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(273, 89)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(102, 31)
        Me.TableLayoutPanel8.TabIndex = 65
        Me.TableLayoutPanel8.Visible = False
        '
        'chkvalidsymbol
        '
        Me.chkvalidsymbol.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkvalidsymbol.Checked = True
        Me.chkvalidsymbol.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkvalidsymbol.Location = New System.Drawing.Point(273, 50)
        Me.chkvalidsymbol.Name = "chkvalidsymbol"
        Me.chkvalidsymbol.Size = New System.Drawing.Size(102, 32)
        Me.chkvalidsymbol.TabIndex = 73
        Me.chkvalidsymbol.Text = "Required Valid Symbol"
        Me.chkvalidsymbol.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.TableLayoutPanel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(400, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(300, 211)
        Me.Panel5.TabIndex = 2
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.lAuthor, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.txtSignersName, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.lblAuthorsName, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.tbAuthor, 0, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.lReason, 0, 4)
        Me.TableLayoutPanel7.Controls.Add(Me.cbReason, 0, 5)
        Me.TableLayoutPanel7.Controls.Add(Me.Label5, 0, 6)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 7
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(298, 209)
        Me.TableLayoutPanel7.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(3, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(292, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "The sentence is displayed in Digital "
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(703, 95)
        Me.Panel1.TabIndex = 6
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.DG2
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(701, 93)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TLP1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(703, 154)
        Me.Panel2.TabIndex = 7
        '
        'TLP1
        '
        Me.TLP1.BackColor = System.Drawing.Color.White
        Me.TLP1.ColumnCount = 3
        Me.TLP1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.61905!))
        Me.TLP1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.16667!))
        Me.TLP1.Controls.Add(Me.rbUseCertFile, 0, 0)
        Me.TLP1.Controls.Add(Me.lCertPassword, 1, 3)
        Me.TLP1.Controls.Add(Me.tbCertPassword, 0, 3)
        Me.TLP1.Controls.Add(Me.rbUseSystemCert, 1, 0)
        Me.TLP1.Controls.Add(Me.tbCert, 0, 2)
        Me.TLP1.Controls.Add(Me.btnBrowseCert, 2, 2)
        Me.TLP1.Controls.Add(Me.cbSystemCerts, 0, 1)
        Me.TLP1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLP1.Location = New System.Drawing.Point(0, 0)
        Me.TLP1.Name = "TLP1"
        Me.TLP1.RowCount = 4
        Me.TLP1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TLP1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579!))
        Me.TLP1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.68421!))
        Me.TLP1.Size = New System.Drawing.Size(701, 152)
        Me.TLP1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 487)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(703, 95)
        Me.Panel3.TabIndex = 8
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.16477!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.46809!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04965!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.19149!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.04965!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancel, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnFindFiles, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBack, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnSign, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtY, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDongle, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtX, 2, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.01639!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.98361!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(701, 93)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnSign
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(734, 608)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblDestination)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Options to Sign"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TLP2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TLP1.ResumeLayout(False)
        Me.TLP1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
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


        'gbSigProps.Enabled = Not DemoVersion
        TLP1.Enabled = Not DemoVersion
        TLP2.Enabled = Not DemoVersion

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

        SaveUserSettings()
        If blnGenerateControlNo Then
            Dim MainControlDirectory As New DirectoryInfo(strPdfPath)
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
                'lblStatus.Text = "Signing " & objFile.Name.ToString
                Application.DoEvents()
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
                    Try
                        'TempPath = Path.GetTempFileName()
                        If objFile.IsReadOnly Then
                            MessageBox.Show("Please Close the " & objFile.Name & " Pdf and then try again.", "Digital Signature")
                            Exit Sub
                        End If
                        'System.IO.File.Copy(objFile.FullName, TempPath, True)
                        Success = False

                        'F = New FileStream(TempPath, FileMode.Open, FileAccess.ReadWrite)
                        Try
                            'Document = New TElPDFDocument
                            'Document.Open(F)

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
                                        If Mid(objFile.Name.ToUpper, 1, objFile.Name.Length - 4) = (dr1.Item(2).ToString().ToUpper) Then
                                            strPwd = dr1.Item(3).ToString()
                                            Exit Do
                                        End If
                                    Loop

                                    dr1.Close()
                                    conExcel1.Close()

                                    'If chkPwdProtect.Checked = True And strPwd <> "" Then
                                    '    encryption = New TElPDFPasswordSecurityHandler
                                    '    Document.EncryptionHandler = encryption
                                    '    encryption.OwnerPassword = Decrypt(strPwd.ToString) '"1234"
                                    '    encryption.UserPassword = strPwd.ToString '"10101" ' "4321"
                                    '    encryption.StreamEncryptionAlgorithm = SBConstants.Unit.SB_ALGORITHM_CNT_RC4
                                    '    encryption.StreamEncryptionKeyBits = 128
                                    '    encryption.StringEncryptionAlgorithm = encryption.StreamEncryptionAlgorithm
                                    '    encryption.StringEncryptionKeyBits = encryption.StreamEncryptionKeyBits
                                    '    Document.Encrypt()
                                    '    Document.Close(True)
                                    '    Document.Open(F)
                                    '    Dim x As TElPDFPasswordSecurityHandler = New TElPDFPasswordSecurityHandler
                                    '    Document.EncryptionHandler = x
                                    '    x.OwnerPassword = Decrypt(strPwd.ToString) '"1234"
                                    '    x.UserPassword = "10101"
                                    '    Document.DecryptionMode = SBPDF.Unit.dmSign
                                    '    Document.Decrypt()
                                    'End If

                                End If
                            End If

                            Dim blnSign As Boolean = SetSignProperty()
                            If Not blnSign Then
                                objWriter.Close()
                                objWriter1.Close()
                                Exit Sub
                            End If
                            Success = oForm1.SysSignCertificates(cbSystemCerts.SelectedIndex, Path.Combine(strPdfPath, objFile.Name),
                                                                 Path.Combine(strDestFolderPath, objFile.Name), IIf(chkvalidsymbol.Checked, False, True))

                            '__Bhaskaran  : 17may21
                            '__secureblackbox stop
                            'Try
                            '    If (Document.Encrypted) Then
                            '        MessageBox.Show("The document is encrypted and cannot be signed", "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '        Return
                            '    End If
                            '    Dim intPageCount As Integer = Document.PageInfoCount
                            '    index = Document.AddSignature()
                            '    Sig = Document.Signatures(index)
                            '    Sig.Handler = PublicKeyHandler
                            '    Sig.AuthorName = tbAuthor.Text
                            '    Sig.SignatureName = txtSignersName.Text

                            '    Sig.MDPHashAlgorithm = TSBPDFSecurityHandlerEncryptionMethod.emUnknown

                            '    If chkHideBackground.Checked Then
                            '        Sig.WidgetProps.BackgroundStyle = TSBPDFWidgetBackgroundStyle.pbsNoBackground
                            '    End If


                            '    If blnCustom = True Then
                            '        Sig.WidgetProps.AutoText = False
                            '    Else
                            '        If txtSignersName.Text.Trim = String.Empty Then
                            '            Sig.WidgetProps.AutoText = True
                            '        Else
                            '            Sig.WidgetProps.AutoText = False
                            '        End If
                            '        Sig.WidgetProps.Header = txtSignersName.Text
                            '        Sig.WidgetProps.SignerCaption = tbAuthor.Text
                            '        Sig.WidgetProps.SignerInfo = Sig.WidgetProps.SignerInfo
                            '        Sig.SigningTime = DateTime.Now.ToUniversalTime()
                            '    End If
                            '    Sig.WidgetProps.AutoPos = False

                            '    If cbPrintOn.Text = "First Page" Then
                            '        Sig.WidgetProps.ShowOnAllPages = False
                            '    ElseIf cbPrintOn.Text = "Last Page" Then
                            '        Sig.WidgetProps.ShowOnAllPages = False
                            '        Sig.Page = intPageCount - 1
                            '    Else
                            '        Sig.WidgetProps.ShowOnAllPages = True
                            '    End If

                            '    Sig.WidgetProps.OffsetY = Val(txtY.Text)
                            '    Sig.WidgetProps.OffsetX = Val(txtX.Text)

                            '    If (String.Compare(cbReason.Text, "<none>") <> 0) Then
                            '        If cbReason.Text = "Control No. will be updated" Then
                            '            Sig.Reason = strControlNo.ToString
                            '            Sig.WidgetProps.AlgorithmCaption = "Control No.: " & strControlNo.ToString
                            '        Else
                            '            Sig.Reason = cbReason.Text
                            '            Sig.WidgetProps.AlgorithmCaption = cbReason.Text
                            '        End If
                            '    Else
                            '        Sig.Reason = ""
                            '    End If
                            '    Sig.Invisible = False
                            '    If (rbUseCertFile.Checked) Then
                            '        CertF = New FileStream(tbCert.Text, FileMode.Open)
                            '        Try
                            '            CertFormat = TElX509Certificate.DetectCertFileFormat(CertF)
                            '            CertF.Position = 0
                            '            Select Case (CertFormat)
                            '                Case SBX509.Unit.cfDER
                            '                    Cert.LoadFromStream(CertF, 0)
                            '                Case SBX509.Unit.cfPEM
                            '                    Cert.LoadFromStreamPEM(CertF, tbCertPassword.Text, 0)
                            '                Case SBX509.Unit.cfPFX
                            '                    Cert.LoadFromStreamPFX(CertF, tbCertPassword.Text, 0)
                            '                Case Else
                            '                    MessageBox.Show("Failed to load certificate", "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '                    Return
                            '            End Select
                            '        Finally
                            '            CertF.Close()
                            '        End Try
                            '    Else
                            '        Cert = SystemStore.Certificates(cbSystemCerts.SelectedIndex)
                            '    End If

                            '    If Not Sig.Invisible Then
                            '        If cbFont.Text = "Free Serif, Unicode" Then
                            '            AddTrueTypeFont("FreeSerif", Sig.WidgetProps)
                            '        Else
                            '            If (cbFont.Text = "") OrElse (cbFont.Text = "Helvetica") Then
                            '            Else
                            '                If cbFont.Text = "Helvetica, Win-1252" Then
                            '                    Dim SimpleFont As New TElPDFSimpleFont()
                            '                    SimpleFont.BaseFont = "Helvetica"
                            '                    Sig.WidgetProps.AddFont(SimpleFont)
                            '                    SimpleFont.EncodingObject = New TElPDFEncoding()
                            '                    Sig.WidgetProps.AddFontObject(SimpleFont.EncodingObject)
                            '                    SimpleFont.EncodingObject.BaseEncoding = "WinAnsiEncoding"
                            '                    AddHandler Sig.WidgetProps.OnConvertStringToAnsi, AddressOf UTF16ToWin1252
                            '                Else
                            '                    Dim SimpleFont As TElPDFSimpleFont = New TElPDFSimpleFont
                            '                    SimpleFont.BaseFont = cbFont.Text
                            '                    Sig.WidgetProps.AddFont(SimpleFont)
                            '                End If
                            '            End If
                            '        End If
                            '    End If

                            '    If blnCustom = True Then
                            '        Sig.WidgetProps.Header = ""
                            '        Sig.WidgetProps.SignerCaption = "   Digitally signed by"
                            '        Sig.WidgetProps.SignerInfo = "Name      : " & IIf(txtSignersName.Text = "", Cert.SubjectName.CommonName, txtSignersName.Text) & vbCrLf & "Date        : " & DateTime.Now() &
                            '            vbCrLf & "Reason   : " & Sig.Reason &
                            '            vbCrLf & IIf(Sig.AuthorName = "", "", "Author's Name : " & Sig.AuthorName) ''FASTFACTS-523                                    
                            '        Sig.WidgetProps.ShowTimestamp = False
                            '        Sig.WidgetProps.AlgorithmCaption = ""
                            '    Else
                            '        Sig.WidgetProps.SignerCaption = "Signer (" + Microsoft.VisualBasic.ChrW(8364) + ")" & "                                                            " & DateTime.Now()
                            '        Sig.WidgetProps.ShowTimestamp = False
                            '        If Sig.AuthorName <> "" Then
                            '            Sig.WidgetProps.AlgorithmInfo = "Author's Name : " & Sig.AuthorName
                            '        End If
                            '    End If
                            '    Sig.WidgetProps.AutoFontSize = False
                            '    Sig.WidgetProps.TitleFontSize = 7 '8.77
                            '    Sig.WidgetProps.SectionTitleFontSize = 6.5 '7
                            '    Sig.WidgetProps.SectionTextFontSize = 6.5 '5
                            '    Sig.WidgetProps.TimestampFontSize = 4.89
                            '    Sig.WidgetProps.AutoSize = False
                            '    Sig.WidgetProps.Width += 160 '20
                            '    Sig.WidgetProps.Height += 20
                            '    If cmbRotation.Text.ToString().Trim() <> "" Then
                            '        Sig.WidgetProps.Rotate = cmbRotation.Text
                            '    End If
                            '    CertStorage.Clear()
                            '    CertStorage.Add(Cert, True)
                            '    PublicKeyHandler.CertStorage = CertStorage
                            '    PublicKeyHandler.SignatureType = TSBPDFPublicKeySignatureType.pstPKCS7SHA1
                            '    If blnCustom = True Then
                            '        Dim t As TimeZone
                            '        Dim tm As Date
                            '        t = TimeZone.CurrentTimeZone
                            '        tm = t.ToUniversalTime(Date.Now)
                            '        Sig.SigningTime = tm
                            '        PublicKeyHandler.Certificates.Validate(Cert, 0, tm)
                            '    End If
                            '    PublicKeyHandler.CustomName = "Adobe.PPKMS"
                            '    If cbTimestamp.Checked Then
                            '        TSPClient.URL = tbTimestampServer.Text
                            '        TSPClient.HashAlgorithm = SBConstants.Unit.SB_ALGORITHM_DGST_SHA1
                            '        TSPClient.HTTPClient = HTTPClient
                            '        PublicKeyHandler.TSPClient = TSPClient
                            '    End If
                            '    Success = True
                            'Finally
                            '    Document.Close(Success)
                            '    blnSigned = True
                            'End Try
                            '__secureblackbox stop
                            '__Bhaskaran  : 17may21

                            'Success = True
                        Finally
                            'F.Close()
                            'F.Dispose()
                            'Document.Dispose()
                        End Try

                    Catch exep As EElPDFPublicKeySecurityHandlerError
                        MessageBox.Show("Error : " & exep.Message.ToString, "Digital Signature")
                        Success = False
                        ProgressBar1.Visible = False
                        'lblStatus.Text = ""
                        objWriter = Nothing
                        objWriter1 = Nothing
                        Exit Sub
                    Catch ex As Exception
                        MessageBox.Show("Error: " + ex.Message, "Digital Signature", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Success = False
                        ProgressBar1.Visible = False
                        'lblStatus.Text = ""
                    End Try

                    If (Success) Then
                        intSuccessCount += 1
                        Try
                            'File.Copy(TempPath, strDestFolderPath & objFile.Name, True)
                            If chkArchive.Checked Then
                                File.Move(strPdfPath & "\" & objFile.Name, strArchievePath & "\" & objFile.Name)
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Please Close the " & objFile.Name & " Pdf and then try again to sign this document.", "Digital Signature")
                        End Try
                    End If
                    'File.Delete(TempPath)
                    intI = intI + 1
                    'lblNoEmployee.Text = "Number of files Processed: " & intI
                End If

                If (Success) = False Then
                    intErrCount += 1
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
            'lblStatus.Text = ""
            MessageBox.Show("Signing process completed successfully" & vbNewLine & " Signed Files: " & intSuccessCount & vbNewLine & " Failed to sign: " & intNotSigned, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Function SetSignProperty() As Boolean
        Try
            '            //signatureAppearance.SetVisibleSignature(New iTextSharp.text.Rectangle(0, 700, 150, 750), 1, osignproperty.signname); //UL
            '//signatureAppearance.SetVisibleSignature(New iTextSharp.text.Rectangle(450, 700, 600, 750), 1, osignproperty.signname); //UR
            '//signatureAppearance.SetVisibleSignature(New iTextSharp.text.Rectangle(0, 0, 150, 50), 1, osignproperty.signname); //BL
            '//signatureAppearance.SetVisibleSignature(New iTextSharp.text.Rectangle(450, 0, 600, 50), 1, osignproperty.signname);//BR
            With oForm1.osignproperty
                .syscerti = rbUseSystemCert.Checked
                If .syscerti Then
                    .username = String.Empty : .pwd = String.Empty
                Else
                    .username = tbCert.Text.Trim : .pwd = tbCertPassword.Text.Trim
                End If
                .signpage = cbPrintOn.Text
                If autopos Then
                    'Dim objReader As New System.IO.StreamReader(Path.Combine(Application.StartupPath, "autopos.txt"))
                    'Do While objReader.Peek() <> -1
                    '    Dim TextLine As String = objReader.ReadLine()
                    '    Dim SplitLine As String() = Split(TextLine, ",")
                    '    If SplitLine.Length <> 4 Then
                    '        Dim strsql As String = "Invalid Sign Posistion Format"
                    '        strsql &= vbCrLf & "Actual Format : LowerX,LowerY,UpperX,UpperY"
                    '        strsql &= vbCrLf & "Example : 300,220,500,320"
                    '        MessageBox.Show(strsql, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        objReader.Dispose() : objReader.Close()
                    '        Return False
                    '    End If
                    '    .lx = Val(SplitLine(0)) : .ly = Val(SplitLine(1)) : .rx = Val(SplitLine(2)) : .ry = Val(SplitLine(3))
                    '    objReader.Dispose() : objReader.Close()
                    '    Exit Do
                    'Loop
                    Dim strposarr As String() = cmbforms.SelectedValue.ToString.Split(",")
                    .lx = strposarr(0) : .ly = strposarr(1) : .rx = strposarr(2) : .ry = strposarr(3)
                Else
                    If cbPosition.Text = "Bottom Right" Then
                        .lx = 450 : .ly = 0 : .rx = 600 : .ry = 50
                    ElseIf cbPosition.Text = "Top Left " Then
                        .lx = 0 : .ly = 700 : .rx = 150 : .ry = 750
                    ElseIf cbPosition.Text = "Bottom Left" Then
                        .lx = 20 : .ly = 5 : .rx = 170 : .ry = 55
                    Else
                        .lx = 450 : .ly = 700 : .rx = 600 : .ry = 750
                    End If
                End If
                .font = cbFont.Text
                .signname = txtSignersName.Text
                .authorname = tbAuthor.Text
                .reason = cbReason.Text
                .rotate = Val(cmbRotation.Text)
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'grpSignPic.Visible = False
        'picSign.ImageLocation = ""
    End Sub
    'Ashish End for Custom Sign


    'Ashish Start for Custom Sign
    Private Sub lnkOption2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOption2.LinkClicked
        'grpSignPic.Visible = True
        'picSign.ImageLocation = Application.StartupPath & "\New.png"
        Dim ofrmsignaturetype As New frmsignaturetype
        ofrmsignaturetype.PictureBox1.ImageLocation = Application.StartupPath & "\New.png"
        Dim oDialogResult As DialogResult = ofrmsignaturetype.ShowDialog
    End Sub
    'Ashish end for Custom Sign


    'Ashish Start for Custom Sign
    Private Sub lnkOption1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOption1.LinkClicked
        'grpSignPic.Visible = True
        'picSign.ImageLocation = Application.StartupPath & "\OLD.png"
        Dim ofrmsignaturetype As New frmsignaturetype
        ofrmsignaturetype.PictureBox1.ImageLocation = Application.StartupPath & "\OLD.png"
        Dim oDialogResult As DialogResult = ofrmsignaturetype.ShowDialog
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
    Private Sub ttReasonforsig_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim t As New ToolTip()
        t.IsBalloon = True
        't.SetToolTip(ttReasonforsig, "The sentence is displayed in Digital Signer properties , it is to Certify / Authenticate of document")
    End Sub
End Class
