<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Help
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bienvenue !")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuration Requise")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Prise en main")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PyXel - Général", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PyXel - Extensions")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Help))
        Me.KryptonHeaderGroup1 = New ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup()
        Me.KryptonPalette1 = New ComponentFactory.Krypton.Toolkit.KryptonPalette(Me.components)
        Me.KryptonTreeView1 = New ComponentFactory.Krypton.Toolkit.KryptonTreeView()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.KryptonHeaderGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonHeaderGroup1.Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonHeaderGroup1.Panel.SuspendLayout()
        Me.KryptonHeaderGroup1.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonHeaderGroup1
        '
        Me.KryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Left
        Me.KryptonHeaderGroup1.HeaderVisibleSecondary = False
        Me.KryptonHeaderGroup1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonHeaderGroup1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonHeaderGroup1.Name = "KryptonHeaderGroup1"
        Me.KryptonHeaderGroup1.Palette = Me.KryptonPalette1
        Me.KryptonHeaderGroup1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        '
        'KryptonHeaderGroup1.Panel
        '
        Me.KryptonHeaderGroup1.Panel.Controls.Add(Me.KryptonTreeView1)
        Me.KryptonHeaderGroup1.Size = New System.Drawing.Size(518, 935)
        Me.KryptonHeaderGroup1.TabIndex = 0
        Me.KryptonHeaderGroup1.ValuesPrimary.Heading = "Aide"
        Me.KryptonHeaderGroup1.ValuesPrimary.Image = Nothing
        '
        'KryptonPalette1
        '
        Me.KryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2013
        '
        'KryptonTreeView1
        '
        Me.KryptonTreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonTreeView1.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorOverflow
        Me.KryptonTreeView1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonTreeView1.Name = "KryptonTreeView1"
        TreeNode1.Name = "Nœud2"
        TreeNode1.Tag = "welcome"
        TreeNode1.Text = "Bienvenue !"
        TreeNode2.Name = "Nœud5"
        TreeNode2.Tag = "configuration"
        TreeNode2.Text = "Configuration Requise"
        TreeNode3.Name = "Nœud2"
        TreeNode3.Tag = "getstarted"
        TreeNode3.Text = "Prise en main"
        TreeNode4.Checked = True
        TreeNode4.Name = "Nœud0"
        TreeNode4.Tag = "general"
        TreeNode4.Text = "PyXel - Général"
        TreeNode5.Name = "Nœud1"
        TreeNode5.Text = "PyXel - Extensions"
        Me.KryptonTreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5})
        Me.KryptonTreeView1.Palette = Me.KryptonPalette1
        Me.KryptonTreeView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonTreeView1.Size = New System.Drawing.Size(516, 877)
        Me.KryptonTreeView1.TabIndex = 0
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.WebBrowser1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(518, 0)
        Me.KryptonPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Palette = Me.KryptonPalette1
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.KryptonPanel1.Size = New System.Drawing.Size(972, 935)
        Me.KryptonPanel1.TabIndex = 1
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(972, 935)
        Me.WebBrowser1.TabIndex = 0
        '
        'Help
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1490, 935)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Controls.Add(Me.KryptonHeaderGroup1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "Help"
        Me.Palette = Me.KryptonPalette1
        Me.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom
        Me.Text = "Help"
        CType(Me.KryptonHeaderGroup1.Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonHeaderGroup1.Panel.ResumeLayout(False)
        CType(Me.KryptonHeaderGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonHeaderGroup1.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonHeaderGroup1 As ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Private WithEvents KryptonPalette1 As ComponentFactory.Krypton.Toolkit.KryptonPalette
    Friend WithEvents KryptonTreeView1 As ComponentFactory.Krypton.Toolkit.KryptonTreeView
    Friend WithEvents WebBrowser1 As WebBrowser
End Class
