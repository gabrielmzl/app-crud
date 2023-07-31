Public Class FormEditar

    Dim Id As Integer
    Dim controller As New ClienteController()

    Public Sub New(ByVal idCliente As Integer)
        InitializeComponent()

        Id = idCliente
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Id = 0 Then
            MessageBox.Show("Selecione um cliente.")
            Close()
        Else
            Try
                Dim cliente = controller.BuscarPorId(Id)

                TextBox1.Text = cliente.nome
                MaskedTextBox1.Text = cliente.cep
                TextBox3.Text = cliente.endereco
                NumericUpDown1.Text = cliente.numero
                TextBox5.Text = cliente.bairro
                TextBox6.Text = cliente.cidade
                TextBox7.Text = cliente.uf
                NumericUpDown2.Text = cliente.ddd
                MaskedTextBox2.Text = cliente.telefone
                MaskedTextBox3.Text = cliente.rg
                MaskedTextBox4.Text = cliente.cpf
                TextBox12.Text = cliente.email
                MaskedTextBox5.Text = cliente.nascimento

            Catch ex As Exception
                MessageBox.Show("Ocorreu um erro ao tentar encontrar odss ID, tente novamente mais tarde.", "Erro")
                Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cliente = controller.BuscarPorId(Id)

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
            Dim clienteEditado As Cliente = cliente

            clienteEditado.nome = Nome
            clienteEditado.cep = Cep
            clienteEditado.endereco = Endereco
            clienteEditado.numero = Numero
            clienteEditado.bairro = Bairro
            clienteEditado.cidade = Cidade
            clienteEditado.uf = Uf
            clienteEditado.ddd = DDD
            clienteEditado.telefone = Telefone
            clienteEditado.rg = Rg
            clienteEditado.cpf = CPF
            clienteEditado.email = Email
            clienteEditado.nascimento = Nascimento

            controller.Atualizar(clienteEditado)

            MessageBox.Show("Cliente editado com sucesso!", "Sucesso")
            Close()
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao tentar editar o cliente, tente novamente mais tarde", "Erro")
        End Try
    End Sub
End Class