using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_1
{
    class Player : Entity
    {
        private Item[] _items;
        private Item _currentItem;
        private int _currentItemIndex;
        private string _job;

        public override float DefensePower
        {
            get
            {
                //Will return defense stat with the item boost added
                if (_currentItem.Type == ItemType.DEFENSE)
                    return base.DefensePower + CurrentItem.StatBoost;

                return base.DefensePower;
            }
        }
        public override float AttackPower
        {
            get
            {
                //Will return attack stat with item boost added
                if (_currentItem.Type == ItemType.ATTACK)
                    return base.AttackPower + CurrentItem.StatBoost;

                return base.AttackPower;
            }
        }

        //Sets these values to be used by other classes
        public Item CurrentItem
        {
            get
            {
                return _currentItem;
            }
        }

        public string Job
        {
            get
            {
                return _job;
            }
            set
            {
                _job = value;
            }
        }
        //Sets base values for player
        public Player()
        {
            _items = new Item[0];
            _currentItem.Name = "Nothing";
            _currentItemIndex = -1;
        }
        public Player(Item[] items) : base()
        {
            _currentItem.Name = "Nothing";
            _items = items;
            _currentItemIndex = -1;
        }
        //Alows player to insert values
        public Player(string name, float health, float attackPower, float defensePower, Item[] items, string job) : base(name, health, attackPower, defensePower)
        {
            _items = items;
            _currentItem.Name = "Nothing";
            _job = job;
            _currentItemIndex = -1;
        }       
        /// <summary>
        /// Sets the item at the given index to be the current item.
        /// </summary>
        /// <param name="index">The index of the item in the array</param>
        /// <returns>False if the index is outside the bounds of the array</returns>
        public bool TryEquipItem(int index)
        {
            //If the index is out of bounds..
            if (index >= _items.Length || index < 0)
            {
                //..return false
                return false;
            }
            //Setscurrent _current itemIndex
            _currentItemIndex = index;
            //Set the current item to be the array at the given index
            _currentItem = _items[_currentItemIndex];

            return true;
        }
        /// <summary>
        /// Set the current item to be nothing
        /// </summary>
        /// <returns>False if there is no item equipped</returns>
        public bool TryRemoveCurrentItem()
        {
            //If the current item is set to nothing..
            if (CurrentItem.Name == "Nothing")
            {
                //..Return false
                return false;
            }
            _currentItemIndex = -1;

            //Set item to nothing
            _currentItem = new Item();
            _currentItem.Name = "Nothing";

            return true;
        }
        /// <summary>
        /// Gets all the names of the items in the players inventory
        /// </summary>
        /// <returns></returns>
        public string[] GetItemNames()
        {
            //sets the itemNames to the array items length
            string[] itemNames = new string[_items.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                itemNames[i] = _items[i].Name;
            }
            return itemNames;
        }
    }
}
