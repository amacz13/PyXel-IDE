Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KryptonHeader1.Values.Description = My.Settings.Version
    End Sub
End Class