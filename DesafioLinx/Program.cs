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

            try
            {
                SwitchInicial(ref x, ref y, entrada);
            }
            catch (Exception ex)
            {
                x = 999;
                y = 999;                
            }
            

            Console.WriteLine($"({x}, {y})");
            Console.ReadKey();
        }

        public static void SwitchInicial(ref int x, ref int y, string entrada)
        {
            int retira = 0;
            bool erro = false;

            for (int i = 0; i < entrada.Length; i++)
            {
                char letraAtual = entrada[i];
                char letraAnterior = i > 0 ? entrada[i - 1] : ' ';

                switch (letraAtual)
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
                        if (i > 0) CaseX(ref x, ref y, entrada[i - retira], ref retira);                        
                        break;
                    default:
                        if (letraAnterior != 'X')
                        {
                            switch (letraAnterior)
                            {
                                case 'N':
                                    var num = "";
                                    int pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) y = (int.Parse(num));
                                    else CaseX(ref x, ref y, letraAnterior, ref retira);
                                    i += pular - 1;
                                    break;
                                case 'S':
                                    num = "";
                                    pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) y = -(int.Parse(num));
                                    else CaseX(ref x, ref y, letraAnterior, ref retira);
                                    i += pular - 1;
                                    break;
                                case 'L':
                                    num = "";
                                    pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) x = (int.Parse(num));
                                    else CaseX(ref x, ref y, letraAnterior, ref retira);
                                    break;
                                case 'O':
                                    num = "";
                                    pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) x = -(int.Parse(num));
                                    else CaseX(ref x, ref y, letraAnterior, ref retira);
                                    break;
                            }
                        }
                        else
                        {
                            erro = true;
                        }
                        break;
                }

                if (erro)
                {
                    x = 999;
                    y = 999;
                    break;
                }
            }
        }

        public static void CaseX(ref int x, ref int y, char letra, ref int retira)
        {
            
            switch (letra)
            {
                case 'N':
                    y--;
                    retira++;
                    break;
                case 'S':
                    y++;
                    retira++;
                    break;
                case 'L':
                    x--;
                    retira++;
                    break;
                case 'O':
                    x++;
                    retira++;
                    break;
            }
            
        }

        public static void ForeachNumeric(ref string num, ref int pular, string entrada)
        {
            foreach (var c in entrada)
            {
                try
                {
                    int.Parse(c.ToString());
                    num += c;
                    pular++;
                }
                catch (Exception ex)
                {
                    if (c == 'X')
                    {
                        num = "";
                        pular++;
                    }
                    break;
                }
            }
        }
    }
}
