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
   
    internal class ProdutosDAO :IDAO <Produtos>
    {
        public void Cadastrar (Produtos produtos)
        {
            try
            {
                string sql = "INSERT INTO Produtos (nome_produto, descricao, preco)" +
                    "VALUES(@nome_produto, @descricao, @preco) ";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_produto", produtos.nome_produto);
                comando.Parameters.AddWithValue("@descricao", produtos.descricao);
                comando.Parameters.AddWithValue("@preco", produtos.preco);
               
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Produtos produtos)
        {
            try
            {
                string sql = "UPDATE Produtos SET (nome_produto = @nome_produto, descricao = @descricao, preco = @preco WHERE id_produto = @id_produto)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_produto", produtos.nome_produto);
                comando.Parameters.AddWithValue("@descricao", produtos.descricao);
                comando.Parameters.AddWithValue("@preco", produtos.preco);
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Produtos produtos)
        {
            try
            {
                string sql = "DELETE FROM Produtos WHERE id_produto = @id_produto)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_produto", produtos.id_produto);
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produtos> BuscarTodos()
        {
            List<Produtos> produtosCadastrados = new List<Produtos>();
            try
            {
                string sql = "SELECT * FROM Produtos ORDER BY nome_produto";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Produtos P = new Produtos();
                        P.id_produto = dr.GetInt32("id_produto");
                        P.nome_produto = dr.GetString("nome_produto");
                        P.descricao = dr.GetString("descricao");
                        P.preco = dr.GetString("preco");
                       

                        produtosCadastrados.Add(P);
                    }
                }
                Conexao.FecharConexao();
                return produtosCadastrados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
