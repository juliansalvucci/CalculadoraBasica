Public Class Form1

    Private ultimaOrden As String  'Último boton pulsado'
    Private puntoDecimal As Boolean 'Punto para valores decimales'
    Private cantOperandos As Integer 'Pasos para realizar las operaciones'
    Private operador As Char 'Oprecación que se realiza'
    Private operando1 As Double
    Private operando2 As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ultimaOrden = "Vacio"
        puntoDecimal = False
        cantOperandos = 0
        operador = ""
        operando1 = 0 : operando2 = 0

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        lblPantalla.Text = lblPantalla.Text.Remove(lblPantalla.Text.Length - 1)
        If lblPantalla.Text.Length = 0 Then  'Se borran individualmente cada dígito de la pantalla'
            lblPantalla.Text = "0"
        End If
    End Sub

    Private Sub btnReiniciar_Click(sender As Object, e As EventArgs) Handles btnReiniciar.Click
        lblPantalla.Text = "0"
        Form1_Load(Nothing, Nothing) 'Al reiniciar, la calculadora se estabiliza en 0'
    End Sub
    'BOTONES DE NÚMEROS'
    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim numero As String
        If lblPantalla.Text = "0" And sender.Text = "0" And puntoDecimal = False Then
            Exit Sub
        End If
        If ultimaOrden <> "digito" Then
            lblPantalla.Text = ""
            puntoDecimal = False
        End If
        numero = lblPantalla.Text
        lblPantalla.Text = numero & sender.Text
        ultimaOrden = "digito"
    End Sub
    'APAGAR'
    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        Me.Close()
    End Sub
    'PUNTO DECIMAL'
    Private Sub coma_Click(sender As Object, e As EventArgs) Handles coma.Click
        If ultimaOrden <> "digito" Then
            lblPantalla.Text = "0." 'Permite añadir el punto al iniciar'
        ElseIf puntoDecimal = False Then
            lblPantalla.Text = lblPantalla.Text & "." 'Solo se permite agregar el punto por única vez dentro de un operando'

        End If
        puntoDecimal = True
        ultimaOrden = "digito"
    End Sub


    'CAMBIO DE SIGNO'
    Private Sub btnSigno_Click(sender As Object, e As EventArgs) Handles btnSigno.Click
        lblPantalla.Text = -lblPantalla.Text
    End Sub
    'CÁLCULOS'
    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click, btnSumar.Click, btnRestar.Click, btnMultiplicar.Click, btnDividir.Click, btnPotencia.Click, btnRaiz.Click, btnPorcentaje.Click

        If ultimaOrden = "digito" Then
            cantOperandos = cantOperandos + 1
        End If
        If cantOperandos = 1 Then
            operando1 = Val(lblPantalla.Text)
        End If

        If cantOperandos = 2 Then
            operando2 = Val(lblPantalla.Text)
            Select Case operador
                Case "+" : operando1 = operando1 + operando2
                Case "-" : operando1 = operando1 - operando2
                Case "*" : operando1 = operando1 * operando2
                Case "/" : operando1 = operando1 / operando2
                Case "^" : operando1 = operando1 ^ operando2
                Case "√" : operando1 = Math.Pow(operando1, 1 / operando2) '16 a la 1/2 es 4'
                Case "%" : operando1 = (operando1 * Val(operando2)) / 100

            End Select
            lblPantalla.Text = Str(operando1)
            cantOperandos = 1
        End If
        ultimaOrden = "operador"
        operador = sender.Text
    End Sub
    Private Sub btn1x_Click(sender As Object, e As EventArgs) Handles btn1x.Click
        operando1 = Val(lblPantalla.Text)
        operando1 = 1 / operando1
        lblPantalla.Text = operando1
    End Sub


End Class
