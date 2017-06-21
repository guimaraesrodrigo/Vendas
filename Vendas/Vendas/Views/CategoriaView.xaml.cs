
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vendas.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Vendas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaView : ContentPage
    {
        public CategoriaView()
        {
            this.BindingContext = new CategoriaViewModel();
            InitializeComponent();
        }
    }
}