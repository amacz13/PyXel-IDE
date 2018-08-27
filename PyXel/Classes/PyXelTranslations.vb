Imports System.IO

Public Class PyXelTranslations

    Public Shared strings As New Dictionary(Of String, String)

    Public Shared Sub LoadStrings()
        Try
            Dim sr As StreamReader = New StreamReader(Application.StartupPath + "\lang\" + ApplicationSettings.lang)
            Do While sr.Peek() >= 0
                Try
                    Dim str As String = sr.ReadLine()
                    If str.Substring(0, 1) IsNot "#" Then
                        Dim items As String() = str.Split("=")
                        Dim key As String = ""
                        Dim value As String = ""
                        For Each substring In items
                            If key = "" Then
                                key = substring
                            Else
                                value = substring
                            End If
                        Next
                        strings.Add(key, value)
                    End If
                Catch
                    MsgBox("An error occured while loading translations !")
                End Try
            Loop
            sr.Close()
        Catch ex As Exception
            MsgBox("An error occured while loading translations !")
        End Try
    End Sub

End Class
