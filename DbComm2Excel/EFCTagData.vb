Public Class EFCTagData

    Private _Index As Integer
    Private _Desc_Key As String
    Private _Desc_Value As String
    Private _PC1_H As String
    Private _PC1_L As String
    Private _PC2_H As String
    Private _PC2_L As String
    Private _PC3_H As String
    Private _PC3_L As String

    Public Sub New()
    End Sub

    Public Sub New(index As Integer, desc_key As String, desc_value As String, pC1_H As String, pC1_L As String, pC2_H As String, pC2_L As String, pC3_H As String, pC3_L As String)
        Me.Index = index
        Me.Desc_Key = desc_key
        Me.Desc_Value = desc_value
        Me.PC1_H = pC1_H
        Me.PC1_L = pC1_L
        Me.PC2_H = pC2_H
        Me.PC2_L = pC2_L
        Me.PC3_H = pC3_H
        Me.PC3_L = pC3_L
    End Sub

    Public Property Desc_Value As String
        Get
            Return _Desc_Value
        End Get
        Set(value As String)
            _Desc_Value = value
        End Set
    End Property

    Public Property PC1_H As String
        Get
            Return _PC1_H
        End Get
        Set(value As String)
            _PC1_H = value
        End Set
    End Property

    Public Property PC1_L As String
        Get
            Return _PC1_L
        End Get
        Set(value As String)
            _PC1_L = value
        End Set
    End Property

    Public Property PC2_H As String
        Get
            Return _PC2_H
        End Get
        Set(value As String)
            _PC2_H = value
        End Set
    End Property

    Public Property PC2_L As String
        Get
            Return _PC2_L
        End Get
        Set(value As String)
            _PC2_L = value
        End Set
    End Property

    Public Property PC3_H As String
        Get
            Return _PC3_H
        End Get
        Set(value As String)
            _PC3_H = value
        End Set
    End Property

    Public Property PC3_L As String
        Get
            Return _PC3_L
        End Get
        Set(value As String)
            _PC3_L = value
        End Set
    End Property

    Public Property Desc_Key As String
        Get
            Return _Desc_Key
        End Get
        Set(value As String)
            _Desc_Key = value
        End Set
    End Property

    Public Property Index As Integer
        Get
            Return _Index
        End Get
        Set(value As Integer)
            _Index = value
        End Set
    End Property
End Class
