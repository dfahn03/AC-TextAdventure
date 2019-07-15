using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string AltDescription { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void Print()
    {
      Console.WriteLine($"Welcome to {Name}!");
      Console.WriteLine($"{Description}");
    }
    public void PrintOptions()
    {
      System.Console.Write("Type 'help' to get the list of all commands you can type in.");
    }
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
    public void AddItem(Item item)
    {

    }


    public Room(string name, string description, string altDescription)
    {
      Name = name;
      Description = description;
      AltDescription = altDescription;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}