Public Class FrmEmailStatus
    Private oEmailStatus As New EmailStatus
    Sub New()
        Try
            InitializeComponent()
            FillDefaultValues()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FillDefaultValues()
        Try
            dtpmaildate.Value = Now.Date
            cmbstatus.Items.Add("Both")
            cmbstatus.Items.Add("Success")
            cmbstatus.Items.Add("Failed")
            cmbstatus.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btngenerate_Click(sender As Object, e As EventArgs) Handles btngenerate.Click
        Try
            oEmailStatus.date = Format(dtpmaildate.Value, "ddMMMyyyy")
            oEmailStatus.Status = cmbstatus.Text.Trim
            oEmailStatus.GenerateStatusReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Try
            Me.Dispose()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class