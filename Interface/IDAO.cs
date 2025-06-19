using System;
using AulaCRUD.mapeamento;
using AulaCRUD.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaCRUD.Interface
{
    internal interface IDAO<T>
    {
        public void Cadastrar(T t);

        public void Atualizar(T t);

        public void Deletar(T t);

        public List<Categorias> BuscarTodos();

        public List<Produtos> BuscarTodos();

        public List<Clientes> BuscarTodos();



    }
}
