using System;
using System.Configuration;

namespace TemaLab4
{
    class Program
    {
        static void Main()
        {
            int x, q, b, v,j;
            long buget, b1;
            string m1, c1;
            Automobile[] masini = new Automobile[6];
            Automobile audi = new Automobile("audi", "rosu", 50000);
            Automobile bmw = new Automobile("bmw", "albastru", 70000);
            Automobile toyota = new Automobile("toyota", "alb", 20000);
            Automobile dacia = new Automobile("dacia,verde,10000");
            Console.WriteLine("Se introduc in memorie 2 noi inregistrari: \n");
            Console.WriteLine("Creare inregistrare masina (string)");
            Console.WriteLine("Introduceti marca,culoarea,pretul separate prin virgula");
            Automobile masina1 = new Automobile(Console.ReadLine());
            Console.WriteLine("Creare inregistrare citire rand cu rand de la tastatura");
            Console.WriteLine("Marca:");
            m1 = Console.ReadLine();
            Console.WriteLine("Culoare:");
            c1 = Console.ReadLine();
            Console.WriteLine("Pret:");
            b1 = Convert.ToInt64(Console.ReadLine());
            Automobile masina2 = new Automobile(m1, c1, b1);
            masini[0] = audi;
            masini[1] = bmw;
            masini[2] = toyota;
            masini[3] = dacia;
            masini[4] = masina1;
            masini[5] = masina2;
            do
            {
                Console.Clear();
                Console.WriteLine("     MENIU    ");
                Console.WriteLine("A: Afisati modelele disponibile:");
                Console.WriteLine("P: Verificare masina in functie de preferinte");
                Console.WriteLine("C: Optiuni in functie de Culoare  ");
                Console.WriteLine("M: Optiuni in functie de Marca ");
                Console.WriteLine("B: Optiuni in functie de Buget");
                Console.WriteLine("N: Arata masina cea mai ieftina");
                Console.WriteLine("V: Compara pretul a doua optiuni");
                Console.WriteLine("I: Info autor ");
                Console.WriteLine("X: Iesire ");
                x = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (x)
                {
                    case 'i':
                        Console.WriteLine("Sovea Stefan, grupa 3121A");
                        Console.ReadKey();
                        break;
                    case 'x':
                        Environment.Exit(1);
                        break;
                    case 'a':
                        Console.WriteLine("Optiuni disponibile:");
                        Console.WriteLine();
                        for (j = 0; j < 6; j++)
                        {
                            string c = masini[j].afisare();
                            Console.Write("Optiunea {0}: {1}",j+1,c);
                        }
                        Console.ReadKey();
                        break;
                    case 'p':
                        Console.WriteLine("Marca dorita:");
                        string optiune = Console.ReadLine();
                        Console.WriteLine("Culoarea dorita:");
                        string opcul = Console.ReadLine();
                        Console.WriteLine("Introduceti bugetul dumneavoastra:");
                        buget = Convert.ToInt64(Console.ReadLine());
                        q = 0;
                        for (j = 0; j < 6; j++)
                        {
                            q = masini[j].Preferinte(optiune, opcul, buget);
                            if (q == 1)
                            {
                                Console.WriteLine("Optiunea exista si va permiteti sa o achizitionati");
                                break;
                            }
                            if (q == 2)
                            {
                                Console.WriteLine("Optiunea exista, dar nu va permiteti sa o achizitionati");
                                break;
                            }
                        }
                        if (q == 0)
                            Console.WriteLine("Optiunea nu exista ");
                        Console.ReadKey();
                        break;
                    case 'c':
                        Console.WriteLine("Introduceti culoarea cautata:");
                        string cul = Console.ReadLine();
                        b = 0;
                        v = 0;
                        for (int t = 0; t < 6; t++)
                        {
                            b = 0;
                            b = masini[t].verifCuloare(cul);
                            if (b == 1)
                            {
                                Console.WriteLine(masini[t].afisare());
                                v = 1;
                            }
                        }
                        if (b == 0 && v == 0)
                            Console.WriteLine("Nu sunt optiuni disponibile");
                        Console.ReadKey();
                        break;
                    case 'm':
                        Console.WriteLine("Introduceti marca cautata:");
                        string mar = Console.ReadLine();
                        b = 0;
                        v = 0;
                        for (int t = 0; t < masini.Length; t++)
                        {
                            b = 0;
                            b = masini[t].verifMarca(mar);
                            if (b == 1)
                            {
                                Console.WriteLine(masini[t].afisare());
                                v = 1;
                            }

                        }
                        if (b == 0 && v == 0)
                            Console.WriteLine("Nu sunt optiuni disponibile");

                        Console.ReadKey();
                        break;
                    case 'b':
                        Console.WriteLine("Introduceti bugetul de care dispuneti:");
                        long bug = Convert.ToInt64(Console.ReadLine());
                        b = 0;
                        for (int t = 0; t < 6; t++)
                        {
                            b = 0;
                            b = masini[t].verifPret(bug);
                            if (b == 1)
                                Console.WriteLine(masini[t].afisare());
                        }
                        if (b == 0)
                            Console.WriteLine("Nu sunt optiuni disponibile");
                        Console.ReadKey();
                        break;
                    case 'n':
                        long BugetRef = masini[1].pret;
                        j = 0;
                        for(int i=0;i<6;i++)
                        {
                           if(masini[i].pret<BugetRef)
                            {
                                BugetRef = masini[i].pret;
                                j = i;
                            }
                        }
                        Console.WriteLine(masini[j].afisare());
                        Console.ReadKey();
                        break;

                    case 'v':
                        Console.WriteLine("       COMPARATOR     ");
                        Console.WriteLine("Introduceti numarul primei optiuni de comparat:");
                        int comp1= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Introduceti numarul celei de-a doua optiuni de comparat:");
                        int comp2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(masini[comp2 - 1].Compara(masini[comp1 - 1].pret));
                        Console.ReadKey();
                        break;
                }

            } while (1 != 0);
            Console.ReadKey();
        }
    }
}