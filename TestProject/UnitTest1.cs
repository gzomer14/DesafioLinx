using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DesafioLinx;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteSimples()
        {
            var program = new CoordenadasDrone();

            program.Coordenadas("nnnlll");

            var result = program.Resultado();

            Assert.AreEqual("(3, 3)", result);
        }

        [TestMethod]
        public void TesteX()
        {
            var program = new CoordenadasDrone();

            program.Coordenadas("NNNXLLLXX");

            var result = program.Resultado();

            Assert.AreEqual("(1, 2)", result);
        }

        [TestMethod]
        public void SimulaErroNumericoX()
        {
            var program = new CoordenadasDrone();

            program.Coordenadas("NNX2");

            var result = program.Resultado();

            Assert.AreEqual("(999, 999)", result);
        }

        [TestMethod]
        public void TesteNumero()
        {
            var program = new CoordenadasDrone();

            program.Coordenadas("N123LSX");

            var result = program.Resultado();

            Assert.AreEqual("(1, 123)", result);
        }

        public void TesteDesconsiderarNumero()
        {
            var program = new CoordenadasDrone();

            program.Coordenadas("NLS3X");

            var result = program.Resultado();

            Assert.AreEqual("(1, 1)", result);
        }

        [TestMethod]
        public void TesteVariosCasos()
        {
            var program = new CoordenadasDrone();

            program.Coordenadas("NNNXLLXXS125");

            var result = program.Resultado();

            Assert.AreEqual("(0, -125)", result);
        }
    }
}
