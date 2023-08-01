Public Class FormListar

    Dim Id As Integer
    Dim controller As New ClienteController()

    Public Sub CarregarTabela()
        Try
            Dim clientes = controller.Buscar()

            dataGridViewClientes.DataSource = clientes
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao carregar os clientes, tente novamente mais tarde...", "Erro")
            Close()
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarTabela()
    End Sub

    Public Sub PegarId(sender As Object, e As EventArgs) Handles dataGridViewClientes.SelectionChanged
        If dataGridViewClientes.SelectedRows.Count > 0 Then
            Id = CInt(dataGridViewClientes.SelectedRows(0).Cells("id").Value)
        End If
    End Sub

    Private Sub dataGridViewClientes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dataGridViewClientes.DoubleClick
        Dim formEditar As New FormEditar(Id)
        formEditar.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Id = 0 Then
            MessageBox.Show("Selecione um cliente.", "Erro")
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