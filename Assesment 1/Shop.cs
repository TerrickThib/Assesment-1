using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assesment_1
{
    class Shop
    {
        //Varibles for shop
        private int _gold;
        private Item[] _inventory;
        public string name;
        public int cost;

        

        public Shop()
        {
            _gold = 100;
            _inventory = new Item[3];
        }

        public Shop(Item[] items)
        {
            _gold = 100;
            //Set our inventory array to be the array of items that was passed in.
            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex)
        {
            //Find the item to buy in the inventory array
            Item itemToBuy = _inventory[itemIndex];            
            //Check to see if the player has anofe gold
            if (player.Gold() >= itemToBuy.Cost)
            {
                //Increase shops gold by item cost to complete the transaction
                _gold += itemToBuy.Cost;
                player.Buy(itemToBuy);
                return true;
            }               
            return true;            
        }
        //Gets the items name in the shop to display
        public string[] GetItemNames()
        {
            string[] itemNames = new string[_inventory.Length];
            //Increments the array one by one
            for (int i = 0; i < _inventory.Length; i++)
            {
                itemNames[i] = _inventory[i].Name;
            }

            return itemNames;
        }
        public void Save(StreamWriter writer)
        {
            writer.WriteLine(_gold);
        }
        public bool Load(StreamReader reader)
        {
            
            //If the current line can't be converted into an int...
            if (!int.TryParse(reader.ReadLine(), out _gold))
                return false;

            return true;
        }
    }

}
