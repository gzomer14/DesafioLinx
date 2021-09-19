using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioLinx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cord = new CoordenadasDrone();
            cord.Coordenadas(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
