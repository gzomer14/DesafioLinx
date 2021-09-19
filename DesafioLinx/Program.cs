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
                //Chamado para switch inicial
                Utils.SwitchInicial(ref x, ref y, entrada);
            }
            catch (Exception ex)
            {
                x = 999;
                y = 999;                
            }
            

            Console.WriteLine($"({x}, {y})");
            Console.ReadKey();
        }
    }
}
