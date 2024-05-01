using DrinksMVC.Data;
using DrinksMVC.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Tools
{
    public static class DbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var dbContext = serviceProvider.GetRequiredService<WendingDbContext>())
            {
                dbContext.Coins.RemoveRange(dbContext.Coins);
                dbContext.Drinks.RemoveRange(dbContext.Drinks);
                dbContext.Storages.RemoveRange(dbContext.Storages);
                dbContext.WendingMachine.RemoveRange(dbContext.WendingMachine);

                dbContext.WendingMachine.Add(new WendingMachine
                {
                    Balance = 100,
                    Drinks = new List<Drink>
                    {
                        new Drink
                        {
                            Name = "Americano",
                            Price = 50,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl = "/Image/Americano.jpg"
                        },
                        new Drink
                        {
                            Name = "Capucchino",
                            Price = 60,
                            isAvailable = true,
                            Count = 20,
                            ImageUrl = "/Image/Capucchino.jpg"
                        },
                        new Drink
                        {
                            Name = "Coffee",
                            Price = 40,
                            isAvailable = true,
                            Count = 30,
                            ImageUrl = "/Image/Coffee.png"
                        },
                        new Drink
                        {
                            Name = "CoffeeStrong",
                            Price = 55,
                            isAvailable = true,
                            Count = 25,
                            ImageUrl = "/Image/CoffeeStrong.jgp"
                        },
                        new Drink
                        {
                            Name = "JapanTea",
                            Price = 80,
                            isAvailable = true,
                            Count = 40,
                            ImageUrl = "/Image/JapanTea.jpg"
                        },
                        new Drink
                        {
                            Name = "Latte",
                            Price = 55,
                            isAvailable = true,
                            Count = 23,
                            ImageUrl = "/Image/Latte.jpg"
                        },
                        new Drink
                        {
                            Name = "Lipton Green",
                            Price = 60,
                            isAvailable = true,
                            Count = 33,
                            ImageUrl = "/Image/liptonGreen.png"
                        },
                        new Drink
                        {
                            Name = "Lipton",
                            Price = 60,
                            isAvailable = true,
                            Count = 35,
                            ImageUrl = "/Image/lipton.jpeg",
                        },
                        new Drink
                        {
                            Name = "Nestea Green",
                            Price = 55,
                            isAvailable = true,
                            Count = 40m,
                            ImageUrl = "/Image/nesteaGreen.jpg"
                        }
                    }
                });

                dbContext.Storages.Add(new CoinStorage
                {
                    CountCoins = 5,
                    Coins = new List<Coin>
                    {
                        new Coin
                        {
                            Value = 1,
                            isAvailable = true,
                            ImageUrl = ""
                        },
                        new Coin
                        {
                            Value = 2,
                            isAvailable = true,
                            ImageUrl = ""
                        },
                        new Coin
                        {
                            Value = 5,
                            isAvailable = true,
                            ImageUrl = ""
                        },
                        new Coin
                        {
                            Value = 10,
                            isAvailable = true,
                            ImageUrl = ""
                        }
                    }
                });
                dbContext.SaveChanges();
            }
        }
    }
}
