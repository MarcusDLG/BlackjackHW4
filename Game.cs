using System;

namespace BlackjackHW4
{
  public class Program2
  {
    public static void Game()
    {
      var replay = true;
      while (replay == true)
      {
        Console.WriteLine($"Would you like to play another round? (YES) or (NO)");
        var playerInput = Console.ReadLine().ToLower();
        if (playerInput != "yes" && playerInput != "no")
        {
          Console.WriteLine("That is not a valid choice, chose again from yes or no");
          playerInput = Console.ReadLine().ToLower();
        }
        else if (playerInput == "no")
        {
          replay = false;
          Console.WriteLine("Goodbye");
        }
        else if (playerInput == "yes")
        {
          replay = false;
          BlackjackHW4.Program.Main();
        }
      }
    }
  }
}