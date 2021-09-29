using System;
using System.Collections.Generic;
using System.Text;

namespace Assesment_1
{
    public enum Scene
    {
        //Scenes in the game
        STARTMENU,
        NAMECREATION,
        CHARACTERSELECTION,
        BATTLE,
        RESTARTMENU

    }
    public enum ItemType
    {
        DEFENSE,
        ATTACK,
        HEALTH,
        NONE
    }
    
    public struct Item
    {
        public string Name;
        public float StatBoost;
        public ItemType Type;
        public int Cost;
    }
    class Game
    {
        //Varibles
        private bool _gameOver;
        private Scene _currentScene;
        private Player _player;
        private Entity[] _enemies;
        private int _currentEnemyIndex = 0;
        private Entity _currentEnemy;
        private string _playerName;
        private Item[] _wizardItems;
        private Item[] _knightItems;
        //Shop items
        private Shop _shop;       
        private Item[] _shopInventory;


        /// <summary>
        /// Sets values for characters items so i can call on them later.
        /// </summary>
        public void InitalizeItems()
        {
            //Wizard Items
            Item wizardWand = new Item { Name = "Wizard Wand", StatBoost = 20, Type = ItemType.ATTACK };
            Item wizardBook = new Item { Name = "Spell Book of Defense", StatBoost = 5, Type = ItemType.DEFENSE };

            //Knight Items
            Item sword = new Item { Name = "Knight Sword", StatBoost = 15, Type = ItemType.ATTACK };
            Item shield = new Item { Name = "Knights Shield", StatBoost = 5, Type = ItemType.DEFENSE };

            //Initialize item arrays per character
            _wizardItems = new Item[] { wizardWand, wizardBook };
            _knightItems = new Item[] { sword, shield };

            //Initialize Shop Items
            Item healthPotion = new Item { Name = "Health Potion", StatBoost = 10, Type = ItemType.HEALTH, Cost = 20 };
            Item attackPotion = new Item { Name = "Attack Potion", StatBoost = 10, Type = ItemType.ATTACK, Cost = 20 };
            Item defensePotion = new Item { Name = "Defense Potion", StatBoost = 10, Type = ItemType.DEFENSE, Cost = 20 };
            
            //Initalized the shops inventory into a array
            _shopInventory = new Item[] { healthPotion, attackPotion, defensePotion };
        }
        //Sets the enemies stats
        public void InitalizeEnemies()
        {
            _currentEnemyIndex = 0;

            //Enemie 1
            Entity bandit = new Entity("Bandit", 10.0f, 5.0f, 5.0f);
            //Enemie 2
            Entity warrior = new Entity("Warrior Buuba", 15.0f, 10.0f, 15.0f);
            //Enemie 3
            Entity rockMon = new Entity("Rocky THe Rock Dude", 25.0f, 20.0f, 20.0f);
            //Enemie 4
            Entity thatGuy = new Entity("That One Guy", 1.0f, 1.0f, 1.0f);
            //Enemie 5
            Entity unclePhil = new Entity("Uncle PHil", 50.0f, 30.0f, 25.0f);

            //Creates a array of enemies
            _enemies = new Entity[] { bandit, warrior, rockMon, thatGuy, unclePhil };
            //sets current enemy to a enemie in the current enemy index
            _currentEnemy = _enemies[_currentEnemyIndex];
            
        }
        public void Run()
        {
            Start();
            while (!_gameOver)
            {
                Update();

            }

            End();
        }
        /// <summary>
        /// Function sets any starting values by default
        /// </summary>
        public void Start()
        {
            _gameOver = false;
            _currentScene = 0;
            InitalizeItems();
            InitalizeEnemies();
            _player = new Player();
            _shop = new Shop(_shopInventory);
        }
        public void Update()
        {
            DisplayCurrentScene();
        }
        public void End()
        {

        }
        void DisplayCurrentScene()
        {
            switch(_currentScene)
            {
                case Scene.STARTMENU:
                    DisplayStartMenu();
                    break;
                case Scene.NAMECREATION:
                    GetPlayerName();
                    break;
                case Scene.CHARACTERSELECTION:
                    CharacterSelection();
                    break;
                case Scene.BATTLE:
                    Battle();
                    CheckBattleResults();
                    break;
                case Scene.RESTARTMENU:
                    RestartMenu();
                    break;
            }
        }
        /// <summary>
        /// Gets input from the player based on the options given
        /// </summary>
        /// <param name="description">The question or thing being descriped</param>
        /// <param name="options">Options the player has and can pick</param>
        /// <returns></returns>
        int GetInput(string description, params string[] options)
        {
            string input = "";
            int inputReceived = -1;

            while (inputReceived == -1)
            {
                //Print all of are options using the for loop to increment
                Console.WriteLine(description);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + options[i]);
                }
                Console.Write("> ");

                //Gets input from the player
                input = Console.ReadLine();

                //If the player typed an integer...
                if (int.TryParse(input, out inputReceived))
                {
                    //...decrement the input and check if it's within the bounds of the array if they choose 1 they atwally choose 0 in the array
                    inputReceived--;
                    if (inputReceived < 0 || inputReceived >= options.Length)
                    {
                        //Will set the input recived to be the default value
                        inputReceived = -1;
                        //Displays a error message
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey(true);
                    }
                }
                //If the player didn't type an integer
                else
                {
                    //Will set the input recived to be the default value
                    inputReceived = -1;
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey(true);
                }

                Console.Clear();
            }

            return inputReceived;
        }
        
        //Will Save sertain aspects of the game to load later
        public void Save()
        {

        }

        //Will try to Load game infomation from earlier save
        public bool Load()
        {
            bool loadSuccessful = true;
            return loadSuccessful;
        }
          
        public void DisplayStartMenu()
        {
            int choice = GetInput("Welcome to Fantsy Fighters!! ", "Start New Game", "Load Game");
            //Will start a new game ad move on the the next Scene
            if (choice == 0)
            {
                _currentScene = Scene.NAMECREATION;
            }
            else if (choice == 1)
            {
                //Will try to load up a previous save.
                if (Load())
                {
                    Console.WriteLine("Load Successful!");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            
        }
        /// <summary>
        /// Will Ask for the player for there name. It will then comfurm the name and move on to the next scene. 
        /// </summary>
        public void GetPlayerName()
        {
            Console.WriteLine("Befor we let you fight whats your name so we can Put it on your TOMESTONE!!!? ");
            Console.Write("> ");
            _playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(_playerName);

            //Will ask to confirm name or not.
            int Choice = GetInput("Are You Sure? ", "Yes", "No");
            if (Choice == 0)
            {
                _currentScene = Scene.CHARACTERSELECTION;
            }
            else if (Choice == 1)
            {
                GetPlayerName();
            }
        }
        /// <summary>
        /// Gets thew players Choice of CHaracter and updates the players Stats to that of there selection
        /// </summary>
        public void CharacterSelection()
        {
            int Choice = GetInput("Pick a Character. ", "Wizard", "Knight");
            if (Choice == 0)
            {
                _player = new Player(_playerName, 30, 20, 5, _wizardItems, "Wizard", 100);
                _currentScene = Scene.BATTLE;
            }
            else if (Choice == 1)
            {
                _player = new Player(_playerName, 50, 15, 10, _knightItems, "Knight", 100);
                _currentScene = Scene.BATTLE;
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Displays the stats of a Entity.
        /// </summary>
        /// <param name="character"></param>
        public void DisplayStats(Entity character)
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("AttackPower: " + character.AttackPower);
            Console.WriteLine("DefensePower: " + character.DefensePower);
            Console.WriteLine();
        }
        public void DisplayEquipItemMenu()
        {
            //Gets item index
            int input = GetInput("What You Want.", _player.GetItemNames());

            //Equip item at given index
            if (!_player.TryEquipItem(input))
                Console.WriteLine("Yo where your stuff go!!? Item not found.");

            //Prints Feedback if equiped
            Console.WriteLine("You equipped " + _player.CurrentItem.Name + "!");
        }
        public void Battle()
        {
            float damageDealt = 0;

            DisplayStats(_player);
            DisplayStats(_currentEnemy);

            int input = GetInput("A " + _currentEnemy.Name + " stands in front of you! What will you do?", "Attack", "Equip Item", "Remove current item", "Save Game");

            //If player decides to Attack
            if (input == 0)
            {
                damageDealt = _player.Attack(_currentEnemy);
                Console.WriteLine("You dealt " + damageDealt + " damage!");
            }
            //If player decides to equiped a item
            else if (input == 1)
            {
                DisplayEquipItemMenu();
                Console.ReadKey();
                Console.Clear();
                return;
            }
            //If player unequipts item
            else if (input == 2)
            {
                if (!_player.TryRemoveCurrentItem())
                {
                    Console.WriteLine("You dont got anything SOnnnnnnn.");
                }
                else
                {
                    Console.WriteLine("You Picked it up in your gucci bag. ");
                }
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            //If player wants to Save the game
            else if (input == 3)
            {
                Save();
                Console.WriteLine("Saved Game");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            //Displays how much dammagie you did and how much the enemie does
            damageDealt = _currentEnemy.Attack(_player);
            Console.WriteLine("The " + _currentEnemy.Name + " dealt" + damageDealt, " damage!");

            Console.ReadKey(true);
            Console.Clear();
        }
        void CheckBattleResults()
        {
            if(_player.Health <= 0)
            {
                Console.WriteLine("You done diddly Lost, Get out of hear");
                Console.ReadKey(true);
                Console.Clear();
                _currentScene = Scene.RESTARTMENU;
            }
            else if (_currentEnemy.Health <= 0)
            {
                Console.WriteLine("You Beat " + _currentEnemy.Name);
                Console.ReadKey();
                Console.Clear();

                ShopMenu();
                _currentEnemyIndex++;

               if (_currentEnemyIndex >= _enemies.Length)
                {
                    _currentScene = Scene.RESTARTMENU;
                    Console.WriteLine("You Killed everyone even BILL GOD WHY BILL HE WAS INCENT HE WAS GOOD. : (");
                    return;
                }
                _currentEnemy = _enemies[_currentEnemyIndex];
            }
        }
        //Ask the player if they want to restart Game or Quit
        void RestartMenu()
        {
            int Input = GetInput("Play Again", "Yes", "No");

            if (Input == 0)
            {
                _currentScene = Scene.STARTMENU;
                InitalizeEnemies();
            }
            else if (Input == 1)
            {
                _gameOver = true;
            }
        }
        private void ShopMenu()
        {
            //Displays players gold
            Console.WriteLine("Player Gold: " + _player.Gold());

            //Displays the item list for the shop
            int input = GetInput("Items To Buy.", _shop.GetItemNames());
            //_shop.Sell(_player, input);
            _shop.Sell(_player, input);
                        
        }
    }
}
