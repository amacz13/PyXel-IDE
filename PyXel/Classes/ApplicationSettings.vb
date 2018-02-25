Public Class ApplicationSettings

    'PyXel Launch Conditions
    Public Shared isFileOpened As Boolean = False
    Public Shared fileOpened As String

    'General Settings
    Public Shared lang As String = "French"
    Public Shared theme As ComponentFactory.Krypton.Toolkit.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
    Public Shared recentDocs As Dictionary(Of String, String)

    'Editor Colors
    Public Shared editorBackColor As Color = Color.White
    Public Shared editorForeColor As Color = Color.Black
    Public Shared editorFont As New Font(FontFamily.GenericSansSerif, 12)

    'Interpreter Config
    Public Shared interpreterBackColor As Color = Color.Black
    Public Shared interpreterForeColor As Color = Color.White
    Public Shared interpreterFont As New Font(FontFamily.GenericSansSerif, 12)

    'Python Path
    Public Shared python2 As String = "none"
    Public Shared python3 As String = "C:\Windows\py.exe"

End Class
