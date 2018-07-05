Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' Les événements suivants sont disponibles pour MyApplication :
    ' Startup : Déclenché au démarrage de l'application avant la création du formulaire de démarrage.
    ' Shutdown : Déclenché après la fermeture de tous les formulaires de l'application.  Cet événement n'est pas déclenché si l'application se termine de façon anormale.
    ' UnhandledException : Déclenché si l'application rencontre une exception non gérée.
    ' StartupNextInstance : Déclenché lors du lancement d'une application à instance unique et si cette application est déjà active. 
    ' NetworkAvailabilityChanged : Déclenché quand la connexion réseau est connectée ou déconnectée.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Count > 0 Then
                ApplicationSettings.isFileOpened = True
                ApplicationSettings.fileOpened = e.CommandLine.Item(0)
            End If

        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            MsgBox("A fatal error occured, please restart PyXel.", MsgBoxStyle.Critical, "PyXel Error")
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            If (File.Exists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")) Then
                File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")
                Dim sw As StreamWriter = New StreamWriter(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\recentDocs.txt")
                ApplicationSettings.recentDocs.Reverse()
                For Each item In ApplicationSettings.recentDocs
                    sw.WriteLine(item)
                Next
                sw.Close()
            End If
        End Sub
    End Class
End Namespace
