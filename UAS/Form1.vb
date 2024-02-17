Imports System.IO
Public Class Form1

    Private Function Hitung()
        Dim Jumlah, Harga, Total As Integer
        Jumlah = txtjumlah.Text
        Harga = txtharga.Text
        Total = Jumlah * Harga
        txttotal.Text = Total
        Return Total
    End Function

    Sub CekDataKosong()
        If txtkode.Text = "" Then
            MsgBox("Kode Tidak Boleh Kosong", 48, "Konfirmasi")
            txtkode.Focus()
        ElseIf txtnama.Text = "" Then
            MsgBox("Nama Tidak Boleh Kosong", 48, "Konfirmasi")
            txtnama.Focus()
        ElseIf txtharga.Text = "" Then
            MsgBox("Harga Tidak Boleh Kosong", 48, "Konfirmasi")
            txtharga.Focus()
        ElseIf txtjumlah.Text = "" Then
            MsgBox("Jumlah Tidak Boleh Kosong", 48, "Konfirmasi")
            txtjumlah.Focus()
        Else
            Call Hitung()
        End If
    End Sub

    Sub Bersih()
        txtkode.Clear() : txtnama.Clear()
        txtharga.Clear() : txtjumlah.Clear()
        txttotal.Text = "" : txtkode.Focus()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call CekDataKosong()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Bersih()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Program Akan Ditutup", 32 + 4, "Konfirmasi") = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim MyWriter As StreamWriter
        Dim dialog As SaveFileDialog
        Dim Selected As Boolean
        Dim filename As String

        dialog = New SaveFileDialog()
        Selected = dialog.ShowDialog
        If Selected = True Then
            filename = dialog.FileName
            MyWriter = File.CreateText(filename)
            MyWriter.WriteLine(txtdata.Text)
            MyWriter.Close()
        End If
    End Sub

    Private Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        Dim MyReader As StreamReader
        Dim dialog As OpenFileDialog
        Dim selected As Boolean
        Dim filename As String

        dialog = New OpenFileDialog
        selected = dialog.ShowDialog
        If selected = True Then
            filename = dialog.FileName
            If File.Exists(filename) Then
                MyReader = File.OpenText(filename)
                txtdata.Text = MyReader.ReadToEnd
                MyReader.Close()
            End If
        Else
            MsgBox("Tidak Ada File Yang Dipilih")
        End If
    End Sub
End Class
