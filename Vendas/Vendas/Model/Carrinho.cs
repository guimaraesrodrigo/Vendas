using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model;
namespace Vendas.Model
{
    public class Carrinho
    {
        private static Carrinho instance;
        public ObservableCollection<Produto> ListaProdutos;

        private Carrinho()
        {
            ListaProdutos = new ObservableCollection<Produto>();
        }

        public static Carrinho GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Carrinho();
                }
                return instance;
            }
        }
    }

}
