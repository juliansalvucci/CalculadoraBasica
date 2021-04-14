Public Class Form1

    Private ultimaOrden As String
    Private comaDecimal As Boolean
    Private cantOperandos As Integer
    Private operador As Char
    Private operando1, operando2 As Double
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ultimaOrden = "Vacio"
        comaDecimal = False
        cantOperandos = 0
        operador = ""
        operando1 = 0 : operando2 = 0
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        lblPantalla.Text = lblPantalla.Text.Remove(lblPantalla.Text.Length - 1)
        'comaDecimal = False'
        'ultimaOrden = "borrar"'
    End Sub

    Private Sub btnReiniciar_Click(sender As Object, e As EventArgs) Handles btnReiniciar.Click
        lblPantalla.Text = "0."
        Form1_Load(Nothing, Nothing)
    End Sub
    'PULSAR 0'
    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim numero As String
        If lblPantalla.Text = "0." And sender.Text = "0" And comaDecimal = False Then
            Exit Sub
        End If
        If ultimaOrden <> "digito" Then
            lblPantalla.Text = ""
            comaDecimal = False
        End If
        numero = lblPantalla.Text
        lblPantalla.Text = numero & sender.Text
        ultimaOrden = "digito"
    End Sub

    Private Sub btnApagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click
        Me.Close()
    End Sub

    Private Sub coma_Click(sender As Object, e As EventArgs) Handles coma.Click
        If ultimaOrden <> "digito" Then
            lblPantalla.Text = "0."
        ElseIf comaDecimal = False Then
            lblPantalla.Text = lblPantalla.Text & ","

        End If
        comaDecimal = True
        ultimaOrden = "digito"
    End Sub

    Private Sub btnPorcentaje_Click(sender As Object, e As EventArgs) Handles btnPorcentaje.Click
        Dim resultado As Double
        If ultimaOrden = "digito" Then resultado = operando1 * Val(lblPantalla.Text) / 100
        If operador = "=" Then
                resultado = 0
                lblPantalla.Text = Str(resultado)
                ultimaOrden = "operador"
            End If
        End If
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click, btnSumar.Click, btnRestar.Click, btnMultiplicar.Click, btnDividir.Click, btnPotencia.Click, btnRaiz.Click, btn1x.Click

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
                Case "√" : operando1 = operando1 ^ (1 / Val(operando2))

            End Select
            lblPantalla.Text = Str(operando1)
            cantOperandos = 1

        End If
        ultimaOrden = "operador"
        operador = sender.Text
    End Sub
End Class
