Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text.RegularExpressions
Imports ComponentFactory.Krypton.Navigator
Imports FastColoredTextBoxNS

Public Class Form1

    'Styles CodeEditor

    Dim greenStyle As Style = New TextStyle(Brushes.Green, Brushes.White, FontStyle.Italic)
    Dim blueStyle As Style = New TextStyle(Brushes.Blue, Brushes.White, FontStyle.Regular)
    Dim orangeStyle As Style = New TextStyle(Brushes.Orange, Brushes.White, FontStyle.Regular)
    Dim redStyle As Style = New TextStyle(Brushes.Red, Brushes.White, FontStyle.Bold)
    Dim purpleStyle As Style = New TextStyle(Brushes.Purple, Brushes.White, FontStyle.Bold)

    'Variables Fichiers
    Dim isFileSet As Boolean = False
    Dim fileName As String = "Sans Nom"
    Dim isFileSaved As Boolean = True

    'MultiEditor
    Dim tabs As New Dictionary(Of Integer, KryptonPage)
    Dim tabsInversed As New Dictionary(Of KryptonPage, Integer)
    Dim editors As New Dictionary(Of Integer, FastColoredTextBox)
    Dim editorsInversed As New Dictionary(Of FastColoredTextBox, Integer)
    Dim pagesSaved As New Dictionary(Of Integer, Boolean)
    Dim filesOpened As New Dictionary(Of Integer, String)
    Dim pages As Integer = 0


    Private Sub KryptonContextMenuItem2_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem2.Click
        If isFileSaved = False Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                SaveFile()
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Fichiers Python|*.py"
        openFileDialog1.Title = "Ouvrir un fichier Python"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(openFileDialog1.FileName)
            fileName = openFileDialog1.FileName
            Dim newPage As New KryptonPage
            newPage.Text = fileName
            Dim editor As New FastColoredTextBox
            editor.Dock = DockStyle.Fill
            pages += 1
            tabs.Add(pages, newPage)
            editors.Add(pages, editor)
            tabsInversed.Add(newPage, pages)
            editorsInversed.Add(editor, pages)
            AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged
            KryptonDockableNavigator1.Pages.Add(newPage)
            KryptonDockableNavigator1.NavigatorMode = NavigatorMode.BarRibbonTabGroup
            KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
            newPage.Controls.Add(editor)
            editor.Text = sr.ReadToEnd
            sr.Close()
            pagesSaved.Add(pages, True)
            filesOpened.Add(pages, fileName)
        End If
    End Sub

    Private Sub FastColoredTextBox1_TextChanged(sender As Object, e As TextChangedEventArgs)
        e.ChangedRange.ClearStyle(greenStyle)
        e.ChangedRange.ClearStyle(orangeStyle)
        e.ChangedRange.ClearStyle(blueStyle)
        e.ChangedRange.ClearStyle(redStyle)
        e.ChangedRange.ClearStyle(purpleStyle)
        e.ChangedRange.SetStyle(greenStyle, "#.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(blueStyle, "(print|input|if|else|for|in\s|range|while|try|except|catch|return|\(|\)|\{|\}|\[|\])")
        e.ChangedRange.SetStyle(orangeStyle, "(int|float|string|list|dict)")
        e.ChangedRange.SetStyle(redStyle, "(def\s|import\s|\sas\s|\sfrom\s)")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(34) + "(.*?)" + Chr(34) + "")
        Dim id As Integer = editorsInversed.Item(sender)
        Dim tab As KryptonPage = tabs.Item(id)
        tab.Text = filesOpened.Item(id) + "*"
        pagesSaved.Item(id) = False
        'If e.ChangedRange.Length > 0 Then
        'Me.Text = "PyXel - " + fileName + "*"
        'isFileSaved = False
        'End If
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
            End If
            tabs.Item(id).Text = fileName
        Else
            Dim fileName As String = filesOpened.Item(id)
            Using outputFile As New StreamWriter(fileName)
                Await outputFile.WriteAsync(editor.Text)
            End Using
            pagesSaved.Item(id) = True
            tabs.Item(id).Text = fileName
        End If
    End Function
    Public Async Function SaveFile() As Task
        If isFileSet Then
            'Using outputFile As New StreamWriter(fileName)
            'Await outputFile.WriteAsync(FastColoredTextBox1.Text)
            'End Using
            Me.Text = "PyXel - " + fileName
            isFileSaved = True
            isFileSet = True
        Else
            Dim saveFileDialog As New SaveFileDialog
            saveFileDialog.Filter = "Fichiers Python|*.py"
            saveFileDialog.Title = "Enregistrer un fichier Python"
            If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                fileName = saveFileDialog.FileName
                'Using outputFile As New StreamWriter(fileName)
                'Await outputFile.WriteAsync(FastColoredTextBox1.Text)
                'End Using
                isFileSaved = True
                isFileSet = True
            End If
            Me.Text = "PyXel - " + fileName
        End If
    End Function

    Private Sub KryptonContextMenuItem3_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem3.Click
        SavePage(tabsInversed.Item(KryptonDockableNavigator1.SelectedPage))
    End Sub

    Private Sub KryptonRibbonQATButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton1.Click
        SavePage(tabsInversed.Item(KryptonDockableNavigator1.SelectedPage))
    End Sub

    Private Sub KryptonContextMenuItem1_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem1.Click
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
        Dim newPage As New KryptonPage
        newPage.Text = "Sans Nom"
        Dim editor As New FastColoredTextBox
        editor.Dock = DockStyle.Fill
        pages += 1
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged
        KryptonDockableNavigator1.Pages.Add(newPage)
        KryptonDockableNavigator1.NavigatorMode = NavigatorMode.BarRibbonTabGroup
        KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
        newPage.Controls.Add(editor)
        filesOpened.Add(pages, "Sans Nom")
        pagesSaved.Add(pages, True)
        'Dim newform As New Form1
        'newform.Show()


    End Sub





    Private Sub ButtonSpecAppMenu2_Click(sender As Object, e As EventArgs) Handles ButtonSpecAppMenu2.Click
        If isFileSaved = False Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                SaveFile()
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        Application.Exit()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        If isFileSaved = False Then
            Dim msg As String
            Dim title As String
            Dim style As MsgBoxStyle
            msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
            style = MsgBoxStyle.YesNoCancel
            title = "PyXel - Fichier non sauvegardé"
            Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                SaveFile()
            ElseIf result = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        Application.Exit()
    End Sub

    Private Sub ButtonSpecAppMenu1_Click(sender As Object, e As EventArgs) Handles ButtonSpecAppMenu1.Click
        About.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.Theme = "blue" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf My.Settings.Theme = "black" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Else
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        End If
        If My.Settings.PythonPath = "none" Then
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "Fichiers Executables|*.exe"
            openFileDialog1.Title = "Sélectionnez l'emplacement de l'executable Python"
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fn As String = openFileDialog1.FileName
                My.Settings.PythonPath = fn
            End If
        End If
        Dim newPage As New KryptonPage
        newPage.Text = "Sans Nom"
        Dim editor As New FastColoredTextBox
        editor.Dock = DockStyle.Fill
        pages += 1
        tabs.Add(pages, newPage)
        editors.Add(pages, editor)
        tabsInversed.Add(newPage, pages)
        editorsInversed.Add(editor, pages)
        AddHandler editor.TextChanged, AddressOf FastColoredTextBox1_TextChanged
        KryptonDockableNavigator1.Pages.Add(newPage)
        KryptonDockableNavigator1.SelectedIndex = KryptonDockableNavigator1.Pages.Count - 1
        newPage.Controls.Add(editor)
        filesOpened.Add(pages, "Sans Nom")
        pagesSaved.Add(pages, True)

        Dim x As Integer
        For x = 0 To My.Computer.FileSystem.Drives.Count - 1
            If My.Computer.FileSystem.Drives(x).IsReady = True Then
                KryptonTreeView1.Nodes.Add(My.Computer.FileSystem.Drives(x).Name, My.Computer.FileSystem.Drives(x).Name)
                KryptonTreeView1.Nodes(My.Computer.FileSystem.Drives(x).Name).Tag = My.Computer.FileSystem.Drives(x).Name
                For Each SubDirectory As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.Drives(x).Name)
                    KryptonTreeView1.Nodes(x).Nodes.Add(SubDirectory, Mid(SubDirectory, 4))
                    KryptonTreeView1.Nodes(x).Nodes(SubDirectory).Tag = SubDirectory
                Next
            End If
        Next
    End Sub



    Private Sub KryptonRibbonGroupButton4_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton4.Click
        If My.Settings.PythonPath = "none" Then
            MessageBox.Show("Veuillez configurer l'emplacement de l'exécutable Python", "Exécutable Python introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Settings.ShowDialog()
        Else
            If isFileSaved = False Then
                SaveFile()
            End If
            Shell(My.Settings.PythonPath + " " + fileName)
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton5_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton5.Click
        If My.Settings.PythonPath = "none" Then
            MessageBox.Show("Veuillez configurer l'emplacement de l'exécutable Python", "Exécutable Python introuvable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Settings.ShowDialog()
        Else
            Shell(My.Settings.PythonPath)
        End If
    End Sub

    Private Sub KryptonRibbonGroupButton2_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton2.Click
        Dim tab As KryptonPage = KryptonDockableNavigator1.SelectedPage
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Cut()

    End Sub

    Private Sub KryptonRibbonGroupButton3_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton3.Click
        Dim tab As KryptonPage = KryptonDockableNavigator1.SelectedPage
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Copy()
    End Sub

    Private Sub KryptonRibbonGroupButton6_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton6.Click
        Dim tab As KryptonPage = KryptonDockableNavigator1.SelectedPage
        Dim id As Integer = tabsInversed.Item(tab)
        editors.Item(id).Paste()
    End Sub

    Private Sub KryptonContextMenuItem4_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem4.Click
        Settings.ShowDialog()
    End Sub

    Private Sub KryptonRibbonQATButton2_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton2.Click
        KryptonRibbonGroupButton4.PerformClick()
    End Sub

    Private Sub KryptonRibbonGroupButton7_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton7.Click
        MessageBox.Show("Cette fonctionnalité n'est pas encore disponible !", "Non Disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub KryptonContextMenuItem5_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem5.Click
        Dim printDialog As New PrintDialog()
        If printDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim pd As New PrintDocument

        End If
    End Sub

    Private Sub KryptonDockableNavigator1_CloseAction(sender As Object, e As CloseActionEventArgs) Handles KryptonDockableNavigator1.CloseAction
        Dim page As KryptonPage = KryptonDockableNavigator1.SelectedPage
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
                SavePage(id)
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
        If KryptonDockableNavigator1.Pages.Count = 2 Then
            KryptonDockableNavigator1.NavigatorMode = NavigatorMode.Group
        End If
    End Sub

    Public Sub updatePalette()
        If My.Settings.Theme = "blue" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
        ElseIf My.Settings.Theme = "black" Then
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Else
            KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        End If
    End Sub

    Private Sub ButtonSpecAny1_Click(sender As Object, e As EventArgs) Handles ButtonSpecAny1.Click
        Help.Show()
    End Sub

    Private Sub KryptonRibbonGroupButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton1.Click
        Dim editor As FastColoredTextBox = editors.Item(tabsInversed.Item(KryptonDockableNavigator1.SelectedPage))
        If editor.SelectedText.StartsWith("#") Then

        Else
            editor.SelectedText = "#" + editor.SelectedText
        End If

    End Sub
End Class
