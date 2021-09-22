using System;
using System.Text;

public class MainClass
{
    public static void Main(string[] args)
    {
        string classe; //declare as suas variaveis
        string tipo;
        string comida;

        classe = Console.ReadLine(); //insira suas variaveis
        tipo = Console.ReadLine();
        comida = Console.ReadLine();


        if ((classe == "vertebrado") && (tipo == "ave") && (comida == "carnivoro"))
        {
            Console.WriteLine("aguia\n");//complete o desafio
        }

        if ((classe == "vertebrado") && (tipo == "ave") && (comida == "onivoro"))
        {
            Console.WriteLine("pomba\n");//complete o desafio
    }

        if ((classe == "vertebrado") && (tipo == "mamífero") && (comida == "onivoro"))
        {
            Console.WriteLine("homem\n");//complete o desafio
    }

        if ((classe == "vertebrado") && (tipo == "mamífero") && (comida == "herbivoro"))
        {
            Console.WriteLine("vaca\n");//complete o desafio
    }

        if ((classe == "invertebrado") && (tipo == "inseto") && (comida == "hematofago"))
        {
            Console.WriteLine("pulga\n");//complete o desafio
    }

        if ((classe == "invertebrado") && (tipo == "inseto") && (comida == "herbivoro"))
        {
            Console.WriteLine("lagarta\n");//complete o desafio
    }

        if ((classe == "invertebrado") && (tipo == "anelideo") && (comida == "onivoro"))
        {
            Console.WriteLine("minhoca\n");
        }
        if ((classe == "invertebrado") && (tipo == "anelideo") && (comida == "hematofago"))
        {
            Console.WriteLine("sanguessuga\n");
        }

    }
}
