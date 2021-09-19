using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioLinx
{
    public class CoordenadasDrone
    {
        private string resultadoString;

        public void Coordenadas(string entrada)
        {
            entrada = entrada.ToUpper();
            int x = 0;
            int y = 0;

            try
            {
                //Chamado para switch inicial
                Utils.SwitchInicial(ref x, ref y, entrada);
            }
            catch (Exception ex)
            {
                x = 999;
                y = 999;
            }

            //Variavel para teste unitário
            resultadoString = $"({x}, {y})";

            Console.WriteLine($"({x}, {y})");
        }

        public string Resultado()
        {
            return resultadoString;
        }
    }
}
