using Microsoft.VisualStudio.TestTools.UnitTesting;
using OBGOpgaveBeer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OBGOpgaveBeer.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Beer beer = new Beer()
            {
                Id = 1,
                Name = "Corona",
                abv = 45
            };
            string b1 = beer.ToString();
            Assert.AreEqual("1 Corona 45", b1);
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beerNameNull = new()
            {
                Id = 1,
                Name = null,
                abv = 45
            };
            Assert.ThrowsException<ArgumentNullException>( 
                () => beerNameNull.ValidateName());

            Beer Beername = new()
            {

                Id = 1,
                Name = "hi",
                abv = 5
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Beername.ValidateName());
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer beerabv = new()
            {
                Id = 1,
                Name = "Harun",
                abv = 68
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => beerabv.ValidateAbv());

            Beer BeerAbvIn = new()
            {
                Id = 1,
                Name = "Harun",
                abv= 66
            };
            BeerAbvIn.ValidateAbv();
            

            Beer BeerAbvNeg = new()
            {
                Id = 1,
                Name = "Harun",
                abv = -1
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => BeerAbvNeg.ValidateAbv());
        }
    }
}