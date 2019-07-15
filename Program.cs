using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Clear();
      //     string title = @"
      //   ,---.                                    ,--.         ,--------.              ,--.        ,--.               
      //  /  O  \  ,---.  ,---. ,--,--. ,---.  ,---.`--',--,--,  '--.  .--',--.--.,--,--.`--',--,--, `--',--,--,  ,---. 
      // |  .-.  |(  .-' (  .-'' ,-.  |(  .-' (  .-',--.|      \    |  |   |  .--' ,-.  |,--.|      \,--.|      \| .-. |
      // |  | |  |.-'  `).-'  `) '-'  |.-'  `).-'  `)  ||  ||  |    |  |   |  |  \ '-'  ||  ||  ||  ||  ||  ||  |' '-' '
      // `--' `--'`----' `----' `--`--'`----' `----'`--'`--''--'    `--'   `--'   `--`--'`--'`--''--'`--'`--''--'.`-  / 
      //                                                                                                         `---'  
      //     ";
      Console.WriteLine("Welcome to the Assassin Training Program!");
      Console.WriteLine("You are about to put put through the Assassin training program. You will need to use your wit and skill to navigate through this training simulation. Your main objective is to get through the training without dying and defeat every Assassin's arch nemesis, a Templar. Good luck! Make the brotherhood proud!");
      Console.WriteLine("To get started, please tell me your Assassin name?");
      string CPlayer = Console.ReadLine();
      Console.WriteLine("Great, your Assassin name is " + CPlayer);
      Console.WriteLine("Now that you know the objective of this training simulation and your Assassin name. Press 'Enter' or any key to start your training!");
      Console.ReadKey();
      GameService gameService = new GameService();
      //TODO get line above working with no errors
      gameService.StartGame();

    }
  }
}
