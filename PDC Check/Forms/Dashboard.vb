Imports PDC_Check.Customize
Imports System.Threading



Public Class Dashboard

    Dim Customize As New Customize

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CmbBankName.DropDownHeight = 115
        Call LoadPrinters()

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click

        Me.Close()

    End Sub

    Private Sub NavPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles NavPanel.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Customize.ReleaseCapture()
            Customize.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub

    Private Sub LoadPrinters()

        For Each InstalledPrinters In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                CmbPrinters.Items.Add(InstalledPrinters)
        Next InstalledPrinters

    End Sub


    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

        If CmbPayeeName.Text = "" Or TxtAmount.Text = "" Or TxtNoOfChecks.Text = "" Then
            MessageBox.Show("One or more input field(s) are invalid!", "Check Printer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf CmbPrinters.Text = "" Then
            MessageBox.Show("No printer selected!", "Check Printer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else

            Call ProcessData()
            Call PrintDocument()

        End If

    End Sub


    Private Sub TxtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAmount.KeyPress
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            If Asc(e.KeyChar) <> 8 Then
                If Asc(e.KeyChar) <> 46 Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub


    Private Sub TxtNoOfChecks_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNoOfChecks.KeyPress
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            If Asc(e.KeyChar) <> 8 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ProcessData()

        Select Case CmbBankName.Text

            Case "Metrobank"
                ReportDoc = New Metrobank

            Case "Rural Bank of Baguio"
                ReportDoc = New Baguiobank

            Case "UCPB"
                ReportDoc = New UCPB

            Case "BDO"
                'ReportDoc = New BDO

            Case "Land Bank"
                ReportDoc = New Landbank

            Case "East West Bank"
                ReportDoc = New Eastwest

            Case "Bank of Philippine Islands"
                ReportDoc = New BPI

            Case "Philippine National Bank"
                ReportDoc = New PNB

            Case 8
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 9
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 10
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 11
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 12
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 13
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 14
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 15
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 16
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 17
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 18
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 19
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 20
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 21
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case 22
                MessageBox.Show(CmbBankName.SelectedItem.ToString())

            Case Else
                'MessageBox.Show("Select Bank name!", "Check Printer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Select
    End Sub

   
End Class
