using System;


public class minhaClasse
{

	public static void Main(string[] args)
	{

		//implente sua solução aqui
		int quantidadeNotasValidas = 0;
		double media = 0;
		while (quantidadeNotasValidas < 2)
		{

			double valor = double.Parse(Console.ReadLine());

			if (valor >= 0 && valor <= 10)
			{

				quantidadeNotasValidas++;
				media += valor;

			}
			else
			{
				Console.WriteLine("nota invalida");

			}

		}
		media = media / 2;
		Console.WriteLine("media = " + media.ToString("F"));
	}
}
