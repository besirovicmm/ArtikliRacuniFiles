using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikliWPF
{
	[Serializable]
	public class Artikal
	{
		public string Sifra { get; set; }
		public string Naziv { get; set; }

		public decimal Ucena { get; set; }
		public int Marza { get; set; }

		public int Stanje { get; set; } = 0;

		//Read only property
		//Ne cuvamo vrednost nigde, nego je samo
		//racunamo svaki put kada se od nas trazi
		public decimal IzlaznaCena
		{
			get
			{
				return Ucena * (Marza / (decimal)100 + 1);
			}
		}

		public Artikal() { }

		public Artikal(string s, string n, decimal c, int m)
		{
			Sifra = s;
			Naziv = n;
			Ucena = c;
			Marza = m;
		}

		public override string ToString()
		{
			return $"{Sifra} -- {Naziv}";
		}

	}
}