using AulaCRUD.mapeamento;
using AulaCRUD.utilitarios;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaCRUD.DAO
{
    internal class ClientesDAO
    {
        public void Cadastrar(Clientes clientes)
        {
            try
            {
                string sql = "INSERT INTO Clientes (nome_cliente, cpfCnpj, email, endereco, telefone)" + 
                    "VALUES(@nome_cliente,@cpfCnpj,@email,@endereco,@telefone) ";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_cliente",clientes.nome_cliente);
                comando.Parameters.AddWithValue("@cpfCnpj", clientes.cpfCnpj);
                comando.Parameters.AddWithValue("@email", clientes.email);
                comando.Parameters.AddWithValue("@endereco", clientes.endereco);
                comando.Parameters.AddWithValue("@telefone", clientes.telefone);
                comando.ExecuteNonQuery();


                Conexao.FecharConexao(); 
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Clientes clientes)
        {
            try
            {
                string sql = "UPDATE Clientes SET (nome_cliente = @nome_cliente, cpfCnpj = @cpfCnpj, email = @email, endereco = @endereco, telefone=@telefone WHERE id_cliente = @id_cliente)";

            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_cliente", clientes.nome_cliente);
                comando.Parameters.AddWithValue("@cpfCnpj", clientes.cpfCnpj);
                comando.Parameters.AddWithValue("@email", clientes.email);
                comando.Parameters.AddWithValue("@endereco", clientes.endereco);
                comando.Parameters.AddWithValue("@telefone", clientes.telefone);
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(Clientes clientes)
        {
            try
            {
                string sql = "DELETE FROM Clientes WHERE id_cliente = @id_cliente)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_cliente", clientes.id_cliente);
                comando.ExecuteNonQuery();


                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Clientes> BuscarTodos()
        {
            List<Clientes> clientesCadastrados = new List<Clientes>();
            try
            {
                string sql = "SELECT * FROM Clientes ORDER BY nome_cliente";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Clientes C = new Clientes();
                        C.id_cliente = dr.GetInt32("id_cliente");
                        C.nome_cliente = dr.GetString("nome_cliente");
                        C.cpfCnpj = dr.GetString("cpfCnpj");
                        C.email = dr.GetString("email");
                        C.endereco = dr.GetString("endereco");
                        C.telefone = dr.GetString("telefone");

                        clientesCadastrados.Add(C);
                    }
                }
                Conexao.FecharConexao();
                return clientesCadastrados;
            }
            catch (Exception ex) 
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
