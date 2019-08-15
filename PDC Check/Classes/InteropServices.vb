Imports System.Runtime.InteropServices


Public Class InteropServices

    Public Const WM_NCLBUTTONDOWN As Integer = 161
    Public Const HT_CAPTION As Integer = 2

    <DllImport("User32")>
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer

    End Function


    <DllImport("User32")>
    Public Shared Function ReleaseCapture() As Boolean

    End Function



    Private Enum CheckPrinterStatus
        PrinterIdle = 3
        PrinterPrinting = 4
        PrinterWarmingUp = 5
    End Enum

    Private Function PrinterStatus(ByVal PrintStat As CheckPrinterStatus) As String

        Select Case PrintStat
            Case CheckPrinterStatus.PrinterIdle
                Return "idle"
            Case CheckPrinterStatus.PrinterPrinting
                Return "printing"
            Case CheckPrinterStatus.PrinterWarmingUp
                Return "warmup"
            Case Else
                Return "unknown"
        End Select

    End Function
End Class
