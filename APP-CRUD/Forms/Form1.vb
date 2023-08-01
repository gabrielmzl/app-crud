Public Class Form1
    Private Sub Botao1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formCadastro As New FormCadastro()

        formCadastro.Show()
    End Sub

    Private Sub Botao2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formListagem As New FormListar()

        formListagem.Show()
    End Sub
End Class
