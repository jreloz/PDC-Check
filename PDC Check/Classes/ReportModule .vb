Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Drawing.Printing

Module ReportModule
    Public ReportDoc As ReportDocument
    Public Month As Integer

    Public Function ErrorMsg(ByVal ReportError As String) As String

        MessageBox.Show(ReportError, "ONE CLICK PRINT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return ReportError

    End Function

    Public Function InfoMsg(ByVal ReportInfo As String) As String

        MessageBox.Show(ReportInfo, "ONE CLICK PRINT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return ReportInfo

    End Function

    Public Sub PrintDocument()

        Form1.BtnPrint.Text = "Printing..."
        Form1.BtnPrint.Enabled = False


        For x As Integer = 1 To Val(Form1.TxtNoOfChecks.Text)
            ReportDoc.SetParameterValue("PrmPayee", Form1.CmbPayeeName.Text)
            ReportDoc.SetParameterValue("PrmAmount", Val(Form1.TxtAmount.Text))
            ReportDoc.SetParameterValue("PrmDate", Form1.DtDate.Value)
            ReportDoc.SetParameterValue("PrmPTTOO", Form1.TxtNoOfChecks.Text)

            If Form1.CmbPrinters.Text <> "" Then
                ReportDoc.PrintOptions.PrinterName = Form1.CmbPrinters.Text
                ReportDoc.PrintToPrinter(1, True, 1, 1)
            End If

            If x <> Val(Form1.TxtNoOfChecks.Text) Then
                Form1.DtDate.Value = Form1.DtDate.Value.Date.AddMonths(1)
            End If

            If x <> Val(Form1.TxtAmount.Text) Then
                If Form1.DtDate.Value.Year = 12 Then
                    Form1.DtDate.Value = Form1.DtDate.Value.Date.AddYears(1)
                End If
            End If

        Next

        Form1.BtnPrint.Text = "Printing"
        Form1.BtnPrint.Enabled = True

        Exit Sub



    End Sub
End Module
