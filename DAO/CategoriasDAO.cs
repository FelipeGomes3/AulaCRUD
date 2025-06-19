using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AulaCRUD.mapeamento;
using AulaCRUD.utilitarios;
using MySql.Data.MySqlClient;
using AulaCRUD.Interface;


namespace AulaCRUD.DAO
{
   
    internal class CategoriasDAO : IDAO<Categorias>
    {
        public void Cadastrar(Categorias categorias)
        {
            try
            {
                string sql = "INSERT INTO Categorias (nome_categoria)" +
                    "VALUES(@nome_cliente,@cpfCnpj,@email,@endereco,@telefone) ";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_categoria", categorias.nome_categoria);
              
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Categorias categorias)
        {
            try
            {
                string sql = "UPDATE Categorias  SET (nome_categoria = @(nome_categoria, WHERE id_categoria = @id_categoria)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_categoria", categorias.nome_categoria);
           
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Categorias categorias)
        {
            try
            {
                string sql = "DELETE FROM Categorias WHERE id_categoria = @id_categoria)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_categoria", categorias.nome_categoria);
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Categorias> BuscarTodos()
        {
            List<Categorias> categoriasCadastrados = new List<Categorias>();
            try
            {
                string sql = "SELECT * FROM Categorias ORDER BY nome_categoria";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Categorias C = new Categorias();
                        C.id_categoria = dr.GetInt32("id_categoria");
                        C.nome_categoria = dr.GetString("nome_categoria");
                      

                        categoriasCadastrados.Add(C);
                    }
                }
                Conexao.FecharConexao();
                return categoriasCadastrados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
