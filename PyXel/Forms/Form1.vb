Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports ComponentFactory.Krypton.Ribbon
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

    'ImagesLists
    Dim list As New ImageList
    Dim ImagesTreeView As New ImageList

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
        Dim lang As Languages = editorsLanguage.Item(editor)
        If filesOpened.Item(id) = "Sans Nom" Then
            Dim saveFileDialog As New SaveFileDialog
            Select Case lang
                Case Languages.Python
                    saveFileDialog.Filter = "Fichiers Python|*.py"
                    saveFileDialog.Title = "Enregistrer un fichier Python"
                Case Languages.HTML
                    saveFileDialog.Filter = "Fichiers HTML|*.html"
                    saveFileDialog.Title = "Enregistrer un fichier HTML"
                Case Languages.PHP
                    saveFileDialog.Filter = "Fichiers PHP|*.php"
                    saveFileDialog.Title = "Enregistrer un fichier PHP"
                Case Languages.JS
                    saveFileDialog.Filter = "Fichiers JS|*.js"
                    saveFileDialog.Title = "Enregistrer un fichier JS"

            End Select
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
        openFileDialog1.Filter = "Fichiers supportés par PyXel|*.pxl;*.py;*.html;*.php;*.js;*.php3;*.php5|Fichiers Python|*.py|Fichiers HTML|*.html|Fichiers PHP|*.php|Fichiers JS|*.js"
        openFileDialog1.Title = "Ouvrir un fichier"
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
                Dim ext As String = System.IO.Path.GetExtension(fileName)
                'MsgBox(ext)
                Dim editor As New FastColoredTextBox
                Dim lang As Languages
                Select Case ext
                    Case ".pxl"
                        Project.OpenProject(fileName)
                        Continue For
                    Case ".py"
                        lang = Languages.Python
                        newPage.ImageIndex = 5
                    Case ".html"
                        lang = Languages.HTML
                        editor.Language = Language.HTML
                        newPage.ImageIndex = 2
                    Case ".php"
                        lang = Languages.PHP
                        editor.Language = Language.PHP
                        newPage.ImageIndex = 3
                    Case ".js"
                        lang = Languages.JS
                        editor.Language = Language.JS
                        newPage.ImageIndex = 4
                End Select
                configEditor(editor, lang)
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
                If ApplicationSettings.recentDocs.Contains(fileName) Then
                    ApplicationSettings.recentDocs.Remove(fileName)
                End If
                AddRecentDoc(fileName)
            Next
        End If
    End Sub

    Private Sub OpenFile(fileName As String)
        If Not File.Exists(fileName) Then
            MsgBox("File not Found !")
            Exit Sub
        End If
        pages += 1
        pagesSaved.Add(pages, True)
        filesOpened.Add(pages, fileName)
        Dim newPage As New TabPage
        newPage.Text = System.IO.Path.GetFileName(fileName)
        Dim ext As String = System.IO.Path.GetExtension(fileName)
        'MsgBox(ext)
        Dim editor As New FastColoredTextBox
        Dim lang As Languages
        Select Case ext
            Case ".py"
                lang = Languages.Python
                newPage.ImageIndex = 5
            Case ".html"
                lang = Languages.HTML
                editor.Language = Language.HTML
                newPage.ImageIndex = 2
            Case ".php"
                lang = Languages.PHP
                editor.Language = Language.PHP
                newPage.ImageIndex = 3
            Case ".js"
                lang = Languages.JS
                editor.Language = Language.JS
                newPage.ImageIndex = 4
        End Select
        configEditor(editor, lang)
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
        If ApplicationSettings.recentDocs.Contains(fileName) Then
            ApplicationSettings.recentDocs.Remove(fileName)
        End If
        AddRecentDoc(fileName)
    End Sub

    Private Sub openNewTab(lang As Languages)
        If lang = Languages.Python Then
            Dim newPage As New TabPage
            newPage.Text = "Sans Nom"
            newPage.ImageIndex = 5
            'editor Configuration
            Dim editor As New FastColoredTextBox
            configEditor(editor, Languages.Python)


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
        ElseIf lang = Languages.HTML Then
            Dim newPage As New TabPage
            newPage.Text = "Sans Nom"
            newPage.ImageIndex = 2

            'editor Configuration
            Dim editor As New FastColoredTextBox
            configEditor(editor, Languages.HTML)
            editor.Language = Language.HTML

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
        ElseIf lang = Languages.PHP Then
            Dim newPage As New TabPage
            newPage.Text = "Sans Nom"
            newPage.ImageIndex = 3

            'editor Configuration
            Dim editor As New FastColoredTextBox
            configEditor(editor, Languages.PHP)
            editor.Language = Language.PHP

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
        ElseIf lang = Languages.JS Then
            Dim newPage As New TabPage
            newPage.Text = "Sans Nom"
            newPage.ImageIndex = 4

            'editor Configuration
            Dim editor As New FastColoredTextBox
            configEditor(editor, Languages.JS)
            editor.Language = Language.JS

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
        End If
    End Sub

    Private Sub configEditor(editor As FastColoredTextBox, lang As Languages)
        editorsLanguage.Add(editor, lang)
        editor.BackColor = ApplicationSettings.editorBackColor
        editor.ForeColor = ApplicationSettings.editorForeColor
        editor.ContextMenuStrip = ContextMenuStrip2
        editor.Dock = DockStyle.Fill
        editor.Font = ApplicationSettings.editorFont
        AddHandler editor.TextChanged, AddressOf TextChanged
        editor.AllowDrop = True
        AddHandler editor.DragEnter, AddressOf PyXelDragEnter
        AddHandler editor.DragDrop, AddressOf PyXelDragDrop
        If lang = Languages.Python Then
            editor.LeftBracket = "{"
            editor.RightBracket = "}"
            editor.LeftBracket2 = "("
            editor.RightBracket2 = ")"
            editor.AutoCompleteBrackets = True
            editor.CommentPrefix = "#"
            AddHandler editor.AutoIndentNeeded, AddressOf AutoIndent
            AddHandler editor.TextChangedDelayed, AddressOf fctb_TextChangedDelayed
        End If
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
        Dim lang As Languages = editorsLanguage.Item(sender)
        Select Case lang
            Case Languages.Python
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

                Dim popupMenu As AutocompleteMenu = New AutocompleteMenu(sender)
                Dim keywords As String() = {"print", "int", "input"}
                popupMenu.SearchPattern = "[\w\.:=!<>]"
                Dim items As New List(Of AutocompleteItem)()
                For Each item As String In keywords
                    items.Add(New AutocompleteItem(item))
                Next

                'set as autocomplete source
                popupMenu.Items.SetAutocompleteItems(items)
        End Select

    End Sub

    Private Sub AutoIndent(sender As Object, e As AutoIndentEventArgs)
        If e.LineText.Trim.Contains("def") Or e.LineText.Trim.Contains("if") Or e.LineText.Trim.Contains("else") Or e.LineText.Trim.Contains("elif") Or e.LineText.Trim.Contains("for") Or e.LineText.Trim.Contains("while") Then
            e.ShiftNextLines = e.TabLength
        End If
    End Sub

    Private Sub fctb_TextChangedDelayed(sender As Object, e As TextChangedEventArgs)
        Dim editor As FastColoredTextBox = sender
        editor.Range.ClearFoldingMarkers()
        Dim currentIndent As Integer = 0
        Dim lastNonEmptyLine As Integer = 0
        For i As Integer = 0 To editor.LinesCount - 1
            Dim line As Line = editor(i)
            Dim spacesCount As Integer = line.StartSpacesCount
            If spacesCount <> line.Count Then
                If currentIndent < spacesCount Then
                    editor(lastNonEmptyLine).FoldingStartMarker = "m" + currentIndent.ToString()
                Else
                    If currentIndent > spacesCount Then
                        editor(lastNonEmptyLine).FoldingEndMarker = "m" + spacesCount.ToString()
                    End If
                End If
                currentIndent = spacesCount
                lastNonEmptyLine = i
            End If
        Next
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
        Me.Icon = My.Resources.Pyxel_Icon
        'KryptonPalette1.Import(Application.StartupPath() + "\test.xml")

        'Adding Recent Documents
        KryptonRibbon1.RibbonAppButton.AppButtonShowRecentDocs = True
        ReloadRecentDocs()


        'Updating ImageList
        list.Images.Add(My.Resources.c16)
        list.Images.Add(My.Resources.css16)
        list.Images.Add(My.Resources.html16)
        list.Images.Add(My.Resources.php16)
        list.Images.Add(My.Resources.js16)
        list.Images.Add(My.Resources.python16)

        'Allow Dropping file into Ribbon and TabControl
        KryptonRibbon1.AllowDrop = True
        AddHandler KryptonRibbon1.DragEnter, AddressOf PyXelDragEnter
        AddHandler KryptonRibbon1.DragDrop, AddressOf PyXelDragDrop
        Me.AllowDrop = True
        CustomTabControl1.AllowDrop = True
        AddHandler CustomTabControl1.DragEnter, AddressOf PyXelDragEnter
        AddHandler CustomTabControl1.DragDrop, AddressOf PyXelDragDrop

        CustomTabControl1.ImageList = list
        KryptonRibbon1.AllowFormIntegrate = False
        KryptonRibbon1.SelectedContext = "Python"
        Me.TextExtra = My.Settings.Version
        pages = 0
        KryptonPanel1.Palette = KryptonPalette1
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme

        Dim newPage As New TabPage
        newPage.Text = "Sans Nom"
        newPage.ImageIndex = 5

        'Editor configuration
        Dim editor As New FastColoredTextBox
        configEditor(editor, Languages.Python)
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

        'Detect Windows version in order to purpose Edge on Windows 10 systems
        If My.Computer.Info.OSFullName.Contains("Windows 10") Then
            KryptonRibbonGroupButton21.ImageLarge = My.Resources.edge
            KryptonRibbonGroupButton21.ImageSmall = My.Resources.edge
            KryptonRibbonGroupButton21.TextLine1 = "Microsoft"
            KryptonRibbonGroupButton21.TextLine2 = "Edge"

        End If

        'Detect Installed Browsers
        If Not File.Exists("C:\Program Files\Mozilla Firefox\firefox.exe") Then
            KryptonRibbonGroupButton22.Enabled = False
            KryptonRibbonGroupButton22.ToolTipTitle = "Mozilla Firefox missing"
            KryptonRibbonGroupButton22.ToolTipBody = "Please install Mozilla Firefox and restart PyXel in order to preview your file in Mozilla Firefox."
        End If
        If Not File.Exists("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") Then
            KryptonRibbonGroupButton23.Enabled = False
            KryptonRibbonGroupButton23.ToolTipTitle = "Google Chrome missing"
            KryptonRibbonGroupButton23.ToolTipBody = "Please install Google Chrome and restart PyXel in order to preview your file in Google Chrome."
        End If
        If Not File.Exists("C:\Program Files\Opera\launcher.exe") Then
            KryptonRibbonGroupButton24.Enabled = False
            KryptonRibbonGroupButton24.ToolTipTitle = "Opera missing"
            KryptonRibbonGroupButton24.ToolTipBody = "Please install Opera and restart PyXel in order to preview your file in Opera."
        End If

        'Create ImageList for TreeView
        ImagesTreeView.Images.Add("c", My.Resources.c16)
        ImagesTreeView.Images.Add("css", My.Resources.css16)
        ImagesTreeView.Images.Add("html", My.Resources.html16)
        ImagesTreeView.Images.Add("php", My.Resources.php16)
        ImagesTreeView.Images.Add("js", My.Resources.js16)
        ImagesTreeView.Images.Add("py", My.Resources.python16)
        ImagesTreeView.Images.Add("file", My.Resources.new321)
        ImagesTreeView.Images.Add("folder", My.Resources.open321)
        ImagesTreeView.Images.Add("project", My.Resources.project161)
        KryptonTreeView1.ImageList = ImagesTreeView

        'Hiding Projects panel when no project is loaded
        KryptonSplitContainer2.Panel1Collapsed = True

        'Update Checking
        checkForUpdates()

        'ContextMenus Configuration
        CustomTabControl1.ContextMenuStrip = ContextMenuStrip1

    End Sub

    '
    'File Menu Subs
    '
    ' 1. New Project / File
    ' 2. Open
    ' 3. Save
    ' 4. Import
    ' 5. Export
    ' 6. Send
    ' 7. Print
    ' 8. Settings
    ' 9. About
    ' 10. Exit
    '

    '
    ' 1. New Project / File
    '

    '
    ' A. New File (Quick, create an empty file without syntax highlighting before the file is save)
    '

    Private Sub KryptonContextMenuItem1_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem1.Click
        openNewTab(Languages.Python)
    End Sub

    '
    ' B. New Project
    '

    Private Sub NewProjectClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem13.Click
        NewProjectWizard.ShowDialog()
    End Sub

    '
    ' C. New Python File
    '

    Private Sub NewPythonClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem7.Click
        'Create New Python File
        openNewTab(Languages.Python)
    End Sub

    '
    ' D. New HTML File
    '

    Private Sub NewHTMLClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem8.Click
        'Create New HTML File
        openNewTab(Languages.HTML)
    End Sub

    '
    ' E. New CSS File
    '

    Private Sub NewCSSClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem9.Click
        'Create New CSS File
        MsgBox("New CSS File")
    End Sub

    '
    ' F. New JS File
    '

    Private Sub NewJSClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem10.Click
        'Create New JS File
        openNewTab(Languages.JS)
    End Sub

    '
    ' G. New PHP File
    '

    Private Sub NewPHPClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem11.Click
        'Create New PHP File
        openNewTab(Languages.PHP)
    End Sub

    '
    ' H. New C File
    '

    Private Sub NewCClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem12.Click
        'Create New C File
        MsgBox("New C File")
    End Sub

    '
    ' I. New C++ File
    '

    Private Sub NewCPPClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem14.Click
        'Create New C++ File
        MsgBox("New C++ File")
    End Sub

    '
    ' I. New H File
    '

    Private Sub NewHClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem16.Click
        'Create New H File
        MsgBox("New H File")
    End Sub

    '
    ' 10. Exit Application
    '

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

    Private Sub KryptonContextMenuItem2_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem2.Click
        OpenFile()
    End Sub



    Private Async Sub KryptonContextMenuItem3_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem3.Click
        Await SavePage(tabsInversed.Item(CustomTabControl1.SelectedTab))
    End Sub

    Private Async Sub KryptonRibbonQATButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton1.Click
        Await SavePage(tabsInversed.Item(CustomTabControl1.SelectedTab))
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
            openNewTab(Languages.Python)
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
        Dim lang As Languages = editorsLanguage.Item(editor)
        Select Case lang
            Case Languages.PHP
            Case Languages.JS
            Case Languages.C
                If editor.SelectedText.Length = 0 Then
                    editor.InsertLinePrefix("//")
                ElseIf editor.GetLine(editor.Selection.Start.iLine).Text.Chars(0) = "//" Then
                    editor.RemoveLinePrefix("//")
                Else
                    editor.InsertLinePrefix("//")
                End If
            Case Languages.Python
                If editor.SelectedText.Length = 0 Then
                    editor.InsertLinePrefix("#")
                ElseIf editor.GetLine(editor.Selection.Start.iLine).Text.Chars(0) = "#" Then
                    editor.RemoveLinePrefix("#")
                Else
                    editor.InsertLinePrefix("#")
                End If
            Case Languages.HTML
                If editor.SelectedText.Length = 0 Then
                    editor.InsertLinePrefix("<!-- -->")
                End If
        End Select

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
        openNewTab(Languages.Python)
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
        Try
            Me.Text = "PyXel IDE - " + CustomTabControl1.SelectedTab.Text
        Catch
            Me.Text = "PyXel IDE"
        End Try

        Dim id As Integer = tabsInversed.Item(CustomTabControl1.SelectedTab)
        Dim editor As FastColoredTextBox = editors.Item(id)
        Dim lang As Languages = editorsLanguage.Item(editor)
        Select Case lang
            Case Languages.Python
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    KryptonRibbon1.SelectedContext = "Python,Projet"
                Else
                    KryptonRibbon1.SelectedContext = "Python"
                End If
                KryptonSplitContainer1.Panel2Collapsed = False
            Case Languages.HTML
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    KryptonRibbon1.SelectedContext = "HTML,Projet"
                Else
                    KryptonRibbon1.SelectedContext = "HTML"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.PHP
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    KryptonRibbon1.SelectedContext = "HTML,Projet"
                Else
                    KryptonRibbon1.SelectedContext = "HTML"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.JS
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    KryptonRibbon1.SelectedContext = "HTML,Projet"
                Else
                    KryptonRibbon1.SelectedContext = "HTML"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
        End Select
    End Sub

    'Open web file in IE
    Private Async Sub KryptonRibbonGroupButton21_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton21.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Vous devez sauvegarder ce fichier pour pouvoir l'ouvrir. Voulez-vous continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                Await SavePage(id)
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        If My.Computer.Info.OSFullName.Contains("Windows 10") Then
            System.Diagnostics.Process.Start("shell:Appsfolder\Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge", filesOpened(id))
        Else
            System.Diagnostics.Process.Start("iexplore.exe", filesOpened(id))
        End If
    End Sub

    'Open web file in Firefox
    Private Async Sub KryptonRibbonGroupButton22_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton22.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Vous devez sauvegarder ce fichier pour pouvoir l'ouvrir. Voulez-vous continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                Await SavePage(id)
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        'MsgBox(filesOpened(id))
        If Environment.Is64BitOperatingSystem Then
            Try
                System.Diagnostics.Process.Start("C:\Program Files\Mozilla Firefox\firefox.exe", "file:///" + filesOpened(id).Replace(" ", "%20"))
            Catch
                MsgBox("Pyxel only support version of Mozilla Firefox corresponding to your os architecture (64 bits here). Please install a 64 bits version of Mozilla Firefox !")
            End Try

        End If
    End Sub

    'Open web file in Chrome
    Private Async Sub KryptonRibbonGroupButton23_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton23.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Vous devez sauvegarder ce fichier pour pouvoir l'ouvrir. Voulez-vous continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                Await SavePage(id)
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        'MsgBox(filesOpened(id))
        System.Diagnostics.Process.Start("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "file:///" + filesOpened(id).Replace(" ", "%20"))
    End Sub

    'Open web file in Opera
    Private Async Sub KryptonRibbonGroupButton24_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton24.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Vous devez sauvegarder ce fichier pour pouvoir l'ouvrir. Voulez-vous continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                Await SavePage(id)
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        'MsgBox(filesOpened(id))
        If Environment.Is64BitOperatingSystem Then
            Try
                System.Diagnostics.Process.Start("C:\Program Files\Opera\launcher.exe", "file:///" + filesOpened(id).Replace(" ", "%20"))
            Catch
                MsgBox("Pyxel only support version of Opera corresponding to your os architecture (64 bits here). Please install a 64 bits version of Opera !")
            End Try

        End If
    End Sub

    Private Sub KryptonTreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles KryptonTreeView1.NodeMouseDoubleClick
        Dim clickedNode As TreeNode = e.Node
        If clickedNode.SelectedImageKey IsNot "project" And clickedNode.SelectedImageKey IsNot "folder" And clickedNode.SelectedImageKey IsNot "file" Then
            OpenFile(clickedNode.Tag)
        End If

    End Sub

    Private Sub PyXelDragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub PyXelDragDrop(sender As Object, e As DragEventArgs)
        Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
        For Each file In files
            OpenFile(file)
        Next
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F1 Then
            Help.Show()
        End If
    End Sub

    Private Sub openRecentDoc(sender As Object, e As EventArgs)
        Dim item As KryptonRibbonRecentDoc = sender
        OpenFile(item.Text)
    End Sub

    Private Sub ReloadRecentDocs()
        KryptonRibbon1.RibbonAppButton.AppButtonRecentDocs.Clear()

        Dim rcntDocs As ArrayList = ApplicationSettings.recentDocs
        rcntDocs.Reverse()
        For Each elem In rcntDocs
            If elem IsNot "" Then
                Dim item As New KryptonRibbonRecentDoc()
                item.Text = elem
                AddHandler item.Click, AddressOf openRecentDoc
                KryptonRibbon1.RibbonAppButton.AppButtonRecentDocs.Add(item)
            End If
        Next
    End Sub

    Private Sub AddRecentDoc(file As String)
        ApplicationSettings.recentDocs.Add(file)
        ReloadRecentDocs()
    End Sub

End Class
