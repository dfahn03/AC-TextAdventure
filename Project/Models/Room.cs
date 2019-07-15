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