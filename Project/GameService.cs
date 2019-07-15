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

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {
      #region Rooms
      Room lair = new Room("Assassin Lair", "Assassin's always have a main lair that they can meet and regroup at any time that the situation arises. It is also used to store your maps, weapons, collectables and anyone you are trying to keep safe from the Templars. This Lair is special in the sense that it includes a Assassin training simulator. This is your starting point. Ready to start your training?", "Every Assassin needs his/her essentail tools to get started. Pick up your new Hidden Blade and Torch. The Hidden Blade will help you defend yourself against the Templars and the Torch will help illuminate your path along your quest to save humanity");
      Room cyprus = new Room("Cyprus", "Welcome to Cyprus. Cyprus is where Altair served the Assassin Brotherhood. He went from being one of the highest ranking Assassin's in the Brotherhood to being shunned and demoted. You walk into a lit room. You can see that there is a Assassin's outfit in the room.");
      Room spain = new Room("Spain", "Welcome to Spain. Spain is where Ezio first learned that his father was an Assassin. His father and two brothers were hung by the Templars here. It was a very dark time in Ezio's life and started his path in the Brotherhood. At first, all he wanted was revenge but he quickly learned what it means to be an Assassin. You can see that this room contains an Assassin Hidden Blade.");
      Room venice = new Room("Venice", "Welcome to Venice.  As you walk into this room, this room is lit by several torches on the wall and you notice a figure standing in the room. Venice is a big part of Ezio's journey. He learned to master the necessary skills to be an Assassin.", "You have approached Ezio and need to decide what to do next.");
      Room rome = new Room("Rome", "Welcome to Rome. As you walk into Rome, you can see that the room is completely lit by several torches. There is a large locked door with weird symbols and drawings on it. To the right of the door you see a little hole that is the mechanism in which you use to unlock the door. The mechanism takes a special key to unlock.", "You have have successfully unlocked the door but do you dare enter to find out what's on the other side.");
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
      #region Exits
      Dictionary<string, IRoom>.Add("North", );
      #endregion

      CurrentRoom = lair;
      // CurrentPlayer = ;
    }

    public void StartGame()
    {
      while (running)
      {
        CurrentRoom.Description.Print();
        CurrentRoom.PrintOptions();
        string input = Console.ReadLine();
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
            CurrentRoom = CurrentRoom.(option);
            break;
        }
      }

    }

    public void TakeItem(string itemName)
    {
      if (Item.itemName == Player.Inventory.itemName)
      {
        Console.WriteLine("You already picked this item up. Please continue on with the game.");
      }
      else
      {
        Console.WriteLine($"You have picked up {Item.name}")
      }

    }

    public void UseItem(string itemName)
    {

    }

    public GameService(Room room, Player player)
    {
      CurrentRoom = room;
      CurrentPlayer = player;
      Setup();
    }
  }
}