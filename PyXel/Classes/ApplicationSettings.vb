Imports System.Xml

Public Class ApplicationSettings

    'PyXel Launch Conditions
    Public Shared isFileOpened As Boolean = False
    Public Shared fileOpened As String

    'General Settings
    Public Shared lang As String = "French"
    Public Shared theme As ComponentFactory.Krypton.Toolkit.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
    Public Shared recentDocs As New ArrayList

    'Editor Colors
    Public Shared editorBackColor As Color = Color.White
    Public Shared editorForeColor As Color = Color.Black
    Public Shared editorFont As New Font("Consolas", 12)

    'Interpreter Config
    Public Shared interpreterBackColor As Color = Color.Black
    Public Shared interpreterForeColor As Color = Color.White
    Public Shared interpreterFont As New Font("Consolas", 12)

    'Python Path
    Public Shared python2 As String = ""
    Public Shared python3 As String = "C:\Windows\py.exe"

    Public Shared Sub createConfig()
        Dim writer As New XmlTextWriter(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("PyXel")
        writer.WriteStartElement("ConfigVersion")
        writer.WriteString(My.Settings.Version)
        writer.WriteEndElement()
        writer.WriteStartElement("General")
        writer.WriteStartElement("Language")
        writer.WriteString("French")
        writer.WriteEndElement()
        writer.WriteStartElement("Theme")
        writer.WriteString("Blue")
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Colors")
        writer.WriteStartElement("Editor")
        writer.WriteStartElement("ForeColor")
        writer.WriteString(Color.Black.Name)
        writer.WriteEndElement()
        writer.WriteStartElement("BackColor")
        writer.WriteString(Color.White.Name)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Interpreter")
        writer.WriteStartElement("ForeColor")
        writer.WriteString(Color.White.Name)
        writer.WriteEndElement()
        writer.WriteStartElement("BackColor")
        writer.WriteString(Color.Black.Name)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("PythonPath")
        writer.WriteStartElement("Python2")
        writer.WriteString("")
        writer.WriteEndElement()
        writer.WriteStartElement("Python3")
        writer.WriteString(ApplicationSettings.python3)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Public Shared Sub readConfig()
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/PyXel/General")
        For Each node As XmlNode In nodes
            ApplicationSettings.lang = node.SelectSingleNode("Language").InnerText
            Dim theme As String = node.SelectSingleNode("Theme").InnerText
            Select Case theme
                Case "Blue"
                    ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
                Case "Silver"
                    ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
                Case "Black"
                    ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
                Case Else
                    ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
            End Select
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Colors/Editor")
        For Each node As XmlNode In nodes
            Dim fc As String = node.SelectSingleNode("ForeColor").InnerText
            Dim bc As String = node.SelectSingleNode("BackColor").InnerText
            If fc = "Black" Then
                ApplicationSettings.editorForeColor = Color.Black
            Else
                ApplicationSettings.editorForeColor = Color.FromArgb(fc)
            End If
            If bc = "White" Then
                ApplicationSettings.editorBackColor = Color.White
            Else
                ApplicationSettings.editorBackColor = Color.FromArgb(bc)
            End If

            'ApplicationSettings.editorForeColor = Color.FromName(node.SelectSingleNode("ForeColor").InnerText)
            'ApplicationSettings.editorBackColor = Color.FromName(node.SelectSingleNode("BackColor").InnerText)
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Colors/Interpreter")
        For Each node As XmlNode In nodes

            Dim fc As String = node.SelectSingleNode("ForeColor").InnerText
            Dim bc As String = node.SelectSingleNode("BackColor").InnerText
            If fc = "White" Then
                ApplicationSettings.interpreterForeColor = Color.White
            Else
                ApplicationSettings.interpreterForeColor = Color.FromArgb(fc)
            End If
            If bc = "Black" Then
                ApplicationSettings.interpreterBackColor = Color.Black
            Else
                ApplicationSettings.interpreterBackColor = Color.FromArgb(bc)
            End If
            'ApplicationSettings.interpreterForeColor = Color.FromName(node.SelectSingleNode("ForeColor").InnerText)
            'ApplicationSettings.interpreterBackColor = Color.FromName(node.SelectSingleNode("BackColor").InnerText)
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/PythonPath")
        For Each node As XmlNode In nodes
            ApplicationSettings.python2 = node.SelectSingleNode("Python2").InnerText
            ApplicationSettings.python3 = node.SelectSingleNode("Python3").InnerText
        Next
    End Sub
End Class

