using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioLinx
{
    public class Utils
    {
        public static void SwitchInicial(ref int x, ref int y, string entrada)
        {
            //Utilizado para retirar posições caso exista mais de um X na entrada
            int retira = 0;

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

                        //Método para retirar posições incrementadas, de acordo com quantidade de X encontrado.
                        if (i > 0) CaseX(ref x, ref y, entrada[i - retira], ref retira);

                        break;
                    default:
                        //Validar se a letra anterior a sequencia numérica não é um X, caso for dispara erro.
                        if (letraAnterior != 'X')
                        {
                            switch (letraAnterior)
                            {
                                case 'N':
                                    var num = "";
                                    int pular = 0;

                                    //Método para adquirir por completo a sequencia numérica e atribuir a sua respectiva posição
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));

                                    //Caso encontre algum X logo após sequencia numérica, variavel virá vazia e
                                    //irá disparar o cancelamento da posição incrementada a partir do método CaseX
                                    if (!String.IsNullOrEmpty(num)) 
                                        y = (int.Parse(num));
                                    else 
                                        CaseX(ref x, ref y, letraAnterior, ref retira);
                                    i += pular - 1;
                                    break;
                                case 'S':
                                    num = "";
                                    pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) 
                                        y = -(int.Parse(num));
                                    else 
                                        CaseX(ref x, ref y, letraAnterior, ref retira);
                                    i += pular - 1;
                                    break;
                                case 'L':
                                    num = "";
                                    pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) 
                                        x = (int.Parse(num));
                                    else 
                                        CaseX(ref x, ref y, letraAnterior, ref retira);
                                    break;
                                case 'O':
                                    num = "";
                                    pular = 0;
                                    ForeachNumeric(ref num, ref pular, entrada.Substring(i));
                                    if (!String.IsNullOrEmpty(num)) 
                                        x = -(int.Parse(num));
                                    else 
                                        CaseX(ref x, ref y, letraAnterior, ref retira);
                                    i += pular - 1;
                                    break;
                            }
                        }
                        else
                        {
                            throw new Exception("X antes de sequência numérica.");
                        }
                        break;
                }
            }
        }

        private static void CaseX(ref int x, ref int y, char letra, ref int retira)
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

        private static void ForeachNumeric(ref string num, ref int pular, string entrada)
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
