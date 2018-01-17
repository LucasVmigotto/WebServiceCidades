using System.Collections.Generic;
using System.Data.SqlClient;
using WebServiceCidades.Models;
using System;
namespace WebServiceCidades.Repositorio
{
    public class CidadeRepositorio
    {
        string sqlString = @"Data source=.\SqlExpress;Initial catalog=WebServiceCidades; User Id=sa; Password=senai@123";
        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        public bool Cadastrar(Cidade cidade)
        {
            bool res;
            try
            {
                sqlConnection = new SqlConnection(sqlString);
                sqlCommand = new SqlCommand("INSERT INTO cidade (nome, estado, habitantes) VALUES (@n, @e, @h)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@n", cidade.Nome);
                sqlCommand.Parameters.AddWithValue("@e", cidade.Estado);
                sqlCommand.Parameters.AddWithValue("@h", cidade.Habitantes);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
                sqlCommand.Parameters.Clear();
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao salvar! Descrição do erro: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return res;

        }
        public List<Cidade> ListarCidades()
        {
            List<Cidade> cidades = new List<Cidade>();
            try
            {
                sqlConnection = new SqlConnection(sqlString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("SELECT * FROM Cidade", sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    cidades.Add(new Cidade(
                        Convert.ToInt32(sqlDataReader["id"]),
                        sqlDataReader["nome"].ToString(),
                        sqlDataReader["estado"].ToString(),
                        Convert.ToInt32(sqlDataReader["habitantes"])
                    ));
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Não foi possivel listar! Descrição do Erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel listar! Descrição do Erro: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return cidades;
        }

        public bool Delete(int Id)
        {
            bool res;
            try
            {
                sqlConnection = new SqlConnection(sqlString);
                sqlCommand = new SqlCommand("DELETE FROM cidade WHERE id=" + Id, sqlConnection);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Não foi possivel deletar! Descrição do erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel deletar! Descrição do erro: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return res;
        }

        public bool Alterar(Cidade cidade)
        {
            bool res;
            try
            {
                sqlConnection = new SqlConnection(sqlString);
                sqlCommand = new SqlCommand("UPDATE cidade SET nome=@n, estado=@e, habitantes=@h WHERE id=@id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@n", cidade.Nome);
                sqlCommand.Parameters.AddWithValue("@e", cidade.Estado);
                sqlCommand.Parameters.AddWithValue("@h", cidade.Habitantes);
                sqlCommand.Parameters.AddWithValue("@id", cidade.Id);
                sqlConnection.Open();
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Não foi possivel alterar! Descrição do erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel alterar! Descrição do erro: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return res;
        }

        public Cidade Buscar(int id){
            Cidade cidade=null;
            try
            {
                sqlConnection=new SqlConnection(sqlString);
                sqlCommand=new SqlCommand("SELECT * FROM cidade WHERE id=@id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlConnection.Open();
                SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
                if(sqlDataReader.Read()){
                    cidade=new Cidade(Convert.ToInt32(sqlDataReader["id"]),
                    sqlDataReader["nome"].ToString(), 
                    sqlDataReader["estado"].ToString(),
                    Convert.ToInt32(sqlDataReader["habitantes"]));
                }
                sqlCommand.Parameters.Clear();
            }
            catch(SqlException e)
            {
                throw new Exception("Não foi possivel realizar a busca! Descrição do erro: "+e.Message);
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possivel realizar a busca! Descrição do erro: "+e.Message);
            }
            finally{
                sqlConnection.Close();
            }
            return cidade;
        }
    }
}