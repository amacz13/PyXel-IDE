Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports ComponentFactory.Krypton.Ribbon
Imports ComponentFactory.Krypton.Toolkit
Imports FastColoredTextBoxNS
Imports MyAPKapp.VistaUIFramework.TaskDialog

Public Class MainForm

    Enum Languages
        Python
        C
        CPP
        HTML
        XML
        PHP
        JS
        CSS
        Lua
        CSharp
        VBNet
        XAML
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

    '
    ' Loading translations strings
    '
    Public Shared Sub ApplyStrings()
        MainForm.KryptonRibbon1.RibbonAppButton.AppButtonText = PyXelTranslations.strings.Item("menu")
        MainForm.KryptonRibbon1.RibbonStrings.RecentDocuments = PyXelTranslations.strings.Item("recent_docs")
        MainForm.KryptonRibbon1.RibbonStrings.ShowAboveRibbon = PyXelTranslations.strings.Item("show_above_ribbon")
        MainForm.KryptonRibbon1.RibbonStrings.ShowBelowRibbon = PyXelTranslations.strings.Item("show_below_ribbon")
        MainForm.KryptonRibbon1.RibbonStrings.ShowQATAboveRibbon = PyXelTranslations.strings.Item("show_qat_above")
        MainForm.KryptonRibbon1.RibbonStrings.ShowQATBelowRibbon = PyXelTranslations.strings.Item("show_qat_below")
        MainForm.KryptonRibbonQATButton3.Text = PyXelTranslations.strings.Item("new")
        MainForm.KryptonRibbonQATButton3.ToolTipTitle = PyXelTranslations.strings.Item("new")
        MainForm.KryptonRibbonQATButton4.Text = PyXelTranslations.strings.Item("open")
        MainForm.KryptonRibbonQATButton4.ToolTipTitle = PyXelTranslations.strings.Item("open")
        MainForm.KryptonRibbonQATButton1.Text = PyXelTranslations.strings.Item("save")
        MainForm.KryptonRibbonQATButton1.ToolTipTitle = PyXelTranslations.strings.Item("save")
        MainForm.KryptonRibbonQATButton5.Text = PyXelTranslations.strings.Item("back")
        MainForm.KryptonRibbonQATButton5.ToolTipTitle = PyXelTranslations.strings.Item("back")
        MainForm.KryptonRibbonQATButton6.Text = PyXelTranslations.strings.Item("forward")
        MainForm.KryptonRibbonQATButton6.ToolTipTitle = PyXelTranslations.strings.Item("forward")
        MainForm.KryptonContextMenuItem1.Text = PyXelTranslations.strings.Item("new")
        MainForm.KryptonContextMenuHeading4.Text = PyXelTranslations.strings.Item("project")
        MainForm.KryptonContextMenuItem13.Text = PyXelTranslations.strings.Item("new_project")
        MainForm.KryptonContextMenuItem7.Text = PyXelTranslations.strings.Item("python_file")
        MainForm.KryptonContextMenuItem8.Text = PyXelTranslations.strings.Item("html_file")
        MainForm.KryptonContextMenuItem9.Text = PyXelTranslations.strings.Item("css_file")
        MainForm.KryptonContextMenuItem10.Text = PyXelTranslations.strings.Item("js_file")
        MainForm.KryptonContextMenuItem11.Text = PyXelTranslations.strings.Item("php_file")
        MainForm.KryptonContextMenuItem27.Text = PyXelTranslations.strings.Item("xml_file")
        MainForm.KryptonContextMenuItem12.Text = PyXelTranslations.strings.Item("c_file")
        MainForm.KryptonContextMenuItem14.Text = PyXelTranslations.strings.Item("cpp_file")
        MainForm.KryptonContextMenuItem6.Text = PyXelTranslations.strings.Item("csharp_file")
        MainForm.KryptonContextMenuItem16.Text = PyXelTranslations.strings.Item("vb_file")
        MainForm.KryptonContextMenuItem28.Text = PyXelTranslations.strings.Item("xaml_file")
        MainForm.KryptonContextMenuItem2.Text = PyXelTranslations.strings.Item("open")
        MainForm.KryptonContextMenuItem3.Text = PyXelTranslations.strings.Item("save")
        MainForm.KryptonContextMenuItem18.Text = PyXelTranslations.strings.Item("import")
        MainForm.KryptonContextMenuItem19.Text = PyXelTranslations.strings.Item("export")
        MainForm.KryptonContextMenuItem21.Text = PyXelTranslations.strings.Item("pdf_file")
        MainForm.KryptonContextMenuItem22.Text = PyXelTranslations.strings.Item("word_file")
        MainForm.KryptonContextMenuItem23.Text = PyXelTranslations.strings.Item("html_file")
        MainForm.KryptonContextMenuItem4.Text = PyXelTranslations.strings.Item("settings")
        MainForm.ButtonSpecAppMenu1.Text = PyXelTranslations.strings.Item("about")
        MainForm.ButtonSpecAppMenu2.Text = PyXelTranslations.strings.Item("quit")
        MainForm.KryptonRibbonTab1.Text = PyXelTranslations.strings.Item("tab_Home")
        MainForm.KryptonRibbonGroupButton2.TextLine1 = PyXelTranslations.strings.Item("cut")
        MainForm.KryptonRibbonGroupButton3.TextLine1 = PyXelTranslations.strings.Item("copy")
        MainForm.KryptonRibbonGroupButton6.TextLine1 = PyXelTranslations.strings.Item("paste")
        MainForm.KryptonRibbonGroup1.TextLine1 = PyXelTranslations.strings.Item("code")
        MainForm.KryptonRibbonGroupButton1.TextLine1 = PyXelTranslations.strings.Item("comment")
        MainForm.KryptonRibbonGroupButton9.TextLine1 = PyXelTranslations.strings.Item("create_Bookmark_1")
        MainForm.KryptonRibbonGroupButton9.TextLine2 = PyXelTranslations.strings.Item("create_Bookmark_2")
        MainForm.KryptonRibbonGroupButton10.TextLine1 = PyXelTranslations.strings.Item("remove_Bookmark_1")
        MainForm.KryptonRibbonGroupButton10.TextLine2 = PyXelTranslations.strings.Item("remove_Bookmark_2")
        MainForm.KryptonRibbonGroupButton11.TextLine1 = PyXelTranslations.strings.Item("find")
        MainForm.KryptonRibbonGroupButton12.TextLine1 = PyXelTranslations.strings.Item("find_replace_1")
        MainForm.KryptonRibbonGroupButton12.TextLine2 = PyXelTranslations.strings.Item("find_replace_2")
        MainForm.KryptonRibbonGroupButton13.TextLine1 = PyXelTranslations.strings.Item("go_to_line_1")
        MainForm.KryptonRibbonGroupButton13.TextLine2 = PyXelTranslations.strings.Item("go_to_line_2")
        MainForm.KryptonRibbonGroupButton4.TextLine1 = PyXelTranslations.strings.Item("collapse")
        MainForm.KryptonRibbonTab2.Text = PyXelTranslations.strings.Item("tab_Debug")
        MainForm.KryptonRibbonTab7.Text = PyXelTranslations.strings.Item("tab_Python")
        MainForm.KryptonRibbonGroupButton14.TextLine1 = PyXelTranslations.strings.Item("execute")
        MainForm.KryptonRibbonGroupButton16.TextLine1 = PyXelTranslations.strings.Item("console")
        MainForm.KryptonRibbonGroupButton17.TextLine1 = PyXelTranslations.strings.Item("stop_execution_1")
        MainForm.KryptonRibbonGroupButton17.TextLine2 = PyXelTranslations.strings.Item("stop_execution_2")
        MainForm.KryptonRibbonGroupButton18.TextLine1 = PyXelTranslations.strings.Item("execute")
        MainForm.KryptonRibbonGroupButton19.TextLine1 = PyXelTranslations.strings.Item("console")
        MainForm.KryptonRibbonGroupButton20.TextLine1 = PyXelTranslations.strings.Item("stop_execution_1")
        MainForm.KryptonRibbonGroupButton20.TextLine2 = PyXelTranslations.strings.Item("stop_execution_2")
        MainForm.KryptonRibbonTab8.Text = PyXelTranslations.strings.Item("tab_Web")
        MainForm.KryptonRibbonGroup7.TextLine1 = PyXelTranslations.strings.Item("preview")
        MainForm.KryptonRibbonTab3.Text = PyXelTranslations.strings.Item("tab_C")
        MainForm.KryptonRibbonGroup8.TextLine1 = PyXelTranslations.strings.Item("compilation")
        MainForm.KryptonRibbonGroupButton25.TextLine1 = PyXelTranslations.strings.Item("compile")
        MainForm.KryptonRibbonGroupButton26.TextLine1 = PyXelTranslations.strings.Item("execute")
        MainForm.KryptonHeaderGroup1.ValuesPrimary.Heading = PyXelTranslations.strings.Item("projects")
        MainForm.ToolStripMenuItem1.Text = PyXelTranslations.strings.Item("close_tab")
        MainForm.ToolStripMenuItem2.Text = PyXelTranslations.strings.Item("cut")
        MainForm.ToolStripMenuItem3.Text = PyXelTranslations.strings.Item("copy")
        MainForm.ToolStripMenuItem4.Text = PyXelTranslations.strings.Item("paste")
        MainForm.ToolStripMenuItem5.Text = PyXelTranslations.strings.Item("back")
        MainForm.ToolStripMenuItem6.Text = PyXelTranslations.strings.Item("forward")
    End Sub

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
        If filesOpened.Item(id) = PyXelTranslations.strings.Item("untitled") Then
            Dim saveFileDialog As New SaveFileDialog
            saveFileDialog.Title = PyXelTranslations.strings.Item("save_file")
            Select Case lang
                Case Languages.Python
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("python_file") + "|*.py"
                Case Languages.HTML
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("html_file") + "|*.html"
                Case Languages.XML
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("xml_file") + "|*.xml"
                Case Languages.PHP
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("php_file") + "|*.php"
                Case Languages.JS
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("js_file") + "|*.js"
                Case Languages.CSS
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("css_file") + "|*.css"
                Case Languages.C
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("c_file") + "*.c|" + PyXelTranslations.strings.Item("h_file") + "|*.h"
                Case Languages.CPP
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("cpp_file") + "*.cpp|" + PyXelTranslations.strings.Item("h_file") + "|*.h"
                Case Languages.CSharp
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("csharp_file") + "*.cs|"
                Case Languages.VBNet
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("vb_file") + "*.vb|"
                Case Languages.XAML
                    saveFileDialog.Filter = PyXelTranslations.strings.Item("xaml_file") + "*.xaml|"

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
        openFileDialog1.Filter = PyXelTranslations.strings.Item("pyxel_supported_files") + "|*.pxl;*.py;*.html;*.xml;*.php;*.js;*.php3;*.php5;*.css;*.c;*.cpp;*.h;*.cs;*.vb;*.xaml|" + PyXelTranslations.strings.Item("python_file") + "|*.py|" + PyXelTranslations.strings.Item("html_file") + "|*.html|" + PyXelTranslations.strings.Item("php_file") + "|*.php|" + PyXelTranslations.strings.Item("js_file") + "|*.js|" + PyXelTranslations.strings.Item("css_file") + "|*.css|" + PyXelTranslations.strings.Item("c_file") + "|*.c;*.h|" + PyXelTranslations.strings.Item("cpp_file") + "|*.cpp;*.h|" + PyXelTranslations.strings.Item("csharp_file") + "|*.cs|" + PyXelTranslations.strings.Item("vb_file") + "|*.vb|" + PyXelTranslations.strings.Item("xaml_file") + "|*.xaml"
        openFileDialog1.Title = PyXelTranslations.strings.Item("open_files")
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
                Dim splitter As New KryptonSplitContainer
                splitter.Dock = DockStyle.Fill
                AddHandler splitter.SplitterMoved, AddressOf SplitterMoved
                Dim editor As New FastColoredTextBox
                Dim map As New DocumentMap
                map.Target = editor
                splitter.SplitterDistance = ApplicationSettings.splitterDistance
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
                    Case ".xml"
                        lang = Languages.XML
                        editor.Language = Language.XML
                        newPage.ImageIndex = 7
                    Case ".php"
                        lang = Languages.PHP
                        editor.Language = Language.PHP
                        newPage.ImageIndex = 3
                    Case ".js"
                        lang = Languages.JS
                        editor.Language = Language.JS
                        newPage.ImageIndex = 4
                    Case ".css"
                        lang = Languages.CSS
                        newPage.ImageIndex = 1
                    Case ".cpp"
                        lang = Languages.CPP
                        editor.Language = Language.CSharp
                        newPage.ImageIndex = 6
                    Case ".c"
                    Case ".h"
                        lang = Languages.C
                        editor.Language = Language.CSharp
                        newPage.ImageIndex = 0
                    Case ".cs"
                        lang = Languages.CSharp
                        editor.Language = Language.CSharp
                        newPage.ImageIndex = 8
                    Case ".vb"
                        lang = Languages.VBNet
                        editor.Language = Language.VB
                        newPage.ImageIndex = 9
                    Case ".xaml"
                        lang = Languages.XAML
                        editor.Language = Language.HTML
                        newPage.ImageIndex = 10
                End Select
                configEditor(editor, lang)
                displayNames.Add(pages, System.IO.Path.GetFileName(fileName))
                map.Dock = DockStyle.Fill
                editor.Dock = DockStyle.Fill
                tabs.Add(pages, newPage)
                editors.Add(pages, editor)
                tabsInversed.Add(newPage, pages)
                editorsInversed.Add(editor, pages)
                CustomTabControl1.TabPages.Add(newPage)
                CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
                splitter.Panel1.Controls.Add(editor)
                splitter.Panel2.Controls.Add(map)
                newPage.Controls.Add(splitter)
                Dim menu As New AutocompleteMenu(editor)
                AutoCompleteTools.LoadDefaultItems(menu, lang)
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
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("file_not_found")
            td.Content = PyXelTranslations.strings.Item("cannot_find_file") + ":" + vbNewLine + fileName
            td.ShowDialog()
            Exit Sub
        End If
        pages += 1
        pagesSaved.Add(pages, True)
        filesOpened.Add(pages, fileName)
        Dim newPage As New TabPage
        newPage.Text = System.IO.Path.GetFileName(fileName)
        Dim ext As String = System.IO.Path.GetExtension(fileName)
        'MsgBox(ext)
        Dim splitter As New KryptonSplitContainer
        splitter.Dock = DockStyle.Fill
        AddHandler splitter.SplitterMoved, AddressOf SplitterMoved
        Dim editor As New FastColoredTextBox
        Dim map As New DocumentMap
        map.Target = editor
        splitter.SplitterDistance = ApplicationSettings.splitterDistance
        Dim lang As Languages
        Select Case ext
            Case ".py"
                lang = Languages.Python
                newPage.ImageIndex = 5
            Case ".html"
                lang = Languages.HTML
                editor.Language = Language.HTML
                newPage.ImageIndex = 2
            Case ".xml"
                lang = Languages.XML
                editor.Language = Language.XML
                newPage.ImageIndex = 7
            Case ".php"
                lang = Languages.PHP
                editor.Language = Language.PHP
                newPage.ImageIndex = 3
            Case ".js"
                lang = Languages.JS
                editor.Language = Language.JS
                newPage.ImageIndex = 4
            Case ".css"
                lang = Languages.CSS
                newPage.ImageIndex = 1
            Case ".cpp"
                lang = Languages.CPP
                editor.Language = Language.CSharp
                newPage.ImageIndex = 6
            Case ".c"
            Case ".h"
                lang = Languages.C
                editor.Language = Language.CSharp
                newPage.ImageIndex = 0
            Case ".cs"
                lang = Languages.CSharp
                editor.Language = Language.CSharp
                newPage.ImageIndex = 8
            Case ".vb"
                lang = Languages.VBNet
                editor.Language = Language.VB
                newPage.ImageIndex = 9
            Case ".xaml"
                lang = Languages.XAML
                editor.Language = Language.HTML
                newPage.ImageIndex = 10
        End Select
        configEditor(editor, lang)
        displayNames.Add(pages, System.IO.Path.GetFileName(fileName))
        map.Dock = DockStyle.Fill
        editor.Dock = DockStyle.Fill
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        CustomTabControl1.TabPages.Add(newPage)
        CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
        splitter.Panel1.Controls.Add(editor)
        splitter.Panel2.Controls.Add(map)
        newPage.Controls.Add(splitter)
        Dim menu As New AutocompleteMenu(editor)
        AutoCompleteTools.LoadDefaultItems(menu, lang)
        menus.Add(pages, menu)
        firstLoad.Add(pages, True)
        editor.OpenFile(fileName)
        If ApplicationSettings.recentDocs.Contains(fileName) Then
            ApplicationSettings.recentDocs.Remove(fileName)
        End If
        AddRecentDoc(fileName)
    End Sub

    Private Sub openNewTab(lang As Languages)
        Dim splitter As New KryptonSplitContainer
        splitter.Dock = DockStyle.Fill
        AddHandler splitter.SplitterMoved, AddressOf SplitterMoved
        Dim editor As New FastColoredTextBox
        Dim map As New DocumentMap
        map.Target = editor
        splitter.SplitterDistance = ApplicationSettings.splitterDistance
        map.Dock = DockStyle.Fill
        editor.Dock = DockStyle.Fill
        Dim newPage As New TabPage
        newPage.Text = PyXelTranslations.strings.Item("untitled")
        configEditor(editor, lang)
        Select Case lang
            Case Languages.Python
                newPage.ImageIndex = 5
            Case Languages.HTML
                newPage.ImageIndex = 2
                editor.Language = Language.HTML
            Case Languages.XML
                newPage.ImageIndex = 7
                editor.Language = Language.XML
            Case Languages.PHP
                newPage.ImageIndex = 3
                editor.Language = Language.PHP
            Case Languages.JS
                newPage.ImageIndex = 4
                editor.Language = Language.JS
            Case Languages.CSS
                newPage.ImageIndex = 1
            Case Languages.C
                newPage.ImageIndex = 0
                editor.Language = Language.CSharp
            Case Languages.CPP
                newPage.ImageIndex = 6
                editor.Language = Language.CSharp
            Case Languages.CSharp
                newPage.ImageIndex = 8
                editor.Language = Language.CSharp
            Case Languages.VBNet
                newPage.ImageIndex = 9
                editor.Language = Language.VB
            Case Languages.XAML
                newPage.ImageIndex = 10
                editor.Language = Language.HTML
        End Select
        pages += 1
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        CustomTabControl1.TabPages.Add(newPage)
        CustomTabControl1.SelectedIndex = CustomTabControl1.TabCount - 1
        splitter.Panel1.Controls.Add(editor)
        splitter.Panel2.Controls.Add(map)
        newPage.Controls.Add(splitter)
        Dim menu As New AutocompleteMenu(editor)
        AutoCompleteTools.LoadDefaultItems(menu, lang)
        menus.Add(pages, menu)
        filesOpened.Add(pages, PyXelTranslations.strings.Item("untitled"))
        pagesSaved.Add(pages, True)
        displayNames.Add(pages, PyXelTranslations.strings.Item("untitled"))
        firstLoad.Add(pages, True)
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
        AddHandler editor.KeyDown, AddressOf CloseTabShortcut
        Select Case lang
            Case Languages.Python
                editor.LeftBracket = "{"
                editor.RightBracket = "}"
                editor.LeftBracket2 = "("
                editor.RightBracket2 = ")"
                editor.AutoCompleteBrackets = True
                editor.CommentPrefix = "#"
                AddHandler editor.AutoIndentNeeded, AddressOf AutoIndent
                AddHandler editor.TextChangedDelayed, AddressOf fctb_TextChangedDelayed
                AddHandler editor.TextChanged, AddressOf PythonHighlight
            Case Languages.CSS
                editor.LeftBracket = "{"
                editor.RightBracket = "}"
                editor.LeftBracket2 = "("
                editor.RightBracket2 = ")"
                editor.AutoCompleteBrackets = True
                editor.CommentPrefix = "#"
                AddHandler editor.AutoIndentNeeded, AddressOf AutoIndent
                AddHandler editor.TextChanged, AddressOf CSSHighlight
        End Select
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
    End Sub

    Private Sub AutoIndent(sender As Object, e As AutoIndentEventArgs)
        Dim lang As Languages = editorsLanguage.Item(sender)
        Select Case lang
            Case Languages.Python
                If e.LineText.Trim.Contains("def") Or e.LineText.Trim.Contains("if") Or e.LineText.Trim.Contains("else") Or e.LineText.Trim.Contains("elif") Or e.LineText.Trim.Contains("for") Or e.LineText.Trim.Contains("while") Then
                    e.ShiftNextLines = e.TabLength
                End If
            Case Languages.CSS
                If e.LineText.Trim.Contains("{") Then
                    e.ShiftNextLines = e.TabLength
                ElseIf e.LineText.Trim.Contains("}") Then
                    e.ShiftNextLines = -e.TabLength
                End If
        End Select

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
            If ApplicationSettings.updateCanal = "Stable" Then
                My.Computer.Network.DownloadFile("https://amacz13.fr/files/pyxel/currentversion.txt", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            Else
                My.Computer.Network.DownloadFile("https://amacz13.fr/files/pyxel/insiderversion.txt", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            End If
            Dim versionReader As New System.IO.StreamReader(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\currentversion.txt")
            Dim version As String = versionReader.ReadToEnd
            versionReader.Close()
            If String.Compare(My.Settings.Version, version) = 0 Then
                ButtonSpecAny2.Visible = False
            Else
                ButtonSpecAny2.Text = version
                ButtonSpecAny2.Visible = True
                If ApplicationSettings.updateType = "Normal" Then
                    Dim td As New TaskDialog
                    td.CommonButtons = TaskDialogCommonButton.OK
                    td.StandardIcon = TaskDialogIcon.ShieldOK
                    td.WindowTitle = "PyXel"
                    td.MainInstruction = PyXelTranslations.strings.Item("update_available")
                    td.Content = PyXelTranslations.strings.Item("version") + " " + version + " " + PyXelTranslations.strings.Item("available") + " !"
                    td.ShowDialog()
                    'MsgBox("La version " + version + " de PyXel est disponible !", MsgBoxStyle.Information, "PyXel - Mise à jour disponible")
                End If
            End If
        Catch
            ButtonSpecAny2.Visible = False
        End Try
    End Sub

    'Form Loading Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ApplyStrings()

        ButtonSpecAny2.Visible = False
        Me.Icon = My.Resources.Pyxel_Icon
        'KryptonPalette1.Import(Application.StartupPath() + "\test.xml")

        'Adding Recent Documents
        KryptonRibbon1.RibbonAppButton.AppButtonShowRecentDocs = True
        KryptonRibbon1.RibbonAppButton.AppButtonMinRecentSize = New Size(KryptonRibbon1.RibbonAppButton.AppButtonMinRecentSize.Width, 400)
        ReloadRecentDocs()

        'Updating ImageList
        list.Images.Add(My.Resources.c16)
        list.Images.Add(My.Resources.css16)
        list.Images.Add(My.Resources.html16)
        list.Images.Add(My.Resources.php16)
        list.Images.Add(My.Resources.js16)
        list.Images.Add(My.Resources.python16)
        list.Images.Add(My.Resources.cpp16)
        list.Images.Add(My.Resources.xml16)
        list.Images.Add(My.Resources.csharp16)
        list.Images.Add(My.Resources.vb16)
        list.Images.Add(My.Resources.xaml16)

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
        newPage.Text = PyXelTranslations.strings.Item("untitled")
        newPage.ImageIndex = 5

        'Editor configuration

        'Open file which launched the app
        If ApplicationSettings.isFileOpened = True Then
            Try
                OpenFile(ApplicationSettings.fileOpened)
                'filesOpened.Add(pages, ApplicationSettings.fileOpened)
                'displayNames.Add(pages, System.IO.Path.GetFileName(ApplicationSettings.fileOpened))
                'Dim sr As New System.IO.StreamReader(ApplicationSettings.fileOpened)
                'editor.Text = sr.ReadToEnd
                'SR.Close()
            Catch
                MessageBox.Show(PyXelTranslations.strings.Item("file_open_error"), "PyXel", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'filesOpened.Add(pages, PyXelTranslations.strings.Item("untitled"))
                'displayNames.Add(pages, PyXelTranslations.strings.Item("untitled"))
            End Try

        Else
            'No file launched the app, just adding a blank tab
            filesOpened.Add(pages, PyXelTranslations.strings.Item("untitled"))
            displayNames.Add(pages, PyXelTranslations.strings.Item("untitled"))
            Dim splitter As New KryptonSplitContainer
            splitter.Dock = DockStyle.Fill
            AddHandler splitter.SplitterMoved, AddressOf SplitterMoved
            Dim editor As New FastColoredTextBox
            Dim map As New DocumentMap
            map.Target = editor
            splitter.SplitterDistance = ApplicationSettings.splitterDistance
            map.Dock = DockStyle.Fill
            editor.Dock = DockStyle.Fill
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
            splitter.Panel1.Controls.Add(editor)
            splitter.Panel2.Controls.Add(map)
            newPage.Controls.Add(splitter)
            pagesSaved.Add(pages, True)
            firstLoad.Add(pages, True)
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

        'Detect Installed Python
        If Not File.Exists(ApplicationSettings.python2) Then
            KryptonRibbonGroupButton14.Enabled = False
            KryptonRibbonGroupButton16.Enabled = False
            KryptonRibbonGroupButton17.Enabled = False
            KryptonRibbonGroupButton14.ToolTipImage = My.Resources.warning24
            KryptonRibbonGroupButton14.ToolTipTitle = "Python 2 missing"
            KryptonRibbonGroupButton14.ToolTipBody = "Please install Python 2 and restart PyXel in order to execute your Pyhton 2 code. If Python 2 is already installed, you can configure its path in the settings."
            KryptonRibbonGroupButton16.ToolTipTitle = KryptonRibbonGroupButton14.ToolTipTitle
            KryptonRibbonGroupButton16.ToolTipBody = KryptonRibbonGroupButton14.ToolTipBody
            KryptonRibbonGroupButton16.ToolTipImage = KryptonRibbonGroupButton14.ToolTipImage
        End If
        If Not File.Exists(ApplicationSettings.python3) Then
            KryptonRibbonGroupButton18.Enabled = False
            KryptonRibbonGroupButton19.Enabled = False
            KryptonRibbonGroupButton20.Enabled = False
            KryptonRibbonGroupButton18.ToolTipImage = My.Resources.warning24
            KryptonRibbonGroupButton18.ToolTipTitle = "Python 3 missing"
            KryptonRibbonGroupButton18.ToolTipBody = "Please install Python 3 and restart PyXel in order to execute your Pyhton 3 code. If Python 3 is already installed, you can configure its path in the settings."
            KryptonRibbonGroupButton19.ToolTipTitle = KryptonRibbonGroupButton18.ToolTipTitle
            KryptonRibbonGroupButton19.ToolTipBody = KryptonRibbonGroupButton18.ToolTipBody
            KryptonRibbonGroupButton19.ToolTipImage = KryptonRibbonGroupButton18.ToolTipImage
        End If

        'Detect Installed Compilers
        If Not File.Exists(ApplicationSettings.gcc) Then
            KryptonRibbonGroupButton25.Enabled = False
            KryptonRibbonGroupButton26.Enabled = False
            KryptonRibbonGroupButton27.Enabled = False
            KryptonRibbonGroupButton25.ToolTipImage = My.Resources.warning24
            KryptonRibbonGroupButton25.ToolTipTitle = "GCC missing"
            KryptonRibbonGroupButton25.ToolTipBody = "Please install GCC and restart PyXel in order to compile your code. If GCC is already installed, you can configure its path in the settings."
            KryptonRibbonGroupButton26.ToolTipTitle = KryptonRibbonGroupButton25.ToolTipTitle
            KryptonRibbonGroupButton27.ToolTipTitle = KryptonRibbonGroupButton25.ToolTipTitle
            KryptonRibbonGroupButton26.ToolTipBody = KryptonRibbonGroupButton25.ToolTipBody
            KryptonRibbonGroupButton27.ToolTipBody = KryptonRibbonGroupButton25.ToolTipBody
            KryptonRibbonGroupButton26.ToolTipImage = KryptonRibbonGroupButton25.ToolTipImage
            KryptonRibbonGroupButton27.ToolTipImage = KryptonRibbonGroupButton25.ToolTipImage

        End If

        'Detect Installed Browsers
        If Not File.Exists(ApplicationSettings.firefox) Then
            KryptonRibbonGroupButton22.Enabled = False
            KryptonRibbonGroupButton22.ToolTipImage = My.Resources.warning24
            KryptonRibbonGroupButton22.ToolTipTitle = "Mozilla Firefox missing"
            KryptonRibbonGroupButton22.ToolTipBody = "Please install Mozilla Firefox and restart PyXel in order to preview your file in Mozilla Firefox. If Mozilla Firefox is already installed, you can configure its path in the settings."
        End If
        If Not File.Exists(ApplicationSettings.chrome) Then
            KryptonRibbonGroupButton23.Enabled = False
            KryptonRibbonGroupButton23.ToolTipImage = My.Resources.warning24
            KryptonRibbonGroupButton23.ToolTipTitle = "Google Chrome missing"
            KryptonRibbonGroupButton23.ToolTipBody = "Please install Google Chrome and restart PyXel in order to preview your file in Google Chrome. If Google Chrome is already installed, you can configure its path in the settings."
        End If
        If Not File.Exists(ApplicationSettings.opera) Then
            KryptonRibbonGroupButton24.Enabled = False
            KryptonRibbonGroupButton24.ToolTipImage = My.Resources.warning24
            KryptonRibbonGroupButton24.ToolTipTitle = "Opera missing"
            KryptonRibbonGroupButton24.ToolTipBody = "Please install Opera and restart PyXel in order to preview your file in Opera. If Opera is already installed, you can configure its path in the settings."
        End If

        'Create ImageList for TreeView
        ImagesTreeView.Images.Add("c", My.Resources.c16)
        ImagesTreeView.Images.Add("cpp", My.Resources.cpp16)
        ImagesTreeView.Images.Add("css", My.Resources.css16)
        ImagesTreeView.Images.Add("html", My.Resources.html16)
        ImagesTreeView.Images.Add("php", My.Resources.php16)
        ImagesTreeView.Images.Add("js", My.Resources.js16)
        ImagesTreeView.Images.Add("py", My.Resources.python16)
        ImagesTreeView.Images.Add("file", My.Resources.new321)
        ImagesTreeView.Images.Add("folder", My.Resources.open321)
        ImagesTreeView.Images.Add("project", My.Resources.project161)
        ImagesTreeView.Images.Add("h", My.Resources.header16)
        ImagesTreeView.Images.Add("img", My.Resources.picture)
        ImagesTreeView.Images.Add("xml", My.Resources.xml16)
        ImagesTreeView.Images.Add("cs", My.Resources.csharp16)
        ImagesTreeView.Images.Add("vb", My.Resources.vb16)
        ImagesTreeView.Images.Add("xaml", My.Resources.xaml16)
        KryptonTreeView1.ImageList = ImagesTreeView

        'Hiding Projects panel when no project is loaded
        KryptonSplitContainer2.Panel1Collapsed = True

        'Update Checking
        If ApplicationSettings.updateType IsNot "Disabled" Then
            Dim th As New Thread(AddressOf checkForUpdates)
            th.Start()
        End If

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
        openNewTab(Languages.CSS)
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
        openNewTab(Languages.C)
    End Sub

    '
    ' I. New C++ File
    '

    Private Sub NewCPPClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem14.Click
        'Create New C++ File
        openNewTab(Languages.CPP)
    End Sub
    Private Sub NewXMLClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem27.Click
        'Create New HTML File
        openNewTab(Languages.XML)
    End Sub
    Private Sub NewCSharpClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem6.Click
        'Create New HTML File
        openNewTab(Languages.CSharp)
    End Sub
    Private Sub NewVBClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem16.Click
        'Create New HTML File
        openNewTab(Languages.VBNet)
    End Sub
    Private Sub NewXAMLClick(sender As Object, e As EventArgs) Handles KryptonContextMenuItem28.Click
        'Create New HTML File
        openNewTab(Languages.XAML)
    End Sub

    '
    ' 10. Exit Application
    '

    Private Async Sub ButtonSpecAppMenu2_Click(sender As Object, e As EventArgs) Handles ButtonSpecAppMenu2.Click
        For Each page As TabPage In CustomTabControl1.TabPages
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                CustomTabControl1.SelectedTab = page
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
                td.Content = PyXelTranslations.strings.Item("save_before_continue")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    Await SavePage(id)
                ElseIf res = DialogResult.Cancel Then
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
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
                td.Content = PyXelTranslations.strings.Item("save_before_continue")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    Await SavePage(id)
                ElseIf res = DialogResult.Cancel Then
                    e.Cancel = True
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
        If Not File.Exists(ApplicationSettings.python2) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = "Exécutable Python introuvable"
            td.Content = "Veuillez configurer l'emplacement de l'exécutable Python avant de continuer."
            td.ShowDialog()
            Settings.ShowDialog()
        Else
            Dim page As TabPage = CustomTabControl1.SelectedTab
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
                td.Content = PyXelTranslations.strings.Item("save_before_continue")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    Await SavePage(id)
                ElseIf res = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            If ConsoleControl1.IsProcessRunning Then
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("process_active")
                td.Content = PyXelTranslations.strings.Item("interrupt_process")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    ConsoleControl1.StopProcess()
                ElseIf res = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            Threading.Thread.Sleep(500)
            Try
                ConsoleControl1.StartProcess(ApplicationSettings.python2, filesOpened(id))
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("execution_error")
                td.Content = PyXelTranslations.strings.Item("execution_error_msg")
                td.ShowDialog()
            End Try
        End If
    End Sub

    Private Async Sub KryptonRibbonGroupButton18_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton18.Click
        If Not File.Exists(ApplicationSettings.python3) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = "Exécutable Python introuvable"
            td.Content = "Veuillez configurer l'emplacement de l'exécutable Python avant de continuer."
            td.ShowDialog()
            Settings.ShowDialog()
        Else
            Dim page As TabPage = CustomTabControl1.SelectedTab
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
                td.Content = PyXelTranslations.strings.Item("save_before_continue")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    Await SavePage(id)
                ElseIf res = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            If ConsoleControl1.IsProcessRunning Then
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("process_active")
                td.Content = PyXelTranslations.strings.Item("interrupt_process")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    ConsoleControl1.StopProcess()
                ElseIf res = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            Threading.Thread.Sleep(500)
            Try
                ConsoleControl1.StartProcess(ApplicationSettings.python3, filesOpened(id))
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("execution_error")
                td.Content = PyXelTranslations.strings.Item("execution_error_msg")
                td.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton16_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton16.Click
        If Not File.Exists(ApplicationSettings.python2) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = "Exécutable Python introuvable"
            td.Content = "Veuillez configurer l'emplacement de l'exécutable Python avant de continuer."
            td.ShowDialog()
            Settings.ShowDialog()
        Else
            Try
                ConsoleControl1.StartProcess(ApplicationSettings.python2, "")
                'Shell(ApplicationSettings.python3)
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = "Exécutable Python introuvable"
                td.Content = "Veuillez configurer l'emplacement de l'exécutable Python avant de continuer."
                td.ShowDialog()
                Settings.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton19_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton19.Click
        If Not File.Exists(ApplicationSettings.python3) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = "Exécutable Python introuvable"
            td.Content = "Veuillez configurer l'emplacement de l'exécutable Python avant de continuer."
            td.ShowDialog()
            Settings.ShowDialog()
        Else
            Try
                ConsoleControl1.StartProcess(ApplicationSettings.python3, "")
                'Shell(ApplicationSettings.python3)
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = "Exécutable Python introuvable"
                td.Content = "Veuillez configurer l'emplacement de l'exécutable Python avant de continuer."
                td.ShowDialog()
                Settings.ShowDialog()
            End Try
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
        Dim td As New TaskDialog
        td.CommonButtons = TaskDialogCommonButton.OK
        td.StandardIcon = TaskDialogIcon.ShieldRegular
        td.WindowTitle = "PyXel"
        td.MainInstruction = "Fonctionnalité non disponible"
        td.Content = "Cette fonctionnalité n'est pas encore disponible !"
        td.ShowDialog()
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
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
            td.StandardIcon = TaskDialogIcon.ShieldWarning
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
            td.Content = PyXelTranslations.strings.Item("save_before_continue")
            Dim res As DialogResult = td.ShowDialog().CommonButton
            If res = DialogResult.Yes Then
                Await SavePage(id)
            ElseIf res = DialogResult.Cancel Then
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
        Dim td As New TaskDialog
        td.CommonButtons = TaskDialogCommonButton.OK
        td.StandardIcon = TaskDialogIcon.ShieldRegular
        td.WindowTitle = "PyXel"
        td.MainInstruction = "Fonctionnalité non disponible"
        td.Content = "Cette fonctionnalité n'est pas encore disponible !"
        td.ShowDialog()
    End Sub

    Private Sub KryptonRibbonGroupButton15_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton17.Click
        If ConsoleControl1.IsProcessRunning Then
            ConsoleControl1.StopProcess()
        End If
    End Sub

    Private Async Sub KryptonContextMenuItem6_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem23.Click
        Dim id As Integer = tabsInversed.Item(CustomTabControl1.SelectedTab)
        Dim editor As FastColoredTextBox = editors.Item(id)
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = PyXelTranslations.strings.Item("html_file") + "|*.html"
        saveFileDialog.Title = PyXelTranslations.strings.Item("export_html")
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
                    'KryptonRibbon1.SelectedContext = "Python,Projet"
                    KryptonRibbon1.SelectedContext = "Python"
                Else
                    KryptonRibbon1.SelectedContext = "Python"
                End If
                KryptonSplitContainer1.Panel2Collapsed = False
            Case Languages.HTML
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    'KryptonRibbon1.SelectedContext = "HTML,Projet"
                    KryptonRibbon1.SelectedContext = "HTML"
                Else
                    KryptonRibbon1.SelectedContext = "HTML"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.PHP
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    'KryptonRibbon1.SelectedContext = "HTML,Projet"
                    KryptonRibbon1.SelectedContext = "HTML"
                Else
                    KryptonRibbon1.SelectedContext = "HTML"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.JS
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    'KryptonRibbon1.SelectedContext = "HTML,Projet"
                    KryptonRibbon1.SelectedContext = "HTML"
                Else
                    KryptonRibbon1.SelectedContext = "HTML"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.C
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    'KryptonRibbon1.SelectedContext = "C,Projet"
                    KryptonRibbon1.SelectedContext = "C"
                Else
                    KryptonRibbon1.SelectedContext = "C"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.CPP
                If Not KryptonSplitContainer2.Panel1Collapsed Then
                    'KryptonRibbon1.SelectedContext = "C,Projet"
                    KryptonRibbon1.SelectedContext = "C"
                Else
                    KryptonRibbon1.SelectedContext = "C"
                End If
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.XML
                KryptonRibbon1.SelectedContext = ""
                KryptonSplitContainer1.Panel2Collapsed = True
            Case Languages.CSharp, Languages.VBNet, Languages.XAML
                KryptonRibbon1.SelectedContext = "DotNet"
                KryptonSplitContainer1.Panel2Collapsed = True
        End Select
    End Sub

    'Open web file in IE
    Private Async Sub KryptonRibbonGroupButton21_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton21.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
            td.StandardIcon = TaskDialogIcon.ShieldWarning
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
            td.Content = PyXelTranslations.strings.Item("save_before_continue")
            Dim res As DialogResult = td.ShowDialog().CommonButton
            If res = DialogResult.Yes Then
                Await SavePage(id)
            ElseIf res = DialogResult.Cancel Then
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
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
            td.StandardIcon = TaskDialogIcon.ShieldWarning
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
            td.Content = PyXelTranslations.strings.Item("save_before_continue")
            Dim res As DialogResult = td.ShowDialog().CommonButton
            If res = DialogResult.Yes Then
                Await SavePage(id)
            ElseIf res = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        'MsgBox(filesOpened(id))
        If Environment.Is64BitOperatingSystem Then
            Try
                System.Diagnostics.Process.Start(ApplicationSettings.firefox, "file:///" + filesOpened(id).Replace(" ", "%20"))
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = "Navigateur incompatible"
                td.Content = "PyXel ne supporte que les versions de Mozilla Firefox ayant la même architecture que votre ordinateur." + vbNewLine + "Merci d'installer la version 64 bits de Mozilla Firefox !"
                td.ShowDialog()
            End Try

        End If
    End Sub

    'Open web file in Chrome
    Private Async Sub KryptonRibbonGroupButton23_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton23.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
            td.StandardIcon = TaskDialogIcon.ShieldWarning
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
            td.Content = PyXelTranslations.strings.Item("save_before_continue")
            Dim res As DialogResult = td.ShowDialog().CommonButton
            If res = DialogResult.Yes Then
                Await SavePage(id)
            ElseIf res = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        'MsgBox(filesOpened(id))
        System.Diagnostics.Process.Start(ApplicationSettings.chrome, "file:///" + filesOpened(id).Replace(" ", "%20"))
    End Sub

    'Open web file in Opera
    Private Async Sub KryptonRibbonGroupButton24_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton24.Click
        Dim page As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(page)
        If Not pagesSaved.Item(id) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
            td.StandardIcon = TaskDialogIcon.ShieldWarning
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
            td.Content = PyXelTranslations.strings.Item("save_before_continue")
            Dim res As DialogResult = td.ShowDialog().CommonButton
            If res = DialogResult.Yes Then
                Await SavePage(id)
            ElseIf res = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        'MsgBox(filesOpened(id))
        If Environment.Is64BitOperatingSystem Then
            Try
                System.Diagnostics.Process.Start(ApplicationSettings.opera, "file:///" + filesOpened(id).Replace(" ", "%20"))
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = "Navigateur incompatible"
                td.Content = "PyXel ne supporte que les versions d'Opera ayant la même architecture que votre ordinateur." + vbNewLine + "Merci d'installer la version 64 bits d'Opera !"
                td.ShowDialog()
            End Try

        End If
    End Sub

    Private Sub KryptonTreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles KryptonTreeView1.NodeMouseDoubleClick
        Dim clickedNode As TreeNode = e.Node
        If clickedNode.SelectedImageKey IsNot "project" And clickedNode.SelectedImageKey IsNot "folder" And clickedNode.SelectedImageKey IsNot "file" And clickedNode.SelectedImageKey IsNot "img" Then
            OpenFile(clickedNode.Tag)
        ElseIf clickedNode.SelectedImageKey = "img" Then
            Dim pw As New PictureViewer
            pw.img = clickedNode.Tag
            pw.Show()
        End If

    End Sub

    Private Sub PyXelDragEnter(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub PyXelDragDrop(sender As Object, e As DragEventArgs)
        Try
            Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
            For Each file In files
                OpenFile(file)
            Next
        Catch
        End Try
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

    Private Async Sub KryptonContextMenuItem21_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem21.Click
        'Dim id As Integer = tabsInversed.Item(CustomTabControl1.SelectedTab)
        'Dim editor As FastColoredTextBox = editors.Item(id)
        'Dim saveFileDialog As New SaveFileDialog
        'SaveFileDialog.Filter = "Fichiers PDF|*.PDF"
        'SaveFileDialog.Title = "Exporter en pDF"
        'If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        'Dim fileName As String
        'fileName = saveFileDialog.FileName
        'Using outputFile As New StreamWriter(fileName)
        'Await outputFile.WriteAsync(editor.Html)
        'End Using
        'filesOpened.Item(id) = fileName
        'End If
    End Sub

    'Syntax Highlighting engine

    Public Delegate Sub highlightDelegate(sender As Object, e As TextChangedEventArgs)

    Private Sub PythonHighlight(sender As Object, e As TextChangedEventArgs)
        Me.Invoke(New highlightDelegate(AddressOf RunPythonHighlight), New Object() {sender, e})
    End Sub

    Private Sub RunPythonHighlight(sender As Object, e As TextChangedEventArgs)
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
    End Sub

    Private Sub CSSHighlight(sender As Object, e As TextChangedEventArgs)
        Me.Invoke(New highlightDelegate(AddressOf RunCSSHighlight), New Object() {sender, e})
    End Sub

    Private Sub RunCSSHighlight(sender As Object, e As TextChangedEventArgs)
        e.ChangedRange.ClearStyle(greenStyle)
        e.ChangedRange.ClearStyle(orangeStyle)
        e.ChangedRange.ClearStyle(blueStyle)
        e.ChangedRange.ClearStyle(redStyle)
        e.ChangedRange.ClearStyle(purpleStyle)
        e.ChangedRange.SetStyle(greenStyle, "\/\*[^*]*\*+([^/*][^*]*\*+)*\/", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(blueStyle, "(([.#@]*[a-zA-Z\-_]+))(?: *{)|(})")
        e.ChangedRange.SetStyle(salmonStyle, "([a-zA-Z\-]+)(?:\s*:)")
        e.ChangedRange.SetStyle(orangeStyle, "(([a-zA-Z0-9\-_\.\" + Chr(34) + "\" + Chr(39) + "\#\(\)\,]+))(?:\s*;)")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(34) + "(.*?)" + Chr(34) + "")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(39) + "(.*?)" + Chr(39) + "")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(44) + "(.*?)" + Chr(44) + "")
    End Sub

    Private Async Sub CloseTabShortcut(sender As Object, e As KeyEventArgs)
        'If e.Control And e.KeyCode = Keys.W Then
        '    Dim page As TabPage = CustomTabControl1.SelectedTab
        '    Dim id As Integer = tabsInversed.Item(page)
        '    If Not pagesSaved.Item(id) Then
        '        Dim td As New TaskDialog
        '        td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No
        '        td.StandardIcon = TaskDialogIcon.ShieldWarning
        '        td.WindowTitle = "PyXel"
        '        td.MainInstruction = "Fichier non sauvegardé"
        '        td.Content = "Voulez-vous sauvegarder le fichier avant de continuer ?"
        '        Dim res As DialogResult = td.ShowDialog().CommonButton
        '        If res = DialogResult.Yes Then
        '            Await SavePage(id)
        '        ElseIf res = DialogResult.Cancel Then
        '            Exit Sub
        '        End If
        '    End If
        '    tabsInversed.Remove(tabs.Item(id))
        '    tabs.Remove(id)
        '    editorsInversed.Remove(editors.Item(id))
        '    editors.Remove(id)
        '    pagesSaved.Remove(id)
        '    filesOpened.Remove(id)
        '    displayNames.Remove(id)
        '    firstLoad.Remove(id)
        '    If CustomTabControl1.TabCount = 1 Then
        '        openNewTab(Languages.Python)
        '    End If
        'End If
    End Sub

    Private Sub SplitterMoved(sender As Object, e As SplitterEventArgs)
        Dim spl As KryptonSplitContainer = sender
        'MsgBox(spl.SplitterDistance)
        ApplicationSettings.splitterDistance = spl.SplitterDistance
    End Sub

    Private Async Sub KryptonRibbonGroupButton25_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton25.Click
        If Not File.Exists(ApplicationSettings.gcc) Then
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = "Compilateur GCC introuvable"
            td.Content = "Veuillez configurer l'emplacement du Compilateur GCC avant de continuer."
            td.ShowDialog()
            Settings.ShowDialog()
        Else
            Dim page As TabPage = CustomTabControl1.SelectedTab
            Dim id As Integer = tabsInversed.Item(page)
            If Not pagesSaved.Item(id) Then
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("file_not_saved")
                td.Content = PyXelTranslations.strings.Item("save_before_continue")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    Await SavePage(id)
                ElseIf res = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            If ConsoleControl1.IsProcessRunning Then
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.Yes Or TaskDialogCommonButton.No Or TaskDialogCommonButton.Cancel
                td.StandardIcon = TaskDialogIcon.ShieldWarning
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("process_active")
                td.Content = PyXelTranslations.strings.Item("interrupt_process")
                Dim res As DialogResult = td.ShowDialog().CommonButton
                If res = DialogResult.Yes Then
                    ConsoleControl1.StopProcess()
                ElseIf res = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
            Threading.Thread.Sleep(500)
            Try
                ConsoleControl1.StartProcess(ApplicationSettings.gcc, filesOpened(id) + " -o " + filesOpened(id) + ".exe")
            Catch
                Dim td As New TaskDialog
                td.CommonButtons = TaskDialogCommonButton.OK
                td.StandardIcon = TaskDialogIcon.ShieldError
                td.WindowTitle = "PyXel"
                td.MainInstruction = PyXelTranslations.strings.Item("execution_error")
                td.Content = PyXelTranslations.strings.Item("execution_error_msg")
                td.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton26_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton26.Click
        Try
            Dim page As TabPage = CustomTabControl1.SelectedTab
            Dim id As Integer = tabsInversed.Item(page)
            ConsoleControl1.StartProcess(filesOpened(id) + ".exe", "")
        Catch
            Dim td As New TaskDialog
            td.CommonButtons = TaskDialogCommonButton.OK
            td.StandardIcon = TaskDialogIcon.ShieldError
            td.WindowTitle = "PyXel"
            td.MainInstruction = PyXelTranslations.strings.Item("execution_error")
            td.Content = PyXelTranslations.strings.Item("execution_error_msg")
            td.ShowDialog()
        End Try
    End Sub

    Private Sub KryptonRibbonQATButton5_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton5.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Undo()
    End Sub
    Private Sub KryptonRibbonQATButton6_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton6.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Redo()
    End Sub
    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Undo()
    End Sub
    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Dim tab As TabPage = CustomTabControl1.SelectedTab
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Redo()
    End Sub

    Private Sub KryptonRibbon1_ShowQATCustomizeMenu(sender As Object, e As EventArgs) Handles KryptonRibbon1.Click

    End Sub
End Class
