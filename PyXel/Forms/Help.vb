Imports System.IO

Public Class Help


    Public Sub updatePalette()
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
    End Sub

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.TextExtra = My.Settings.Version
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
    End Sub

    Private Sub KryptonTreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles KryptonTreeView1.NodeMouseClick
        If File.Exists(My.Application.Info.DirectoryPath + "\help\" + e.Node.Tag + ".html") Then
            WebBrowser1.Url = New Uri(My.Application.Info.DirectoryPath + "\help\" + e.Node.Tag + ".html")
        End If

        'MsgBox(My.Application.Info.DirectoryPath + "\help\" + e.Node.Tag + ".html")
    End Sub
End Class