﻿Imports System.Data.SqlClient

Public Class Program
    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        Try
            'Dim sql As ISQLRepository
            Dim str = GetStrCon()
            Using conexao = New SqlConnection(str)
                conexao.Open()
                Dim sql = "SELECT * FROM Pet"
                Using dataAdapter = New SqlDataAdapter(sql, conexao)
                    Using dt = New DataTable()
                        dataAdapter.Fill(dt)
                        DataGridView1.DataSource = dt
                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try
    End Sub
End Class