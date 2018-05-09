﻿Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text.RegularExpressions
Imports ComponentFactory.Krypton.Navigator
Imports ComponentFactory.Krypton.Toolkit
Imports FastColoredTextBoxNS

Public Class Form1

    Enum Languages
        Python
        C
        HTML
        PHP
        JS
        Lua
        CSharp
        VBNet
    End Enum

    'Styles CodeEditor

    Public Shared greenStyle As Style = New TextStyle(Brushes.Green, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Italic)
    Public Shared blueStyle As Style = New TextStyle(Brushes.Blue, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Regular)
    Public Shared orangeStyle As Style = New TextStyle(Brushes.Orange, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Regular)
    Public Shared redStyle As Style = New TextStyle(Brushes.Red, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Bold)
    Public Shared purpleStyle As Style = New TextStyle(Brushes.Purple, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Bold)
    Public Shared salmonStyle As Style = New TextStyle(Brushes.Salmon, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Regular)

    'Python Interpreter
    Private WithEvents proc As New Process
    Dim consoleSender As StreamWriter
    Dim inExec As Boolean = False

    'Number of files opened
    Dim pages As New Integer

    'Dictionnaries
    Dim tabs As New Dictionary(Of Integer, TabPage)
    Dim tabsInversed As New Dictionary(Of TabPage, Integer)
    Public Shared editors As New Dictionary(Of Integer, FastColoredTextBox)
    Dim editorsInversed As New Dictionary(Of FastColoredTextBox, Integer)
    Public Shared editorsIdLanguage As New Dictionary(Of Integer, Languages)
    Dim editorsLanguage As New Dictionary(Of FastColoredTextBox, Languages)
    Dim interpretersOutputs As New Dictionary(Of Integer, FastColoredTextBox)
    Dim interpretersProcess As New Dictionary(Of Integer, System.Diagnostics.Process)
    Dim interpretersProcessInverted As New Dictionary(Of System.Diagnostics.Process, Integer)
    Dim firstLoad As New Dictionary(Of Integer, Boolean)
    Dim pagesSaved As New Dictionary(Of Integer, Boolean)
    Dim filesOpened As New Dictionary(Of Integer, String)
    Dim displayNames As New Dictionary(Of Integer, String)
    Dim menus As New Dictionary(Of Integer, AutocompleteMenu)

    'Utilities Sub

    Public Shared Sub updateEditors()
        greenStyle = New TextStyle(Brushes.Green, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Italic)
        blueStyle = New TextStyle(Brushes.Blue, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Regular)
        orangeStyle = New TextStyle(Brushes.Orange, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Regular)
        redStyle = New TextStyle(Brushes.Red, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Bold)
        purpleStyle = New TextStyle(Brushes.Purple, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Bold)
        salmonStyle = New TextStyle(Brushes.Salmon, New SolidBrush(ApplicationSettings.editorBackColor), FontStyle.Regular)
        For Each item As KeyValuePair(Of Integer, FastColoredTextBox) In editors
            item.Value.ForeColor = ApplicationSettings.editorForeColor
            item.Value.BackColor = ApplicationSettings.editorBackColor
            item.Value.Font = ApplicationSettings.editorFont
        Next
    End Sub
    Public Async Function SavePage(id As Integer) As Task
        Dim editor As FastColoredTextBox = editors.Item(id)
        If filesOpened.Item(id) = "Sans Nom" Then
            Dim saveFileDialog As New SaveFileDialog
            saveFileDialog.Filter = "Fichiers Python|*.py"
            saveFileDialog.Title = "Enregistrer un fichier Python"
            If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fileName As String
                fileName = saveFileDialog.FileName
                Using outputFile As New StreamWriter(fileName)
                    Await outputFile.WriteAsync(editor.Text)
                End Using
                pagesSaved.Item(id) = True
                filesOpened.Item(id) = fileName
                displayNames.Item(id) = System.IO.Path.GetFileName(fileName)
                tabs.Item(id).Text = System.IO.Path.GetFileName(filesOpened.Item(id))
            End If
        Else
            Dim fileName As String = filesOpened.Item(id)
            Using outputFile As New StreamWriter(fileName)
                Await outputFile.WriteAsync(editor.Text)
            End Using
            pagesSaved.Item(id) = True
            tabs.Item(id).Text = displayNames.Item(id)
        End If
    End Function
    Private Sub OpenFile()
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Fichiers Python|*.py"
        openFileDialog1.Title = "Ouvrir un fichier Python"
        openFileDialog1.Multiselect = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For x = 0 To openFileDialog1.FileNames.Count - 1
                Dim fileName As String
                fileName = openFileDialog1.FileNames(x)
                pages += 1
                pagesSaved.Add(pages, True)
                filesOpened.Add(pages, fileName)
                Dim newPage As New TabPage
                newPage.Text = System.IO.Path.GetFileName(fileName)
                Dim editor As New FastColoredTextBox
                configEditor(editor)
                displayNames.Add(pages, System.IO.Path.GetFileName(fileName))
                editor.Dock = DockStyle.Fill
                tabs.Add(pages, newPage)
                editors.Add(pages, editor)
                tabsInversed.Add(newPage, pages)
                editorsInversed.Add(editor, pages)
                CustomTabControl1.TabPages.Add(newPage)
                CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
                newPage.Controls.Add(editor)
                Dim menu As New AutocompleteMenu(editor)
                AutoCompleteTools.LoadDefaultItems(menu, Languages.Python)
                menus.Add(pages, menu)
                firstLoad.Add(pages, True)
                editor.OpenFile(fileName)
            Next
        End If
    End Sub
    Private Sub openNewTab()
        Dim newPage As New TabPage
        newPage.Text = "Sans Nom"

        'editor Configuration
        Dim editor As New FastColoredTextBox
        configEditor(editor)


        pages += 1
        Dim menu As New AutocompleteMenu(editor)
        AutoCompleteTools.LoadDefaultItems(menu, Languages.Python)
        menus.Add(pages, menu)
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        CustomTabControl1.TabPages.Add(newPage)
        CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
        newPage.Controls.Add(editor)
        filesOpened.Add(pages, "Sans Nom")
        pagesSaved.Add(pages, True)
        displayNames.Add(pages, "Sans Nom")
        firstLoad.Add(pages, True)
    End Sub

    Private Sub configEditor(editor As FastColoredTextBox)
        editor.BackColor = ApplicationSettings.editorBackColor
        editor.ForeColor = ApplicationSettings.editorForeColor
        editor.LeftBracket = "{"
        editor.RightBracket = "}"
        editor.LeftBracket2 = "("
        editor.RightBracket2 = ")"
        editor.AutoCompleteBrackets = True
        editor.CommentPrefix = "#"
        editor.ContextMenuStrip = ContextMenuStrip2
        AddHandler editor.AutoIndentNeeded, AddressOf AutoIndent
        AddHandler editor.TextChanged, AddressOf TextChanged
        editor.Dock = DockStyle.Fill
        editor.Font = ApplicationSettings.editorFont
    End Sub
    Private Sub TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim id As Integer = editorsInversed.Item(sender)
        If Not firstLoad.Item(id) Then
            Dim tab As TabPage = tabs.Item(id)
            tab.Text = displayNames.Item(id) + "*"
            pagesSaved.Item(id) = False
        End If
        If firstLoad.Item(id) Then
            firstLoad.Item(id) = False
        End If
        e.ChangedRange.ClearStyle(greenStyle)
        e.ChangedRange.ClearStyle(orangeStyle)
        e.ChangedRange.ClearStyle(blueStyle)
        e.ChangedRange.ClearStyle(redStyle)
        e.ChangedRange.ClearStyle(purpleStyle)
        e.ChangedRange.SetStyle(blueStyle, "(([A-z0-9]))\w*\s*\=")
        e.ChangedRange.SetStyle(greenStyle, "#.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(greenStyle, "(''')(.*?(\n))+.*(''')", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(blueStyle, "(abs|all|any|ascii|bytearray|bytes|callable|chr|classmethod|compile|complex|delattr|dir|divmod|enumerate|eval|exec|filter|format|getattr|globals|hasattr|hash|help|hex|id|input|isinstance|issubclass|iter|len|locals|map|max|memoryview|min|next|oct|open|ord|pow|print|range|repr|reversed|round|setattr|sorted|sum|super|vars|zip|\(|\)|\{|\}|\[|\])")
        e.ChangedRange.SetStyle(orangeStyle, "(int|long|float|complex|str|tuple|list|set|dict|frozenset|chr|unichr|ord|hex|oct)(\s|\()")
        e.ChangedRange.SetStyle(redStyle, "(def\s|import\s|\sas\s|\sfrom\s)")
        e.ChangedRange.SetStyle(salmonStyle, "(if\s|else(\s|\:)|elif\s|for\s|while\s)|try(\s|\:)|except(\s|\:)|raise(\s)")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(34) + "(.*?)" + Chr(34) + "")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(39) + "(.*?)" + Chr(39) + "")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(44) + "(.*?)" + Chr(44) + "")
    End Sub

    Private Sub AutoIndent(sender As Object, e As AutoIndentEventArgs)
        If e.LineText.Trim.Contains("def") Or e.LineText.Trim.Contains("if") Or e.LineText.Trim.Contains("else") Or e.LineText.Trim.Contains("elif") Or e.LineText.Trim.Contains("for") Or e.LineText.Trim.Contains("while") Then
            e.ShiftNextLines = e.TabLength
        End If
    End Sub

    Private Sub checkForUpdates()
        Try
            If (File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")) Then
                System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            End If
            My.Computer.Network.DownloadFile("https://amacz13.fr/files/pyxel/currentversion.txt", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            Dim versionReader As New System.IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            Dim version As String = versionReader.ReadToEnd
            versionReader.Close()
            If String.Compare(My.Settings.Version, version) = 0 Then
                ButtonSpecAny2.Visible = False
            Else
                ButtonSpecAny2.Text = version
                ButtonSpecAny2.Visible = True
            End If
        Catch
            ButtonSpecAny2.Visible = False
        End Try
    End Sub

    'Form Loading Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'KryptonHeaderGroup1.Hide()
        KryptonRibbon1.SelectedContext = "Python"
        Me.TextExtra = My.Settings.Version
        pages = 0
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme

        Dim newPage As New TabPage
        newPage.Text = "Sans Nom"

        'Editor configuration
        Dim editor As New FastColoredTextBox
        configEditor(editor)
        editor.ContextMenuStrip = ContextMenuStrip2

        pages += 1
        Dim menu As New AutocompleteMenu(editor)
        AutoCompleteTools.LoadDefaultItems(menu, Languages.Python)
        menus.Add(pages, menu)
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        CustomTabControl1.TabPages.Add(newPage)
        CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
        newPage.Controls.Add(editor)
        pagesSaved.Add(pages, True)
        firstLoad.Add(pages, True)

        'Open file which launched the app
        If ApplicationSettings.isFileOpened = True Then
            Try
                filesOpened.Add(pages, ApplicationSettings.fileOpened)
                displayNames.Add(pages, System.IO.Path.GetFileName(ApplicationSettings.fileOpened))
                Dim sr As New System.IO.StreamReader(ApplicationSettings.fileOpened)
                editor.Text = sr.ReadToEnd
                sr.Close()
            Catch
                MessageBox.Show("Une erreur est survenue lors de l'ouverture du fichier", "PyXel - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                filesOpened.Add(pages, "Sans Nom")
                displayNames.Add(pages, "Sans Nom")
            End Try

        Else
            'No file launched the app, just adding a blank tab
            filesOpened.Add(pages, "Sans Nom")
            displayNames.Add(pages, "Sans Nom")
        End If

        'Interpreter Console Configuration
        ConsoleControl1.BackColor = ApplicationSettings.interpreterBackColor
        ConsoleControl1.ForeColor = ApplicationSettings.interpreterForeColor

        'FastColoredTextBox1.BackColor = ApplicationSettings.interpreterBackColor
        'FastColoredTextBox1.ForeColor = ApplicationSettings.interpreterForeColor

        'Update Checking
        checkForUpdates()

        'ContextMenus Configuration
        CustomTabControl1.ContextMenuStrip = ContextMenuStrip1

    End Sub

    Private Sub KryptonContextMenuItem2_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem2.Click
        OpenFile()
    End Sub



    Private Async Sub KryptonContextMenuItem3_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem3.Click
        Await SavePage(tabsInversed.Item(CustomTabControl1.SelectedTab))
    End Sub

    Private Async Sub KryptonRibbonQATButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton1.Click
        Await SavePage(tabsInversed.Item(CustomTabControl1.SelectedTab))
    End Sub

    Private Sub KryptonContextMenuItem1_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem1.Click
        openNewTab()
    End Sub

    Private Async Sub ButtonSpecAppMenu2_Click(sender As Object, e As EventArgs) Handles ButtonSpecAppMenu2.Click
        For Each page As TabPage In CustomTabControl1.TabPages
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                CustomTabControl1.SelectedTab = page
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
                style = MsgBoxStyle.YesNoCancel
                title = "PyXel - Fichier non sauvegardé"
                Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = MsgBoxResult.Yes Then
                    Await SavePage(id)
                ElseIf result = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End If
            tabsInversed.Remove(tabs.Item(id))
            tabs.Remove(id)
            editorsInversed.Remove(editors.Item(id))
            editors.Remove(id)
            pagesSaved.Remove(id)
            filesOpened.Remove(id)
            displayNames.Remove(id)
            menus.Remove(id)
            firstLoad.Remove(id)
        Next
        Application.Exit()
    End Sub

    Private Async Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        For Each page As TabPage In CustomTabControl1.TabPages
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                CustomTabControl1.SelectedTab = page
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
                style = MsgBoxStyle.YesNoCancel
                title = "PyXel - Fichier non sauvegardé"
                Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = MsgBoxResult.Yes Then
                    Await SavePage(id)
                ElseIf result = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End If
            tabsInversed.Remove(tabs.Item(id))
            tabs.Remove(id)
            editorsInversed.Remove(editors.Item(id))
            editors.Remove(id)
            pagesSaved.Remove(id)
            filesOpened.Remove(id)
            displayNames.Remove(id)
            menus.Remove(id)
            firstLoad.Remove(id)
        Next
        Application.Exit()
    End Sub

    Private Sub ButtonSpecAppMenu1_Click(sender As Object, e As EventArgs) Handles ButtonSpecAppMenu1.Click
        About.ShowDialog()
    End Sub


    Private Async Sub KryptonRibbonGroupButton14_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton14.Click
        If ApplicationSettings.python3 = "none" Then
            MessageBox.Show("Veuillez configurer l'emplacement de l'exécutable Python", "Exécutable Python introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Settings.ShowDialog()
        Else
            Dim page As TabPage = CustomTabControl1.SelectedTab
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                msg = "Vous devez sauvegarder ce fichier pour l'interpréter. Voulez-vous continuer ?"   ' Define message.
                style = MsgBoxStyle.YesNoCancel
                title = "PyXel - Fichier non sauvegardé"
                Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = MsgBoxResult.Yes Then
                    Await SavePage(id)
                ElseIf result = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End If

            'If inExec Then
            '    proc.CancelOutputRead()
            '    proc.Kill()
            '    KryptonRibbonGroupButton14.Enabled = True
            '    inExec = False
            'End If
            'proc.StartInfo.FileName = ApplicationSettings.python3
            'proc.StartInfo.Arguments = filesOpened(id)
            'proc.StartInfo.CreateNoWindow = True
            'proc.StartInfo.UseShellExecute = False
            'proc.EnableRaisingEvents = True
            'proc.StartInfo.RedirectStandardOutput = True
            'proc.StartInfo.RedirectStandardInput = True
            'proc.Start()
            'proc.BeginOutputReadLine()
            'consoleSender = proc.StandardInput
            'inExec = True
            If ConsoleControl1.IsProcessRunning Then
                Dim msg As String
                Dim title As String
                Dim style As MsgBoxStyle
                msg = "Un processus est en cours d'exécution. Voulez-vous l'interrompre ?"   ' Define message.
                style = MsgBoxStyle.YesNoCancel
                title = "PyXel - Processus en cours"
                Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = MsgBoxResult.Yes Then
                    ConsoleControl1.StopProcess()
                ElseIf result = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End If
            Threading.Thread.Sleep(500)
            Try
                ConsoleControl1.StartProcess(ApplicationSettings.python3, filesOpened(id))
            Catch
                MessageBox.Show("Une erreur est survenue lors de l'exécution du programme", "PyXel - Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    'Private Sub proc_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles proc.Exited
    '    inExec = False
    '    proc.CancelOutputRead()
    'End Sub

    'Private Sub proc_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles proc.OutputDataReceived
    '    If e.Data <> Nothing Then
    '        Invoke(New OutputRecievedDel(AddressOf OutputRecieved), e.Data)
    '    End If
    'End Sub

    'Private Delegate Sub OutputRecievedDel(ByVal out As String)

    'Private Sub OutputRecieved(ByVal out As String)
    '    FastColoredTextBox1.Text += vbNewLine + out
    'End Sub

    Private Sub KryptonRibbonGroupButton5_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton16.Click
        If ApplicationSettings.python3 = "none" Then
            MessageBox.Show("Veuillez configurer l'emplacement de l'exécutable Python", "Exécutable Python introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Settings.ShowDialog()
        Else
            Shell(ApplicationSettings.python3)
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton2_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton2.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Cut()

    End Sub

    Private Sub KryptonRibbonGroupButton3_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton3.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Copy()
    End Sub

    Private Sub KryptonRibbonGroupButton6_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton6.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Paste()
    End Sub

    Private Sub KryptonContextMenuItem4_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem4.Click
        Settings.ShowDialog()
    End Sub

    Private Sub KryptonRibbonGroupButton7_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton7.Click
        MessageBox.Show("Cette fonctionnalité n'est pas encore disponible !", "Non Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub KryptonContextMenuItem5_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem5.Click
        Dim id As Integer = tabsInversed.Item(CustomTabControl1.SelectedTab)
        Dim editor As FastColoredTextBox = editors.Item(id)
        Dim ps As New PrintDialogSettings
        ps.IncludeLineNumbers = True
        ps.ShowPrintDialog = True
        editor.Print(ps)
    End Sub

    Private Async Sub KryptonDockableNavigator1_CloseAction(sender As Object, e As TabControlCancelEventArgs) Handles CustomTabControl1.TabClosing
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                Await SavePage(id)
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        tabsInversed.Remove(tabs.Item(id))
        tabs.Remove(id)
        editorsInversed.Remove(editors.Item(id))
        editors.Remove(id)
        pagesSaved.Remove(id)
        filesOpened.Remove(id)
        displayNames.Remove(id)
        firstLoad.Remove(id)
        If CustomTabControl1.TabCount = 1 Then
            openNewTab()
        End If
    End Sub

    Public Sub updatePalette()
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
    End Sub

    Private Sub ButtonSpecAny1_Click(sender As Object, e As EventArgs) Handles ButtonSpecAny1.Click
        Help.Show()
    End Sub

    Private Sub KryptonRibbonGroupButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton1.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        If editor.SelectedText.Length = 0 Then
            editor.InsertLinePrefix("#")
        ElseIf editor.GetLine(editor.Selection.Start.iLine).Text.Chars(0) = "#" Then
            editor.RemoveLinePrefix("#")
        Else
            editor.InsertLinePrefix("#")
        End If

    End Sub

    Private Sub KryptonRibbonGroupButton8_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton8.Click
        MessageBox.Show("Cette fonctionnalité n'est pas encore disponible !", "Non Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub KryptonRibbonGroupButton15_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton17.Click
        If ConsoleControl1.IsProcessRunning Then
            ConsoleControl1.StopProcess()
        End If
    End Sub

    Private Async Sub KryptonContextMenuItem6_Click(sender As Object, e As EventArgs)
        Dim id As Integer = tabsInversed.Item(CustomTabControl1.SelectedTab)
        Dim editor As FastColoredTextBox = editors.Item(id)
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "Fichiers HTML|*.html"
        saveFileDialog.Title = "Exporter en HTML"
        If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fileName As String
            fileName = saveFileDialog.FileName
            Using outputFile As New StreamWriter(fileName)
                Await outputFile.WriteAsync(editor.Html)
            End Using
            filesOpened.Item(id) = fileName
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton9_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton9.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        editor.BookmarkLine(editor.Selection.Start.iLine)
    End Sub

    Private Sub KryptonRibbonGroupButton10_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton10.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        editor.UnbookmarkLine(editor.Selection.Start.iLine)
    End Sub

    Private Sub KryptonRibbonGroupButton11_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton11.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        editor.ShowFindDialog()
    End Sub

    Private Sub KryptonRibbonGroupButton12_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton12.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        editor.ShowReplaceDialog()
    End Sub

    Private Sub KryptonRibbonGroupButton13_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton13.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        editor.ShowGoToDialog()
    End Sub

    Private Sub KryptonRibbonQATButton3_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton3.Click
        openNewTab()
    End Sub

    Private Sub KryptonRibbonQATButton4_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton4.Click
        OpenFile()
    End Sub

    Private Sub ButtonSpecAny2_Click(sender As Object, e As EventArgs) Handles ButtonSpecAny2.Click
        Process.Start("https://pyxel.amacz13.fr")
    End Sub

    Private Sub KryptonRibbonGroupButton4_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton4.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(CustomTabControl1.SelectedTab))
        editor.CollapseBlock(editor.Selection.Start.iLine, editor.Selection.End.iLine)
    End Sub

    Private Sub CustomTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CustomTabControl1.SelectedIndexChanged
        Me.Text = "PyXel IDE - " + CustomTabControl1.SelectedTab.Text
    End Sub

    'Private Sub KryptonTextBox1_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        consoleSender.WriteLine(KryptonTextBox1.Text)
    '        KryptonTextBox1.Text = ""
    '    End If
    'End Sub

End Class
