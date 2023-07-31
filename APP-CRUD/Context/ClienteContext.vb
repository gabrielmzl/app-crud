Imports System.Data.Entity
Public Class ClienteContext
    Inherits DbContext

    Public Property Clientes As DbSet(Of Cliente)

    Public Sub New()
        MyBase.New("name=DefaultConnection")
    End Sub
End Class
