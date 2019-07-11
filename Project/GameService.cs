using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    private bool Running = true;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

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
      //Rooms
      Room lair = new Room("Assassin Lair", "Assassin's always have a main lair that they can meet and regroup at any time that the situation arises. It is also used to store your maps, weapons, collectables and anyone you are trying to keep safe from the Templars. This Lair is special in the sense that it includes a Assassin training simulator. This is your starting point. Ready to start your training?", "Every Assassin needs his/her essentail tools to get started. Pick up your new Hidden Blade and Torch. The Hidden Blade will help you defend yourself against the Templars and the Torch will help illuminate your path along your quest to save humanity");
      Room cyprus = new Room("Cyprus", "Cyprus is where Altair served the Assassin Brotherhood. He went from being one of the highest ranking Assassin's in the Brotherhood to being shunned and demoted. You walk into a dark room and can't see anything. Symoblizing the fall of Altair and his journey to regaining his high ranking status in the Brotherhood.", "You lit up and the room. You can now see that there is a Assassin's outfit in the room.");
      Room spain = new Room("Spain", "Spain is where Ezio first learned that his father was an Assassin. His father and two brothers were hung by the Templars here. It was a very dark time in Ezio's life and started his path in the Brotherhood. At first, all he wanted was revenge but he quickly learned what it means to be an Assassin. Therefore, as you enter this room, it is completely dark. This symbolizes Ezio dark start with the Brotherhood.", "You have used your torch to light up the room and can now see that his room contains a window and an Assassin Hidden Blade.");

      //Items
      Item torch = new Item("Torch", "A simple stick of wood with the top of it wrapped with cloth that was dipped in flammable oil. When lit, it creates a decent amount of light to better view your surroundings.");
      Item ablade1 = new Item("Hidden Blade", "A hidden blade is an Assassin's main tool. It is light-weight and fits over your hand covering your wrist and forearm. Provides protection from incoming strikes and support to your wrist as you maneuver around this world");
      Item ablad2 = new Item("Hidden Blade", "Adds another hidden blade to your other wrist to create a dual hidden blade feature. AKA Double Hidden Blades");
      Item aOutfit = new Item("Assassin Outfit", "These are the robes that all Assassin's wear to hide their identity and blend in.");
      Item AI = new Item("Ezio", "Ezio is a master Assassin and will help you along your journey to defeat the Templars");
      Item apple = new Item("Apple of Eden", "A rare artifact that dates back to the creation of mankind. It can only be weilded but special individuals that possess the correct fortitude. It can be used to control the minds of others and to physically harm others.");
    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {

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