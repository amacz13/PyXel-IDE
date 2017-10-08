<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.KryptonRibbon1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbon()
        Me.KryptonRibbonQATButton1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonQATButton()
        Me.KryptonRibbonQATButton2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonQATButton()
        Me.KryptonContextMenuItem1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonContextMenuItem2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonContextMenuItem3 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonContextMenuItem4 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.KryptonContextMenuItem5 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.ButtonSpecAppMenu1 = New ComponentFactory.Krypton.Ribbon.ButtonSpecAppMenu()
        Me.ButtonSpecAppMenu2 = New ComponentFactory.Krypton.Ribbon.ButtonSpecAppMenu()
        Me.KryptonRibbonTab1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab()
        Me.KryptonRibbonGroup1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup()
        Me.KryptonRibbonGroupTriple1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple()
        Me.KryptonRibbonGroupButton2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroupButton3 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroupButton6 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroupSeparator1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator()
        Me.KryptonRibbonGroupTriple3 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple()
        Me.KryptonRibbonGroupButton1 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroup2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup()
        Me.KryptonRibbonGroupTriple2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple()
        Me.KryptonRibbonGroupButton4 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroupButton5 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonTab2 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab()
        Me.KryptonRibbonGroup3 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup()
        Me.KryptonRibbonGroupTriple4 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple()
        Me.KryptonRibbonGroupButton7 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonGroupButton8 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton()
        Me.KryptonRibbonTab3 = New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.KryptonRibbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonRibbon1
        '
        Me.KryptonRibbon1.InDesignHelperMode = True
        Me.KryptonRibbon1.Name = "KryptonRibbon1"
        Me.KryptonRibbon1.QATButtons.AddRange(New System.ComponentModel.Component() {Me.KryptonRibbonQATButton1, Me.KryptonRibbonQATButton2})
        Me.KryptonRibbon1.RibbonAppButton.AppButtonMenuItems.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.KryptonContextMenuItem1, Me.KryptonContextMenuItem2, Me.KryptonContextMenuItem3, Me.KryptonContextMenuItem4, Me.KryptonContextMenuItem5})
        Me.KryptonRibbon1.RibbonAppButton.AppButtonSpecs.AddRange(New ComponentFactory.Krypton.Ribbon.ButtonSpecAppMenu() {Me.ButtonSpecAppMenu1, Me.ButtonSpecAppMenu2})
        Me.KryptonRibbon1.RibbonAppButton.AppButtonText = "Fichier"
        Me.KryptonRibbon1.RibbonStrings.CustomizeQuickAccessToolbar = "Personnalisez les raccourics"
        Me.KryptonRibbon1.RibbonStrings.Minimize = "Réduire le ruban"
        Me.KryptonRibbon1.RibbonStrings.MoreColors = "&Plus de couleurs..."
        Me.KryptonRibbon1.RibbonStrings.NoColor = "&Pas de couleurs"
        Me.KryptonRibbon1.RibbonStrings.RecentColors = "Couleurs récentes"
        Me.KryptonRibbon1.RibbonStrings.RecentDocuments = "Fichiers récents"
        Me.KryptonRibbon1.RibbonStrings.ShowAboveRibbon = "&Afficher au dessus du Ruban"
        Me.KryptonRibbon1.RibbonStrings.ShowBelowRibbon = "&Afficher en dessous du Ruban"
        Me.KryptonRibbon1.RibbonStrings.ShowQATAboveRibbon = "&Afficher les raccourcis au dessus du Ruban"
        Me.KryptonRibbon1.RibbonStrings.ShowQATBelowRibbon = "&Afficher les raccourcis en dessous du Ruban"
        Me.KryptonRibbon1.RibbonTabs.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonTab() {Me.KryptonRibbonTab1, Me.KryptonRibbonTab2, Me.KryptonRibbonTab3})
        Me.KryptonRibbon1.SelectedTab = Me.KryptonRibbonTab1
        Me.KryptonRibbon1.Size = New System.Drawing.Size(1182, 115)
        Me.KryptonRibbon1.TabIndex = 0
        '
        'KryptonRibbonQATButton1
        '
        Me.KryptonRibbonQATButton1.Image = Global.PyXel.My.Resources.Resources.save16
        Me.KryptonRibbonQATButton1.Text = "Enregistrer"
        '
        'KryptonRibbonQATButton2
        '
        Me.KryptonRibbonQATButton2.Image = Global.PyXel.My.Resources.Resources.run16
        Me.KryptonRibbonQATButton2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.KryptonRibbonQATButton2.Text = "Executer"
        '
        'KryptonContextMenuItem1
        '
        Me.KryptonContextMenuItem1.Image = Global.PyXel.My.Resources.Resources.new32
        Me.KryptonContextMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.KryptonContextMenuItem1.Text = "Nouveau"
        '
        'KryptonContextMenuItem2
        '
        Me.KryptonContextMenuItem2.Image = Global.PyXel.My.Resources.Resources.open32
        Me.KryptonContextMenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.KryptonContextMenuItem2.Text = "Ouvrir"
        '
        'KryptonContextMenuItem3
        '
        Me.KryptonContextMenuItem3.Image = Global.PyXel.My.Resources.Resources.save321
        Me.KryptonContextMenuItem3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.KryptonContextMenuItem3.Text = "Enregistrer"
        '
        'KryptonContextMenuItem4
        '
        Me.KryptonContextMenuItem4.Image = Global.PyXel.My.Resources.Resources.settings
        Me.KryptonContextMenuItem4.Text = "Paramètres"
        '
        'KryptonContextMenuItem5
        '
        Me.KryptonContextMenuItem5.Image = Global.PyXel.My.Resources.Resources.printer
        Me.KryptonContextMenuItem5.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.KryptonContextMenuItem5.Text = "Imprimer"
        '
        'ButtonSpecAppMenu1
        '
        Me.ButtonSpecAppMenu1.Image = Global.PyXel.My.Resources.Resources.help
        Me.ButtonSpecAppMenu1.Text = "A propos"
        Me.ButtonSpecAppMenu1.UniqueName = "03656E50B816453706A5AE29FD944B66"
        '
        'ButtonSpecAppMenu2
        '
        Me.ButtonSpecAppMenu2.Image = Global.PyXel.My.Resources.Resources.close
        Me.ButtonSpecAppMenu2.Text = "Quitter"
        Me.ButtonSpecAppMenu2.UniqueName = "148F529BABBC45FE508A6EDA6486F2E3"
        '
        'KryptonRibbonTab1
        '
        Me.KryptonRibbonTab1.Groups.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup() {Me.KryptonRibbonGroup1, Me.KryptonRibbonGroup2})
        Me.KryptonRibbonTab1.KeyTip = "A"
        Me.KryptonRibbonTab1.Text = "Accueil"
        '
        'KryptonRibbonGroup1
        '
        Me.KryptonRibbonGroup1.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer() {Me.KryptonRibbonGroupTriple1, Me.KryptonRibbonGroupSeparator1, Me.KryptonRibbonGroupTriple3})
        Me.KryptonRibbonGroup1.TextLine1 = "Code"
        '
        'KryptonRibbonGroupTriple1
        '
        Me.KryptonRibbonGroupTriple1.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem() {Me.KryptonRibbonGroupButton2, Me.KryptonRibbonGroupButton3, Me.KryptonRibbonGroupButton6})
        '
        'KryptonRibbonGroupButton2
        '
        Me.KryptonRibbonGroupButton2.ImageLarge = Global.PyXel.My.Resources.Resources.cut
        Me.KryptonRibbonGroupButton2.ImageSmall = Global.PyXel.My.Resources.Resources.cut
        Me.KryptonRibbonGroupButton2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.KryptonRibbonGroupButton2.TextLine1 = "Couper"
        '
        'KryptonRibbonGroupButton3
        '
        Me.KryptonRibbonGroupButton3.ImageLarge = Global.PyXel.My.Resources.Resources.copy
        Me.KryptonRibbonGroupButton3.ImageSmall = Global.PyXel.My.Resources.Resources.copy
        Me.KryptonRibbonGroupButton3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.KryptonRibbonGroupButton3.TextLine1 = "Copier"
        '
        'KryptonRibbonGroupButton6
        '
        Me.KryptonRibbonGroupButton6.ImageLarge = Global.PyXel.My.Resources.Resources.paste
        Me.KryptonRibbonGroupButton6.ImageSmall = Global.PyXel.My.Resources.Resources.paste
        Me.KryptonRibbonGroupButton6.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.KryptonRibbonGroupButton6.TextLine1 = "Coller"
        '
        'KryptonRibbonGroupTriple3
        '
        Me.KryptonRibbonGroupTriple3.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem() {Me.KryptonRibbonGroupButton1})
        '
        'KryptonRibbonGroupButton1
        '
        Me.KryptonRibbonGroupButton1.ImageLarge = Global.PyXel.My.Resources.Resources.comment
        Me.KryptonRibbonGroupButton1.TextLine1 = "Commenter"
        '
        'KryptonRibbonGroup2
        '
        Me.KryptonRibbonGroup2.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer() {Me.KryptonRibbonGroupTriple2})
        Me.KryptonRibbonGroup2.TextLine1 = "Execution"
        '
        'KryptonRibbonGroupTriple2
        '
        Me.KryptonRibbonGroupTriple2.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem() {Me.KryptonRibbonGroupButton4, Me.KryptonRibbonGroupButton5})
        '
        'KryptonRibbonGroupButton4
        '
        Me.KryptonRibbonGroupButton4.ImageLarge = Global.PyXel.My.Resources.Resources.run
        Me.KryptonRibbonGroupButton4.ImageSmall = Global.PyXel.My.Resources.Resources.run
        Me.KryptonRibbonGroupButton4.TextLine1 = "Executer"
        '
        'KryptonRibbonGroupButton5
        '
        Me.KryptonRibbonGroupButton5.ImageLarge = Global.PyXel.My.Resources.Resources.console
        Me.KryptonRibbonGroupButton5.ImageSmall = Global.PyXel.My.Resources.Resources.console
        Me.KryptonRibbonGroupButton5.TextLine1 = "Console"
        '
        'KryptonRibbonTab2
        '
        Me.KryptonRibbonTab2.Groups.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup() {Me.KryptonRibbonGroup3})
        Me.KryptonRibbonTab2.KeyTip = "D"
        Me.KryptonRibbonTab2.Text = "Débogage"
        '
        'KryptonRibbonGroup3
        '
        Me.KryptonRibbonGroup3.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupContainer() {Me.KryptonRibbonGroupTriple4})
        Me.KryptonRibbonGroup3.TextLine1 = "Syntaxe"
        '
        'KryptonRibbonGroupTriple4
        '
        Me.KryptonRibbonGroupTriple4.Items.AddRange(New ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupItem() {Me.KryptonRibbonGroupButton7, Me.KryptonRibbonGroupButton8})
        '
        'KryptonRibbonGroupButton7
        '
        Me.KryptonRibbonGroupButton7.ImageLarge = Global.PyXel.My.Resources.Resources.verify
        Me.KryptonRibbonGroupButton7.ImageSmall = Global.PyXel.My.Resources.Resources.verify
        Me.KryptonRibbonGroupButton7.TextLine1 = "Vérifier"
        '
        'KryptonRibbonGroupButton8
        '
        Me.KryptonRibbonGroupButton8.ImageLarge = Global.PyXel.My.Resources.Resources.dictionary
        Me.KryptonRibbonGroupButton8.ImageSmall = Global.PyXel.My.Resources.Resources.dictionary
        Me.KryptonRibbonGroupButton8.TextLine1 = "Dictionnaire"
        '
        'KryptonRibbonTab3
        '
        Me.KryptonRibbonTab3.KeyTip = "V"
        Me.KryptonRibbonTab3.Text = "Gestionnaire de Version"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "file.py"
        '
        'FastColoredTextBox1
        '
        Me.FastColoredTextBox1.AutoCompleteBracketsList = New Char() {Global.Microsoft.VisualBasic.ChrW(40), Global.Microsoft.VisualBasic.ChrW(41), Global.Microsoft.VisualBasic.ChrW(123), Global.Microsoft.VisualBasic.ChrW(125), Global.Microsoft.VisualBasic.ChrW(91), Global.Microsoft.VisualBasic.ChrW(93), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(34), Global.Microsoft.VisualBasic.ChrW(39), Global.Microsoft.VisualBasic.ChrW(39)}
        Me.FastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(27, 14)
        Me.FastColoredTextBox1.BackBrush = Nothing
        Me.FastColoredTextBox1.CharHeight = 14
        Me.FastColoredTextBox1.CharWidth = 8
        Me.FastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FastColoredTextBox1.Font = New System.Drawing.Font("Courier New", 9.75!)
        Me.FastColoredTextBox1.IsReplaceMode = False
        Me.FastColoredTextBox1.Location = New System.Drawing.Point(0, 115)
        Me.FastColoredTextBox1.Name = "FastColoredTextBox1"
        Me.FastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastColoredTextBox1.ServiceColors = CType(resources.GetObject("FastColoredTextBox1.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        Me.FastColoredTextBox1.Size = New System.Drawing.Size(1182, 418)
        Me.FastColoredTextBox1.TabIndex = 1
        Me.FastColoredTextBox1.Zoom = 100
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 533)
        Me.Controls.Add(Me.FastColoredTextBox1)
        Me.Controls.Add(Me.KryptonRibbon1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PyXel - Sans Nom"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.KryptonRibbon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FastColoredTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KryptonRibbon1 As ComponentFactory.Krypton.Ribbon.KryptonRibbon
    Friend WithEvents KryptonContextMenuItem1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonContextMenuItem2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonContextMenuItem3 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents ButtonSpecAppMenu1 As ComponentFactory.Krypton.Ribbon.ButtonSpecAppMenu
    Friend WithEvents ButtonSpecAppMenu2 As ComponentFactory.Krypton.Ribbon.ButtonSpecAppMenu
    Friend WithEvents KryptonRibbonTab1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonTab
    Friend WithEvents KryptonRibbonGroup1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup
    Friend WithEvents KryptonRibbonGroupTriple1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple
    Friend WithEvents KryptonRibbonGroup2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup
    Friend WithEvents KryptonRibbonGroupTriple2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple
    Friend WithEvents KryptonRibbonGroupButton4 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonGroupButton5 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonTab2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonTab
    Friend WithEvents KryptonRibbonQATButton1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonQATButton
    Friend WithEvents KryptonRibbonQATButton2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonQATButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents KryptonContextMenuItem4 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents KryptonRibbonGroupButton2 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonGroupButton3 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonGroupButton6 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonGroupSeparator1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupSeparator
    Friend WithEvents KryptonRibbonGroupTriple3 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple
    Friend WithEvents KryptonRibbonGroupButton1 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonGroup3 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroup
    Friend WithEvents KryptonRibbonGroupTriple4 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupTriple
    Friend WithEvents KryptonRibbonGroupButton7 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonGroupButton8 As ComponentFactory.Krypton.Ribbon.KryptonRibbonGroupButton
    Friend WithEvents KryptonRibbonTab3 As ComponentFactory.Krypton.Ribbon.KryptonRibbonTab
    Friend WithEvents KryptonContextMenuItem5 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
End Class
