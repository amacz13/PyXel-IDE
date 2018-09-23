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
        ApplyStrings()

    End Sub

    Public Shared Sub ApplyStrings()
        '
        ' MainForm
        '
        MainForm.KryptonRibbon1.RibbonStrings.RecentDocuments = PyXelTranslations.strings.Item("recent_docs")
        MainForm.KryptonRibbon1.RibbonStrings.ShowAboveRibbon = PyXelTranslations.strings.Item("show_above_ribbon")
        MainForm.KryptonRibbon1.RibbonStrings.ShowBelowRibbon = PyXelTranslations.strings.Item("show_below_ribbon")
        MainForm.KryptonRibbon1.RibbonStrings.ShowQATAboveRibbon = PyXelTranslations.strings.Item("show_qat_above")
        MainForm.KryptonRibbon1.RibbonStrings.ShowQATBelowRibbon = PyXelTranslations.strings.Item("show_qat_below")
        MainForm.KryptonRibbonQATButton3.Text = PyXelTranslations.strings.Item("new")
        MainForm.KryptonRibbonQATButton3.ToolTipTitle = PyXelTranslations.strings.Item("new")
        MainForm.KryptonRibbonQATButton4.Text = PyXelTranslations.strings.Item("open")
        MainForm.KryptonRibbonQATButton4.ToolTipTitle = PyXelTranslations.strings.Item("open")
        MainForm.KryptonRibbonQATButton1.Text = PyXelTranslations.strings.Item("save")
        MainForm.KryptonRibbonQATButton1.ToolTipTitle = PyXelTranslations.strings.Item("save")
        MainForm.KryptonRibbonQATButton5.Text = PyXelTranslations.strings.Item("back")
        MainForm.KryptonRibbonQATButton5.ToolTipTitle = PyXelTranslations.strings.Item("back")
        MainForm.KryptonRibbonQATButton6.Text = PyXelTranslations.strings.Item("forward")
        MainForm.KryptonRibbonQATButton6.ToolTipTitle = PyXelTranslations.strings.Item("forward")
        MainForm.KryptonContextMenuItem1.Text = PyXelTranslations.strings.Item("new")
        MainForm.KryptonContextMenuHeading4.Text = PyXelTranslations.strings.Item("project")
        MainForm.KryptonContextMenuItem13.Text = PyXelTranslations.strings.Item("new_project")
        MainForm.KryptonContextMenuItem7.Text = PyXelTranslations.strings.Item("python_file")
        MainForm.KryptonContextMenuItem8.Text = PyXelTranslations.strings.Item("html_file")
        MainForm.KryptonContextMenuItem9.Text = PyXelTranslations.strings.Item("css_file")
        MainForm.KryptonContextMenuItem10.Text = PyXelTranslations.strings.Item("js_file")
        MainForm.KryptonContextMenuItem11.Text = PyXelTranslations.strings.Item("php_file")
        MainForm.KryptonContextMenuItem27.Text = PyXelTranslations.strings.Item("xml_file")
        MainForm.KryptonContextMenuItem12.Text = PyXelTranslations.strings.Item("c_file")
        MainForm.KryptonContextMenuItem14.Text = PyXelTranslations.strings.Item("cpp_file")
        MainForm.KryptonContextMenuItem2.Text = PyXelTranslations.strings.Item("open")
        MainForm.KryptonContextMenuItem3.Text = PyXelTranslations.strings.Item("save")
        MainForm.KryptonContextMenuItem18.Text = PyXelTranslations.strings.Item("import")
        MainForm.KryptonContextMenuItem19.Text = PyXelTranslations.strings.Item("export")
        MainForm.KryptonContextMenuItem21.Text = PyXelTranslations.strings.Item("pdf_file")
        MainForm.KryptonContextMenuItem22.Text = PyXelTranslations.strings.Item("word_file")
        MainForm.KryptonContextMenuItem23.Text = PyXelTranslations.strings.Item("html_file")
        MainForm.KryptonContextMenuItem4.Text = PyXelTranslations.strings.Item("settings")
        MainForm.ButtonSpecAppMenu1.Text = PyXelTranslations.strings.Item("about")
        MainForm.ButtonSpecAppMenu2.Text = PyXelTranslations.strings.Item("quit")
        MainForm.KryptonRibbonTab1.Text = PyXelTranslations.strings.Item("tab_Home")
        MainForm.KryptonRibbonGroupButton2.TextLine1 = PyXelTranslations.strings.Item("cut")
        MainForm.KryptonRibbonGroupButton3.TextLine1 = PyXelTranslations.strings.Item("copy")
        MainForm.KryptonRibbonGroupButton6.TextLine1 = PyXelTranslations.strings.Item("paste")
        MainForm.KryptonRibbonGroup1.TextLine1 = PyXelTranslations.strings.Item("code")
        MainForm.KryptonRibbonGroupButton1.TextLine1 = PyXelTranslations.strings.Item("comment")
        MainForm.KryptonRibbonGroupButton9.TextLine1 = PyXelTranslations.strings.Item("create_Bookmark_1")
        MainForm.KryptonRibbonGroupButton9.TextLine2 = PyXelTranslations.strings.Item("create_Bookmark_2")
        MainForm.KryptonRibbonGroupButton10.TextLine1 = PyXelTranslations.strings.Item("remove_Bookmark_1")
        MainForm.KryptonRibbonGroupButton10.TextLine2 = PyXelTranslations.strings.Item("remove_Bookmark_2")
        MainForm.KryptonRibbonGroupButton11.TextLine1 = PyXelTranslations.strings.Item("find")
        MainForm.KryptonRibbonGroupButton12.TextLine1 = PyXelTranslations.strings.Item("find_replace_1")
        MainForm.KryptonRibbonGroupButton12.TextLine2 = PyXelTranslations.strings.Item("find_replace_2")
        MainForm.KryptonRibbonGroupButton13.TextLine1 = PyXelTranslations.strings.Item("go_to_line_1")
        MainForm.KryptonRibbonGroupButton13.TextLine2 = PyXelTranslations.strings.Item("go_to_line_2")
        MainForm.KryptonRibbonGroupButton4.TextLine1 = PyXelTranslations.strings.Item("collapse")
        MainForm.KryptonRibbonTab2.Text = PyXelTranslations.strings.Item("tab_Debug")
        MainForm.KryptonRibbonTab7.Text = PyXelTranslations.strings.Item("tab_Python")
        MainForm.KryptonRibbonGroupButton14.TextLine1 = PyXelTranslations.strings.Item("execute")
        MainForm.KryptonRibbonGroupButton16.TextLine1 = PyXelTranslations.strings.Item("console")
        MainForm.KryptonRibbonGroupButton17.TextLine1 = PyXelTranslations.strings.Item("stop_execution_1")
        MainForm.KryptonRibbonGroupButton17.TextLine2 = PyXelTranslations.strings.Item("stop_execution_2")
        MainForm.KryptonRibbonGroupButton18.TextLine1 = PyXelTranslations.strings.Item("execute")
        MainForm.KryptonRibbonGroupButton19.TextLine1 = PyXelTranslations.strings.Item("console")
        MainForm.KryptonRibbonGroupButton20.TextLine1 = PyXelTranslations.strings.Item("stop_execution_1")
        MainForm.KryptonRibbonGroupButton20.TextLine2 = PyXelTranslations.strings.Item("stop_execution_2")
        MainForm.KryptonRibbonTab8.Text = PyXelTranslations.strings.Item("tab_Web")
        MainForm.KryptonRibbonGroup7.TextLine1 = PyXelTranslations.strings.Item("preview")
        MainForm.KryptonRibbonTab3.Text = PyXelTranslations.strings.Item("tab_C")
        MainForm.KryptonRibbonGroup8.TextLine1 = PyXelTranslations.strings.Item("compilation")
        MainForm.KryptonRibbonGroupButton25.TextLine1 = PyXelTranslations.strings.Item("compile")
        MainForm.KryptonRibbonGroupButton26.TextLine1 = PyXelTranslations.strings.Item("execute")
        MainForm.KryptonHeaderGroup1.ValuesPrimary.Heading = PyXelTranslations.strings.Item("projects")
        MainForm.ToolStripMenuItem1.Text = PyXelTranslations.strings.Item("close_tab")
        MainForm.ToolStripMenuItem2.Text = PyXelTranslations.strings.Item("cut")
        MainForm.ToolStripMenuItem3.Text = PyXelTranslations.strings.Item("copy")
        MainForm.ToolStripMenuItem4.Text = PyXelTranslations.strings.Item("paste")
        MainForm.ToolStripMenuItem5.Text = PyXelTranslations.strings.Item("back")
        MainForm.ToolStripMenuItem6.Text = PyXelTranslations.strings.Item("forward")

        '
        ' Settings
        '
        Settings.KryptonPage1.Text = PyXelTranslations.strings.Item("general")
        Settings.KryptonRadioButton6.Values.Text = PyXelTranslations.strings.Item("yes")
        Settings.KryptonRadioButton7.Values.Text = PyXelTranslations.strings.Item("discreet")
        Settings.KryptonRadioButton8.Values.Text = PyXelTranslations.strings.Item("no")
        Settings.KryptonLabel8.Values.Text = PyXelTranslations.strings.Item("update_research")
        Settings.KryptonRadioButton5.Values.Text = PyXelTranslations.strings.Item("insider")
        Settings.KryptonRadioButton4.Values.Text = PyXelTranslations.strings.Item("stable")
        Settings.KryptonLabel4.Values.Text = PyXelTranslations.strings.Item("update_canal")
        Settings.KryptonLabel2.Values.Text = PyXelTranslations.strings.Item("language")
        Settings.KryptonPage2.Text = PyXelTranslations.strings.Item("customize")
        Settings.KryptonRadioButton9.Values.Text = PyXelTranslations.strings.Item("modern_theme")
        Settings.KryptonButton5.Values.Text = PyXelTranslations.strings.Item("more_settings")
        Settings.KryptonButton4.Values.Text = PyXelTranslations.strings.Item("more_settings")
        Settings.KryptonColorButton3.Values.Text = PyXelTranslations.strings.Item("fore_color")
        Settings.KryptonColorButton4.Values.Text = PyXelTranslations.strings.Item("back_color")
        Settings.KryptonLabel7.Values.Text = PyXelTranslations.strings.Item("interpreter")
        Settings.KryptonColorButton2.Values.Text = PyXelTranslations.strings.Item("fore_color")
        Settings.KryptonColorButton1.Values.Text = PyXelTranslations.strings.Item("back_color")
        Settings.KryptonLabel6.Values.Text = PyXelTranslations.strings.Item("editor")
        Settings.KryptonLabel5.Values.Text = PyXelTranslations.strings.Item("pyxel_theme")
        Settings.KryptonRadioButton3.Values.Text = PyXelTranslations.strings.Item("black_theme")
        Settings.KryptonRadioButton2.Values.Text = PyXelTranslations.strings.Item("silver_theme")
        Settings.KryptonRadioButton1.Values.Text = PyXelTranslations.strings.Item("blue_theme")
        Settings.KryptonPage3.Text = PyXelTranslations.strings.Item("projects")
        Settings.KryptonLabel12.Values.Text = PyXelTranslations.strings.Item("default_workspace")
        Settings.KryptonLabel3.Values.Text = PyXelTranslations.strings.Item("python3_exe_path")
        Settings.KryptonLabel1.Values.Text = PyXelTranslations.strings.Item("python2_exe_path")
        Settings.KryptonLabel11.Values.Text = PyXelTranslations.strings.Item("opera_path")
        Settings.KryptonLabel10.Values.Text = PyXelTranslations.strings.Item("chrome_path")
        Settings.KryptonLabel9.Values.Text = PyXelTranslations.strings.Item("firefox_path")
        Settings.KryptonLabel13.Values.Text = PyXelTranslations.strings.Item("gcc_path")
        Settings.Text = PyXelTranslations.strings.Item("settings")

        '
        ' New Project Wizard
        '
        NewProjectWizard.KryptonLabel3.Values.Text = PyXelTranslations.strings.Item("location")
        NewProjectWizard.KryptonLabel2.Values.Text = PyXelTranslations.strings.Item("project_name")
        NewProjectWizard.KryptonLabel1.Values.Text = PyXelTranslations.strings.Item("new_project")
        NewProjectWizard.KryptonButton1.Values.Text = PyXelTranslations.strings.Item("confirm")
        NewProjectWizard.Text = PyXelTranslations.strings.Item("new_project_wizard")

        '
        ' About
        '
        About.KryptonHeader1.Values.Heading = PyXelTranslations.strings.Item("license")
        About.Text = PyXelTranslations.strings.Item("about_pyxel")

        '
        ' Help
        ' For some obscur reasons, it is impossible to apply strings of the Help form at this moment, so the code will be placed into the Load function of the form
        '
        'Help.Text = PyXelTranslations.strings.Item("help")
        'Help.KryptonHeaderGroup1.ValuesPrimary.Heading = PyXelTranslations.strings.Item("help")
    End Sub

End Class
