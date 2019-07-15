using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    // public string AltDescription { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public override void PrintOptions()
    {
      System.Console.Write("type 'go North', 'go East', 'go South', 'go West', or one of the other commands. ");
    }
    public override Go(string dir)
    {
      switch (dir)
      {
        case "previous":
          if (Previous != null) return Previous;
          return this;
        case "next":
          if (Next != null) return Next;
          return this;

      }
    }


    public Room(string name, string description, string altdescription)
    {
      Name = name;
      Description = description;
      AltDescription = altdescription;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }
  }
}