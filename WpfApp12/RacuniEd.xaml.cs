using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArtikliWPF
{
	/// <summary>
	/// Interaction logic for RacuniEd.xaml
	/// </summary>
	public partial class RacuniEd : Window
	{
		public string Sifra { get; set; }

		public List<Artikal> SviArtikli;

		public Racun TrenutniRacun = new Racun();

		public RacuniEd(List<Artikal> a)
		{
			InitializeComponent();
			BindingGroup = new BindingGroup();
			SviArtikli = a;
			dgArtikli.ItemsSource = TrenutniRacun.Artikli;
			DataContext = this;
		}

		private void UnosArt(object sender, RoutedEventArgs e)
		{
			if (BindingGroup.CommitEdit())
			{
				foreach (Artikal art in SviArtikli)
				{
					if (art.Sifra == Sifra)
					{
						if (!TrenutniRacun.Artikli.ContainsKey(art))
						{
							TrenutniRacun.Artikli.Add(art, 1); //za domaci kolicina i provera stanja :P
						}
						else
						{
							TrenutniRacun.Artikli[art] += 1;
						}
						dgArtikli.ItemsSource = null;
						dgArtikli.ItemsSource = TrenutniRacun.Artikli;
						return;
					}
				}
				MessageBox.Show("Ne postoji artikal sa tom sifrom!");
			}
		}

		private void Snimi(object sender, RoutedEventArgs e)
		{
			TrenutniRacun.datumIzdavanja = DateTime.Now;
			DialogResult = true;
			this.Close();
		}
	}
}