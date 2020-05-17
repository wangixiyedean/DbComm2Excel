Public Class ManageData

    Private _TagName As String
    Private _UNIT As String
    Private _PV As String

    Public Sub New()
    End Sub

    Public Sub New(tagName As String, uNIT As String, pV As String)
        Me.TagName = tagName
        Me.UNIT = uNIT
        Me.PV = pV
    End Sub

    Public Property TagName As String
        Get
            Return _TagName
        End Get
        Set(value As String)
            _TagName = value
        End Set
    End Property

    Public Property PV As String
        Get
            Return _PV
        End Get
        Set(value As String)
            _PV = value
        End Set
    End Property

    Public Property UNIT As String
        Get
            Return _UNIT
        End Get
        Set(value As String)
            _UNIT = value
        End Set
    End Property
End Class
