using System;
using System.IO;
using System.Collections.Generic;

namespace MegaSena
{
    class Program
    {
        public static int numero;
        public static int[] jogo = new int[60];

        public static void Main(string[] args)
		{
			Jogo();
		}
		
		public static void Jogo()
		{
			int quantidade;

            do
			{
				Console.WriteLine("Quantos números?");
				
				quantidade = Convert.ToInt16(Console.ReadLine()) + 1;
			}
			while (quantidade >= 62);

			NumeroAletatorio();

			//jogo = new List<int> ();

			for (int i = 1; i < quantidade; i++)
			{
				while (jogo.Contains(numero))
				{
					NumeroAletatorio();
				}

				jogo.Add(numero);
			}

			//jogo.Sort();

			string texto = "Os números são:";

			foreach (var element in jogo)
			{
				texto += " " + element;
			}

			Console.WriteLine("\n" + texto);
			
			GravarJogo(texto);

			Console.WriteLine("\nJogar novamente? (S/N)");

			if (Console.ReadLine().ToUpper() == "S")
			{
				Console.Clear();
				Jogo();
			}
		}

		public static void NumeroAletatorio()
		{
            for (int i = 1; i < 61; i++)
            {
                jogo[i] = i;
            }

            //Random rand = new Random();

            //jogo.sh; //rand.Next(1, 61);
		}

		public static void GravarJogo(string texto)
		{
			StreamWriter valor = new StreamWriter(@"D:\OneDrive\Programacao\02 C#\MegaSena\Resultados.txt", true);

			valor.WriteLine(DateTime.Now.ToString() + " - " + texto.Replace("Os números são:", "").TrimStart().Replace(" ", ", "));

			valor.Close();
		}
	}
}