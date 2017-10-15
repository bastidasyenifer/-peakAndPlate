Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Public Class CkequeoPicoyPlaca
    Public comandos As SqlCommand
    Public respuesta As SqlDataReader
    Public adaptador As SqlDataAdapter
    Public registros As New DataSet
    Public registrosFecha As New DataSet
    Public registrosHora As New DataSet
    Public dFecha As String
    Public dMatricula As String


    Private Sub CkequeoPicoyPlaca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip2.IsBalloon = True
        Me.ToolTip3.IsBalloon = True

        Me.ToolTip1.SetToolTip(btnSalir, "Salir")
        Me.ToolTip2.SetToolTip(btnConsultar, "Consultar")
        Me.ToolTip3.SetToolTip(btnLimpiar, "Limpiar")

        TextBox1.CharacterCasing = CharacterCasing.Upper

    
        Label8.Text = DateTime.Now.ToString("dd/MM/yyyy")
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd-MM-yyyy"

        DateTimePicker2.CustomFormat = ("HH:mm")
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.ShowUpDown = True
        DateTimePicker2.Text = "00:00"
     

    End Sub
   
    Private Sub TextBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Enter

        Dim dt As DateTime

        Dim bln As Boolean = DateTime.TryParse(TextBox3.Text, dt)

        If (bln) Then
            TextBox3.Text = String.Format("{0:ddMMyyyy}", dt)

        Else
            TextBox3.Clear()
        End If

    End Sub

    Private Sub TextBox3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Leave

        Dim ci As CultureInfo = Threading.Thread.CurrentThread.CurrentCulture

        Dim dt As DateTime
        Dim bln As Boolean = DateTime.TryParseExact(TextBox3.Text, "ddMMyyyy", ci, DateTimeStyles.None, dt)

        If (bln) Then
            TextBox3.Text = String.Format("{0:dd/MM/yyyy}", dt)

        Else
            MessageBox.Show("Fecha incorrecta.")

        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      
        If TextBox1.Text = "" Then

            MsgBox("Falta ingresar datos de la Matrícula")
            TextBox1.Focus()
        ElseIf TextBox1.Text.Trim.Length < 2 Then

            MsgBox("La Mátricula debe tener por lo menos dos letras")
            TextBox1.Focus()
     
        ElseIf TextBox2.Text = "" Then

            MsgBox("Falta ingresar datos de la Matrícula")
            TextBox2.Focus()


        ElseIf TextBox2.Text.Trim.Length < 3 Then

            MsgBox("La Mátricula debe tener por lo menos tres números")
            TextBox2.Focus()
        Else

            If TextBox1.Text = "cd" Or TextBox1.Text = "CD" Then
                ' MsgBox("La Mátricula pertenece a un Cuerpo Diplomatico y puede Transitar")
                Label5.Text = "La Mátricula pertenece a un Cuerpo Diplomatico y puede Transitar"
                Label5.Visible = True
            Else


                If TextBox3.Text = "" Then

                    MsgBox("Debe ingresar una fecha")
                    TextBox3.Focus()
                Else
                    ' Dim fecha As Date
                    ' Dim dia As Integer
                    ' fecha = DateTimePicker1.Value
                    ' dia = Weekday(fecha)
                    Dim fecha As Date
                    Dim dia As Integer
                    fecha = TextBox3.Text
                    dia = Weekday(fecha)
                    Dim ultimoCaracter As String = TextBox2.Text.Substring(TextBox2.Text.Length - 1)

                    '  MsgBox("Ultimo'" & ultimoCaracter & "'")
                    If dia = 0 Or dia = 1 Or dia = 7 Then
                        Label5.Text = "Para este dia todos los vehículos pueden transitar"
                        Label5.Visible = True
                        ' MsgBox("Para este dia todos los vehiculos pueden transitar")

                    Else
                        Dim hora As Integer = DateTimePicker2.Value.ToString("HH")
                        Dim minutos As Integer = DateTimePicker2.Value.ToString("mm")
                        Dim horaS As Integer = hora * 3600
                        Dim minutosS As Integer = minutos * 60
                        Dim resultado As Integer = horaS + minutosS
                        TextBox4.Text = resultado

                        If (resultado >= 25200 And resultado <= 34200) Or (resultado >= 57600 And resultado <= 70200) Then


                            Select Case dia

                                Case 2
                                    '"Lunes"
                                    If ultimoCaracter = 1 Or ultimoCaracter = 2 Then
                                        Label5.Text = "Este vehículo No puede transitar"
                                        Label5.Visible = True
                                    Else

                                        Label5.Text = "Este vehículo SI puede transitar"
                                        Label5.Visible = True

                                    End If

                                Case 3
                                    'Martes
                                    If ultimoCaracter = 3 Or ultimoCaracter = 4 Then
                                        Label5.Text = "Este vehículo No puede transitar"
                                        Label5.Visible = True
                                    Else

                                        Label5.Text = "Este vehículo SI puede transitar"
                                        Label5.Visible = True

                                    End If
                                Case 4
                                    '"Miercoles"
                                    If ultimoCaracter = 5 Or ultimoCaracter = 6 Then
                                        Label5.Text = "Este vehículo No puede transitar"
                                        Label5.Visible = True
                                    Else

                                        Label5.Text = "Este vehículo SI puede transitar"
                                        Label5.Visible = True

                                    End If
                                Case 5
                                    '"Jueves"
                                    If ultimoCaracter = 7 Or ultimoCaracter = 8 Then
                                        Label5.Text = "Este vehículo No puede transitar"
                                        Label5.Visible = True
                                    Else

                                        Label5.Text = "Este vehículo SI puede transitar"
                                        Label5.Visible = True

                                    End If
                                Case 6
                                    '"Viernes"
                                    If ultimoCaracter = 9 Or ultimoCaracter = 0 Then

                                        Label5.Text = "Este vehículo No puede transitar"
                                        Label5.Visible = True
                                    Else

                                        Label5.Text = "Este vehículo SI puede transitar"
                                        Label5.Visible = True

                                    End If

                            End Select
                        Else

                            Label5.Text = "En este horario pueden transitar todos los vehículos"
                            Label5.Visible = True
                            ' MsgBox("Este vehiculo SI puede transitar para este horario")

                        End If
                    End If
                End If
            End If
        End If

    End Sub

   

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) = False Then
            If e.KeyChar = CChar(ChrW(Keys.Back)) Or e.KeyChar = CChar(ChrW(
                Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
                MsgBox("Solo Letras")
            End If
        End If

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            If e.KeyChar = CChar(ChrW(Keys.Back)) Or e.KeyChar = CChar(ChrW(
                Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
                MsgBox("Solo Números")
            End If
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        End
    End Sub

   
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

        DateTimePicker2.CustomFormat = ("HH:mm")
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.ShowUpDown = True
        DateTimePicker2.Text = "00:00"

    End Sub
End Class