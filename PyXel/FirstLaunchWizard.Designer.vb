<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirstLaunchWizard
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FirstLaunchWizard))
        Me.KryptonNavigator1 = New ComponentFactory.Krypton.Navigator.KryptonNavigator()
        Me.KryptonPage1 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.KryptonPage2 = New ComponentFactory.Krypton.Navigator.KryptonPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CommandLink1 = New WindowsFormsAero.CommandLink()
        Me.CommandLink2 = New WindowsFormsAero.CommandLink()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator1.SuspendLayout()
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage1.SuspendLayout()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonNavigator1
        '
        Me.KryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonNavigator1.Name = "KryptonNavigator1"
        Me.KryptonNavigator1.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.Group
        Me.KryptonNavigator1.Pages.AddRange(New ComponentFactory.Krypton.Navigator.KryptonPage() {Me.KryptonPage1, Me.KryptonPage2})
        Me.KryptonNavigator1.SelectedIndex = 0
        Me.KryptonNavigator1.Size = New System.Drawing.Size(672, 327)
        Me.KryptonNavigator1.TabIndex = 0
        Me.KryptonNavigator1.Text = "KryptonNavigator1"
        '
        'KryptonPage1
        '
        Me.KryptonPage1.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage1.Controls.Add(Me.KryptonButton1)
        Me.KryptonPage1.Controls.Add(Me.Label2)
        Me.KryptonPage1.Controls.Add(Me.Label1)
        Me.KryptonPage1.Flags = 65534
        Me.KryptonPage1.LastVisibleSet = True
        Me.KryptonPage1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage1.Name = "KryptonPage1"
        Me.KryptonPage1.Size = New System.Drawing.Size(670, 325)
        Me.KryptonPage1.Text = "KryptonPage1"
        Me.KryptonPage1.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage1.UniqueName = "34743CACD199402073A75E6439F14BDC"
        '
        'KryptonPage2
        '
        Me.KryptonPage2.AutoHiddenSlideSize = New System.Drawing.Size(200, 200)
        Me.KryptonPage2.Controls.Add(Me.CommandLink2)
        Me.KryptonPage2.Controls.Add(Me.CommandLink1)
        Me.KryptonPage2.Controls.Add(Me.Label3)
        Me.KryptonPage2.Controls.Add(Me.Label4)
        Me.KryptonPage2.Flags = 65534
        Me.KryptonPage2.LastVisibleSet = True
        Me.KryptonPage2.MinimumSize = New System.Drawing.Size(50, 50)
        Me.KryptonPage2.Name = "KryptonPage2"
        Me.KryptonPage2.Size = New System.Drawing.Size(670, 325)
        Me.KryptonPage2.Text = "KryptonPage2"
        Me.KryptonPage2.ToolTipTitle = "Page ToolTip"
        Me.KryptonPage2.UniqueName = "EF3A5BA79A654C00DBB34B9305A03818"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(28, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(29, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(550, 65)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Location = New System.Drawing.Point(569, 289)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(90, 25)
        Me.KryptonButton1.TabIndex = 2
        Me.KryptonButton1.Values.Text = "Suivant"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(29, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(206, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tout d'abord, veuillez choisir votre langue."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(28, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Langue"
        '
        'CommandLink1
        '
        Me.CommandLink1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CommandLink1.Location = New System.Drawing.Point(32, 106)
        Me.CommandLink1.Name = "CommandLink1"
        Me.CommandLink1.ShowShield = True
        Me.CommandLink1.Size = New System.Drawing.Size(604, 47)
        Me.CommandLink1.TabIndex = 4
        Me.CommandLink1.Text = "Français"
        Me.CommandLink1.UseVisualStyleBackColor = True
        '
        'CommandLink2
        '
        Me.CommandLink2.Enabled = False
        Me.CommandLink2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CommandLink2.Location = New System.Drawing.Point(32, 159)
        Me.CommandLink2.Name = "CommandLink2"
        Me.CommandLink2.ShowShield = True
        Me.CommandLink2.Size = New System.Drawing.Size(604, 47)
        Me.CommandLink2.TabIndex = 5
        Me.CommandLink2.Text = "English"
        Me.CommandLink2.UseVisualStyleBackColor = True
        '
        'FirstLaunchWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 327)
        Me.ControlBox = False
        Me.Controls.Add(Me.KryptonNavigator1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FirstLaunchWizard"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Assistant de Configuration de PyXel"
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator1.ResumeLayout(False)
        CType(Me.KryptonPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage1.ResumeLayout(False)
        Me.KryptonPage1.PerformLayout()
        CType(Me.KryptonPage2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPage2.ResumeLayout(False)
        Me.KryptonPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents KryptonNavigator1 As ComponentFactory.Krypton.Navigator.KryptonNavigator
    Friend WithEvents KryptonPage1 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonPage2 As ComponentFactory.Krypton.Navigator.KryptonPage
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CommandLink2 As WindowsFormsAero.CommandLink
    Friend WithEvents CommandLink1 As WindowsFormsAero.CommandLink
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
