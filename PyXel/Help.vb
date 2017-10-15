Public Class Help

    Public Sub updatePalette()
        If My.Settings.Theme = "blue" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf My.Settings.Theme = "black" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Else
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        End If
    End Sub

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextExtra = My.Settings.Version
        If My.Settings.Theme = "blue" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf My.Settings.Theme = "black" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Else
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        End If
    End Sub
End Class