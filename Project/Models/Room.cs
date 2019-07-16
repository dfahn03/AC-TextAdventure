using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string AltDescription { get; set; }
    public string FinalDescription { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void Print()
    {
      Console.WriteLine($"Welcome to {Name}!");
      Console.WriteLine();
      Console.WriteLine($"{Description}");
      Thread.Sleep(1000);
      Console.WriteLine();
      if (Items.Count == 0 || Name == "Venice")
      {
        Console.WriteLine($"There are no Items in {Name}:");
        Console.WriteLine();
        Console.WriteLine("What do you do?");
      }
      else if (Items.Count != 0)
      {
        Console.WriteLine($"Items in {Name}:");
        foreach (var item in Items)
        {
          Console.WriteLine(item.Name);
        }
        Console.WriteLine("What do you do?");
      }
    }
    public void PrintAltDescription()
    {
      Console.WriteLine($"Welcome to {Name}!");
      Console.WriteLine();
      Console.WriteLine($"{AltDescription}");
      Thread.Sleep(1000);
      Console.WriteLine();
      Console.WriteLine("Do you want Ezio to join you? If 'Yes' type 'take ezio'. If 'No' just leave the room.");
      Console.WriteLine();
      if (Items.Count == 0)
      {
        Console.WriteLine($"There are no Items in {Name}:");
        Console.WriteLine();
        Console.WriteLine("What do you do?");
      }
      else if (Items.Count != 0)
      {
        Console.WriteLine($"Items in {Name}:");
        foreach (var item in Items)
        {
          Console.WriteLine(item.Name);
        }
        Console.WriteLine("What do you do?");
      }
    }
    public void PrintThirdDescription()
    {
      Console.WriteLine($"Welcome to {Name}!");
      Console.WriteLine();
      Console.WriteLine($"{FinalDescription}");
      Thread.Sleep(1000);
      Console.WriteLine();
      if (Items.Count == 0)
      {
        Console.WriteLine($"There are no Items in {Name}:");
        Console.WriteLine();
        Console.WriteLine("What do you do?");
      }
      else if (Items.Count != 0)
      {
        Console.WriteLine($"Items in {Name}:");
        foreach (var item in Items)
        {
          Console.WriteLine(item.Name);
        }
        Console.WriteLine("What do you do?");
      }
    }

    // public void PrintUsedTorch()
    // {
    //   Console.WriteLine($"Welcome to the new {Name}!");
    //   Console.WriteLine();
    //   Console.WriteLine(AltDescription);
    //   Console.WriteLine();
    //   Console.WriteLine("Do you want Ezio to join you? If 'Yes' type 'take ezio'. If 'No' just leave the room.");
    //   // Console.ReadLine();
    // }

    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      else
      {
        Console.WriteLine("Direction does not exist!");
        return this;
      }
    }
    // public void AddItem(Item item)
    // {

    // }


    public Room(string name, string description, string altDescription, string finalDescription)
    {
      Name = name;
      Description = description;
      AltDescription = altDescription;
      FinalDescription = finalDescription;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}