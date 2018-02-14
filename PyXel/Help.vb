Public Class Help

    Public Sub updatePalette()
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
    End Sub

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextExtra = My.Settings.Version
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
    End Sub
End Class