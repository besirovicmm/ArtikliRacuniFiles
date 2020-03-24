using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ArtikliWPF
{
	/// <summary>
	/// Interaction logic for ArtEd.xaml
	/// </summary>
	public partial class ArtEd : Window
	{

		public ArtEd()
		{
			InitializeComponent();

			DataContext = new Artikal();

			this.BindingGroup = new BindingGroup();
		}

		private void Unos(object sender, RoutedEventArgs e)
		{
			if (this.BindingGroup.CommitEdit())
			{
				this.DialogResult = true;
				this.Close();
			}
		}

		private void Otkazi(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}