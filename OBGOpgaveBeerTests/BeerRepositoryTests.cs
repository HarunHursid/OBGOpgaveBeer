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
    public class BeerRepositoryTests
    {
        [TestMethod()]
        public void AddBeerTest()
        {
            //List<Beer> beer = new()
            //{
            //    new Beer
            //    {
            //        Id = 1,
            //        Name = "Corona",
            //        abv = 25
            //    },
               
            //    new Beer
            //    {
            //        Id = 2,
            //        Name = "Heineken",
            //        abv = 10
            //    },
               

            //};

            BeerRepository beerRepository = new();
            Beer beer1 = new Beer() { Name = "blanc", abv = 37 };
            var addbeer = beerRepository.AddBeer(beer1);
            Assert.AreEqual(6, beerRepository.Get().Count());
            Assert.AreEqual(beer1,addbeer);
            

        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
            //List<Beer> beers = new()
            //{
            //    new Beer
            //    {
            //        Id = 1,
            //        Name = "Corona",
            //        abv = 25
            //    },
                
            //    new Beer
            //    {
            //        Id = 2,
            //        Name = "Heineken",
            //        abv = 10
            //    },
                
            //};
            BeerRepository repository = new();
            Beer beer = new Beer() { Name = "Blanc", abv = 37 };
            var deletedbeer = repository.DeleteBeer(4);
            Assert.AreEqual(4, repository.Get().Count());
        }

        [TestMethod()]
        public void GetTest()
        {
            BeerRepository repository = new();
            var beers = repository.Get();
            Assert.AreEqual(5, beers.Count());

            var filteredBeersByAbv = repository.Get(minAbv: 56);
            Assert.AreEqual(1, filteredBeersByAbv.Count());

            List<Beer> beersWithNameSorted = repository.Get(sortby: "Name");
            Assert.AreEqual("Heineken", beersWithNameSorted[3].Name);
        }


        [TestMethod()]
        public void UpdateBeerTest()
        {
            //List<Beer> beers = new()
            //{
            //    new Beer
            //    {
            //        Id = 1,
            //        Name = "Corona",
            //        abv = 25
            //    },
            //    new Beer
            //    {
            //        Id = 2,
            //        Name = "Heineken",
            //        abv = 10
            //    },

            //};

            //Beer UpdatedBeer = beers.FirstOrDefault(b => b.Id == 2);
            //if (UpdatedBeer != null)
            //{
            //    UpdatedBeer.Name = "Updated name";
            //    UpdatedBeer.abv = 57;
            //}
            //Assert.AreEqual("Updated name", UpdatedBeer.Name);
            //Assert.AreEqual(57, UpdatedBeer.abv);


            BeerRepository repository = new();
            Beer beer = new Beer() { Id = 4,Name = "Blanc", abv = 37 };
            var updatedBeer = repository.UpdateBeer(beer, 4);
            Assert.AreEqual("Blanc", updatedBeer.Name);
            Assert.AreEqual(37, updatedBeer.abv);

        }
    }
}
