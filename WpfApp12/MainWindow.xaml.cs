using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ArtikliWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public ObservableCollection<Artikal> Art = new ObservableCollection<Artikal>();
		public ObservableCollection<Racun> Racuni = new ObservableCollection<Racun>();

		public MainWindow()
		{
			InitializeComponent();

			Ucitaj();
			BinaryFormatter BF = new BinaryFormatter();
			using (Stream tokPodataka = new FileStream("Racuni.txt", FileMode.Open, FileAccess.Read))
			{
				Racuni = BF.Deserialize(tokPodataka) as ObservableCollection<Racun>;
			}
			dg.ItemsSource = Art;
			dgRacuni.ItemsSource = Racuni;
		}
		public void Ucitaj()
		{
			if (File.Exists("Artikli.txt"))
			{
				BinaryFormatter BF = new BinaryFormatter();
				using (Stream tokPodataka = new FileStream("Artikli.txt", FileMode.Open, FileAccess.Read))
				{
					Art = BF.Deserialize(tokPodataka) as ObservableCollection<Artikal>;
				}
			}
		}
		public void Sacuvaj()
		{
			BinaryFormatter BF = new BinaryFormatter();
			using (Stream Citanje = new FileStream("Artikli.txt", FileMode.OpenOrCreate, FileAccess.Write))
			{
				BF.Serialize(Citanje, Art);
			}
		}
		private void Izmena(object sender, RoutedEventArgs e)
		{
			if (dg.SelectedItem != null)
			{
				ArtEd Editor = new ArtEd();
				Editor.Owner = this;
				Editor.DataContext = dg.SelectedItem;
				Editor.ShowDialog();
			}
			Sacuvaj();
		}
		private void Dodavanje(object sender, RoutedEventArgs e)
		{
			ArtEd Editor = new ArtEd();
			Editor.Owner = this;
			if (Editor.ShowDialog() == true)
			{
				Art.Add(Editor.DataContext as Artikal);
			}
			Sacuvaj();

		}

		private void Brisanje(object sender, RoutedEventArgs e)
		{
			if (dg.SelectedItem != null)
			{
				Art.Remove(dg.SelectedItem as Artikal);
			}
			Sacuvaj();
		}

		private void NoviRacun(object sender, RoutedEventArgs e)
		{
			RacuniEd r = new RacuniEd(Art.ToList());
			r.Owner = this;
			if (r.ShowDialog() == true)
			{
				Racuni.Add(r.TrenutniRacun);
				BinaryFormatter BF = new BinaryFormatter();
				using (Stream snimanjeracuna = new FileStream("Racuni.txt", FileMode.OpenOrCreate, FileAccess.Write))
				{
					BF.Serialize(snimanjeracuna, Racuni);
				}
			}
		}
	}
}