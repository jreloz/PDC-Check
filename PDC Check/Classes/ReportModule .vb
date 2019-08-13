Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Printing
Imports System.Reflection


Module ReportModule
    Public ReportDoc As ReportDocument
    Public Month As Integer


    Public Sub PrintDocument()

        Dim SWriter As System.IO.StreamWriter
        Dim AppDir As String

        Dim PrntCount As String = Dashboard.TxtNoOfChecks.Text
        Dim DatePrinted As String = Dashboard.DtDate.Value.ToShortDateString()
        Dim Amount As String = Dashboard.TxtAmount.Text
        Dim BankName As String = Dashboard.CmbBankName.Text
        Dim Payee As String = Dashboard.CmbPayeeName.Text

        Dim SaveData As String = "## " + PrntCount + "; " + BankName + "; " + Amount + "; " + Payee + "; " + DatePrinted + " ##"

        Dashboard.BtnPrint.Text = "Printing..."
        Dashboard.BtnPrint.Enabled = False

        AppDir = System.Reflection.Assembly.GetExecutingAssembly.Location

        SWriter = My.Computer.FileSystem.OpenTextFileWriter(AppDir + "PrintLog.txt", True)
        SWriter.WriteLine(SaveData)
        SWriter.Close()

        For x As Integer = 1 To Val(Dashboard.TxtNoOfChecks.Text)
            ReportDoc.SetParameterValue("PrmPayee", Dashboard.CmbPayeeName.Text)
            ReportDoc.SetParameterValue("PrmAmount", Val(Dashboard.TxtAmount.Text))
            ReportDoc.SetParameterValue("PrmDate", Dashboard.DtDate.Value)
            ReportDoc.SetParameterValue("PrmPTTOO", Dashboard.CmbPayeeName.Text)

            If Dashboard.CmbPrinters.Text <> "" Then
                ReportDoc.PrintOptions.PrinterName = Dashboard.CmbPrinters.Text
                ReportDoc.PrintToPrinter(1, True, 1, 1)
            End If

            If x <> Val(Dashboard.TxtNoOfChecks.Text) Then
                Dashboard.DtDate.Value = Dashboard.DtDate.Value.Date.AddMonths(1)
            End If

            If x <> Val(Dashboard.TxtAmount.Text) Then
                If Dashboard.DtDate.Value.Year = 12 Then
                    Dashboard.DtDate.Value = Dashboard.DtDate.Value.Date.AddYears(1)
                End If
            End If

        Next

        Dashboard.BtnPrint.Text = "Print"
        Dashboard.BtnPrint.Enabled = True

        Exit Sub



    End Sub
End Module
