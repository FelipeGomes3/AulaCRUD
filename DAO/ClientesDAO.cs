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
            string sql = "UPDATE Clientes SET (nome_cliente = @nome_cliente, cpfCnpj = @cpfCnpj, email = @email, endereco = @endereco, telefone=@telefone WHERE id_cliente = @id_cliente);
            
            
            MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
            comando.Parameters.AddWithValue("@nome_cliente", clientes.nome_cliente);
            comando.Parameters.AddWithValue("@cpfCnpj", clientes.cpfCnpj);
            comando.Parameters.AddWithValue("@email", clientes.email);
            comando.Parameters.AddWithValue("@endereco", clientes.endereco);
            comando.Parameters.AddWithValue("@telefone", clientes.telefone);
            comando.ExecuteNonQuery();


            Conexao.FecharConexao();
        }
    }
}
