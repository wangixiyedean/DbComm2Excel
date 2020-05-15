Public Class CfgSectionData

    Private _Section As String
    Private _ModelName As String
    Private _Tags As List(Of String)

    Public Sub New(section As String, modelName As String, tags As List(Of String))
        Me.Section = section
        Me.ModelName = modelName
        Me.Tags = tags
    End Sub

    Public Property Section() As String
        Get
            Return _Section
        End Get
        Set(value As String)
            _Section = value
        End Set
    End Property

    Public Property ModelName() As String
        Get
            Return _ModelName
        End Get
        Set(value As String)
            _ModelName = value
        End Set
    End Property

    Public Property Tags() As List(Of String)
        Get
            Return _Tags
        End Get
        Set(value As List(Of String))
            _Tags = value
        End Set
    End Property
End Class
