Imports System.ComponentModel

Public Class Splash

    Dim img As Integer = 0
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles Me.Load
        KryptonLabel1.ForeColor = Color.White
        KryptonLabel1.Text = My.Settings.Version
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If img = 0 Then
            img = 1
            Me.BackgroundImage = My.Resources.splash3
        Else
            img = 0
            Me.BackgroundImage = My.Resources.splash2
        End If
        Timer1.Start()
    End Sub

    Private Sub Splash_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Stop()
    End Sub
End Class