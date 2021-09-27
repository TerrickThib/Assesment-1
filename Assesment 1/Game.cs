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
        NONE
    }
    public struct Item
    {
        public string Name;
        public float StatBoost;
        public ItemType Type;
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
        /// <summary>
        /// Sets values for characters items so i can call on them later.
        /// </summary>
        public void InitalizeItems()
        {
            //Wizard Items
            Item wizardWand = new Item { Name = "Wizard Wand", StatBoost = 25, Type = ItemType.ATTACK };
            Item wizardBook = new Item { Name = "Spell Book of Defense", StatBoost = 15, Type = ItemType.DEFENSE };

            //Knight Items
            Item sword = new Item { Name = "Knight Sword", StatBoost = 10, Type = ItemType.ATTACK };
            Item shield = new Item { Name = "Knights Shield", StatBoost = 15, Type = ItemType.DEFENSE };

            //Initialize item arrays per character
            _wizardItems = new Item[] { wizardWand, wizardBook };
            _knightItems = new Item[] { sword, shield };

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
                _player = new Player(_playerName, 30, 20, 10, _wizardItems, "Wizard");
                _currentScene = Scene.BATTLE;
            }
            else if (Choice == 1)
            {
                _player = new Player(_playerName, 50, 15, 20, _knightItems, "Knight");
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
    }
}
