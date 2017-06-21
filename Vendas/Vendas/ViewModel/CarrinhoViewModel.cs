using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model;
using Vendas.Views;
using Xamarin.Forms;

namespace Vendas.ViewModel
{
    public class CarrinhoViewModel : ViewModelBase
    {
        private ObservableCollection<Produto> _ListaProdutos;
        public Command FinalizarCompraCommand { get; set; }
        public Command ExcluirItemCommand { get; set; }

        private Produto _ProdutoSelecionado;

        public Produto ProdutoSelecionado
        {
            get { return _ProdutoSelecionado; }
            set
            {
                _ProdutoSelecionado = value;
                notify();
            }
        }


        public ObservableCollection<Produto> ListaProdutos
        {
            get { return _ListaProdutos; }
            set
            {
                _ListaProdutos = value;                
            }
        }

        private string _QuantidadeProdutos;

        public string QuantidadeProdutos
        {
            get { return _QuantidadeProdutos; }
            set
            {
                _QuantidadeProdutos = value;
                notify();
            }
        }

        private string _ValorProdutos;

        public string ValorProdutos
        {
            get { return _ValorProdutos; }
            set
            {
                _ValorProdutos = value;
                notify();
            }
        }

        public CarrinhoViewModel()
        {
            _ListaProdutos = new ObservableCollection<Produto>();

            foreach (Produto produto in Carrinho.GetInstance.ListaProdutos)
            {
                _ListaProdutos.Add(produto);

            }

            FinalizarCompraCommand = new Command(ExecutarFinalizarCompraCommand, PodeFinalizarCompraCommand);
            ExcluirItemCommand = new Command(ExecutarExcluirItem, PodeExecutarExcluirItem);

            TotalizarValores();

        }

        async void  ExecutarExcluirItem()
        {
            if (ProdutoSelecionado != null)
            {
                var resposta = await App.Current.MainPage.DisplayAlert("Vendas", $"Confirma Exclusão do Produto {ProdutoSelecionado.sDscProduto} ?", "Sim", "Não");
                if (resposta)
                {
                    ListaProdutos.Remove(ProdutoSelecionado);
                    Carrinho.GetInstance.ListaProdutos.Remove(ProdutoSelecionado);
                    TotalizarValores();
                    ExcluirItemCommand.ChangeCanExecute();
                }
            }
        }

        bool PodeExecutarExcluirItem()
        {
            return _ListaProdutos.Count > 0;
            TotalizarValores();
        }


        private void TotalizarValores()
        {
            var TotalQuantidade = _ListaProdutos.Sum<Produto>(x => x.iQuantidade);
            var TotalValor = _ListaProdutos.Sum<Produto>(x => (x.iQuantidade * x.nPrecoProduto));

            QuantidadeProdutos = $"{TotalQuantidade}";
            ValorProdutos = $"R${TotalValor.ToString("#,##0.00")}";

        }

        private void ExecutarFinalizarCompraCommand()
        {
            App.Current.MainPage.DisplayAlert("Vendas", "Obrigado pela compra. Volte Sempre.", "ok");
        }

        private bool PodeFinalizarCompraCommand()
        {
            return _ListaProdutos.Count() > 0;
        }

    }
}
