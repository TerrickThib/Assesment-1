using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_1
{
    class Entity
    {
        //Is Everything a Base Entity Has
        private string _name;
        private float _health;
        private float _attackPower;
        private float _defensePower;

        //How the other classes access the information
        public string Name
        {
            get { return _name; }
        }
        public virtual float Health
        {
            get { return _health;  }
        }
        public virtual float AttackPower
        {
            get { return _attackPower; }
        }
        public virtual float DefensePower
        {
            get { return _defensePower; }
        }

        public Entity()
        {
            //Will Set Bssic Values for Entitys
            _name = "Default";
            _health = 0;
            _attackPower = 0;
            _defensePower = 0;
        }

        public Entity(string name, float health, float attackPower, float defensePower)
        {
            //gives the ability to insert values for Entitys
            _name = name;
            _health = health;
            _attackPower = attackPower;
            _defensePower = defensePower;
        }
        /// <summary>
        /// Calculates the amout of damage that will be taken.
        /// </summary>
        /// <param attackpower="damageAmount"></param>
        /// <returns></returns>
        public float TakeDamage(float damageAmount)
        {
            float damageTaken = damageAmount - DefensePower;

            if (damageTaken < 0)
            {
                damageTaken = 0;
            }

            _health -= damageTaken;

            return damageTaken;
        }
       
        //Makes the defender take damage
        public float Attack(Entity defender)
        {
            return defender.TakeDamage(AttackPower);
        }
    }
}
