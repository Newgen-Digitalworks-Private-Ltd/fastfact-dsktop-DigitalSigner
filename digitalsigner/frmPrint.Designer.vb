<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboSignDates = New System.Windows.Forms.ComboBox()
        Me.lblSelectDate = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lblDongle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.dgControlLog = New System.Windows.Forms.DataGridView()
        Me.SigningDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BatchNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControlNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TLPSign = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.dgControlLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TLPSign.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboSignDates
        '
        Me.cboSignDates.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboSignDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSignDates.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cboSignDates.FormattingEnabled = True
        Me.cboSignDates.Location = New System.Drawing.Point(157, 9)
        Me.cboSignDates.Name = "cboSignDates"
        Me.cboSignDates.Size = New System.Drawing.Size(293, 23)
        Me.cboSignDates.TabIndex = 0
        '
        'lblSelectDate
        '
        Me.lblSelectDate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSelectDate.AutoSize = True
        Me.lblSelectDate.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblSelectDate.Location = New System.Drawing.Point(3, 13)
        Me.lblSelectDate.Name = "lblSelectDate"
        Me.lblSelectDate.Size = New System.Drawing.Size(128, 15)
        Me.lblSelectDate.TabIndex = 0
        Me.lblSelectDate.Text = "Select Date of Signing"
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnBack.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.Location = New System.Drawing.Point(339, 11)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(86, 34)
        Me.btnBack.TabIndex = 4
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
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(615, 11)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 34)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "E&xit"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnNext.BackColor = System.Drawing.Color.Transparent
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnNext.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Location = New System.Drawing.Point(431, 11)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(85, 34)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "&Display"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'lblDongle
        '
        Me.lblDongle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDongle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDongle.ForeColor = System.Drawing.Color.Black
        Me.lblDongle.Location = New System.Drawing.Point(3, 67)
        Me.lblDongle.Name = "lblDongle"
        Me.lblDongle.Size = New System.Drawing.Size(330, 16)
        Me.lblDongle.TabIndex = 49
        Me.lblDongle.Text = "Dongle Not Found"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Black
        Me.lblVersion.Location = New System.Drawing.Point(3, 20)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(330, 16)
        Me.lblVersion.TabIndex = 48
        Me.lblVersion.Text = " Version"
        '
        'dgControlLog
        '
        Me.dgControlLog.AllowUserToAddRows = False
        Me.dgControlLog.AllowUserToDeleteRows = False
        Me.dgControlLog.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgControlLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgControlLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SigningDate, Me.BatchNumber, Me.ControlNumber, Me.FileName})
        Me.dgControlLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgControlLog.Location = New System.Drawing.Point(0, 0)
        Me.dgControlLog.Name = "dgControlLog"
        Me.dgControlLog.ReadOnly = True
        Me.dgControlLog.Size = New System.Drawing.Size(698, 328)
        Me.dgControlLog.TabIndex = 50
        '
        'SigningDate
        '
        Me.SigningDate.DataPropertyName = "SigningDate"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.SigningDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.SigningDate.HeaderText = "Sign Date"
        Me.SigningDate.Name = "SigningDate"
        Me.SigningDate.ReadOnly = True
        '
        'BatchNumber
        '
        Me.BatchNumber.DataPropertyName = "Batch"
        Me.BatchNumber.HeaderText = "Batch Number"
        Me.BatchNumber.Name = "BatchNumber"
        Me.BatchNumber.ReadOnly = True
        '
        'ControlNumber
        '
        Me.ControlNumber.DataPropertyName = "ControlNo"
        Me.ControlNumber.HeaderText = "Control Number"
        Me.ControlNumber.Name = "ControlNumber"
        Me.ControlNumber.ReadOnly = True
        '
        'FileName
        '
        Me.FileName.DataPropertyName = "FileName"
        Me.FileName.HeaderText = "File Name"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        '
        'btnExport
        '
        Me.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExport.BackColor = System.Drawing.Color.Transparent
        Me.btnExport.BackgroundImage = CType(resources.GetObject("btnExport.BackgroundImage"), System.Drawing.Image)
        Me.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExport.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.btnExport.ForeColor = System.Drawing.Color.Black
        Me.btnExport.Location = New System.Drawing.Point(522, 9)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(85, 38)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "&Export To Excel"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.097394!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98.9026!))
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
        Me.TableLayoutPanel1.TabIndex = 51
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(10, 11)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.88189!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.11811!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(712, 586)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TLPSign, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 99)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(706, 383)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'TLPSign
        '
        Me.TLPSign.ColumnCount = 2
        Me.TLPSign.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.08955!))
        Me.TLPSign.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.91045!))
        Me.TLPSign.Controls.Add(Me.cboSignDates, 1, 0)
        Me.TLPSign.Controls.Add(Me.lblSelectDate, 0, 0)
        Me.TLPSign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TLPSign.Location = New System.Drawing.Point(3, 3)
        Me.TLPSign.Name = "TLPSign"
        Me.TLPSign.RowCount = 1
        Me.TLPSign.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPSign.Size = New System.Drawing.Size(700, 41)
        Me.TLPSign.TabIndex = 51
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dgControlLog)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(700, 330)
        Me.Panel3.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(706, 90)
        Me.Panel1.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.DigitalSigner.My.Resources.Resources.DG2
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(704, 88)
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
        Me.Panel2.Size = New System.Drawing.Size(706, 95)
        Me.Panel2.TabIndex = 5
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.72727!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.06818!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.92614!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.92614!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.06818!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancel, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExport, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDongle, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnNext, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblVersion, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBack, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.42857!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.57143!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(704, 93)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'frmPrint
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 608)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Control List"
        CType(Me.dgControlLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TLPSign.ResumeLayout(False)
        Me.TLPSign.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lblSelectDate As System.Windows.Forms.Label
    Friend WithEvents cboSignDates As System.Windows.Forms.ComboBox
    Friend WithEvents lblDongle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents dgControlLog As System.Windows.Forms.DataGridView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents SigningDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ControlNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TLPSign As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
