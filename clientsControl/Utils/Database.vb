﻿Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.SqlServer
Module Database
    Private strCon As String
    Private server As String
    Private db As String
    Private user As String
    Private password As String


    Public Sub SetStrCon(ByRef server, ByRef db, ByRef user, ByRef password)
        Database.server = server
        Database.db = db
        Database.user = user
        Database.password = password
        strCon = $"Data Source={Database.server}; Integrated Security=false; Initial Catalog={Database.db}; User ID={Database.user}; Password={Database.password}"
    End Sub

    Public Function GetStrCon()
        Return strCon
    End Function

    Public Function TestarConexao(strCon As String)
        Try
            Dim conn = New SqlConnection(strCon)
            conn.Open()
            Return True
        Catch ex As Exception
            Return MsgBox("Erro ao se conectar com o banco de dados!" & vbNewLine & vbNewLine & ex.Message, vbCritical)
            Return False
        End Try
    End Function

    Public Function CriarTabelas() As Boolean
        Try
            Dim str As String = GetStrCon()
            Dim conn As SqlConnection
            Dim cmd As SqlCommand
            Dim criarTabela = "if object_id('Usuarios') is null   
                 BEGIN
                 CREATE TABLE Usuarios (id int IDENTITY(1,1) PRIMARY KEY, nome varchar(255), sobrenome varchar(255), username varchar(255), senha varchar(255), cargo varchar(10))
                 END"

            conn = New SqlConnection(str)
            cmd = New SqlCommand(criarTabela, conn)
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            MsgBox("Erro ao criar tabela! " & ex.Message)
            Return False
        End Try
        Return True
    End Function
End Module
