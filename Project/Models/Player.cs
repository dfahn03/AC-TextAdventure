using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public void AddItemToInventory(Item i)
    {
      List<Item> inventory = Inventory;
      if (!inventory.Contains(i))
      {
        Inventory.Add(i);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You have picked up {i.Name}. {i.Description}");
        Console.ResetColor();
      }
      else
      {
        Console.WriteLine("You already have this item in your inventory and cannot pick it up again. Please continue with your training.");
      }
    }

    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }
  }
}