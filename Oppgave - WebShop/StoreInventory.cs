using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Oppgave___WebShop
{
    public class StoreInventory 
    {
    
            public List<Game> InventoryList { get; set; }

            public List<Game> ListPhysicalItems()
            {
                return InventoryList.Where(x => x is IShippable).ToList();
            }

            public List<Game> ListDownLoadable()
            {
                return InventoryList.Where(x => x is IDownloadable).ToList();
            }

        public StoreInventory()
            {
                var InventoryList = new List<Game>();
                InventoryList.Add(new PUBG());
                InventoryList.Add(new PokemonLetsGoEvee());
                InventoryList.Add(new CyberPunk());
                InventoryList.Add(new BattleField());
        }


        public void PrintInventory(string command)
        {
            if (command == "1")
            {
                Print(InventoryList);
            }
            else if (command == "2")
            {
                Print(ListPhysicalItems());
            }
            else
            {
                Print(ListDownLoadable());
            }
        }

        private void Print(List<Game> games)
        {
            games.ForEach(x => x.PrintGameNameAndPrice());
        }

        
    }
}