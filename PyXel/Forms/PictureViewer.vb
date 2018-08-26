Imports System.IO

Public Class PictureViewer

    Public Shared img As String = ""

    Private Sub PictureViewer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = PyXelTranslations.strings.Item("previewof")
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
        If img = "" Then
            Me.Close()
        Else
            Try
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                Dim pic As Image = Image.FromFile(img)
                Me.Text = PyXelTranslations.strings.Item("previewof") + img + " [" + pic.Size.Width.ToString + " x " + pic.Size.Height.ToString + "]"
                PictureBox1.Image = pic
            Catch
                Me.Close()
            End Try

        End If
    End Sub
End Class