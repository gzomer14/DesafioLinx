using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioLinx
{
    class Program
    {
        static void Main(string[] args)
        {
            var entrada = Console.ReadLine().ToUpper();
            int x = 0;
            int y = 0;
            int retira = 0;
            bool erro = false;

            for (int i = 0; i < entrada.Length; i++)
            {
                
                switch (entrada[i])
                {
                    case 'N': 
                        y++; 
                        retira = 0; 
                        break;
                    case 'S': 
                        y--; 
                        retira = 0;
                        break;
                    case 'L': 
                        x++; 
                        retira = 0; 
                        break;
                    case 'O': 
                        x--; 
                        retira = 0; 
                        break;
                    case 'X': 
                        retira++;
                        if(i > 0)
                        {
                            switch (entrada[i - retira])
                            {
                                case 'N':
                                    y--;
                                    break;
                                case 'S':
                                    y++;
                                    break;
                                case 'L':
                                    x--;
                                    break;
                                case 'O':
                                    x++;
                                    break;
                            }
                        }
                        break;
                    default:
                        if(entrada[i-1] != 'X')
                        {
                            switch (entrada[i - 1])
                            {
                                case 'N':
                                    var num = "";
                                    foreach(var c in entrada.Substring(i))
                                    {
                                        try
                                        {
                                            int.Parse(c.ToString());
                                            num += c;
                                        }
                                        catch (Exception ex)
                                        {
                                            break;
                                        }
                                    }
                                    y = int.Parse(num);
                                    entrada = entrada.Replace(num, "");
                                    i--;
                                    break;
                                case 'S':
                                    num = "";
                                    foreach (var c in entrada.Substring(0, i+1))
                                    {
                                        try
                                        {
                                            int.Parse(c.ToString());
                                            num += c;
                                        }
                                        catch (Exception ex)
                                        {
                                            break;
                                        }
                                    }
                                    y = int.Parse(num);
                                    break;
                                case 'L':
                                    num = "";
                                    foreach (var c in entrada.Substring(0, i+1))
                                    {
                                        try
                                        {
                                            int.Parse(c.ToString());
                                            num += c;
                                        }
                                        catch (Exception ex)
                                        {
                                            break;
                                        }
                                    }
                                    x = int.Parse(num);
                                    break;
                                case 'O':
                                    num = "";
                                    foreach (var c in entrada.Substring(0, i+1))
                                    {
                                        try
                                        {
                                            int.Parse(c.ToString());
                                            num += c;
                                        }
                                        catch (Exception ex)
                                        {
                                            break;
                                        }
                                    }
                                    x = int.Parse(num);
                                    break;
                            }
                        }
                        else
                        {
                            erro = true;
                        }
                        break;
                }

                if (erro) break;
            }

            Console.WriteLine($"({x}, {y})");
            Console.ReadKey();
        }
    }
}
