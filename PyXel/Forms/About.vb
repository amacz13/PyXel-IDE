Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = My.Settings.Version
    End Sub
End Class