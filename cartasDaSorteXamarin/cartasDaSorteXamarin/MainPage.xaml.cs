using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace cartasDaSorteXamarin
{
	public partial class MainPage : ContentPage
	{

        int QuantidadeVitoria = 0;
        int QuantidadeErros = 0;
        int numeroVencedor = 0;


        public MainPage()
		{
			InitializeComponent();
            randomCards();
            
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            
            var imageSender = (Image)sender;

            int numeroDaImagem = int.Parse(imageSender.ClassId);

            if (numeroDaImagem.Equals(numeroVencedor))
            {
                imageSender.Source = ImageSource.FromFile("a_card.jpg");
                QuantidadeVitoria++;
                textVitoria.Text = "Quantidade de Vitórias: " + QuantidadeVitoria;
                DisplayAlert("Parabéns", "Você ganhou", "OK");
                habilitarAcaoCarta(false);
            }
            else
            {
                imageSender.Source = ImageSource.FromFile("jocker_card.jpg");
                QuantidadeErros++;
                textErros.Text = "Quantidade de Erros: " + QuantidadeErros;
                DisplayAlert("Errou", "Você perdeu", "OK");
                habilitarAcaoCarta(false);
            }
        }

        void randomCards()
        {
            var rnd = new Random();
            numeroVencedor = Enumerable.Range(1, 3).OrderBy(x => rnd.Next()).Take(1).FirstOrDefault();
        }

        private void reiniciar_Clicked(object sender, EventArgs e)
        {
            reiniciaJogo();
        }

        void reiniciaJogo()
        {
            habilitarAcaoCarta(true);
            randomCards();
            image1.Source = ImageSource.FromFile("back_card.jpg");
            image2.Source = ImageSource.FromFile("back_card.jpg");
            image3.Source = ImageSource.FromFile("back_card.jpg");
        }

        void habilitarAcaoCarta(bool tapCarta)
        {
            image1.IsEnabled = tapCarta;
            image2.IsEnabled = tapCarta;
            image3.IsEnabled = tapCarta;
        }
    }
}
