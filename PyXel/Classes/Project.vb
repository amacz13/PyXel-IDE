Imports System.IO
Imports System.Xml

Public Class Project

    Private filePath As String
    Private displayName As String
    Private workingDirectory As String
    Public projectNode As TreeNode
    Public nodeDict As Dictionary(Of TreeNode, String)

    Public Sub New(filePath As String, displayName As String, workingDirectory As String)
        Me.filePath = filePath
        Me.displayName = displayName
        Me.workingDirectory = workingDirectory
    End Sub

    Public Shared Function OpenProject(filePath As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(filePath)
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/PyXelProject/General")
        Dim projectName As String = "Untitled Project"
        For Each node As XmlNode In nodes
            projectName = node.SelectSingleNode("ProjectName").InnerText
        Next
        Dim dir As String = Path.GetDirectoryName(filePath)
        Dim project As New Project(filePath, projectName, dir)

        Dim ProjectNode As TreeNode = Form1.KryptonTreeView1.Nodes.Add(projectName)
        ProjectNode.ImageKey = "project"
        ProjectNode.SelectedImageKey = "project"
        ProjectNode.StateImageKey = "project"
        project.projectNode = ProjectNode
        LoadDirectory(dir, project)
        Form1.KryptonSplitContainer2.Panel1Collapsed = False
        Form1.KryptonRibbon1.SelectedContext += ",Projet"
        Return project
    End Function



    Public Shared Sub LoadDirectory(directory As String, prj As Project)
        Dim di As New DirectoryInfo(directory)
        LoadSubDirectories(directory, prj.projectNode)
        LoadFiles(directory, prj.projectNode)
    End Sub

    Public Shared Sub LoadSubDirectories(dir As String, td As TreeNode)
        Dim subdirectoryEntries As String() = Directory.GetDirectories(dir)
        For Each subdirectory As String In subdirectoryEntries
            Dim di As New DirectoryInfo(subdirectory)
            Dim tds As TreeNode = td.Nodes.Add(di.Name)
            tds.ImageKey = "folder"
            tds.StateImageKey = "folder"
            tds.SelectedImageKey = "folder"
            tds.Tag = di.FullName
            Dim menu As New ContextMenuStrip
            menu.Items.Add(New ToolStripMenuItem("Nouveau Fichier"))
            menu.Items.Add(New ToolStripMenuItem("Nouveau Dossier"))
            tds.ContextMenuStrip = menu
            LoadSubDirectories(subdirectory, tds)
            LoadFiles(subdirectory, tds)
        Next
    End Sub

    Public Shared Sub LoadFiles(dir As String, td As TreeNode)
        Dim Files As String() = Directory.GetFiles(dir, "*.*")
        For Each File In Files
            Dim fi As New FileInfo(File)
            Dim tds As TreeNode = td.Nodes.Add(fi.Name)
            tds.Tag = fi.FullName
            'prj.nodeDict.Add(tds, fi.FullName)
            Select Case fi.Extension
                Case ".py"
                    tds.ImageKey = "py"
                    tds.StateImageKey = "py"
                    tds.SelectedImageKey = "py"
                Case ".html"
                    tds.ImageKey = "html"
                    tds.StateImageKey = "html"
                    tds.SelectedImageKey = "html"
                Case ".js"
                    tds.ImageKey = "js"
                    tds.StateImageKey = "js"
                    tds.SelectedImageKey = "js"
                Case ".php"
                    tds.ImageKey = "php"
                    tds.StateImageKey = "php"
                    tds.SelectedImageKey = "php"
                Case ".css"
                    tds.ImageKey = "css"
                    tds.StateImageKey = "css"
                    tds.SelectedImageKey = "css"
                Case ".cpp"
                    tds.ImageKey = "cpp"
                    tds.StateImageKey = "cpp"
                    tds.SelectedImageKey = "cpp"
                Case ".c"
                    tds.ImageKey = "c"
                    tds.StateImageKey = "c"
                    tds.SelectedImageKey = "c"
                Case ".h"
                    tds.ImageKey = "h"
                    tds.StateImageKey = "h"
                    tds.SelectedImageKey = "h"
                Case Else
                    tds.ImageKey = "file"
                    tds.StateImageKey = "file"
                    tds.SelectedImageKey = "file"

            End Select
        Next
    End Sub
End Class
