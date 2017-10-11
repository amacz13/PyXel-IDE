<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonDockableNavigator1 = New ComponentFactory.Krypton.Docking.KryptonDockableNavigator()
        Me.KryptonPage1 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonButton3 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonTextBox3 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonTextBox2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonRadioButton5 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonRadioButton4 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPage2 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonRadioButton3 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonRadioButton2 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonRadioButton1 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonPage3 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonDockableNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonDockableNavigator1.SuspendLayout()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage1.SuspendLayout()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage2.SuspendLayout()
        CType(Me.KryptonPage3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonDockableNavigator1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(947, 461)
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonDockableNavigator1
        '
        Me.KryptonDockableNavigator1.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None
        Me.KryptonDockableNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None
        Me.KryptonDockableNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide
        Me.KryptonDockableNavigator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonDockableNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonDockableNavigator1.Name = "KryptonDockableNavigator1"
        Me.KryptonDockableNavigator1.Pages.AddRange(New ComponentFactory.Krypton.Navigator.KryptonPage() {Me.KryptonPage1, Me.KryptonPage2, Me.KryptonPage3})
        Me.KryptonDockableNavigator1.Palette = Me.KryptonPalette1
        Me.KryptonDockableNavigator1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonDockableNavigator1.SelectedIndex = 0
        Me.KryptonDockableNavigator1.Size = New System.Drawing.Size(947, 461)
        Me.KryptonDockableNavigator1.TabIndex = 0
        Me.KryptonDockableNavigator1.Text = "KryptonDockableNavigator1"
        '
        'KryptonPage1
        '
        Me.KryptonPage1.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage1.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPage1.Controls.Add(Me.KryptonButton3)
        Me.KryptonPage1.Controls.Add(Me.KryptonTextBox3)
        Me.KryptonPage1.Controls.Add(Me.KryptonButton2)
        Me.KryptonPage1.Controls.Add(Me.KryptonTextBox2)
        Me.KryptonPage1.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPage1.Controls.Add(Me.KryptonRadioButton5)
        Me.KryptonPage1.Controls.Add(Me.KryptonRadioButton4)
        Me.KryptonPage1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPage1.Controls.Add(Me.KryptonButton1)
        Me.KryptonPage1.Controls.Add(Me.KryptonTextBox1)
        Me.KryptonPage1.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPage1.Flags = 65534
        Me.KryptonPage1.LastVisibleSet = True
        Me.KryptonPage1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage1.Name = "KryptonPage1"
        Me.KryptonPage1.Size = New System.Drawing.Size(945, 434)
        Me.KryptonPage1.Text = "Général"
        Me.KryptonPage1.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage1.UniqueName = "54201FA19EA54097D69B7DEE6263BA24"
        '
        'KryptonButton3
        '
        Me.KryptonButton3.Location = New System.Drawing.Point(889, 96)
        Me.KryptonButton3.Name = "KryptonButton3"
        Me.KryptonButton3.Size = New System.Drawing.Size(45, 25)
        Me.KryptonButton3.TabIndex = 11
        Me.KryptonButton3.Values.Text = "..."
        '
        'KryptonTextBox3
        '
        Me.KryptonTextBox3.Location = New System.Drawing.Point(252, 97)
        Me.KryptonTextBox3.Name = "KryptonTextBox3"
        Me.KryptonTextBox3.ReadOnly = True
        Me.KryptonTextBox3.Size = New System.Drawing.Size(631, 23)
        Me.KryptonTextBox3.TabIndex = 10
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Location = New System.Drawing.Point(889, 67)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.Size = New System.Drawing.Size(45, 25)
        Me.KryptonButton2.TabIndex = 8
        Me.KryptonButton2.Values.Text = "..."
        '
        'KryptonTextBox2
        '
        Me.KryptonTextBox2.Location = New System.Drawing.Point(252, 68)
        Me.KryptonTextBox2.Name = "KryptonTextBox2"
        Me.KryptonTextBox2.ReadOnly = True
        Me.KryptonTextBox2.Size = New System.Drawing.Size(631, 23)
        Me.KryptonTextBox2.TabIndex = 7
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(11, 71)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(235, 20)
        Me.KryptonLabel3.TabIndex = 6
        Me.KryptonLabel3.Values.Text = "Emplacement de l'exécutable Python 3.x :"
        '
        'KryptonRadioButton5
        '
        Me.KryptonRadioButton5.Location = New System.Drawing.Point(326, 15)
        Me.KryptonRadioButton5.Name = "KryptonRadioButton5"
        Me.KryptonRadioButton5.Size = New System.Drawing.Size(61, 20)
        Me.KryptonRadioButton5.TabIndex = 5
        Me.KryptonRadioButton5.Values.Text = "English"
        '
        'KryptonRadioButton4
        '
        Me.KryptonRadioButton4.Checked = True
        Me.KryptonRadioButton4.Location = New System.Drawing.Point(252, 15)
        Me.KryptonRadioButton4.Name = "KryptonRadioButton4"
        Me.KryptonRadioButton4.Size = New System.Drawing.Size(66, 20)
        Me.KryptonRadioButton4.TabIndex = 4
        Me.KryptonRadioButton4.Values.Text = "Français"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(11, 15)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(56, 20)
        Me.KryptonLabel2.TabIndex = 3
        Me.KryptonLabel2.Values.Text = "Langue : "
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(889, 37)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(45, 25)
        Me.KryptonButton1.TabIndex = 2
        Me.KryptonButton1.Values.Text = "..."
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Location = New System.Drawing.Point(252, 38)
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.ReadOnly = True
        Me.KryptonTextBox1.Size = New System.Drawing.Size(631, 23)
        Me.KryptonTextBox1.TabIndex = 1
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(11, 41)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(235, 20)
        Me.KryptonLabel1.TabIndex = 0
        Me.KryptonLabel1.Values.Text = "Emplacement de l'exécutable Python 2.x :"
        '
        'KryptonPage2
        '
        Me.KryptonPage2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage2.Controls.Add(Me.KryptonRadioButton3)
        Me.KryptonPage2.Controls.Add(Me.KryptonRadioButton2)
        Me.KryptonPage2.Controls.Add(Me.KryptonRadioButton1)
        Me.KryptonPage2.Flags = 65534
        Me.KryptonPage2.LastVisibleSet = True
        Me.KryptonPage2.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage2.Name = "KryptonPage2"
        Me.KryptonPage2.Size = New System.Drawing.Size(945, 434)
        Me.KryptonPage2.Text = "Personnalisation"
        Me.KryptonPage2.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage2.UniqueName = "1388149E86964C206FA093B3F59F40FA"
        '
        'KryptonRadioButton3
        '
        Me.KryptonRadioButton3.Location = New System.Drawing.Point(224, 15)
        Me.KryptonRadioButton3.Name = "KryptonRadioButton3"
        Me.KryptonRadioButton3.Size = New System.Drawing.Size(87, 20)
        Me.KryptonRadioButton3.TabIndex = 2
        Me.KryptonRadioButton3.Values.Text = "Thème Noir"
        '
        'KryptonRadioButton2
        '
        Me.KryptonRadioButton2.Location = New System.Drawing.Point(103, 15)
        Me.KryptonRadioButton2.Name = "KryptonRadioButton2"
        Me.KryptonRadioButton2.Size = New System.Drawing.Size(100, 20)
        Me.KryptonRadioButton2.TabIndex = 1
        Me.KryptonRadioButton2.Values.Text = "Thème Argent"
        '
        'KryptonRadioButton1
        '
        Me.KryptonRadioButton1.Location = New System.Drawing.Point(11, 15)
        Me.KryptonRadioButton1.Name = "KryptonRadioButton1"
        Me.KryptonRadioButton1.Size = New System.Drawing.Size(86, 20)
        Me.KryptonRadioButton1.TabIndex = 0
        Me.KryptonRadioButton1.Values.Text = "Thème Bleu"
        '
        'KryptonPage3
        '
        Me.KryptonPage3.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage3.Flags = 65534
        Me.KryptonPage3.LastVisibleSet = True
        Me.KryptonPage3.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage3.Name = "KryptonPage3"
        Me.KryptonPage3.Size = New System.Drawing.Size(945, 434)
        Me.KryptonPage3.Text = "Addons"
        Me.KryptonPage3.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage3.UniqueName = "AF1CD006D10E40ACE3BD9433B3F0DD55"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(11, 98)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(112, 20)
        Me.KryptonLabel4.TabIndex = 12
        Me.KryptonLabel4.Values.Text = "Dossier de Travail :"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 461)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.Text = "Paramètres"
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        CType(Me.KryptonDockableNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonDockableNavigator1.ResumeLayout(False)
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage1.ResumeLayout(False)
        Me.KryptonPage1.PerformLayout()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage2.ResumeLayout(False)
        Me.KryptonPage2.PerformLayout()
        CType(Me.KryptonPage3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonDockableNavigator1 As ComponentFactory.Krypton.Docking.KryptonDockableNavigator
    Friend WithEvents KryptonPage1 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage2 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage3 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonRadioButton3 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonRadioButton2 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonRadioButton1 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonRadioButton5 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonRadioButton4 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton3 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox3 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
End Class
