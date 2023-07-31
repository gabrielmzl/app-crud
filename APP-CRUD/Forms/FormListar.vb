Public Class FormListar

    Dim Id As Integer
    Dim controller As New ClienteController()

    Private Sub CarregarTabela()
        Try
            Dim clientes = controller.Buscar()

            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dataGridViewClientes.DataSource = clientes
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao carregar os clientes, tente novamente mais tarde...", "Erro")
            Close()
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarTabela()
    End Sub

    Public Sub PegarId(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewClientes.CellContentClick
        Id = Convert.ToInt32(dataGridViewClientes.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Id = 0 Then
            MessageBox.Show("Selecione um cliente.")
            Return
        Else
            Dim confirmaExclusao As DialogResult = MessageBox.Show("Deseja excluir o id " & Id & "?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If confirmaExclusao = DialogResult.Yes Then
                Try
                    controller.Deletar(Id)
                    MessageBox.Show("Cliente excluido com sucesso!", "Sucesso")
                    CarregarTabela()
                Catch
                    MessageBox.Show("Ocorreu um erro ao excluir o cliente, tente novamente mais tarde...", "Erro")
                End Try
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formEditar As New FormEditar(Id)

        formEditar.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CarregarTabela()
    End Sub
End Class