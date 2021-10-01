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
  
  
# II.Design  
1. *System Architecture*  

All objects inherit from the gameobject class. Each gameobject is reponsible for drawing, updating and making decisions.  

2. *Object Information*  
- **File Name:** Game.cs  

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

Name: GetInput( )  
Description: Is a Function that can be used to give a description and a list of choices.  
Visiblity: Public  

Name: Save( )  
Description: Saves a list of game information to a file.  
Visiblity: Public  

Name: Load( )  
Description: Loads up a save file from earlier.  
Visiblity: Public  






  
  
  




