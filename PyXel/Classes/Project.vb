Public Class Project

    Private filePath As String
    Private displayName As String
    Private language As Form1.Languages
    Private files As ArrayList

    Public Sub New(filePath As String, displayName As String, language As Form1.Languages, files As ArrayList)
        Me.filePath = filePath
        Me.displayName = displayName
        Me.language = language
        Me.files = files
    End Sub

    Public Sub New(filePath As String, displayName As String)
        Me.filePath = filePath
        Me.displayName = displayName
    End Sub

    Public Sub New(language As Form1.Languages)
        Me.language = language

    End Sub

End Class
