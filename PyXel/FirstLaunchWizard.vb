Public Class FirstLaunchWizard
    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        KryptonNavigator1.SelectedPage = KryptonPage2

    End Sub

    Private Sub FirstLaunchWizard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TextExtra = My.Settings.Version
    End Sub
End Class