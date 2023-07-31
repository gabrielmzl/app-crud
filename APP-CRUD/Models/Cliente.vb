Imports System.ComponentModel.DataAnnotations.Schema

<Table("public.clientes")>
Public Class Cliente
    Public Property id As Integer
    Public Property nome As String
    Public Property cep As String
    Public Property endereco As String
    Public Property numero As String
    Public Property bairro As String
    Public Property cidade As String
    Public Property uf As String
    Public Property ddd As Integer
    Public Property telefone As String
    Public Property rg As String
    Public Property cpf As String
    Public Property email As String
    Public Property nascimento As String
End Class