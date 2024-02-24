using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace OBGOpgaveBeer
{
    public class BeerRepository
    {
        private int nextId = 6;
        private List<Beer> beers = new List<Beer>()
        {
            new Beer() {Id = 1, Name = "Corona", abv = 25},
            new Beer() {Id = 2, Name = "Heineken", abv = 10},
            new Beer() {Id = 3, Name = "Tuborg", abv = 60},
            new Beer() {Id = 4, Name = "Carlsberg", abv = 55},
            new Beer() {Id = 5, Name = "Budweiser", abv = 45},

        };



        public Beer AddBeer(Beer beer)
        {
            beer.Id = nextId++;
            beers.Add(beer);
            return beer;
        }

        public Beer? DeleteBeer(int id)
        {
            Beer? beer = beers.Find(b => b.Id == id);
            if (beer != null)
            {
                beers.Remove(beer);
            }
            return beer;
        }

        public List<Beer> Get(string? sortby = null, int? minAbv = null)
        {
            List<Beer> result = new List<Beer>(beers);
            if (minAbv != null)
            {
                result = result.FindAll(b => b.abv >= minAbv);
            }
            if (sortby != null)
            {
                switch (sortby)
                {
                    case "Name":
                        result.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                        break;
                    case "Name_desc":
                        result.Sort((b1, b2) => b2.Name.CompareTo(b1.Name));
                        break;
                    case "abv":
                        result.Sort((b1, b2) => b1.abv - b2.abv);
                        break;
                }
            }
            return result;
        }

        public Beer? GetById(int id)
        {
            return beers.Find(b => b.Id == id);
        }

        public Beer? UpdateBeer(Beer beer,int id)
        {
            Beer? beerToUpdate = beers.Find(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = beer.Name;
                beerToUpdate.abv = beer.abv;
            }
            return beerToUpdate;

        }
    }
}
