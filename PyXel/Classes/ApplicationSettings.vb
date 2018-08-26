Imports System.Xml
Imports System.IO
Imports ComponentFactory.Krypton.Toolkit

Public Class ApplicationSettings

    'PyXel Launch Conditions
    Public Shared isFileOpened As Boolean = False
    Public Shared fileOpened As String

    'General Settings
    Public Shared lang As String = "French"
    Public Shared theme As ComponentFactory.Krypton.Toolkit.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
    Public Shared recentDocs As New ArrayList
    Public Shared updateType = "Normal"
    Public Shared updateCanal = "Stable"

    'Editor Colors
    Public Shared editorBackColor As Color = Color.White
    Public Shared editorForeColor As Color = Color.Black
    Public Shared editorFont As New Font("Consolas", 12)

    'Interpreter Config
    Public Shared interpreterBackColor As Color = Color.Black
    Public Shared interpreterForeColor As Color = Color.White
    Public Shared interpreterFont As New Font("Consolas", 12)

    'Project Path
    Public Shared projectsPath As String = ""

    'Python Path
    Public Shared python2 As String = ""
    Public Shared python3 As String = ""

    'Browsers Path
    Public Shared firefox As String = "C:\Program Files\Mozilla Firefox\firefox.exe"
    Public Shared chrome As String = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
    Public Shared opera As String = "C:\Program Files\Opera\launcher.exe"

    'C Compilers Path
    Public Shared gcc As String = ""

    'DocumentMap
    Public Shared docmapEnabled As Boolean = True

    Public Shared splitterDistance As Integer = 700

    Public Shared Sub createConfig()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml") Then
            File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")
        End If
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
        writer.WriteString(lang)
        writer.WriteEndElement()
        writer.WriteStartElement("UpdateType")
        writer.WriteString(updateType)
        writer.WriteEndElement()
        writer.WriteStartElement("UpdateCanal")
        writer.WriteString(updateCanal)
        writer.WriteEndElement()
        writer.WriteStartElement("DocumentMapEnabled")
        If docmapEnabled Then
            writer.WriteString("Yes")
        Else
            writer.WriteString("No")
        End If
        writer.WriteEndElement()
        writer.WriteStartElement("Theme")
        Select Case theme
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
                writer.WriteString("Modern")
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
                writer.WriteString("Blue")
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
                writer.WriteString("Silver")
            Case ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
                writer.WriteString("Black")
            Case Else
                writer.WriteString("Modern")
        End Select
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
        writer.WriteString(python2)
        writer.WriteEndElement()
        writer.WriteStartElement("Python3")
        writer.WriteString(python3)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Browsers")
        writer.WriteStartElement("Firefox")
        writer.WriteString(firefox)
        writer.WriteEndElement()
        writer.WriteStartElement("Chrome")
        writer.WriteString(chrome)
        writer.WriteEndElement()
        writer.WriteStartElement("Opera")
        writer.WriteString(opera)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Compilers")
        writer.WriteStartElement("GCC")
        writer.WriteString(gcc)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteStartElement("Projects")
        writer.WriteStartElement("DefaultWorkspace")
        writer.WriteString(projectsPath)
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    End Sub

    Public Shared Sub readConfig()
        Try
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/PyXel/General")
            For Each node As XmlNode In nodes
                ApplicationSettings.lang = node.SelectSingleNode("Language").InnerText
                ApplicationSettings.updateType = node.SelectSingleNode("UpdateType").InnerText
                ApplicationSettings.updateCanal = node.SelectSingleNode("UpdateCanal").InnerText
                Dim docmap As String = node.SelectSingleNode("DocumentMapEnabled").InnerText
                If docmap = "Yes" Then
                    ApplicationSettings.docmapEnabled = True
                Else
                    ApplicationSettings.docmapEnabled = False
                End If
                Dim theme As String = node.SelectSingleNode("Theme").InnerText
                Select Case theme
                    Case "Modern"
                        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
                    Case "Blue"
                        ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
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
            Next
            nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/PythonPath")
            For Each node As XmlNode In nodes
                ApplicationSettings.python2 = node.SelectSingleNode("Python2").InnerText
                ApplicationSettings.python3 = node.SelectSingleNode("Python3").InnerText
            Next
            nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Browsers")
            For Each node As XmlNode In nodes
                ApplicationSettings.opera = node.SelectSingleNode("Opera").InnerText
                ApplicationSettings.firefox = node.SelectSingleNode("Firefox").InnerText
                ApplicationSettings.chrome = node.SelectSingleNode("Chrome").InnerText
            Next
            nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Compilers")
            For Each node As XmlNode In nodes
                ApplicationSettings.gcc = node.SelectSingleNode("GCC").InnerText
            Next
            nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Projects")
            For Each node As XmlNode In nodes
                ApplicationSettings.projectsPath = node.SelectSingleNode("DefaultWorkspace").InnerText
            Next
        Catch
            upgradeConfig()
        End Try
    End Sub

    Public Shared Sub upgradeConfig()
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/PyXel/General")
        For Each node As XmlNode In nodes
            Try
                ApplicationSettings.lang = node.SelectSingleNode("Language").InnerText
            Catch
            End Try
            Try
                ApplicationSettings.updateType = node.SelectSingleNode("UpdateType").InnerText
            Catch
            End Try
            Try
                ApplicationSettings.updateCanal = node.SelectSingleNode("UpdateCanal").InnerText
            Catch
            End Try
            Try
                Dim docmap As String = node.SelectSingleNode("DocumentMapEnabled").InnerText
                If docmap = "Yes" Then
                    ApplicationSettings.docmapEnabled = True
                Else
                    ApplicationSettings.docmapEnabled = False
                End If
            Catch
            End Try
            Dim theme As String = node.SelectSingleNode("Theme").InnerText
            Select Case theme
                Case "Modern"
                    ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
                Case "Blue"
                    ApplicationSettings.theme = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue
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
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/PythonPath")
        For Each node As XmlNode In nodes
            ApplicationSettings.python2 = node.SelectSingleNode("Python2").InnerText
            ApplicationSettings.python3 = node.SelectSingleNode("Python3").InnerText
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Browsers")
        For Each node As XmlNode In nodes
            Try
                ApplicationSettings.opera = node.SelectSingleNode("Opera").InnerText
            Catch
            End Try
            Try
                ApplicationSettings.firefox = node.SelectSingleNode("Firefox").InnerText
            Catch
            End Try
            Try
                ApplicationSettings.chrome = node.SelectSingleNode("Chrome").InnerText
            Catch
            End Try
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Compilers")
        For Each node As XmlNode In nodes
            Try
                ApplicationSettings.gcc = node.SelectSingleNode("GCC").InnerText
            Catch
            End Try
        Next
        nodes = xmlDoc.DocumentElement.SelectNodes("/PyXel/Projects")
        For Each node As XmlNode In nodes
            Try
                ApplicationSettings.projectsPath = node.SelectSingleNode("DefaultWorkspace").InnerText
            Catch
            End Try
        Next
        createConfig()
    End Sub

End Class

