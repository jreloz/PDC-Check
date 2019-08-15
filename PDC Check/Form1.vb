Imports PDC_Check.InteropServices
Imports System.Threading



Public Class Form1

    'Dim Customize As New InteropServices

    Dim x As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashTimer.Start()
        SplashTimer.Interval = 1000
    End Sub


    Private Sub SplashTimer_Tick(sender As Object, e As EventArgs) Handles SplashTimer.Tick

        x += 1
        If x = 2 Then
            SplashTimer.Stop()
            Dashboard.Show()
            Me.Hide()
        End If


    End Sub


    Private Sub SplashImage_MouseDown(sender As Object, e As MouseEventArgs) Handles SplashImage.MouseDown
        If (e.Button = MouseButtons.Left) Then
            InteropServices.ReleaseCapture()
            InteropServices.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
End Class
