using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Oppgave___WebShop
{
    public class WebShop
    {
        private StoreInventory Inventory;
        private List<Game> ShoppingCart;
        public WebShop()
        {
            Inventory = new StoreInventory();
            ShoppingCart = new List<Game>();

            while (true)
            {
                Console.WriteLine("Welcome to the shop! ");
                Console.WriteLine("1: Show all available games");
                Console.WriteLine("2: Show only physical games");
                Console.WriteLine("3: Show only downloadable games");
                HandleCommand();
            }
        }

        private void HandleCommand()
        {
            Thread.Sleep(1000);
            var userInput = Console.ReadLine();
            Inventory.PrintInventory(userInput);
            Console.WriteLine("Input the ID of the game you want to buy");
            var gameID = Console.ReadLine();
            var gameToBuy = Inventory.InventoryList.Find(x => x.Id == gameID);
            ShoppingCart.Add(gameToBuy);
            CheckDownloadOrShipping(gameToBuy);

        }

        private void CheckDownloadOrShipping(Game gameToBuy)
        {
            if (gameToBuy is IShippable && gameToBuy is not IDownloadable)
            {
                PrintShippingMessage(gameToBuy.GameName);
            }

            if (gameToBuy is IDownloadable && gameToBuy is not IShippable)
            {
                PrintDownloadMessage(gameToBuy.GameName);
            }
            else
            {
                chooseShippingOrDownload(gameToBuy.GameName);
            }
        }

        private void chooseShippingOrDownload(string gameName)
        {
            Console.WriteLine("Do you wish yo download this game Y/N");
            var answer = Console.ReadLine();
            if (answer.ToUpper() == "Y") PrintDownloadMessage(gameName);
            else
            {
                PrintShippingMessage(gameName);
            }
        }
        private void PrintDownloadMessage(string gameName)
        {
            Console.WriteLine($"Game {gameName} will now be downloaded..");
        }
        private void PrintShippingMessage(string gameName)
        {
            Console.WriteLine($"Game {gameName} will be shipped shortly..");
        }
    }
}