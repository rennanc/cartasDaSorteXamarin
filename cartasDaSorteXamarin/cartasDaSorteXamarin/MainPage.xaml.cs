using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace cartasDaSorteXamarin
{
	public partial class MainPage : ContentPage
	{

        int QuantidadeVitoria = 0;
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
            }
            else
            {
                imageSender.Source = ImageSource.FromFile("jocker_card.jpg");
            }
        }

        void randomCards()
        {
            var rnd = new Random();
            numeroVencedor = Enumerable.Range(1, 3).OrderBy(x => rnd.Next()).Take(1).FirstOrDefault();
        }

        private void botaovai_Clicked(object sender, EventArgs e)
        {
            randomCards();
        }
    }
}
