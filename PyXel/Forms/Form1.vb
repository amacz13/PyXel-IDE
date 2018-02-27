Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text.RegularExpressions
Imports ComponentFactory.Krypton.Navigator
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

    'Variables Fichiers
    Dim isFileSet As Boolean = False
    Dim fileName As String = "Sans Nom"
    Dim isFileSaved As Boolean = True

    Dim inExec As Boolean = False

    'MultiEditor
    'Dim tabs As New Dictionary(Of Integer, KryptonPage)
    'Dim tabsInversed As New Dictionary(Of KryptonPage, Integer)
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
    Dim pages As New Integer
    Private WithEvents proc As New Process

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

    Private Sub KryptonContextMenuItem2_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem2.Click
        OpenFile()
    End Sub

    Private Sub FastColoredTextBox1_AutoIndentNeeded(sender As Object, e As AutoIndentEventArgs)
        If e.LineText.Trim.Contains("def") Or e.LineText.Trim.Contains("if") Or e.LineText.Trim.Contains("else") Or e.LineText.Trim.Contains("elif") Or e.LineText.Trim.Contains("for") Or e.LineText.Trim.Contains("while") Then
            e.ShiftNextLines = e.TabLength
        End If
    End Sub

    Private Sub FastColoredTextBox1_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim id As Integer = editorsInversed.Item(sender)
        'menus.Item(id).SearchPattern = e.ChangedRange.Text
        If Not firstLoad.Item(id) Then
            'menus.Item(id).Show()
            Dim tab As TabPage = tabs.Item(id)
            tab.Text = displayNames.Item(id) + "*"
            pagesSaved.Item(id) = False
            'If e.ChangedRange.Length > 0 Then
            'Me.Text = "PyXel - " + fileName + "*"
            'isFileSaved = False
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
        e.ChangedRange.SetStyle(salmonStyle, "(if\s|else(\s|\:)|elif\s|for\s|while\s)")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(34) + "(.*?)" + Chr(34) + "")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(39) + "(.*?)" + Chr(39) + "")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(44) + "(.*?)" + Chr(44) + "")
    End Sub

    Public Async Function SavePage(id As Integer) As Task
        Dim editor As FastColoredTextBox = editors.Item(id)
        If filesOpened.Item(id) = "Sans Nom" Then
            Dim saveFileDialog As New SaveFileDialog
            saveFileDialog.Filter = "Fichiers Python|*.py"
            saveFileDialog.Title = "Enregistrer un fichier Python"
            If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                fileName = saveFileDialog.FileName
                Using outputFile As New StreamWriter(fileName)
                    Await outputFile.WriteAsync(editor.Text)
                End Using
                pagesSaved.Item(id) = True
                filesOpened.Item(id) = fileName
                displayNames.Item(id) = System.IO.Path.GetFileName(fileName)
            End If
            tabs.Item(id).Text = System.IO.Path.GetFileName(fileName)
        Else
            Dim fileName As String = filesOpened.Item(id)
            Using outputFile As New StreamWriter(fileName)
                Await outputFile.WriteAsync(editor.Text)
            End Using
            pagesSaved.Item(id) = True
            tabs.Item(id).Text = displayNames.Item(id)
        End If
    End Function

    Private Async Sub KryptonContextMenuItem3_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem3.Click
        Await SavePage(tabsInversed.Item(CustomTabControl1.SelectedTab))
    End Sub

    Private Async Sub KryptonRibbonQATButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton1.Click
        Await SavePage(tabsInversed.Item(CustomTabControl1.SelectedTab))
    End Sub

    Private Sub KryptonContextMenuItem1_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem1.Click

        openNewTab()

    End Sub

    Private Sub OpenFile()
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Fichiers Python|*.py"
        openFileDialog1.Title = "Ouvrir un fichier Python"
        openFileDialog1.Multiselect = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            For x = 0 To openFileDialog1.FileNames.Count - 1
                fileName = openFileDialog1.FileNames(x)
                pages += 1
                pagesSaved.Add(pages, True)
                filesOpened.Add(pages, fileName)
                'Dim newPage As New KryptonPage
                'newPage.Text = fileName
                Dim newPage As New TabPage
                newPage.Text = System.IO.Path.GetFileName(fileName)
                Dim editor As New FastColoredTextBox
                'newPage.ImageLarge = My.Resources.new16
                'newPage.ImageMedium = My.Resources.new16
                'newPage.ImageSmall = My.Resources.new16
                displayNames.Add(pages, System.IO.Path.GetFileName(fileName))
                editor.Dock = DockStyle.Fill
                tabs.Add(pages, newPage)
                editors.Add(pages, editor)
                tabsInversed.Add(newPage, pages)
                editorsInversed.Add(editor, pages)
                AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged
                'KryptonDockableNavigator1.Pages.Add(newPage)
                'KryptonDockableNavigator1.NavigatorMode = NavigatorMode.BarRibbonTabGroup
                'KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
                CustomTabControl1.TabPages.Add(newPage)
                CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
                newPage.Controls.Add(editor)
                Dim menu As New AutocompleteMenu(editor)
                AutoCompleteTools.LoadDefaultItems(menu, Languages.Python)
                menus.Add(pages, menu)
                firstLoad.Add(pages, True)
                editor.OpenFile(fileName)
                'MsgBox(fileName)
            Next
        End If
    End Sub

    Private Sub openNewTab()
        'If isFileSaved = False Then
        'Dim msg As String
        'Dim title As String
        'Dim style As MsgBoxStyle
        'msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
        'style = MsgBoxStyle.YesNoCancel
        'title = "PyXel - Fichier non sauvegardé"
        'Dim result As MsgBoxResult = MsgBox(msg, style, title)
        'If result = MsgBoxResult.Yes Then
        'SaveFile()
        'ElseIf result = MsgBoxResult.Cancel Then
        'Exit Sub
        'End If
        'End If

        'isFileSet = False
        'fileName = "Sans Nom"
        'isFileSaved = True
        'FastColoredTextBox1.Text = ""
        'Dim newPage As New KryptonPage
        'newPage.Text = "Sans Nom"
        Dim newPage As New TabPage
        newPage.Text = "Sans Nom"

        'editor Configuration
        Dim editor As New FastColoredTextBox
        editor.BackColor = ApplicationSettings.editorBackColor
        editor.ForeColor = ApplicationSettings.editorForeColor
        editor.LeftBracket = "{"
        editor.RightBracket = "}"
        editor.LeftBracket2 = "("
        editor.RightBracket2 = ")"
        editor.AutoCompleteBrackets = True
        editor.CommentPrefix = "#"
        AddHandler editor.AutoIndentNeeded, AddressOf FastColoredTextBox1_AutoIndentNeeded
        AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged

        editor.Dock = DockStyle.Fill
        pages += 1
        Dim menu As New AutocompleteMenu(editor)
        AutoCompleteTools.LoadDefaultItems(menu, Languages.Python)
        menus.Add(pages, menu)
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged
        'KryptonDockableNavigator1.Pages.Add(newPage)
        'KryptonDockableNavigator1.NavigatorMode = NavigatorMode.BarRibbonTabGroup
        'KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
        CustomTabControl1.TabPages.Add(newPage)
        CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
        newPage.Controls.Add(editor)
        filesOpened.Add(pages, "Sans Nom")
        pagesSaved.Add(pages, True)
        displayNames.Add(pages, "Sans Nom")
        firstLoad.Add(pages, True)
        'Dim newform As New Form1
        'newform.Show()
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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        KryptonHeaderGroup1.Hide()
        KryptonTextBox1.Hide()
        KryptonRibbon1.SelectedContext = "Python"
        'FirstLaunchWizard.ShowDialog()
        Me.TextExtra = My.Settings.Version
        'ButtonSpecAny1.Visible = False
        pages = 0
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
        'Dim newPage As New KryptonPage
        'newPage.Text = "Sans Nom"

        Dim newPage As New TabPage
        newPage.Text = "Sans Nom"

        'Editor configuration
        Dim editor As New FastColoredTextBox
        editor.BackColor = ApplicationSettings.editorBackColor
        editor.ForeColor = ApplicationSettings.editorForeColor
        editor.LeftBracket = "{"
        editor.RightBracket = "}"
        editor.LeftBracket2 = "("
        editor.RightBracket2 = ")"
        editor.AutoCompleteBrackets = True
        editor.CommentPrefix = "#"
        AddHandler editor.AutoIndentNeeded, AddressOf FastColoredTextBox1_AutoIndentNeeded
        AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged

        'newPage.ImageLarge = My.Resources.new16
        'newPage.ImageMedium = My.Resources.new16
        'newPage.ImageSmall = My.Resources.new16
        editor.Dock = DockStyle.Fill
        pages += 1
        Dim menu As New AutocompleteMenu(editor)
        AutoCompleteTools.LoadDefaultItems(menu, Languages.Python)
        menus.Add(pages, menu)
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        'KryptonDockableNavigator1.Pages.Add(newPage)
        'KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
        CustomTabControl1.TabPages.Add(newPage)
        CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
        newPage.Controls.Add(editor)
        pagesSaved.Add(pages, True)
        firstLoad.Add(pages, True)
        If ApplicationSettings.isFileOpened = True Then
            filesOpened.Add(pages, ApplicationSettings.fileOpened)
            displayNames.Add(pages, System.IO.Path.GetFileName(ApplicationSettings.fileOpened))
            Dim sr As New System.IO.StreamReader(ApplicationSettings.fileOpened)
            editor.Text = sr.ReadToEnd
            sr.Close()
        Else
            filesOpened.Add(pages, "Sans Nom")
            displayNames.Add(pages, "Sans Nom")
        End If
        'Dim x As Integer
        'For x = 0 To My.Computer.FileSystem.Drives.Count - 1
        '    If My.Computer.FileSystem.Drives(x).IsReady = True Then
        '        KryptonTreeView1.Nodes.Add(My.Computer.FileSystem.Drives(x).Name, My.Computer.FileSystem.Drives(x).Name)
        '        KryptonTreeView1.Nodes(My.Computer.FileSystem.Drives(x).Name).Tag = My.Computer.FileSystem.Drives(x).Name
        '        For Each SubDirectory As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.Drives(x).Name)
        '            KryptonTreeView1.Nodes(x).Nodes.Add(SubDirectory, Mid(SubDirectory, 4))
        '            KryptonTreeView1.Nodes(x).Nodes(SubDirectory).Tag = SubDirectory
        '        Next
        '    End If
        'Next
        FastColoredTextBox1.BackColor = ApplicationSettings.interpreterBackColor
        FastColoredTextBox1.ForeColor = ApplicationSettings.interpreterForeColor
        Try
            If (File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")) Then
                System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            End If
            My.Computer.Network.DownloadFile("https://amacz13.fr/files/pyxel/currentversion.txt", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            Dim versionReader As New System.IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            Dim version As String = versionReader.ReadToEnd
            'MsgBox("Down : " + version.Length.ToString + " / Current : " + My.Settings.Version.Length.ToString)
            versionReader.Close()
            If String.Compare(My.Settings.Version, version) = 0 Then
                ButtonSpecAny2.Visible = False
            Else
                ButtonSpecAny2.Text = version
                ButtonSpecAny2.Visible = True
            End If


            'MsgBox(version)
        Catch
            'No Internet Connection
            'MsgBox("No Internet !")
            ButtonSpecAny2.Visible = False
        End Try
    End Sub



    Private Async Sub KryptonRibbonGroupButton14_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton14.Click
        If ApplicationSettings.python3 = "none" Then
            MessageBox.Show("Veuillez configurer l'emplacement de l'exécutable Python", "Exécutable Python introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Settings.ShowDialog()
        Else
            'Dim page As KryptonPage = KryptonDockableNavigator1.SelectedPage
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
            'MessageBox.Show(My.Settings.PythonPath + " " + fileName, "Début exec", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            If inExec Then
                proc.CancelOutputRead()
                proc.Kill()
                KryptonRibbonGroupButton14.Enabled = True
                inExec = False
            End If
            proc.StartInfo.FileName = ApplicationSettings.python3 '+ " " + fileName
            proc.StartInfo.Arguments = filesOpened(id)
            proc.StartInfo.CreateNoWindow = True
            proc.StartInfo.UseShellExecute = False
            proc.EnableRaisingEvents = True 'Use this if you want to receive the ProcessExited event
            proc.StartInfo.RedirectStandardOutput = True
            proc.Start()
            proc.BeginOutputReadLine()
            'KryptonRibbonGroupButton4.Enabled = False
            inExec = True
            'Do While inExec

            'Loop

            'KryptonRibbonGroupButton4.Enabled = True
            'Shell(My.Settings.PythonPath + " " + fileName)
        End If
    End Sub

    Private Sub proc_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles proc.Exited
        inExec = False
        proc.CancelOutputRead()
    End Sub

    Private Sub proc_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles proc.OutputDataReceived
        If e.Data <> Nothing Then
            Invoke(New OutputRecievedDel(AddressOf OutputRecieved), e.Data)
        End If
    End Sub

    Private Delegate Sub OutputRecievedDel(ByVal out As String)

    Private Sub OutputRecieved(ByVal out As String)
        'FastColoredTextBox1.Lines.Add(out)
        FastColoredTextBox1.Text += vbNewLine + out
        'MessageBox.Show(out, "Données recues", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Private Sub KryptonRibbonGroupButton5_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton16.Click
        If ApplicationSettings.python3 = "none" Then
            MessageBox.Show("Veuillez configurer l'emplacement de l'exécutable Python", "Exécutable Python introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Settings.ShowDialog()
        Else
            Shell(ApplicationSettings.python3)
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton2_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton2.Click
        'Dim tab As KryptonPage = KryptonDockableNavigator1.SelectedPage
        'Dim id As Integer = tabsInversed.Item(tab)
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Cut()

    End Sub

    Private Sub KryptonRibbonGroupButton3_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton3.Click
        'Dim tab As KryptonPage = KryptonDockableNavigator1.SelectedPage
        'Dim id As Integer = tabsInversed.Item(tab)
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Copy()
    End Sub

    Private Sub KryptonRibbonGroupButton6_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton6.Click
        'Dim tab As KryptonPage = KryptonDockableNavigator1.SelectedPage
        'Dim id As Integer = tabsInversed.Item(tab)
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
        'Dim page As KryptonPage = KryptonDockableNavigator1.SelectedPage
        'e.Cancel = True
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
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
        firstLoad.Remove(id)
        If CustomTabControl1.TabCount = 1 Then
            openNewTab()
        End If
        'If KryptonDockableNavigator1.Pages.Count = 2 Then
        'KryptonDockableNavigator1.NavigatorMode = NavigatorMode.Group
        'End If
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

    'New Python 3 interpreter
    'Private Sub KryptonContextMenuItem8_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem8.Click
    '    Dim newPage As New KryptonPage
    '    newPage.Text = "Interpréteur Python 3"
    '    Dim textbox As New TextBox
    '    Dim editor As New FastColoredTextBox
    '    editor.BackColor = Color.Black
    '    editor.ForeColor = Color.White
    '    newPage.ImageLarge = My.Resources.console16
    '    newPage.ImageMedium = My.Resources.console16
    '    newPage.ImageSmall = My.Resources.console16
    '    textbox.Dock = DockStyle.Bottom
    '    editor.Dock = DockStyle.Fill
    '    editor.ReadOnly = True
    '    pages += 1
    '    tabs.Add(pages, newPage)
    '    editors.Add(pages, editor)
    '    tabsInversed.Add(newPage, pages)
    '    editorsInversed.Add(editor, pages)
    '    'AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged
    '    KryptonDockableNavigator1.Pages.Add(newPage)
    '    KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
    '    newPage.Controls.Add(textbox)
    '    newPage.Controls.Add(editor)
    '    KryptonRibbon1.SelectedContext = "Console"
    '    Dim NewProcess As New System.Diagnostics.Process()
    '    With NewProcess.StartInfo
    '        .FileName = My.Settings.PythonPath
    '        .RedirectStandardOutput = True
    '        .RedirectStandardError = True
    '        .RedirectStandardInput = True
    '        .UseShellExecute = False
    '        .WindowStyle = ProcessWindowStyle.Hidden
    '        .CreateNoWindow = False
    '    End With


    '    interpretersOutputs.Add(pages, editor)
    '    interpretersProcess.Add(pages, NewProcess)
    '    interpretersProcessInverted.Add(NewProcess, pages)

    '    ' Set our event handler to asynchronously read the sort output.
    '    AddHandler NewProcess.OutputDataReceived, AddressOf OutputHandler
    '    NewProcess.Start()
    '    NewProcess.BeginOutputReadLine()

    '    'NewProcess.WaitForExit()
    'End Sub

    Private Sub KryptonRibbonGroupButton15_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton17.Click
        If inExec Then
            proc.CancelOutputRead()
            proc.Kill()
            KryptonRibbonGroupButton14.Enabled = True
            inExec = False
        End If
    End Sub

    Private Async Sub KryptonContextMenuItem6_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem6.Click
        Dim id As Integer = tabsInversed.Item(CustomTabControl1.SelectedTab)
        Dim editor As FastColoredTextBox = editors.Item(id)
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "Fichiers HTML|*.html"
        saveFileDialog.Title = "Exporter en HTML"
        If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            fileName = saveFileDialog.FileName
            Using outputFile As New StreamWriter(fileName)
                Await outputFile.WriteAsync(editor.Html)
            End Using
            pagesSaved.Item(id) = True
            filesOpened.Item(id) = fileName
        End If
        tabs.Item(id).Text = fileName
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
End Class
