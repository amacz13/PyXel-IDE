Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text.RegularExpressions
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
            FastColoredTextBox1.Text = sr.ReadToEnd
            sr.Close()
            isFileSet = True
            fileName = openFileDialog1.FileName
            Me.Text = "PyXel - " + fileName
        End If
    End Sub

    Private Sub FastColoredTextBox1_TextChanged(sender As Object, e As TextChangedEventArgs) Handles FastColoredTextBox1.TextChanged
        e.ChangedRange.ClearStyle(greenStyle)
        e.ChangedRange.ClearStyle(orangeStyle)
        e.ChangedRange.ClearStyle(blueStyle)
        e.ChangedRange.ClearStyle(redStyle)
        e.ChangedRange.ClearStyle(purpleStyle)
        e.ChangedRange.SetStyle(greenStyle, "#.*$", RegexOptions.Multiline)
        e.ChangedRange.SetStyle(blueStyle, "(print|input|if|else|for|in^t|range|while|try|except|catch|\(|\))")
        e.ChangedRange.SetStyle(orangeStyle, "(int|float|string)")
        e.ChangedRange.SetStyle(redStyle, "(def|import|as|from)")
        e.ChangedRange.SetStyle(purpleStyle, "" + Chr(34) + "(.*?)" + Chr(34) + "")
        If FastColoredTextBox1.Text.Length > 0 Then
            Me.Text = "PyXel - " + fileName + "*"
            isFileSaved = False
        End If
    End Sub



    Public Async Function SaveFile() As Task
        If isFileSet Then
            Using outputFile As New StreamWriter(fileName)
                Await outputFile.WriteAsync(FastColoredTextBox1.Text)
            End Using
            Me.Text = "PyXel - " + fileName
            isFileSaved = True
            isFileSet = True
        Else
            Dim saveFileDialog As New SaveFileDialog
            saveFileDialog.Filter = "Fichiers Python|*.py"
            saveFileDialog.Title = "Enregistrer un fichier Python"
            If saveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                fileName = saveFileDialog.FileName
                Using outputFile As New StreamWriter(fileName)
                    Await outputFile.WriteAsync(FastColoredTextBox1.Text)
                End Using
                isFileSaved = True
                isFileSet = True
            End If
            Me.Text = "PyXel - " + fileName
        End If
    End Function

    Private Sub KryptonContextMenuItem3_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem3.Click
        SaveFile()
    End Sub

    Private Sub KryptonRibbonQATButton1_Click(sender As Object, e As EventArgs) Handles KryptonRibbonQATButton1.Click
        SaveFile()
    End Sub

    Private Sub KryptonContextMenuItem1_Click(sender As Object, e As EventArgs) Handles KryptonContextMenuItem1.Click
        'If isFileSaved = False Then
        'Dim msg As String
        'Dim title As String
        'Dim style As MsgBoxStyle
        'msg = "Voulez-vous sauvegarder le fichier avant de continuer ?"   ' Define message.
        '  style = MsgBoxStyle.YesNoCancel
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
        Dim newform As New Form1
        newform.Show()


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
        If My.Settings.PythonPath = "none" Then
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "Fichiers Executables|*.exe"
            openFileDialog1.Title = "Sélectionnez l'emplacement de l'executable Python"
            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fn As String = openFileDialog1.FileName
                My.Settings.PythonPath = fn
            End If
        End If
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
        FastColoredTextBox1.Cut()
    End Sub

    Private Sub KryptonRibbonGroupButton3_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton3.Click
        FastColoredTextBox1.Copy()
    End Sub

    Private Sub KryptonRibbonGroupButton6_Click(sender As Object, e As EventArgs) Handles KryptonRibbonGroupButton6.Click
        FastColoredTextBox1.Paste()
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
End Class
