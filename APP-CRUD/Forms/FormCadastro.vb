Public Class FormCadastro

    Dim controller As New ClienteController()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Nome As String = TextBox1.Text
        Dim Cep As String = MaskedTextBox1.Text
        Dim Endereco As String = TextBox3.Text
        Dim Numero As String = NumericUpDown1.Text
        Dim Bairro As String = TextBox5.Text
        Dim Cidade As String = TextBox6.Text
        Dim Uf As String = TextBox7.Text
        Dim DDD As String = NumericUpDown2.Text
        Dim Telefone As String = MaskedTextBox2.Text
        Dim Rg As String = MaskedTextBox3.Text
        Dim CPF As String = MaskedTextBox4.Text
        Dim Email As String = TextBox12.Text
        Dim Nascimento As String = MaskedTextBox5.Text

        Dim Inputs As String() = {TextBox1.Text, MaskedTextBox1.Text, TextBox3.Text, NumericUpDown1.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, NumericUpDown2.Text, MaskedTextBox2.Text, MaskedTextBox4.Text, MaskedTextBox5.Text, TextBox12.Text, MaskedTextBox3.Text}

        For Each Input As String In Inputs
            If String.IsNullOrWhiteSpace(Input) Then
                MessageBox.Show("Preencha todos os campos.", "Erro")
                Return
            End If
        Next

        Try
            Dim novoCliente As New Cliente() With {
                .nome = Nome,
                .cep = Cep,
                .endereco = Endereco,
                .numero = Numero,
                .bairro = Bairro,
                .cidade = Cidade,
                .uf = Uf,
                .ddd = DDD,
                .telefone = Telefone,
                .rg = Rg,
                .cpf = CPF,
                .email = Email,
                .nascimento = Nascimento
            }

            controller.Adicionar(novoCliente)

            MessageBox.Show("Cliente adicionado com sucesso!", "Sucesso")
            Close()
        Catch
            MessageBox.Show("Ocorreu um erro ao adicionar o cliente, tente novamente mais tarde...", "Erro")
        End Try

    End Sub
End Class