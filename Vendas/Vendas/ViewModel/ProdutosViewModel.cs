using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.Model;
using Vendas.Views;
using Xamarin.Forms;

namespace Vendas.ViewModel
{
    public class ProdutosViewModel : ViewModelBase
    {
        private ObservableCollection<Produto> _ListaProdutos;
        public Command OrdenarCommand { get; set; }
        public Command FiltrarCommand { get; set; }
        private ObservableCollection<Produto> _ListaOriginal;
        public ObservableCollection<Produto> ListaProdutos
        {
            get { return _ListaProdutos; }
            set
            {
                _ListaProdutos = value;
            }
        }

        private Produto _ProdutoSelecionado;

        public Produto ProdutoSelecionado
        {
            get { return _ProdutoSelecionado; }
            set
            {
                _ProdutoSelecionado = value;
                if (_ProdutoSelecionado != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new ProdutoDetalheView(_ProdutoSelecionado));

                }
                notify();
            }
        }

        private bool _SearchBarVisible;

        public bool SearchBarVisible
        {
            get { return _SearchBarVisible; }
            set
            {
                _SearchBarVisible = value;
                notify();
            }
        }

        private string _TextoBusca;

        public string TextoBusca
        {
            get { return _TextoBusca; }
            set
            {
                _TextoBusca = value;
                notify();
                if (string.IsNullOrEmpty(_TextoBusca))
                {
                    _ListaProdutos.Clear();
                    foreach (Produto produto in _ListaOriginal)
                    {
                        _ListaProdutos.Add(produto);
                    }
                }
                else
                {
                    var ListaFiltrada = _ListaProdutos.Where(x => x.sDscProduto.Contains(_TextoBusca)).ToList();
                    _ListaProdutos.Clear();

                    foreach (Produto produto in ListaFiltrada)
                    {
                        _ListaProdutos.Add(produto);

                    }
                }

            }
        }



        private async void ExecutarOrdenarCommand()
        {
            var acao = await App.Current.MainPage.DisplayActionSheet("Ordenação", "Cancelar", null, "Descrição", "Valor");
            if (acao.ToString() == "Descrição")
            {
                var _ListaNova = new ObservableCollection<Produto>(_ListaProdutos.OrderBy(x => x.sDscProduto).ToList());
                _ListaProdutos.Clear();
                foreach (Produto produto in _ListaNova)
                {
                    _ListaProdutos.Add(produto);
                }
            }
            else
            if (acao.ToString() == "Valor")
            {
                var _ListaNova = new ObservableCollection<Produto>(_ListaProdutos.OrderBy(x => x.nPrecoProduto).ToList());
                _ListaProdutos.Clear();
                foreach (Produto produto in _ListaNova)
                {
                    _ListaProdutos.Add(produto);

                }
            }

        }


        private bool PodeExecutarOrdenarCommand()
        {
            return _ListaProdutos.Count > 0;
        }

        private void ExecutarFiltrarCommand()
        {
            SearchBarVisible = !SearchBarVisible;
        }

        public ProdutosViewModel(Categoria Categoria)
        {
            OrdenarCommand = new Command(ExecutarOrdenarCommand, PodeExecutarOrdenarCommand);
            FiltrarCommand = new Command(ExecutarFiltrarCommand, PodeExecutarOrdenarCommand);
            _ListaOriginal = new ObservableCollection<Produto>();
            _ListaProdutos = new ObservableCollection<Produto>()
           {
               new Produto(){iCodCategoria = 1,iCodProduto = 1, sDscProduto = "Processador Intel Core i5 6400", nPrecoProduto = 799.00,sImagemProduto = "https://images3.kabum.com.br/produtos/fotos/71103/71103_index_gg.jpg",sDscProdutoDetalhado="Processador Intel Core i5-6400 Skylake, Cache 6MB, 2.7Ghz (3.3Ghz Max Turbo), LGA 1151, Intel HD Graphics 530 BX80662I56400"},
               new Produto(){iCodCategoria = 1,iCodProduto = 2, sDscProduto = "Processador Intel Core i3-7100", nPrecoProduto = 529.53,sImagemProduto = "https://images3.kabum.com.br/produtos/fotos/71103/71103_index_gg.jpg",sDscProdutoDetalhado="PROCESSADOR INTEL CORE I3-7100 KABY LAKE 3MB CACHE 3.9GHZ DUAL-CORE, BX80677I37100"},
               new Produto(){iCodCategoria = 1,iCodProduto = 3, sDscProduto = "Processador AMD Ryzen 7 1700X", nPrecoProduto = 1539.97,sImagemProduto = "https://images9.kabum.com.br/produtos/fotos/86139/86139_index_gg.jpg",sDscProdutoDetalhado="PROCESSADOR AMD RYZEN 7 1700X, OITO NÚCLEOS, CACHE 20MB, 3.4GHZ, AM4 - YD170XBCAEWOF"},
               new Produto(){iCodCategoria = 1,iCodProduto = 4, sDscProduto = "Processador AMD Ryzen 5 1400", nPrecoProduto = 685.89,sImagemProduto = "https://images8.kabum.com.br/produtos/fotos/87398/87398_index_gg.jpg",sDscProdutoDetalhado="PROCESSADOR AMD RYZEN 5 1400 QUATRO NÚCLEOS CACHE 10MB 3.2GHZ AM4 - YD1400BBAEBOX"},
               new Produto(){iCodCategoria = 2,iCodProduto = 5, sDscProduto = "Placa Mãe Asus B150M-C/BR", nPrecoProduto = 399.99,sImagemProduto = "https://images6.kabum.com.br/produtos/fotos/79406/79406_index_gg.jpg",sDscProdutoDetalhado="Placa-Mãe ASUS p/ Intel 6/7a Geração, LGA 1151, mATX, B150M-C/BR, 4x DDR4, HDMI/DVI/VGA/DP USB 3.0, Crossfire, 2 header COM, SBA,Chassis Intrusion"},

               new Produto(){iCodCategoria = 3,iCodProduto = 6, sDscProduto = "HD Seagate SATA 3,5´ BarraCuda 1TB", nPrecoProduto = 299.99,sImagemProduto = "https://images8.kabum.com.br/produtos/fotos/84108/84108_index_gg.jpg",sDscProdutoDetalhado="HD Seagate SATA 3,5´ BarraCuda 1TB 7200RPM 64MB Cache SATA 6Gb/s - ST1000DM010"},
               new Produto(){iCodCategoria = 4,iCodProduto = 7, sDscProduto = "Monitor LG LED 23´ IPS D-Sub", nPrecoProduto = 399.99,sImagemProduto = "https://images9.kabum.com.br/produtos/fotos/54259/54259_index_gg.jpg",sDscProdutoDetalhado="Monitor LG LED 23´ IPS D-Sub, HDMI, Full HD 23MP55HQ-P Preto"},
               new Produto(){iCodCategoria = 4,iCodProduto = 8, sDscProduto = "Monitor LG 29 Full HD IPS LED", nPrecoProduto = 1199.99,sImagemProduto = "https://images1.kabum.com.br/produtos/fotos/78761/78761_index_gg.jpg",sDscProdutoDetalhado="Monitor LG 29 Full HD IPS LED UltraWide 21:9 HDMI Preto - 29UM68-P"},

           };
            
            _ListaProdutos = new ObservableCollection<Produto>(ListaProdutos.Where(x => x.iCodCategoria == Categoria.iCodCategoria).ToList());            
            foreach (Produto produto in _ListaProdutos)
            {
                _ListaOriginal.Add(produto);
            }
        }


    }
}
