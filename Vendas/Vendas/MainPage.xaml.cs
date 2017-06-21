using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Vendas.Views;

namespace Vendas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoriaView());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //try
            //{
                //httpClient httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var response = await httpClient.GetAsync($"{BaseUrl}/clubes").ConfigureAwait(false);

                //if (response.IsSuccessStatusCode)
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    return JsonConvert.DeserializeObject<List<Clube>>(content);
                //}
                //else return null;
            //}
            //catch (Exception e)
            //{
            //    App.Current.MainPage.DisplayAlert("", e.InnerException.Message, "ok");
            //    return null;
            //}
        }
    }
}
