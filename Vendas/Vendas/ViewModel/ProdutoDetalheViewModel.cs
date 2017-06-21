using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model;
using Xamarin.Forms;
using Android.Widget;
using Vendas.Views;

namespace Vendas.ViewModel
{
    public class ProdutoDetalheViewModel : ViewModelBase
    {
        private Produto _Produto;

        public Produto Produto
        {
            get { return _Produto; }
            set
            {
                _Produto = value;
                notify();
            }
        }

        public Command ComprarCommand { get; set; }

        public ProdutoDetalheViewModel(Produto __Produto)
        {
            _Produto = __Produto;
            ComprarCommand = new Command(ExecutarComprarCommand);
        }

        private async void ExecutarComprarCommand()
        {
            if (Carrinho.GetInstance.ListaProdutos.Where<Produto>(x => x.iCodProduto == _Produto.iCodProduto).ToList().Count == 0)
            {
                _Produto.iQuantidade = 1;
                Carrinho.GetInstance.ListaProdutos.Add(_Produto);
            }
            else
            {
                var produto = Carrinho.GetInstance.ListaProdutos.Single(x => x.iCodProduto == _Produto.iCodProduto);
                produto.iQuantidade = produto.iQuantidade + 1;

                Carrinho.GetInstance.ListaProdutos.Remove(produto);
                Carrinho.GetInstance.ListaProdutos.Add(produto);
            }



            await App.Current.MainPage.DisplayAlert("Vendas","Produto Adicionado ao Carrinho...","ok");
            App.Current.MainPage.Navigation.PopAsync();
        }


    }
}
