using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private bool playing = true;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer
    { get; set; }

    public void Setup()
    {
      #region Rooms
      Room lair = new Room("Assassin Lair", "Assassin's always have a main lair that they can meet and regroup at any time that the situation arises. It is also used to store your maps, weapons, collectables and anyone you are trying to keep safe from the Templars. This Lair is special in the sense that it includes a Assassin training simulator. This is your starting point. Ready to start your training?", "Every Assassin needs his/her essentail tools to get started. Pick up your new Hidden Blade and Torch. The Hidden Blade will help you defend yourself against the Templars and the Torch will help illuminate your path along your quest to save humanity");
      Room cyprus = new Room("Cyprus", "Welcome to Cyprus. Cyprus is where Altair served the Assassin Brotherhood. He went from being one of the highest ranking Assassin's in the Brotherhood to being shunned and demoted. You walk into a lit room. You can see that there is a Assassin's outfit in the room.", "");
      Room spain = new Room("Spain", "Welcome to Spain. Spain is where Ezio first learned that his father was an Assassin. His father and two brothers were hung by the Templars here. It was a very dark time in Ezio's life and started his path in the Brotherhood. At first, all he wanted was revenge but he quickly learned what it means to be an Assassin. As you walk in the room it is completely dark and you can't see anything. You feel your way around the room and feel what seems to be a button. You can see that this room contains an Assassin Hidden Blade.", "You have lit the room and now you can see an Assassin Hidden Blade on the ground.");
      Room venice = new Room("Venice", "Welcome to Venice. Venice is a big part of Ezio's journey. He learned to master the necessary skills to be an Assassin. As you walk into this room, this room is lit by several torches on the wall and you notice a figure standing in the room. You approach the figure and talk to him. You learn that his name is Ezio and he asks to join you in your training. Do you want Ezio to join you?", "");
      Room rome = new Room("Rome", "Welcome to Rome. As you walk into Rome, you can see that the room is completely lit by several torches. There is a large locked door with weird symbols and drawings on it. To the right of the door you see a little hole that is the mechanism in which you use to unlock the door. The mechanism takes a special key to unlock.", "You have unlocked the door and walk through it.");
      Room boss = new Room("Boss", "", "");
      #endregion
      #region Items
      Item torch = new Item("Torch", "A simple stick of wood with the top of it wrapped with cloth that was dipped in flammable oil. When lit, it creates a decent amount of light to better view your surroundings.");
      Item ablade1 = new Item("Hidden Blade", "A hidden blade is an Assassin's main tool. It is light-weight and fits over your hand covering your wrist and forearm. Provides protection from incoming strikes and support to your wrist as you maneuver around this world");
      Item ablade2 = new Item("Hidden Blade", "Adds another hidden blade to your other wrist to create a dual hidden blade feature. AKA Double Hidden Blades");
      Item aOutfit = new Item("Assassin Outfit", "These are the robes that all Assassin's wear to hide their identity and blend in.");
      Item AI = new Item("Ezio", "Ezio is a master Assassin and will help you along your journey to defeat the Templars");
      // Item apple = new Item("Apple of Eden", "A rare artifact that dates back to the creation of mankind. It can only be weilded but special individuals that possess the correct fortitude. It can be used to control the minds of others and to physically harm others.");
      #endregion
      #region Items Added to Rooms
      lair.Items.Add(torch);
      lair.Items.Add(ablade1);
      spain.Items.Add(ablade2);
      cyprus.Items.Add(aOutfit);
      venice.Items.Add(AI);
      #endregion
      #region Room Exits
      lair.Exits.Add("North", venice);
      lair.Exits.Add("East", rome);
      lair.Exits.Add("South", cyprus);
      lair.Exits.Add("West", spain);
      cyprus.Exits.Add("North", lair);
      spain.Exits.Add("East", lair);
      venice.Exits.Add("South", lair);
      rome.Exits.Add("West", lair);
      #endregion

      CurrentRoom = lair;
    }

    public void StartGame()
    {
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.WriteLine("You are about to put put through the Assassin training program. You will need to use your wit and skill to navigate through this training simulation. Your main objective is to get through the training without dying and defeat every Assassin's arch nemesis, a Templar. Good luck! Make the brotherhood proud!");
      Console.ResetColor();
      Thread.Sleep(3000);
      Console.WriteLine();
      Console.WriteLine("To get started, please tell me your Assassin name?");
      string cPlayer = Console.ReadLine();
      CurrentPlayer = new Player(cPlayer);
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Thread.Sleep(3000);
      Console.WriteLine();
      Console.WriteLine("Great! Your Assassin name is " + CurrentPlayer);
      // TODO use the name variale to create an instance of a player and then assign the property CurrentPlayer equal to that newly created player
      Console.ResetColor();
      Thread.Sleep(3000);
      Console.WriteLine();
      Console.WriteLine("Now you know the objective of this training simulation and you have an Assassin name. Let's get started! Press 'Enter'!");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine("If you ever get stuck, type 'help'!");
      Console.ResetColor();
      Console.ReadKey();
      Console.WriteLine();
      Console.WriteLine(CurrentRoom.Description);

      while (playing)
      {
        IRoom currentRoom = CurrentRoom;
        GetUserInput();
      }

    }

    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower();
      Console.Clear();
      string[] inputs = input.Split(' ');
      string command = inputs[0];
      string option = "";
      if (inputs.Length > 1)
      {
        option = inputs[1];
      }
      switch (command)
      {
        case "go":
          Go(option);
          break;
        case "look":
          Look();
          break;
        case "inventory":
          Inventory();
          break;
        case "take":
          TakeItem(option);
          break;
        case "use":
          UseItem(option);
          break;
        case "help":
          Help();
          break;
        case "reset":
          Reset();
          break;
        case "quit":
          Quit();
          break;
      }
    }

    public void Go(string direction)
    {
      Console.Clear();
      Room dest = (Room)CurrentRoom.Go(direction);
      CurrentRoom = dest;
      CurrentRoom.Print();

    }

    public void TakeItem(string itemName)
    {
      //TODO use .find instead of contains so that you can use a callback function to search for the item with that name
      Item item = CurrentRoom.Items.Find(i => i.Name == itemName/**your query function here */);
      //if found item exists then add it to the player's inventory else not a valid item
      if (item != null && item != /**check if item isn't null */)
      {
        CurrentPlayer.AddItemToInventory(item);
      }
      else
      {
        Console.WriteLine($"{CurrentRoom.Name} does not contain any items to pick up or you have already picked the item up.");
      }
    }

    public void UseItem(string itemName)
    {

    }
    public void Help()
    {
      Console.WriteLine(@"There is always shame in asking for help when you are an Assassin... 
       go: Where do you want to go?
       take: If you want it, take it! 
       use: If you got it, do you want to use it?... 
       look: What are you lookin at?
       inventory: What are you carrying?
       quit: I'm a failure and I'm quiting to join the Templars.....or be a peasant!...most likely a peasant though!
       cheat: *Let Ezio join you and use him in while in Rome.
       reset: Will starting over give you an edge?");
      GetUserInput();
    }

    public void Look()
    {
      Console.Clear();
      CurrentRoom.Print();
    }
    public void Inventory()
    {

    }

    public void Reset()
    {
      Console.Clear();
      StartGame();
    }
    public void Quit()
    {
      playing = false;
      // Console.WriteLine("The Matrix has won! Good-bye.");
      Console.WriteLine();
      Console.WriteLine("Play again? b/p");
      ConsoleKeyInfo res = Console.ReadKey();
      if (res.KeyChar == 'b')
      {
        Setup();
        playing = true;
        StartGame();
      }
      else if (res.KeyChar == 'p')
      {
        Console.WriteLine();
        Console.WriteLine("Shame upon you and your family! You wont see us again...");
        // Console.ReadLine();
        Environment.Exit(0);
      }
      else
      {
        Console.WriteLine();
        Quit();
      }

    }

    public void WinGame()
    {

    }
    public void LoseGame()
    {

    }
    public GameService()
    {
      Setup();
    }
  }
}