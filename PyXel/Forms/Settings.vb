Imports System.ComponentModel
Imports System.Xml
Imports ComponentFactory.Krypton.Toolkit

Public Class Settings
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Fichiers Executables|*.exe"
        openFileDialog1.Title = "Sélectionnez l'emplacement de l'executable Python 2"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fn As String = openFileDialog1.FileName
            ApplicationSettings.python2 = fn
            KryptonTextBox1.Text = fn
        End If
    End Sub
    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles KryptonButton2.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Fichiers Executables|*.exe"
        openFileDialog1.Title = "Sélectionnez l'emplacement de l'executable Python 3"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fn As String = openFileDialog1.FileName
            ApplicationSettings.python3 = fn
            KryptonTextBox2.Text = fn
        End If
    End Sub



    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextExtra = My.Settings.Version
        KryptonTextBox1.Text = ApplicationSettings.python2
        KryptonTextBox2.Text = ApplicationSettings.python3
        KryptonButton3.Hide()
        'KryptonButton1.Hide()
        'KryptonTextBox1.Hide()
        KryptonTextBox3.Hide()
        'KryptonLabel2.Hide()
        'KryptonLabel1.Hide()
        KryptonLabel4.Hide()
        'KryptonRadioButton4.Hide()
        'KryptonRadioButton5.Hide()
        If ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue Then
            KryptonRadioButton1.Checked = True
            KryptonRadioButton2.Checked = False
            KryptonRadioButton3.Checked = False
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black Then
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
        KryptonColorButton1.SelectedColor = ApplicationSettings.editorBackColor
        KryptonColorButton2.SelectedColor = ApplicationSettings.editorForeColor
        KryptonColorButton3.SelectedColor = ApplicationSettings.interpreterForeColor
        KryptonColorButton4.SelectedColor = ApplicationSettings.interpreterBackColor
        KryptonColorButton1.Strings.MoreColors = "&Plus de couleurs..."
        KryptonColorButton1.Strings.NoColor = "&Pas de Couleur..."
        KryptonColorButton1.Strings.RecentColors = "Couleurs récentes..."
        KryptonColorButton1.Strings.ThemeColors = "Couleurs du thème..."
        KryptonColorButton1.Strings.StandardColors = "Couleurs standards..."
        KryptonColorButton2.Strings.MoreColors = "&Plus de couleurs..."
        KryptonColorButton2.Strings.NoColor = "&Pas de Couleur..."
        KryptonColorButton2.Strings.RecentColors = "Couleurs récentes..."
        KryptonColorButton2.Strings.ThemeColors = "Couleurs du thème..."
        KryptonColorButton2.Strings.StandardColors = "Couleurs standards..."
        KryptonColorButton3.Strings.MoreColors = "&Plus de couleurs..."
        KryptonColorButton3.Strings.NoColor = "&Pas de Couleur..."
        KryptonColorButton3.Strings.RecentColors = "Couleurs récentes..."
        KryptonColorButton3.Strings.ThemeColors = "Couleurs du thème..."
        KryptonColorButton3.Strings.StandardColors = "Couleurs standards..."
        KryptonColorButton4.Strings.MoreColors = "&Plus de couleurs..."
        KryptonColorButton4.Strings.NoColor = "&Pas de Couleur..."
        KryptonColorButton4.Strings.RecentColors = "Couleurs récentes..."
        KryptonColorButton4.Strings.ThemeColors = "Couleurs du thème..."
        KryptonColorButton4.Strings.StandardColors = "Couleurs standards..."
    End Sub

    Private Sub KryptonRadioButton1_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton1.Click
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        Form1.updatePalette()
        Help.updatePalette()
    End Sub

    Private Sub KryptonRadioButton2_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton2.Click
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Form1.updatePalette()
        Help.updatePalette()

    End Sub

    Private Sub KryptonRadioButton3_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton3.Click
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Form1.updatePalette()
        Help.updatePalette()
    End Sub

    Private Sub KryptonColorButton1_SelectedColorChanged(sender As Object, e As ColorEventArgs) Handles KryptonColorButton1.SelectedColorChanged
        ApplicationSettings.editorBackColor = e.Color
        Form1.updateEditors()
    End Sub

    Private Sub KryptonColorButton2_SelectedColorChanged(sender As Object, e As ColorEventArgs) Handles KryptonColorButton2.SelectedColorChanged
        ApplicationSettings.editorForeColor = e.Color
        Form1.updateEditors()
    End Sub

    Private Sub KryptonColorButton4_SelectedColorChanged(sender As Object, e As ColorEventArgs) Handles KryptonColorButton4.SelectedColorChanged
        ApplicationSettings.interpreterBackColor = e.Color
        Form1.ConsoleControl1.BackColor = e.Color
    End Sub

    Private Sub KryptonColorButton3_SelectedColorChanged(sender As Object, e As ColorEventArgs) Handles KryptonColorButton3.SelectedColorChanged
        ApplicationSettings.interpreterForeColor = e.Color
        Form1.ConsoleControl1.ForeColor = e.Color
    End Sub

    Private Sub Settings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        createConfig()
    End Sub

    Private Sub createConfig()
        System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")
        Dim writer As New XmlTextWriter(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("PyXel")
        writer.WriteStartElement("General")
        writer.WriteStartElement("Language")
        writer.WriteString(ApplicationSettings.lang)
        writer.WriteEndElement()
        writer.WriteStartElement("Theme")
        Select Case ApplicationSettings.theme
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
                writer.WriteString("Blue")
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
                writer.WriteString("Black")
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
                writer.WriteString("Silver")
            Case Else
                writer.WriteString("Blue")
        End Select
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Colors")
        writer.WriteStartElement("Editor")
        writer.WriteStartElement("ForeColor")
        writer.WriteString(ApplicationSettings.editorForeColor.ToArgb)
        writer.WriteEndElement()
        writer.WriteStartElement("BackColor")
        writer.WriteString(ApplicationSettings.editorBackColor.ToArgb)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Interpreter")
        writer.WriteStartElement("ForeColor")
        writer.WriteString(ApplicationSettings.interpreterForeColor.ToArgb)
        writer.WriteEndElement()
        writer.WriteStartElement("BackColor")
        writer.WriteString(ApplicationSettings.interpreterBackColor.ToArgb)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("PythonPath")
        writer.WriteStartElement("Python2")
        writer.WriteString(ApplicationSettings.python2)
        writer.WriteEndElement()
        writer.WriteStartElement("Python3")
        writer.WriteString(ApplicationSettings.python3)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Private Sub KryptonRadioButton4_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton4.Click
        ApplicationSettings.lang = "French"
        MsgBox("La langue de PyXel a été définie sur : Français." + vbNewLine + "Les changement prendront effet après un redémarrage de l'application.", MsgBoxStyle.Information, "PyXel")
    End Sub
    Private Sub KryptonRadioButton5_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton5.Click
        ApplicationSettings.lang = "English"
        MsgBox("PyXel's language is now defined to : English." + vbNewLine + "This modification will be applied after a restart of the application.", MsgBoxStyle.Information, "PyXel")
    End Sub

    Private Sub KryptonButton5_Click(sender As Object, e As EventArgs) Handles KryptonButton5.Click
        Dim fontDial As New FontDialog
        fontDial.Color = ApplicationSettings.interpreterForeColor
        fontDial.ShowColor = False
        If fontDial.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim selFont As Font = fontDial.Font
            Dim fontName As String = selFont.FontFamily.Name
            Dim bold As Boolean = selFont.Bold
            Dim italic As Boolean = selFont.Italic
            Dim underline As Boolean = selFont.Underline
            Dim size As Integer = selFont.SizeInPoints
            ApplicationSettings.interpreterFont = selFont
            Form1.ConsoleControl1.Font = selFont
        End If
    End Sub

    Private Sub KryptonButton4_Click(sender As Object, e As EventArgs) Handles KryptonButton4.Click
        Dim fontDial As New FontDialog
        fontDial.Color = ApplicationSettings.interpreterForeColor
        fontDial.ShowColor = False
        If fontDial.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim selFont As Font = fontDial.Font
            Dim fontName As String = selFont.FontFamily.Name
            Dim bold As Boolean = selFont.Bold
            Dim italic As Boolean = selFont.Italic
            Dim underline As Boolean = selFont.Underline
            Dim size As Integer = selFont.SizeInPoints
            ApplicationSettings.editorFont = selFont
            Form1.updateEditors()
        End If
    End Sub
End Class