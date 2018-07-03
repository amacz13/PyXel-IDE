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
        Me.KryptonCheckButton2 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonCheckButton1 = New ComponentFactory.Krypton.Toolkit.KryptonCheckButton()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonComboBox1 = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPage2 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonButton5 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButton4 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonColorButton3 = New ComponentFactory.Krypton.Toolkit.KryptonColorButton()
        Me.KryptonColorButton4 = New ComponentFactory.Krypton.Toolkit.KryptonColorButton()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonColorButton2 = New ComponentFactory.Krypton.Toolkit.KryptonColorButton()
        Me.KryptonColorButton1 = New ComponentFactory.Krypton.Toolkit.KryptonColorButton()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonRadioButton3 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonRadioButton2 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonRadioButton1 = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.KryptonPage3 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonPage4 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonButton2 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonTextBox2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonPage5 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonPage6 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonDockableNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonDockableNavigator1.SuspendLayout()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage1.SuspendLayout()
        CType(Me.KryptonComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage2.SuspendLayout()
        CType(Me.KryptonPage3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPage4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage4.SuspendLayout()
        CType(Me.KryptonPage5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonPage6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.KryptonDockableNavigator1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(1894, 887)
        Me.KryptonPanel1.TabIndex = 0
        '
        'KryptonDockableNavigator1
        '
        Me.KryptonDockableNavigator1.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameWidthAndHeight
        Me.KryptonDockableNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.HidePage
        Me.KryptonDockableNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide
        Me.KryptonDockableNavigator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonDockableNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonDockableNavigator1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonDockableNavigator1.Name = "KryptonDockableNavigator1"
        Me.KryptonDockableNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarRibbonTabGroup
        Me.KryptonDockableNavigator1.Pages.AddRange(New ComponentFactory.Krypton.Navigator.KryptonPage() {Me.KryptonPage1, Me.KryptonPage2, Me.KryptonPage3, Me.KryptonPage4, Me.KryptonPage5, Me.KryptonPage6})
        Me.KryptonDockableNavigator1.Palette = Me.KryptonPalette1
        Me.KryptonDockableNavigator1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonDockableNavigator1.SelectedIndex = 1
        Me.KryptonDockableNavigator1.Size = New System.Drawing.Size(1894, 887)
        Me.KryptonDockableNavigator1.TabIndex = 0
        Me.KryptonDockableNavigator1.Text = "KryptonDockableNavigator1"
        '
        'KryptonPage1
        '
        Me.KryptonPage1.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage1.Controls.Add(Me.KryptonCheckButton2)
        Me.KryptonPage1.Controls.Add(Me.KryptonCheckButton1)
        Me.KryptonPage1.Controls.Add(Me.KryptonLabel4)
        Me.KryptonPage1.Controls.Add(Me.KryptonComboBox1)
        Me.KryptonPage1.Controls.Add(Me.KryptonLabel2)
        Me.KryptonPage1.Flags = 65534
        Me.KryptonPage1.LastVisibleSet = True
        Me.KryptonPage1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonPage1.MinimumSize = New System.Drawing.Size(100, 96)
        Me.KryptonPage1.Name = "KryptonPage1"
        Me.KryptonPage1.Size = New System.Drawing.Size(1892, 841)
        Me.KryptonPage1.Text = "Général"
        Me.KryptonPage1.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage1.UniqueName = "54201FA19EA54097D69B7DEE6263BA24"
        '
        'KryptonCheckButton2
        '
        Me.KryptonCheckButton2.Location = New System.Drawing.Point(213, 197)
        Me.KryptonCheckButton2.Name = "KryptonCheckButton2"
        Me.KryptonCheckButton2.Palette = Me.KryptonPalette1
        Me.KryptonCheckButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonCheckButton2.Size = New System.Drawing.Size(185, 43)
        Me.KryptonCheckButton2.TabIndex = 7
        Me.KryptonCheckButton2.Values.Text = "Insider"
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
        '
        'KryptonCheckButton1
        '
        Me.KryptonCheckButton1.Checked = True
        Me.KryptonCheckButton1.Location = New System.Drawing.Point(22, 197)
        Me.KryptonCheckButton1.Name = "KryptonCheckButton1"
        Me.KryptonCheckButton1.Palette = Me.KryptonPalette1
        Me.KryptonCheckButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonCheckButton1.Size = New System.Drawing.Size(185, 43)
        Me.KryptonCheckButton1.TabIndex = 6
        Me.KryptonCheckButton1.Values.Text = "Stable"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(22, 147)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(237, 37)
        Me.KryptonLabel4.TabIndex = 5
        Me.KryptonLabel4.Values.Text = "Canal de Mise à jour"
        '
        'KryptonComboBox1
        '
        Me.KryptonComboBox1.DropDownWidth = 893
        Me.KryptonComboBox1.Items.AddRange(New Object() {"Français", "English", "Deutsch"})
        Me.KryptonComboBox1.Location = New System.Drawing.Point(22, 81)
        Me.KryptonComboBox1.Name = "KryptonComboBox1"
        Me.KryptonComboBox1.Palette = Me.KryptonPalette1
        Me.KryptonComboBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonComboBox1.Size = New System.Drawing.Size(893, 37)
        Me.KryptonComboBox1.TabIndex = 4
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(22, 29)
        Me.KryptonLabel2.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Palette = Me.KryptonPalette1
        Me.KryptonLabel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonLabel2.Size = New System.Drawing.Size(106, 37)
        Me.KryptonLabel2.TabIndex = 3
        Me.KryptonLabel2.Values.Text = "Langue : "
        '
        'KryptonPage2
        '
        Me.KryptonPage2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage2.Controls.Add(Me.KryptonButton5)
        Me.KryptonPage2.Controls.Add(Me.KryptonButton4)
        Me.KryptonPage2.Controls.Add(Me.KryptonColorButton3)
        Me.KryptonPage2.Controls.Add(Me.KryptonColorButton4)
        Me.KryptonPage2.Controls.Add(Me.KryptonLabel7)
        Me.KryptonPage2.Controls.Add(Me.KryptonColorButton2)
        Me.KryptonPage2.Controls.Add(Me.KryptonColorButton1)
        Me.KryptonPage2.Controls.Add(Me.KryptonLabel6)
        Me.KryptonPage2.Controls.Add(Me.KryptonLabel5)
        Me.KryptonPage2.Controls.Add(Me.KryptonRadioButton3)
        Me.KryptonPage2.Controls.Add(Me.KryptonRadioButton2)
        Me.KryptonPage2.Controls.Add(Me.KryptonRadioButton1)
        Me.KryptonPage2.Flags = 65534
        Me.KryptonPage2.LastVisibleSet = True
        Me.KryptonPage2.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonPage2.MinimumSize = New System.Drawing.Size(100, 96)
        Me.KryptonPage2.Name = "KryptonPage2"
        Me.KryptonPage2.Size = New System.Drawing.Size(1892, 841)
        Me.KryptonPage2.Text = "Personnalisation"
        Me.KryptonPage2.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage2.UniqueName = "1388149E86964C206FA093B3F59F40FA"
        '
        'KryptonButton5
        '
        Me.KryptonButton5.Location = New System.Drawing.Point(958, 319)
        Me.KryptonButton5.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonButton5.Name = "KryptonButton5"
        Me.KryptonButton5.Palette = Me.KryptonPalette1
        Me.KryptonButton5.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonButton5.Size = New System.Drawing.Size(284, 48)
        Me.KryptonButton5.TabIndex = 12
        Me.KryptonButton5.Values.Text = "Plus de paramètres"
        '
        'KryptonButton4
        '
        Me.KryptonButton4.Location = New System.Drawing.Point(958, 192)
        Me.KryptonButton4.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonButton4.Name = "KryptonButton4"
        Me.KryptonButton4.Palette = Me.KryptonPalette1
        Me.KryptonButton4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonButton4.Size = New System.Drawing.Size(284, 48)
        Me.KryptonButton4.TabIndex = 11
        Me.KryptonButton4.Values.Text = "Plus de paramètres"
        '
        'KryptonColorButton3
        '
        Me.KryptonColorButton3.Location = New System.Drawing.Point(504, 319)
        Me.KryptonColorButton3.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonColorButton3.Name = "KryptonColorButton3"
        Me.KryptonColorButton3.Palette = Me.KryptonPalette1
        Me.KryptonColorButton3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonColorButton3.Size = New System.Drawing.Size(370, 48)
        Me.KryptonColorButton3.Splitter = False
        Me.KryptonColorButton3.TabIndex = 10
        Me.KryptonColorButton3.Values.Text = "Texte"
        '
        'KryptonColorButton4
        '
        Me.KryptonColorButton4.Location = New System.Drawing.Point(54, 319)
        Me.KryptonColorButton4.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonColorButton4.Name = "KryptonColorButton4"
        Me.KryptonColorButton4.Palette = Me.KryptonPalette1
        Me.KryptonColorButton4.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonColorButton4.Size = New System.Drawing.Size(370, 48)
        Me.KryptonColorButton4.Splitter = False
        Me.KryptonColorButton4.TabIndex = 9
        Me.KryptonColorButton4.Values.Text = "Arrière Plan"
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl
        Me.KryptonLabel7.Location = New System.Drawing.Point(22, 269)
        Me.KryptonLabel7.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(156, 37)
        Me.KryptonLabel7.TabIndex = 8
        Me.KryptonLabel7.Values.Text = "Interpréteur"
        '
        'KryptonColorButton2
        '
        Me.KryptonColorButton2.Location = New System.Drawing.Point(504, 192)
        Me.KryptonColorButton2.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonColorButton2.Name = "KryptonColorButton2"
        Me.KryptonColorButton2.Palette = Me.KryptonPalette1
        Me.KryptonColorButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonColorButton2.Size = New System.Drawing.Size(370, 48)
        Me.KryptonColorButton2.Splitter = False
        Me.KryptonColorButton2.TabIndex = 7
        Me.KryptonColorButton2.Values.Text = "Texte"
        '
        'KryptonColorButton1
        '
        Me.KryptonColorButton1.Location = New System.Drawing.Point(54, 192)
        Me.KryptonColorButton1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonColorButton1.Name = "KryptonColorButton1"
        Me.KryptonColorButton1.Palette = Me.KryptonPalette1
        Me.KryptonColorButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonColorButton1.Size = New System.Drawing.Size(370, 48)
        Me.KryptonColorButton1.Splitter = False
        Me.KryptonColorButton1.TabIndex = 6
        Me.KryptonColorButton1.Values.Text = "Arrière Plan"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl
        Me.KryptonLabel6.Location = New System.Drawing.Point(22, 142)
        Me.KryptonLabel6.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(98, 37)
        Me.KryptonLabel6.TabIndex = 5
        Me.KryptonLabel6.Values.Text = "Editeur"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl
        Me.KryptonLabel5.Location = New System.Drawing.Point(22, 29)
        Me.KryptonLabel5.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(201, 37)
        Me.KryptonLabel5.TabIndex = 4
        Me.KryptonLabel5.Values.Text = "Thème de PyXel"
        '
        'KryptonRadioButton3
        '
        Me.KryptonRadioButton3.Location = New System.Drawing.Point(456, 81)
        Me.KryptonRadioButton3.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonRadioButton3.Name = "KryptonRadioButton3"
        Me.KryptonRadioButton3.Palette = Me.KryptonPalette1
        Me.KryptonRadioButton3.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonRadioButton3.Size = New System.Drawing.Size(155, 37)
        Me.KryptonRadioButton3.TabIndex = 2
        Me.KryptonRadioButton3.Values.Text = "Thème Noir"
        '
        'KryptonRadioButton2
        '
        Me.KryptonRadioButton2.Location = New System.Drawing.Point(246, 81)
        Me.KryptonRadioButton2.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonRadioButton2.Name = "KryptonRadioButton2"
        Me.KryptonRadioButton2.Palette = Me.KryptonPalette1
        Me.KryptonRadioButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonRadioButton2.Size = New System.Drawing.Size(182, 37)
        Me.KryptonRadioButton2.TabIndex = 1
        Me.KryptonRadioButton2.Values.Text = "Thème Argent"
        '
        'KryptonRadioButton1
        '
        Me.KryptonRadioButton1.Location = New System.Drawing.Point(62, 81)
        Me.KryptonRadioButton1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonRadioButton1.Name = "KryptonRadioButton1"
        Me.KryptonRadioButton1.Palette = Me.KryptonPalette1
        Me.KryptonRadioButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonRadioButton1.Size = New System.Drawing.Size(154, 37)
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
        Me.KryptonPage3.Size = New System.Drawing.Size(1892, 841)
        Me.KryptonPage3.Text = "Projets"
        Me.KryptonPage3.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage3.UniqueName = "E20B0E02484F48EEF59672E5E22B045C"
        '
        'KryptonPage4
        '
        Me.KryptonPage4.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage4.Controls.Add(Me.KryptonButton2)
        Me.KryptonPage4.Controls.Add(Me.KryptonTextBox2)
        Me.KryptonPage4.Controls.Add(Me.KryptonLabel3)
        Me.KryptonPage4.Controls.Add(Me.KryptonButton1)
        Me.KryptonPage4.Controls.Add(Me.KryptonTextBox1)
        Me.KryptonPage4.Controls.Add(Me.KryptonLabel1)
        Me.KryptonPage4.Flags = 65534
        Me.KryptonPage4.LastVisibleSet = True
        Me.KryptonPage4.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage4.Name = "KryptonPage4"
        Me.KryptonPage4.Size = New System.Drawing.Size(1892, 841)
        Me.KryptonPage4.Text = "Python"
        Me.KryptonPage4.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage4.UniqueName = "3562E56287204BB467A4F6DADFF8131C"
        '
        'KryptonButton2
        '
        Me.KryptonButton2.Location = New System.Drawing.Point(1778, 143)
        Me.KryptonButton2.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonButton2.Name = "KryptonButton2"
        Me.KryptonButton2.Palette = Me.KryptonPalette1
        Me.KryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonButton2.Size = New System.Drawing.Size(90, 48)
        Me.KryptonButton2.TabIndex = 14
        Me.KryptonButton2.Values.Text = "..."
        '
        'KryptonTextBox2
        '
        Me.KryptonTextBox2.Location = New System.Drawing.Point(504, 145)
        Me.KryptonTextBox2.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonTextBox2.Name = "KryptonTextBox2"
        Me.KryptonTextBox2.ReadOnly = True
        Me.KryptonTextBox2.Size = New System.Drawing.Size(1262, 39)
        Me.KryptonTextBox2.TabIndex = 13
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(22, 151)
        Me.KryptonLabel3.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(464, 37)
        Me.KryptonLabel3.TabIndex = 12
        Me.KryptonLabel3.Values.Text = "Emplacement de l'exécutable Python 3.x :"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(1778, 85)
        Me.KryptonButton1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Palette = Me.KryptonPalette1
        Me.KryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonButton1.Size = New System.Drawing.Size(90, 48)
        Me.KryptonButton1.TabIndex = 11
        Me.KryptonButton1.Values.Text = "..."
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Location = New System.Drawing.Point(504, 87)
        Me.KryptonTextBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.ReadOnly = True
        Me.KryptonTextBox1.Size = New System.Drawing.Size(1262, 39)
        Me.KryptonTextBox1.TabIndex = 10
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(22, 93)
        Me.KryptonLabel1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(464, 37)
        Me.KryptonLabel1.TabIndex = 9
        Me.KryptonLabel1.Values.Text = "Emplacement de l'exécutable Python 2.x :"
        '
        'KryptonPage5
        '
        Me.KryptonPage5.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage5.Flags = 65534
        Me.KryptonPage5.LastVisibleSet = True
        Me.KryptonPage5.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage5.Name = "KryptonPage5"
        Me.KryptonPage5.Size = New System.Drawing.Size(1892, 841)
        Me.KryptonPage5.Text = "HTML / CSS / JS"
        Me.KryptonPage5.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage5.UniqueName = "834CDA7246034AEAEDB7FDC56D0274C5"
        '
        'KryptonPage6
        '
        Me.KryptonPage6.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage6.Flags = 65534
        Me.KryptonPage6.LastVisibleSet = True
        Me.KryptonPage6.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage6.Name = "KryptonPage6"
        Me.KryptonPage6.Size = New System.Drawing.Size(1892, 841)
        Me.KryptonPage6.Text = "C / C++"
        Me.KryptonPage6.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage6.UniqueName = "716E62464D95409D978C95226539172C"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1894, 887)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
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
        CType(Me.KryptonComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage2.ResumeLayout(False)
        Me.KryptonPage2.PerformLayout()
        CType(Me.KryptonPage3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPage4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage4.ResumeLayout(False)
        Me.KryptonPage4.PerformLayout()
        CType(Me.KryptonPage5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonPage6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonDockableNavigator1 As ComponentFactory.Krypton.Docking.KryptonDockableNavigator
    Friend WithEvents KryptonPage1 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage2 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonRadioButton3 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonRadioButton2 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonRadioButton1 As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonColorButton1 As ComponentFactory.Krypton.Toolkit.KryptonColorButton
    Friend WithEvents KryptonColorButton2 As ComponentFactory.Krypton.Toolkit.KryptonColorButton
    Friend WithEvents KryptonColorButton3 As ComponentFactory.Krypton.Toolkit.KryptonColorButton
    Friend WithEvents KryptonColorButton4 As ComponentFactory.Krypton.Toolkit.KryptonColorButton
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton5 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonButton4 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonPage3 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage4 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage5 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage6 As ComponentFactory.Krypton.Navigator.KryptonPage
    Private WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonButton2 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonComboBox1 As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents KryptonCheckButton2 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
    Friend WithEvents KryptonCheckButton1 As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
End Class
