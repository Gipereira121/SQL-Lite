using AppVeterinario.Models;

namespace AppVeterinario
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            Especie est = new Especie();
            est.Nome = etrNome.Text;

            await App.Db.Insert(est);

            await DisplayAlert("Sucesso", "Registro inserido", "Ok");

        }
    }

}
