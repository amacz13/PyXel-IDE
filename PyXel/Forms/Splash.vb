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
        If (Not File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\config.xml")) Then
            ApplicationSettings.createConfig()
        Else
            ApplicationSettings.readConfig()
        End If
        PyXelTranslations.LoadStrings()
        If (Not File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")) Then
            Dim sw As StreamWriter = New StreamWriter(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")
            sw.Close()
        Else
            Dim sr As StreamReader = New StreamReader(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")
            Do While sr.Peek() >= 0
                Try
                    Dim str As String = sr.ReadLine()
                    ApplicationSettings.recentDocs.Add(str)
                Catch
                    MsgBox("An error occured while loading recent documents !")
                End Try
            Loop
            sr.Close()
        End If

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

End Class
