using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private bool Running = true;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer
    { get; set; }

    private bool running = true;

    public void Setup()
    {
      #region Rooms
      Room lair = new Room("Assassin Lair", "Assassin's always have a main lair that they can meet and regroup at any time that the situation arises. It is also used to store your maps, weapons, collectables and anyone you are trying to keep safe from the Templars. This Lair is special in the sense that it includes a Assassin training simulator. This is your starting point. Ready to start your training?", "Every Assassin needs his/her essentail tools to get started. Pick up your new Hidden Blade and Torch. The Hidden Blade will help you defend yourself against the Templars and the Torch will help illuminate your path along your quest to save humanity");
      Room cyprus = new Room("Cyprus", "Welcome to Cyprus. Cyprus is where Altair served the Assassin Brotherhood. He went from being one of the highest ranking Assassin's in the Brotherhood to being shunned and demoted. You walk into a lit room. You can see that there is a Assassin's outfit in the room.", "");
      Room spain = new Room("Spain", "Welcome to Spain. Spain is where Ezio first learned that his father was an Assassin. His father and two brothers were hung by the Templars here. It was a very dark time in Ezio's life and started his path in the Brotherhood. At first, all he wanted was revenge but he quickly learned what it means to be an Assassin. As you walk in the room it is completely dark and you can't see anything. You feel your way around the room and feel what seems to be a button. You can see that this room contains an Assassin Hidden Blade.", "You have lit the room and now you can see an Assassin outfit on the ground.");
      Room venice = new Room("Venice", "Welcome to Venice. Venice is a big part of Ezio's journey. He learned to master the necessary skills to be an Assassin. As you walk into this room, this room is lit by several torches on the wall and you notice a figure standing in the room. You approach the figure and talk to him. You learn that his name is Ezio and he asks to join you in your training. Do you want Ezio to join you?", "");
      Room rome = new Room("Rome", "Welcome to Rome. As you walk into Rome, you can see that the room is completely lit by several torches. There is a large locked door with weird symbols and drawings on it. To the right of the door you see a little hole that is the mechanism in which you use to unlock the door. The mechanism takes a special key to unlock.", "You have unlocked the door and walk through it.");
      Room boss = new Room("Boss", "", "");
      #endregion
      #region Items
      Item torch = new Item("Torch", "A simple stick of wood with the top of it wrapped with cloth that was dipped in flammable oil. When lit, it creates a decent amount of light to better view your surroundings.");
      Item ablade1 = new Item("Hidden Blade", "A hidden blade is an Assassin's main tool. It is light-weight and fits over your hand covering your wrist and forearm. Provides protection from incoming strikes and support to your wrist as you maneuver around this world");
      Item ablad2 = new Item("Hidden Blade", "Adds another hidden blade to your other wrist to create a dual hidden blade feature. AKA Double Hidden Blades");
      Item aOutfit = new Item("Assassin Outfit", "These are the robes that all Assassin's wear to hide their identity and blend in.");
      Item AI = new Item("Ezio", "Ezio is a master Assassin and will help you along your journey to defeat the Templars");
      // Item apple = new Item("Apple of Eden", "A rare artifact that dates back to the creation of mankind. It can only be weilded but special individuals that possess the correct fortitude. It can be used to control the minds of others and to physically harm others.");
      #endregion
      #region Lair Exits
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
      // CurrentPlayer = ;
    }

    public void StartGame()
    {
      Console.ForegroundColor = ConsoleColor.Black;
      Console.BackgroundColor = ConsoleColor.Blue;
      Console.WriteLine("You are about to put put through the Assassin training program. You will need to use your wit and skill to navigate through this training simulation. Your main objective is to get through the training without dying and defeat every Assassin's arch nemesis, a Templar. Good luck! Make the brotherhood proud!");
      Console.ResetColor();
      Console.WriteLine("To get started, please tell me your Assassin name?");
      string CurrentPlayer = Console.ReadLine();
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("Great! Your Assassin name is " + CurrentPlayer);
      // TODO use the name variale to create an instance of a player and then assign the property CurrentPlayer equal to that newly created player
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Now you know the objective of this training simulation and you have an Assassin name. Let's get started! Press 'Enter'!");
      Console.ResetColor();
      Console.ReadKey();

      while (running)
      {
        CurrentRoom.Print();
        CurrentRoom.PrintOptions();


      }

    }

    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower();
      // Console.Write("Moving...");
      // for (int i = 0; i < 10; i++)
      // {
      //   Thread.Sleep(500);
      //   Console.Write('.');
      // }
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
          CurrentRoom = CurrentRoom.Go(option);
          break;
        case "Look":
          Look();
          break;
        case "Inventory":
          Inventory();
          break;
        case "Take":
          TakeItem(option);
          break;
        case "Use":
          UseItem(option);
          break;
        case "Help":
          Help();
          break;
        case "Reset":
          Reset();
          break;
        case "Quit":
          Quit();
          break;
      }
    }

    public void Go(string direction)
    {
      switch (direction)
      {
        case "North":
          if (direction != null)
          {
            return this;
          }
        case "next":
          if (direction != null)
          {
            return this;
          }

      }

    }

    public void TakeItem(string itemName)
    {
      //TODO use .find instead of contains so that you can use a callback function to search for the item with that name
      Item item = CurrentRoom.Items.Find(i => i.Name == itemName/**your query function here */);
      //if found item exists then add it to the player's inventory else not a valid item
      if (item != null/**check if item isn't null */)
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

    }

    public void Look()
    {

    }
    public void Inventory()
    {

    }

    public void Reset()
    {
      Console.WriteLine("If you want to reset your training simulator, type 'Reset' at any time");
      Console.ReadLine();
      StartGame();
    }
    public void Quit()
    {
      Console.WriteLine("If you wish to quit the training then type 'Quit' at any time.");
      Console.ReadLine();
      // if ("Quit")
    }


    public GameService()
    {
      Setup();
    }
  }
}