using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model;
using Vendas.Views;
using Xamarin.Forms;

namespace Vendas.ViewModel
{
    public class CategoriaViewModel : ViewModelBase
    {
        private List<Categoria> _ListaCategorias;
        public List<Categoria> ListaCategorias
        {
            get { return _ListaCategorias; }
            set
            {
                _ListaCategorias = value;
                notify();
            }
        }

        public Command CarrinhoComprasCommand { get; set; }

        private Categoria _CategoriaSelecionada;

        public Categoria CategoriaSelecionada
        {
            get { return _CategoriaSelecionada; }
            set
            {
                _CategoriaSelecionada = value;

                if (_CategoriaSelecionada != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new ProdutosView(_CategoriaSelecionada));
                }

                notify();
            }
        }
        private void ExecutarCarrinhoComprasCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new CarrinhoView());
        }

        private bool CanExecutarCarrinhoComprasCommand()
        {
            return Carrinho.GetInstance.ListaProdutos.Count() > 0;
        }

        public CategoriaViewModel()
        {
            CarrinhoComprasCommand = new Command(ExecutarCarrinhoComprasCommand);
            ListaCategorias = new List<Categoria>()
            {
                new Categoria(){ iCodCategoria = 1,sDscCategoria = "Processadores",sImagemCategoria="http://s2.glbimg.com/roYHf_QKq60udXYAFWqkv-Atvas=/695x0/s.glbimg.com/po/tt2/f/original/2015/10/07/processador-da-intel-alcancou-altissima-velocidade.png"},
                new Categoria(){ iCodCategoria = 2,sDscCategoria = "Placas-Mãe",sImagemCategoria="http://s2.glbimg.com/629EF-CYpapx39Fum5QsVXvqd2w=/695x0/s.glbimg.com/po/tt2/f/original/2014/07/04/5370968516_9ff93aee01_b.jpg"},
                new Categoria(){ iCodCategoria = 3,sDscCategoria = "HDs",sImagemCategoria="https://img.ibxk.com.br/2011/11/materias/6094561984144517.jpg?w=700&h=393&mode=crop"},
                new Categoria(){ iCodCategoria = 4,sDscCategoria = "Monitores",sImagemCategoria="http://tecnologia.culturamix.com/blog/wp-content/gallery/o-que-sao-monitores/o-que-sao-monitores-2.jpg"},
                new Categoria(){ iCodCategoria = 5,sDscCategoria = "Memórias",sImagemCategoria="http://files.computador-funcionamento.webnode.pt/200000022-c025ec11b7/memoria-ram.jpg"},
            };
        }
    }
}
