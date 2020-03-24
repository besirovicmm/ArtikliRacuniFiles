using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikliWPF
{
	[Serializable]
	public class Racun
	{
		public DateTime datumIzdavanja { get; set; }

		//public List<Artikal> Kljuc = new List<Artikal>();
		//public List<int> Vrednost = new List<int>();

		public Dictionary<Artikal, int> Artikli { get; set; } = new Dictionary<Artikal, int>();

		public decimal Total
		{
			get
			{
				decimal suma = 0;
				foreach (Artikal a in Artikli.Keys)
				{
					suma += Artikli[a] * a.IzlaznaCena;
				}
				return suma;
			}
		}
	}
}