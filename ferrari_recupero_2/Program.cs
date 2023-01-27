using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ferrari_recupero_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m;
            do
            {
                Console.WriteLine("Inserire n (>4): ");
                n = int.Parse(Console.ReadLine());
            }while( n < 5 );
            do
            {
                Console.WriteLine("Inserire m (>4): ");
                m = int.Parse(Console.ReadLine());
            } while (m < 5);
            Console.Clear();
            int[,] campo = new int[n+2,m+2];
            int numerotartufi = GenerazioneTartufi(n, m, ref campo);
            GenerazioneAdiacenti(n, m, ref campo);
            StampaCampo(n, m, ref campo);
            int trovati = 0, mosse = 0;
            Console.SetCursorPosition(0, 0);
            do
            { 
                mosse++;
            } while (trovati < numerotartufi);
            Console.WriteLine($"Numero di mosse: {mosse}");
        }
        static int GenerazioneTartufi(int riga, int colonna, ref int[,] campo)
        {
            Random random = new Random();
            int tartufi = (riga * colonna) / 10;
            if ((riga * colonna) % 10 > 5)
            {
                tartufi++;
            }
            for (int i = 0; i < tartufi; i++)
            {
                int casuale1 = random.Next(1, riga);
                int casuale2 = random.Next(1, colonna);
                if (campo[casuale1, casuale2] != 100)
                {
                    campo[casuale1, casuale2] = 100;
                }
                else
                {
                    i--;
                }
            }
                return tartufi;
        }
        static void GenerazioneAdiacenti(int riga, int colonna, ref int[,] campo)
        {
            for (int i = 1; i <= colonna; i++)
            {
                for (int l = 1; l <= riga; l++)
                {
                    if (campo[l, i] != 100)
                    {
                        int contatore = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (campo[l - 1 + k, i - 1 + j] == 100)
                                {
                                    contatore++;
                                }
                            }
                        }
                        campo[l, i] = contatore;
                    }
                }
            }
        }
        static void StampaCampo(int riga, int colonna, ref int[,] campo) 
        {
            for (int i = 1; i <= colonna; i++)         
            {
                for (int j = 1; j <= riga; j++)                
                {
                    if (campo[j, i] == 100)                      
                    {
                        Console.Write($"{campo[j, i]} ");
                    }
                    else
                    {
                        Console.Write($" {campo[j, i]}  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}