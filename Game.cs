using System;

namespace BlackjackHW4
{
  public class PlayAgain
  {
    public static void Replay()
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
          Console.Clear();
          Console.WriteLine("Goodbye");
        }
        else if (playerInput == "yes")
        {
          replay = false;
          BlackjackHW4.Program.Main();
        }
      }
    }

    // public static void Results()
    // {
    //   cardsInHand = CardList(playerHand);
    //   playerTotal = Total(playerHand);
    //   if (playerTotal > 21)
    //   {

    //     Console.WriteLine("Sorry, you bust!");
    //     wantsToHit = false;
    //     isRunning = false;
    //   }
    //   else if (dealerTotal > 21 && playerTotal < 21)
    //   {

    //     wantsToHit = false;
    //     isRunning = false;
    //     Console.WriteLine($"Congrats, you win, dealer bust with {dealerTotal} with {cardsInDealerHand}!");
    //   }
    //   else if (playerTotal < dealerTotal)
    //   {

    //     wantsToHit = false;
    //     isRunning = false;
    //     Console.WriteLine($"Sorry, you lose. You had {playerTotal} and dealer had {dealerTotal}");
    //   }
    //   else if (playerTotal > dealerTotal)
    //   {

    //     wantsToHit = false;
    //     isRunning = false;
    //     Console.WriteLine($"Congrats, you win! You had {playerTotal} and dealer had {dealerTotal}");
    //   }
    // }
  }
}