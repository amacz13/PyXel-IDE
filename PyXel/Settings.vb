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
    End Sub
End Class