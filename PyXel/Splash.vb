Public Class Splash
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles Me.Load
        KryptonLabel1.ForeColor = Color.White
        KryptonLabel1.Text = My.Settings.Version
    End Sub
End Class