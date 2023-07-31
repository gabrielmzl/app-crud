Public Class ClienteController
    Public Sub Adicionar(cliente As Cliente)
        Using contexto As New ClienteContext()
            contexto.Clientes.Add(cliente)
            contexto.SaveChanges()
        End Using
    End Sub

    Public Function Buscar() As List(Of Cliente)
        Using contexto As New ClienteContext()
            Return contexto.Clientes.ToList()
        End Using
    End Function

    Public Function BuscarPorId(id As Integer) As Cliente
        Using contexto As New ClienteContext()
            Return contexto.Clientes.Find(id)
        End Using
    End Function

    Public Sub Atualizar(cliente As Cliente)
        Using contexto As New ClienteContext()
            Dim novoCliente = contexto.Clientes.Find(cliente.id)

            If novoCliente IsNot Nothing Then
                contexto.Entry(novoCliente).CurrentValues.SetValues(cliente)
                contexto.SaveChanges()
            End If
        End Using
    End Sub

    Public Sub Deletar(id As Integer)
        Using contexto As New ClienteContext()
            Dim cliente = contexto.Clientes.Find(id)

            If cliente IsNot Nothing Then
                contexto.Clientes.Remove(cliente)
                contexto.SaveChanges()
            End If
        End Using
    End Sub

End Class
