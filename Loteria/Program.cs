using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MegaSena
{
    class Program
    {
        //public static int[] jogo;

        public static void Main(string[] args)
		{
			Jogo();
		}
		
		public static void Jogo()
		{
			int quantidadeNumeros, quantidadeJogo;

			Console.WriteLine("Quantos números tem o jogo?");
            quantidadeNumeros = Convert.ToInt16(Console.ReadLine());

            //jogo = new int[quantidadeNumeros];

            Console.WriteLine("Quantos números serão sorteados?");
            quantidadeJogo = Convert.ToInt16(Console.ReadLine());

            var jogo = NumeroAletatorio(quantidadeNumeros, quantidadeJogo);

            jogo.Sort();

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

		public static List<int> NumeroAletatorio(int quantNum, int quantJogo)
		{
            var list = new List<int> { };
            var rnd = new Random();

            for (int i = 1; i < 61; i++)
            {
                list.Add(i);
            }

            var query =
                from i in list
                let r = rnd.Next()
                orderby r
                select i;

            var shuffled = query.ToList();

            var shuffledTrimed = new List<int> ();

            for (int i = 0; i < quantJogo; i++)
            {
                shuffledTrimed.Add(shuffled.ElementAt(i));
            }

            return shuffledTrimed;
		}

		public static void GravarJogo(string texto)
		{
            var local = Directory.GetCurrentDirectory();

            StreamWriter valor = new StreamWriter(local + @"\Resultados.txt", true);

			valor.WriteLine(DateTime.Now.ToString() + " - " + texto.Replace("Os números são:", "").TrimStart().Replace(" ", ", "));

			valor.Close();
		}
	}
}