using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.Model
{
    public class Produto
    {
        public int iCodProduto { get; set; }
        public int iQuantidade { get; set; }
        public int iCodCategoria { get; set; }
        public string sDscProduto { get; set; }
        public string sDscProdutoDetalhado { get; set; }
        public double nPrecoProduto { get; set; }
        private string _sPrecoFormatado;

        public string sPrecoFormatado
        {
            get
            {
                return "R$ "+nPrecoProduto.ToString("#,##0.00");
            }
        }

        public string sPrecoFormatadoComQuantidade
        {
            get
            {
                return "Quantidade: "+iQuantidade.ToString()+" R$ "+ nPrecoProduto.ToString("#,##0.00") + " = R$"+ (iQuantidade * nPrecoProduto).ToString("#,##0.00");
            }
        }

        public string sImagemProduto { get; set; }

        public string sFabricante { get; set; }
        public string sLinkFabricante { get; set; }
        public string sGarantia { get; set; }
    }
}
