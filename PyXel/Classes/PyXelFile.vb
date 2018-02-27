Imports ComponentFactory.Krypton.Navigator
Imports FastColoredTextBoxNS

Public Class PyXelFile

    Private isSaved As Boolean
    Private isCreated As Boolean
    Private filePath As String
    Private language As Form1.Languages
    Private tab As KryptonPage
    Private editor As FastColoredTextBox

    Public Sub New(isSaved As Boolean, isCreated As Boolean, filePath As String, language As Form1.Languages, tab As KryptonPage, editor As FastColoredTextBox)
        Me.isSaved = isSaved
        Me.isCreated = isCreated
        Me.filePath = filePath
        Me.language = language
        Me.tab = tab
        Me.editor = editor
    End Sub
End Class
