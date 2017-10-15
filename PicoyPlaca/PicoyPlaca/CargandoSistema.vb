Public Class CargandoSistema
    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click
        ProgressBar1.Value = 0.0
        ProgressBar1.Maximum = 100
        Timer1.Interval = 40
        Timer1.Enabled = True



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 10
            Label3.Text = "Cargando el Sistema al " & ProgressBar1.Value & " %"
        Else
            Timer1.Enabled = False
            Me.Hide()
            CkequeoPicoyPlaca.Show()

        End If
    End Sub
End Class