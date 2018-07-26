Imports System.ComponentModel
Imports ComponentFactory.Krypton.Toolkit
Imports MyAPKapp.VistaUIFramework.TaskDialog

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
        If ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue Then
            KryptonRadioButton1.Checked = True
            KryptonRadioButton2.Checked = False
            KryptonRadioButton3.Checked = False
            KryptonRadioButton9.Checked = False
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black Then
            KryptonRadioButton1.Checked = False
            KryptonRadioButton2.Checked = False
            KryptonRadioButton3.Checked = True
            KryptonRadioButton9.Checked = False
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        ElseIf ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black Then
            KryptonRadioButton1.Checked = False
            KryptonRadioButton2.Checked = True
            KryptonRadioButton3.Checked = False
            KryptonRadioButton9.Checked = False
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Else
            KryptonRadioButton1.Checked = False
            KryptonRadioButton2.Checked = False
            KryptonRadioButton3.Checked = False
            KryptonRadioButton9.Checked = True
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
        End If

        If ApplicationSettings.updateCanal = "Stable" Then
            KryptonRadioButton4.Checked = True
            KryptonRadioButton5.Checked = False
        Else
            KryptonRadioButton4.Checked = False
            KryptonRadioButton5.Checked = True
        End If

        If ApplicationSettings.updateType = "Normal" Then
            KryptonRadioButton6.Checked = True
            KryptonRadioButton7.Checked = False
            KryptonRadioButton8.Checked = False
        ElseIf ApplicationSettings.updateType = "Silent" Then
            KryptonRadioButton6.Checked = False
            KryptonRadioButton7.Checked = True
            KryptonRadioButton8.Checked = False
        Else
            KryptonRadioButton6.Checked = False
            KryptonRadioButton7.Checked = False
            KryptonRadioButton8.Checked = True
        End If


        KryptonComboBox1.SelectedText = "Français"

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

        KryptonButton1.Height = KryptonTextBox1.Height
        KryptonButton2.Height = KryptonTextBox1.Height
        KryptonButton3.Height = KryptonTextBox1.Height
        KryptonButton6.Height = KryptonTextBox1.Height
        KryptonButton7.Height = KryptonTextBox1.Height
        KryptonButton8.Height = KryptonTextBox1.Height
        KryptonButton9.Height = KryptonTextBox1.Height
    End Sub

    Private Sub UpdatePalettes()
        Form1.updatePalette()
        Help.updatePalette()
    End Sub

    Private Sub KryptonRadioButton1_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton1.Click
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        UpdatePalettes()
    End Sub

    Private Sub KryptonRadioButton2_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton2.Click
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        UpdatePalettes()

    End Sub

    Private Sub KryptonRadioButton3_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton3.Click
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        UpdatePalettes()
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
        ApplicationSettings.createConfig()
    End Sub


    Private Sub ChangeLanguage(sender As Object, e As EventArgs) Handles KryptonComboBox1.SelectedValueChanged
        Dim td As New TaskDialog
        td.CommonButtons = TaskDialogCommonButton.OK
        td.StandardIcon = TaskDialogIcon.ShieldOK
        td.WindowTitle = "PyXel"
        Select Case KryptonComboBox1.SelectedItem
            Case "Français"
                ApplicationSettings.lang = "French"
                td.MainInstruction = "Changement de langue"
                td.Content = "La langue de PyXel a été définie sur : Français." + vbNewLine + "Les changements prendront effet après un redémarrage de l'application."
                'MsgBox("La langue de PyXel a été définie sur : Français." + vbNewLine + "Les changements prendront effet après un redémarrage de l'application.", MsgBoxStyle.Information, "PyXel")
            Case "English"
                ApplicationSettings.lang = "English"
                td.MainInstruction = "Language change"
                td.Content = "PyXel's language is now defined to : English." + vbNewLine + "This modification will be applied after a restart of the application."
                'MsgBox("PyXel's language is now defined to : English." + vbNewLine + "This modification will be applied after a restart of the application.", MsgBoxStyle.Information, "PyXel")
        End Select
        td.ShowDialog()

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

    Private Sub KryptonRadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles KryptonRadioButton9.CheckedChanged
        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
        KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
        UpdatePalettes()
    End Sub

    Private Sub KryptonRadioButton4_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton4.Click
        ApplicationSettings.updateCanal = "Stable"
    End Sub

    Private Sub KryptonRadioButton5_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton5.Click
        ApplicationSettings.updateCanal = "Insider"
    End Sub

    Private Sub KryptonRadioButton6_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton6.Click
        ApplicationSettings.updateType = "Normal"
    End Sub

    Private Sub KryptonRadioButton7_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton7.Click
        ApplicationSettings.updateType = "Silent"
    End Sub
    Private Sub KryptonRadioButton8_Click(sender As Object, e As EventArgs) Handles KryptonRadioButton8.Click
        ApplicationSettings.updateType = "Disabled"
    End Sub

End Class