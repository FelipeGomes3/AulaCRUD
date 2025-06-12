using AulaCRUD.mapeamento;
using AulaCRUD.utilitarios;
using AulaCRUD.DAO;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Olá");

try
{
    Conexao.Conectar();

    Clientes clientes = new Clientes();
    clientes.nome_cliente = "Felipe";
    clientes.cpfCnpj = "123.456.789.00";
    clientes.email = "felipe@gmail.com";
    clientes.endereco = "Rua da maça 150";
    clientes.telefone = "99999-8888";

    Clientes clientes1 = new Clientes();
    clientes1.nome_cliente = "Pedro Costa";
    clientes1.cpfCnpj = "123.456.789.10";
    clientes1.email = "Pedrocosta@gmail.com";
    clientes1.endereco = "Rua da Pera, 1250, Ji-Paraná - RO";
    clientes1.telefone = "(31)95499-8898";

    ClientesDAO aDAO = new ClientesDAO();
    aDAO.Cadastrar(clientes);
    aDAO.Cadastrar(clientes1);
    Console.WriteLine("Cadastrado com sucesso!");
}
catch (Exception ex)
{
    throw new Exception(ex.Message);
}

