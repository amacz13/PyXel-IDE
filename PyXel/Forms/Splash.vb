Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Xml

Public Class Splash

    Dim img As Integer = 0
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Hide()

        Me.TransparencyKey = Color.Gray
        Label1.ForeColor = Color.White
        Label1.Text = My.Settings.Version
        'MessageBox.Show(My.Application.Info.DirectoryPath, "AppPath", MessageBoxButtons.OK, MessageBoxIcon.Error)
        If (Not File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")) Then
            createConfig()
        Else
            readConfig()
        End If
        If (Not File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")) Then
            Dim sw As StreamWriter = New StreamWriter(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")
            sw.Close()
        Else
            Dim sr As StreamReader = New StreamReader(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")
            Do While sr.Peek() >= 0
                Dim str As String = sr.ReadLine()
                ApplicationSettings.recentDocs.Add(System.IO.Path.GetFileName(str), str)
                sr.Close()
            Loop
        End If
        'If (Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\langs")) Then
        '    If CheckForInternetConnection() Then
        '        Dim msg As String
        '        Dim title As String
        '        Dim style As MsgBoxStyle
        '        msg = "We need to download language files in order PyXel to run properly." + vbNewLine + "Do you want to do this now ?"  ' Define message.
        '        title = "PyXel - Language"
        '        Dim result As MsgBoxResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '        If result = MsgBoxResult.Yes Then
        '            Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\langs")
        '            My.Computer.Network.DownloadFile("https://amacz13.fr/files/pyxel/languagefiles/french.xml", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\langs\french.xml")
        '            My.Computer.Network.DownloadFile("https://amacz13.fr/files/pyxel/languagefiles/english.xml", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\langs\english.xml")
        '            MsgBox("PyXel has downloaded language files successfully.", MsgBoxStyle.Information, "PyXel")
        '        ElseIf result = MsgBoxResult.Cancel Then
        '            MsgBox("PyXel will not download language files." + vbNewLine + "While language files are not downloaded, PyXel language will be in French." + vbNewLine + "We will try to download language file at the next start of PyXel.", MsgBoxStyle.Critical, "PyXel - Error")
        '        End If
        '    Else
        '        MsgBox("You're currently offline. PyXel can't download language files." + vbNewLine + "While language files are not downloaded, PyXel language will be in French." + vbNewLine + "We will try to download language file at the next start of PyXel.", MsgBoxStyle.Critical, "PyXel - Error")
        '    End If
        'Else

        'End If
    End Sub

    Private Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Sub createConfig()
        Dim writer As New XmlTextWriter(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml", System.Text.Encoding.UTF8)
        writer.WriteStartDocument(True)
        writer.Formatting = Formatting.Indented
        writer.Indentation = 2
        writer.WriteStartElement("PyXel")
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

    Private Sub readConfig()
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