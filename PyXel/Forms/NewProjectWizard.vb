Public Class NewProjectWizard
    Private Sub NewProjectWizard_Load(sender As Object, e As EventArgs) Handles Me.Load
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
        KryptonButton3.Height = KryptonTextBox2.Height

    End Sub

End Class