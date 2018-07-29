Imports ComponentFactory.Krypton.Navigator
Imports FastColoredTextBoxNS

Public Class PyxelFile

    Private isSaved As Boolean
    Private isCreated As Boolean
    Private filePath As String
    Private displayName As String
    Private language As MainForm.Languages
    Private tab As KryptonPage
    Private editor As FastColoredTextBox

    Public Sub New(isSaved As Boolean, isCreated As Boolean, filePath As String, displayName As String, language As MainForm.Languages, tab As KryptonPage, editor As FastColoredTextBox)
        Me.isSaved = isSaved
        Me.isCreated = isCreated
        Me.filePath = filePath
        Me.displayName = displayName
        Me.language = language
        Me.tab = tab
        Me.editor = editor
    End Sub

    Public Function getLanguage()
        Return Me.language
    End Function

    Public Function getFilePath()
        Return Me.filePath
    End Function

    Public Function getDisplayName()
        Return Me.displayName
    End Function
    Public Function getTab()
        Return Me.tab
    End Function

    Public Function getEditor()
        Return Me.editor
    End Function

End Class
