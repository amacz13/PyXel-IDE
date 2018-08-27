Imports System.IO

Public Class Help


    Public Sub updatePalette()
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme
    End Sub

    Private Sub Help_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.TextExtra = My.Settings.Version
        KryptonPalette1.BasePaletteMode = ApplicationSettings.theme

        Dim tn As New TreeNode
        tn.Name = "welcome"
        tn.Text = PyXelTranslations.strings.Item("help_welcome")
        tn.Tag = "welcome"

        Dim parent As New TreeNode
        parent.Name = "general"
        parent.Text = PyXelTranslations.strings.Item("help_general")
        parent.Tag = ""
        parent.Nodes.Add(tn)

        KryptonTreeView1.Nodes.Add(parent)



    End Sub

    Private Sub KryptonTreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles KryptonTreeView1.NodeMouseClick
        If File.Exists(My.Application.Info.DirectoryPath + "\help\" + ApplicationSettings.lang + "\" + e.Node.Tag + ".html") Then
            WebBrowser1.Url = New Uri(My.Application.Info.DirectoryPath + "\help\" + ApplicationSettings.lang + "\" + e.Node.Tag + ".html")
        End If

        'MsgBox(My.Application.Info.DirectoryPath + "\help\" + e.Node.Tag + ".html")
    End Sub
End Class