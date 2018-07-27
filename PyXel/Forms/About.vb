Public Class About
    Private Sub About_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.PaletteMode = ApplicationSettings.theme
        KryptonHeader1.PaletteMode = ApplicationSettings.theme
        Label1.Text = My.Settings.Version
    End Sub
End Class