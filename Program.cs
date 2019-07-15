using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      string title = @"
        ,---.                                    ,--.         ,--------.              ,--.        ,--.               
       /  O  \  ,---.  ,---. ,--,--. ,---.  ,---.`--',--,--,  '--.  .--',--.--.,--,--.`--',--,--, `--',--,--,  ,---. 
      |  .-.  |(  .-' (  .-'' ,-.  |(  .-' (  .-',--.|      \    |  |   |  .--' ,-.  |,--.|      \,--.|      \| .-. |
      |  | |  |.-'  `).-'  `) '-'  |.-'  `).-'  `)  ||  ||  |    |  |   |  |  \ '-'  ||  ||  ||  ||  ||  ||  |' '-' '
      `--' `--'`----' `----' `--`--'`----' `----'`--'`--''--'    `--'   `--'   `--`--'`--'`--''--'`--'`--''--'.`-  / 
                                                                                                              `---'  
          ";
      Console.ForegroundColor = ConsoleColor.DarkCyan;
      Console.BackgroundColor = ConsoleColor.DarkGray;
      Console.WriteLine(title);
      Console.WriteLine("Welcome to the Assassin Training Program!");
      Console.ResetColor();
      Console.WriteLine("Press 'Enter' or any key to start your training!");
      Console.ReadKey();
      GameService gameService = new GameService(room, player);

      //TODO get line above working with no errors
      gameService.StartGame();

    }
  }
}
