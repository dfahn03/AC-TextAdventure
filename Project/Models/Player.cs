using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public void PrintInventory()
    {
      if (Inventory.Count == 0)
      {
        Console.WriteLine("You haven't picked anything up yet! Maybe you should do that ;)!");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Current Inventory:");
        Console.ResetColor();
        foreach (var item in Inventory)
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine($"{item.Name}");
          Console.ResetColor();
        }
      }
    }

    // public void AddItemToInventory(Item i)
    // {
    //   List<Item> inventory = Inventory;
    //   if (!inventory.Contains(i))
    //   {
    //     Inventory.Add(i);
    //     Console.ForegroundColor = ConsoleColor.Green;
    //     Console.WriteLine($"You have picked up {i.Name}: {i.Description} Adding it to your inventory now.");
    //     Thread.Sleep(4000);
    //     Console.ResetColor();
    //   }
    //   else
    //   {
    //     Console.WriteLine("You already have this item in your inventory and cannot pick it up again. Please continue with your training.");
    //   }
    // }

    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>(){
        new Item("torch", "A simple stick of wood with the top of it wrapped with cloth that was dipped in flammable oil. When lit, it creates a decent amount of light to better view your surroundings.")
      };
    }
  }
}