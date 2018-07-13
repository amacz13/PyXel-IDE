Imports System.Xml

Public Class NewProjectWizard
    Private Sub NewProjectWizard_Load(sender As Object, e As EventArgs) Handles Me.Load
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
        KryptonButton3.Height = KryptonTextBox2.Height

    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton3_Click(sender As Object, e As EventArgs) Handles KryptonButton3.Click
        Dim fd As New SaveFileDialog
        fd.Title = "Emplacement de création du projet"
        fd.Filter = "Projet PyXel|*.pxl"
        If fd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            KryptonTextBox2.Text = fd.FileName
        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        If KryptonTextBox1.Text = "" Then
            MsgBox("Veuillez saisir le nom du projet !", MsgBoxStyle.Critical, "PyXel")
            Exit Sub
        ElseIf KryptonTextBox2.Text = "" Then
            MsgBox("Veuillez renseigner l'emplacement du projet !", MsgBoxStyle.Critical, "PyXel")
            Exit Sub
        End If

        Try
            Dim writer As New XmlTextWriter(KryptonTextBox2.Text, System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("PyXelProject")
            writer.WriteStartElement("General")
            writer.WriteStartElement("ProjectName")
            writer.WriteString(KryptonTextBox1.Text)
            writer.WriteEndElement()
            writer.WriteEndElement()
            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()
        Catch ex As Exception
            MsgBox("Une erreur est survenue lors de la création du projet." + vbNewLine + "Vérifiez que l'emplacement est accessible en écriture", MsgBoxStyle.Critical, "PyXel")
        End Try
        Project.OpenProject(KryptonTextBox2.Text)
        Me.Close()
    End Sub
End Class