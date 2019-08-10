Imports System.Runtime.InteropServices


Public Class Customize

    Public Const WM_NCLBUTTONDOWN As Integer = 161
    Public Const HT_CAPTION As Integer = 2

    <DllImport("User32")>
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer

    End Function


    <DllImport("User32")>
    Public Shared Function ReleaseCapture() As Boolean

    End Function
End Class
