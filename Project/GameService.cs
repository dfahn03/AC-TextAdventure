using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private bool running = true;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer
    { get; set; }

    public void Setup()
    {
      #region Rooms
      Room lair = new Room("Assassin Lair", "Assassin's always have a main lair that they can meet and regroup at any time that the situation arises. It is also used to store your maps, weapons, collectables and anyone you are trying to keep safe from the Templars. This Lair is special in the sense that it includes a Assassin training simulator. This is your starting point. Every Assassin needs his/her essentail tools to get started. You are automatically given a Torch. The Torch will help illuminate your path along your quest to save humanity", "", "");
      Room cyprus = new Room("Cyprus", "Cyprus is where Altair served the Assassin Brotherhood. He went from being one of the highest ranking Assassin's in the Brotherhood to being shunned and demoted. You walk into a lit room and you see a video running of all the coolest kill streaks Altair every had! There is also a large locked door in front of you.", "", "");
      Room spain = new Room("Spain", "Spain is where Ezio first learned that his father was an Assassin. His father and two brothers were hung by the Templars here. It was a very dark time in Ezio's life and started his path in the Brotherhood. At first, all he wanted was revenge but he quickly learned what it means to be an Assassin. As you walk in the room it is completely dark and you can't see anything. You stumble around to feel what you think is a door and a key hole.", "", "");
      Room venice = new Room("Venice", "Venice is a big part of Ezio's journey. He learned to master the necessary skills to be an Assassin. As you walk into this room, this room is completely dark.", "Well done! You lit up the room and notice a figure standing in the room. You approach the figure and talk to him. You learn that his name is Ezio and he asks to join you in your training.", "The room is lit and you have added Ezio to your team!");
      Room rome = new Room("Rome", "As you walk into Rome, you can see that the room is completely lit by several torches. There is a large locked door with weird symbols and drawings on it. To the right of the door you see a little hole that is the mechanism in which you use to unlock the door. The mechanism takes a special key to unlock.", "You have unlocked the door and walk through it.", "");
      // Room boss = new Room("Boss", "", "");
      #endregion
      #region Items
      // Item torch = new Item("torch", "A simple stick of wood with the top of it wrapped with cloth that was dipped in flammable oil. When lit, it creates a decent amount of light to better view your surroundings.");
      // Item ablade1 = new Item("HiddenBlade", "A hidden blade is an Assassin's main tool. It is light-weight and fits over your hand covering your wrist and forearm. Provides protection from incoming strikes and support to your wrist as you maneuver around this world");
      // Item ablade2 = new Item("HiddenBlade", "Adds another hidden blade to your other wrist to create a dual hidden blade feature. AKA Double Hidden Blades");
      // Item aOutfit = new Item("AssassinOutfit", "These are the robes that all Assassin's wear to hide their identity and blend in.");
      Item AI = new Item("ezio", "Ezio is a master Assassin and will help you along your journey to defeat the Templars.");
      // Item apple = new Item("Apple of Eden", "A rare artifact that dates back to the creation of mankind. It can only be weilded but special individuals that possess the correct fortitude. It can be used to control the minds of others and to physically harm others.");
      #endregion
      #region Items Added to Rooms
      // lair.Items.Add(torch);
      // lair.Items.Add(ablade1);
      // spain.Items.Add(ablade2);
      // cyprus.Items.Add(aOutfit);
      venice.Items.Add(AI);
      #endregion
      #region Room Exits
      lair.Exits.Add("north", venice);
      lair.Exits.Add("east", rome);
      lair.Exits.Add("south", cyprus);
      lair.Exits.Add("west", spain);
      cyprus.Exits.Add("north", lair);
      spain.Exits.Add("east", lair);
      venice.Exits.Add("south", lair);
      rome.Exits.Add("west", lair);
      #endregion
      // #region Player Starting Inventory
      // CurrentPlayer.Inventory.Add(torch);

      // #endregion

      CurrentRoom = lair;
    }

    public void StartGame()
    {
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.WriteLine("You are about to put put through the Assassin training program. You will need to use your wit and skill to navigate through this training simulation. Your main objective is to get through the training without dying and defeat every Assassin's arch nemesis, a Templar. Good luck! Make the brotherhood proud!");
      Console.ResetColor();
      Thread.Sleep(2000);
      Console.WriteLine();
      Console.WriteLine("To get started, please tell me your Assassin name?");
      string cPlayer = Console.ReadLine();
      CurrentPlayer = new Player(cPlayer);
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Thread.Sleep(1000);
      Console.Clear();
      string title = @"
        ,---.                                    ,--.         ,--------.              ,--.        ,--.               
       /  O  \  ,---.  ,---. ,--,--. ,---.  ,---.`--',--,--,  '--.  .--',--.--.,--,--.`--',--,--, `--',--,--,  ,---. 
      |  .-.  |(  .-' (  .-'' ,-.  |(  .-' (  .-',--.|      \    |  |   |  .--' ,-.  |,--.|      \,--.|      \| .-. |
      |  | |  |.-'  `).-'  `) '-'  |.-'  `).-'  `)  ||  ||  |    |  |   |  |  \ '-'  ||  ||  ||  ||  ||  ||  |' '-' '
      `--' `--'`----' `----' `--`--'`----' `----'`--'`--''--'    `--'   `--'   `--`--'`--'`--''--'`--'`--''--'.`-  / 
                                                                                                              `---'  
          ";
      Console.WriteLine(title);
      Console.WriteLine();
      Console.WriteLine("Thank You! Your Assassin name is " + CurrentPlayer.PlayerName);
      Console.ResetColor();
      Thread.Sleep(1000);
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine();
      Console.WriteLine("If you ever get stuck, type 'Help'! Be warned, Assassin's shouldn't ask for help!");
      Console.ResetColor();
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine("Now you know the objective of this training simulation and you have an Assassin name. Let's get started! Press 'Enter'!");
      Console.ResetColor();
      Console.ReadKey();
      Console.Clear();
      CurrentRoom.Print();

      while (running)
      {
        GetUserInput();
      }

    }

    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower();
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

    public void TakeItem(string option)
    {
      Item item = CurrentRoom.Items.Find(i => i.Name == option);
      if (item != null)
      {
        // if (CurrentRoom.Name == "Venice" && CurrentRoom.Items.Contains(item.Name == torch))
        // {

        // }
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine($"You have picked up {item.Name}: {item.Description} Adding it to your inventory now.");
        Thread.Sleep(2000);
        Console.ResetColor();
        Console.WriteLine();
        CurrentRoom.PrintThirdDescription();
      }
      else
      {
        Console.WriteLine($"{CurrentRoom.Name} does not contain any items to pick up, you may need to define what you want to take or you have already picked this item up.");
      }
    }

    public void UseItem(string option)
    {
      Item usableItem = CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == option.ToLower());
      if (CurrentPlayer.Inventory.Contains(usableItem))
      {
        switch (usableItem.Name.ToLower())
        {
          case "torch":
            if (CurrentRoom.Name == "Venice")
            {
              Console.Clear();
              CurrentPlayer.Inventory.Remove(usableItem);
              CurrentRoom.Items.Add(usableItem);
              CurrentRoom.PrintAltDescription();
            }
            else
            {
              CurrentPlayer.Inventory.Remove(usableItem);
              Console.WriteLine("You dummy! This item cannot be used in this room.");
            }
            break;
          case "ezio":
            if (CurrentRoom.Name == "Rome")
            {
              CurrentPlayer.Inventory.Remove(usableItem);
              CurrentRoom.Items.Add(usableItem);
              WinGame();
            }
            else
            {
              LoseGame();
            }
            break;
        }
      }
      else
      {
        System.Console.WriteLine($"{option} is not in your inventory or does not exist Einstein.");
      }
    }

    public void Help()
    {
      Console.WriteLine(@"There is always shame in asking for help when you are an Assassin... 
       Go: Where do you want to go? (i.e. go west)
       Take: If you want it, take it! 
       Use: If you got it, do you want to use it?... 
       Look: What are you lookin at?
       Inventory: What are you carrying?
       Quit: I'm a failure and I'm quiting to join the Templars.....or be a peasant!...most likely a peasant though!
       Cheat: Let Ezio join you and use him while in Rome.
       Reset: Will starting over give you an edge?");
      GetUserInput();
    }

    public void Look()
    {
      Console.Clear();
      CurrentRoom.Print();
    }
    public void Inventory()
    {
      Console.WriteLine();
      CurrentPlayer.PrintInventory();
    }

    public void Reset()
    {
      Console.Clear();
      StartGame();
    }
    public void Quit()
    {
      running = false;
      // Console.WriteLine("The Matrix has won! Good-bye.");
      Console.WriteLine();
      Console.WriteLine("Play again? b/p");
      ConsoleKeyInfo res = Console.ReadKey();
      if (res.KeyChar == 'b')
      {
        Setup();
        running = true;
        StartGame();
      }
      else if (res.KeyChar == 'p')
      {
        Console.WriteLine();
        Console.WriteLine("Shame upon you and your family! You wont see us again...or will you when we hunt you down!");
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
      Console.WriteLine();
      Console.WriteLine("You unlock the locked door. The massive door opens. You walk through the door and into the Boss room. You and Ezio are standing on a ledge above your worst nemesis, The Grand Master Templar. You walk in front of Ezio, you bend down to take a knee, Ezio runs and jumps off your back. Ezio performs a triple backflip with a 1080 twist to land on top of the Grand Master Templar and stabs him. The Templar leans back opening up a critical hit spot and that signals you to leap off ledge. You leap off the ledge, do a gainer into a swan dive straight into the templars chest for a critical strike and killing blow! You won!");
      Thread.Sleep(20000);
      Console.Clear();
      Setup();
      StartGame();
    }
    public void LoseGame()
    {
      Console.WriteLine();
      Console.WriteLine("You tried using Ezio to unlock a door that you shouldn't have. Ezio gets mad and thinks that you are working for the Templars. As you turn to leave the room, Ezio stabs you in the back. This attack kills you!");
      Thread.Sleep(20000);
      Console.Clear();
      Setup();
      StartGame();
    }
    public GameService()
    {
      Setup();
    }
  }
}