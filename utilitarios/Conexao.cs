using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AulaCRUD.utilitarios
{
    internal class Conexao
    {
        static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {

                string strconexao = "server=localhost;uid=root;pwd=root;port=3360; database=ecomerce";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
                Console.WriteLine("Sucesso!");
                return conexao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar com o banco de dados " + ex.Message);
            }
        }
        public static void FecharConexao()
        {
            conexao.Close();
        }

    }
}

