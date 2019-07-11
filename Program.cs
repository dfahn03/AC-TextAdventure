using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      //     Console.WriteLine("
      //   ,---.                                    ,--.         ,--------.              ,--.        ,--.               
      //  /  O  \  ,---.  ,---. ,--,--. ,---.  ,---.`--',--,--,  '--.  .--',--.--.,--,--.`--',--,--, `--',--,--,  ,---. 
      // |  .-.  |(  .-' (  .-'' ,-.  |(  .-' (  .-',--.|      \    |  |   |  .--' ,-.  |,--.|      \,--.|      \| .-. |
      // |  | |  |.-'  `).-'  `) '-'  |.-'  `).-'  `)  ||  ||  |    |  |   |  |  \ '-'  ||  ||  ||  ||  ||  ||  |' '-' '
      // `--' `--'`----' `----' `--`--'`----' `----'`--'`--''--'    `--'   `--'   `--`--'`--'`--''--'`--'`--''--'.`-  / 
      //                                                                                                         `---'  
      //     ")
      Console.WriteLine("Welcome to the Assassin Training Program! What is your player name?");
      string cplayer = Console.ReadLine();
      GameService gameService = new GameService();
      //TODO get line above working with no errors
      gameService.StartGame();

    }
  }
}
