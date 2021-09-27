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

    }
}
