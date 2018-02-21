Public Class ApplicationSettings

    'PyXel Launch Conditions
    Public Shared isFileOpened As Boolean = False
    Public Shared fileOpened As String

    'General Settings
    Public Shared lang As String = "French"
    Public Shared theme As ComponentFactory.Krypton.Toolkit.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue

    'Editor Colors
    Public Shared editorBackColor As Color = Color.White
    Public Shared editorForeColor As Color = Color.Black

    'Interpreter Colors
    Public Shared interpreterBackColor As Color = Color.Black
    Public Shared interpreterForeColor As Color = Color.White

    'Python Path
    Public Shared python2 As String = "none"
    Public Shared python3 As String = "C:\Windows\py.exe"

End Class
