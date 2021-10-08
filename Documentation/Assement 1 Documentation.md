**Terrick Thibodeaux**  
S218032  
Fantsy Fighters  
Assesment 1 C#  
# I.Requirements  
**1.Description of Problem**   

**Name:** Fantsy Fighters   

**Problem Statement:**  
Creation of a application that demnstrates use of C#  

**Problem Specifications:**  
- The application displays use of aspects of c# such as use of arrays 

- The appliction also shows the understanding and use of Classes, and structs  

- Shows use of Constructs in a class

- Uses consepts such as for loops and if statments

- The application also displays use of a Save and Load function to write to a file and save to later load

**Input Information**  
- Takes in players choices/input to get a name, class  

- Takes in players choices/input to also navigate a amount of obsticles  

**Output Information**  
- Uses the inforation gathered to progress through the application based on user input  

**User Interface Information**  
- The main UI displays players Stats there (Health, AttackPower, and DefensePower)  

- Also displays Enemies Stats there (Health, AttackPower, and DefensePower)  

- Displays players options to either Attack, Equiped Item, Unequiped Item, or Save.  

# A:Demo  
  DeBug Dungeon 
  
  
# II.Design  
1. *System Architecture*  

All objects inherit from the gameobject class. Each gameobject is reponsible for drawing, updating and making decisions.  

2. *Object Information*  
- **Class Name:** Game.cs 

Name: InitalizeItems( )  
Description: Sets the stats for the items in the game such as player items and shop items.  
Visibility: Public    

Name: InitalizeEnemies( )  
Description: Sets the Enemies in the games Stats including health attack and defense as well as names.  
Visiblity: Public  

Name: Run( )  
Description: Is the main game function it runs the game.  
Visiblity: Public  

Name: Start( )  
Description: Sets all the objects and varbles the game needs from the start.  
Visiblity: Public  

Name: Update( )  
Description: Uppdates the game to display current scene.  
Visiblity: Public  

Name: End( )  
Description: Displays the GameOver messege and closes application.  
Visiblity: Public  

Name: DisplayCurrentScene( )  
Description: Increments the game based on the current Scene  
Visiblity: Public  

Name: GetInput(string description, params string[] options )  
Description: Is a Function that can be used to give a description and a list of choices, takes in a string and a list of strings/ options.  
Visiblity: Public  

Name: Save( )  
Description: Saves a list of game information to a file.  
Visiblity: Public  

Name: Load( )  
Description: Loads up a save file from earlier.  
Visiblity: Public  

Name: DisplayStartMenu( )  
Description: Displays a Start menu that uses a GetInput to ask if the player would like to start a new game or Load a previous one.  
Visiblity: Public  

Name: GetPlayerName( )  
Description: Writes a line asking for player input that being for a name then takes that name and desplays it and ask to confirm that as there name. 
Visiblity: Public  

Name: CharacterSelection( )  
Description: Uses a GetInput to ask player to pick a Character then takes that choice and sets the players stats to those of there choice.  
Visiblity: Public  

Name: DisplayStats(Entity character)  
Description: Takes in a Entity that being the player or a enemie and displays there stats.  
Visiblity: Public  

Name: DisplayEquipItemMenu( )  
Description: Displays the character items and takes in a players choice of item, if the item selected cant be equiped it fails and displays messege.  
Visiblity: Public  

Name: Battle( )  
Description: Plays the main battle displays both players stats, takes in players choice of move callculates dammage taken or done.  
Visiblity: Public  

Name: CheckBattleResults( )  
Description: Plays after Battle checks to see if player or enemies has died if enemies has died bring in new enemie and if player has died display loss messige and ask if they would like to play again.  
Visiblity: Public  

Name: RestartMenu( )  
Description: Displays a play again menu and uses a get input to get a response if input is yes restart game if no close application.  
Visiblity: Public  

Name: ShopMenu( )  
Description: Displays players gold as well as Shops Items.  
Visiblity: Private  

Name: Scene  
Description: Uses enums to corlate my Scene in the application to a name.  
Visiblity: Public  

Name: ItemType  
Description: Uses enums to set a type for each item. 
Visiblity: Public  

Name: Item  
Description: Uses a struct to set what a Item will be.  
Visiblity: Public

- **Class Name:** Entity.cs  
  
Name: TakeDamage(float damageAmount)  
Description: Calculates the amount of damage that will be taken.  
Visiblity: Public  

Name: Attack(Entity defender)  
Description: Uses the TakeDamage function to make the defender take damage.  
Visiblity: Public  

Name: Save(StreamWriter writer)  
Description: Saves Entitys stats by using StreamWriter  
Visiblity: Public  

Name: Load(StreamReader reader)  
Description: Atempts to load Saved information   
Visiblity: Public    

Name: Entity( )  
Description: Set what a Entity is and gives it basic values  
Visiblity: Public  
 
- **Class Name:** Player.cs  

Name: Player( )  
Description: Sets Basic stats a player will have  
Visiblity: Public  

Name: TryEquipItem(int index)  
Description: Sets the item at the selected index to be the current equiped item   
Visiblity: Public  

Name: TryRemoveCurrentItem( )  
Description: If player selects to unequip item, set current item to be nothing  
Visiblity: Public  

Name: GetItemNames( )  
Description: Gets the Name of all the players items and displays it  
Visiblity: Public  

Name: Gold( )  
Description: Sets _gold to a function to be used else where  
Visiblity: Public  

Name: Buy(Item item)  
Description: Takes in a item and checks if the player can afford the item if so take players gold and set that item to be current equiped item, and if player cant afford return broke  
Visiblity: Public  

Name: Save(StreamWriter writer)  
Description: Saves Players Job, gold, Stats and current item   
Visiblity: Public  

Name: Load(StreamReader reader)  
Description: Attempts to load game saved info if fails return false  
Visiblity: Public  

- **Class Name** Shop.cs  

Name: Shop()  
Description: Sets the shops gold and inventory item array  
Visiblity: Public  

Name: Sell(Player player, int itemIndex)  
Description: Takes in a player and item and finds that item in item array and checks if player can buy then increases shops gold by that gold spent  
Visiblity: Public  

Name: GetItemNames()  
Description: Gets the shops items in the array to display for shop  
Visiblity: Public













  
  
  




