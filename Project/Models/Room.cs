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
    public Dictionary<string, Room> Exits { get; set; }

    public void Print()
    {
      Console.WriteLine($"Welcome to {Name}! {Description}");
    }
    public void PrintOptions()
    {
      System.Console.Write("type 'Go North', 'Go East', 'Go South', 'Go West', or 'Help' to view one of the other commands. ");
    }
    // public override Go(string dir)
    // {
    //   switch (dir)
    //   {
    //     case "previous":
    //       if (Previous != null) return Previous;
    //       return this;
    //     case "next":
    //       if (Next != null) return Next;
    //       return this;

    //   }
    // }


    public Room(string name, string description, string altDescription)
    {
      Name = name;
      Description = description;
      AltDescription = altDescription;
      Items = new List<Item>();
      Exits = new Dictionary<string, Room>();
    }
  }
}