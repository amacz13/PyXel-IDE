Public Class Settings
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Fichiers Executables|*.exe"
        openFileDialog1.Title = "Sélectionnez l'emplacement de l'executable Python"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fn As String = openFileDialog1.FileName
            My.Settings.PythonPath = fn
            KryptonTextBox1.Text = fn
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        KryptonTextBox1.Text = My.Settings.PythonPath
        If My.Settings.Theme = "blue" Then
            KryptonRadioButton1.Checked = True
            KryptonRadioButton2.Checked = False
            KryptonRadioButton3.Checked = False
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf My.Settings.Theme = "black" Then
            KryptonRadioButton1.Checked = False
            KryptonRadioButton2.Checked = False
            KryptonRadioButton3.Checked = True
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Else
            KryptonRadioButton1.Checked = False
            KryptonRadioButton2.Checked = True
            KryptonRadioButton3.Checked = False
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        End If
    End Sub

    Private Sub KryptonRadioButton1_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton1.Click
        My.Settings.Theme = "blue"
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Form1.updatePalette()
    End Sub

    Private Sub KryptonRadioButton2_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton2.Click
        My.Settings.Theme = "silver"
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Form1.updatePalette()

    End Sub

    Private Sub KryptonRadioButton3_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton3.Click
        My.Settings.Theme = "black"
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Form1.updatePalette()
    End Sub
End Class