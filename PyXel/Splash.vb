Imports System.ComponentModel

Public Class Splash

    Dim img As Integer = 0
    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TransparencyKey = Color.Gray
        Label1.ForeColor = Color.White
        Label1.Text = My.Settings.Version
    End Sub

End Class