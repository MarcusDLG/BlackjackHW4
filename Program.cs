using System;
using System.Collections.Generic;

namespace BlackjackHW4
{
  class Program
  {
    public static int Total(List<Card> hand)
    {
      var total = 0;
      for (int i = 0; i < hand.Count; i++)
      {
        total += hand[i].GetCardValue();

      }
      return total;
    }
    // method for displaying cards in hand
    public static string CardList(List<Card> cards)
    {
      var list = " ";
      for (int i = 0; i < cards.Count; i++)
      {
        list += cards[i].DisplayCard() + ", ";
      }
      return list;
    }
    public static void Main()
    {

      bool isRunning = true;
      while (isRunning)
      {
        // bool playerFlag = true;
        // bool dealerFlag = true;
        // bool resultsFlag = true;

        var suits = new List<string>() { "clubs", "spades", "hearts", "diamonds" };
        var ranks = new List<string>() { "ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        var deck = new List<Card>();

        for (int i = 0; i < suits.Count; i++)
        {
          for (int j = 0; j < suits.Count; j++)
          {
            var card = new Card();
            card.Rank = ranks[j]; //
            card.Suit = suits[i];
            if (card.Suit == "diamonds" || card.Suit == "hearts")
            {
              card.ColorOfTheCard = "red";
            }
            else
            {
              card.ColorOfTheCard = "black";
            }
            deck.Add(card);
          }
        }
        for (int i = deck.Count - 1; i >= 1; i--)
        {
          var j = new Random().Next(i);
          var temp = deck[j];
          deck[j] = deck[i];
          deck[i] = temp;
        }


        var playerHand = new List<Card>();
        var dealerHand = new List<Card>();

        // dealer hand initial distribution
        Console.Clear();
        dealerHand.Add(deck[0]);
        deck.RemoveAt(0);

        dealerHand.Add(deck[0]);
        deck.RemoveAt(0);
        var cardsInDealerHand = CardList(dealerHand);
        var dealerTotal = Total(dealerHand);
        // player hand initial distribution
        playerHand.Add(deck[0]);
        deck.RemoveAt(0);
        playerHand.Add(deck[0]);
        deck.RemoveAt(0);
        var cardsInHand = CardList(playerHand);
        var playerTotal = Total(playerHand);

        // Console.WriteLine($"{dealerTotal} {cardsInDealerHand}");
        // Console.WriteLine($"{playerTotal} {cardsInHand}");
        // isRunning = false;

        bool wantsToHit = true;
        bool dealerWantsToHit = true;

        if (playerTotal == 21)
        {
          Console.WriteLine("Congrats, you got blackjack!");
          isRunning = false;
        }
        while (playerTotal <= 20 && wantsToHit == true && dealerWantsToHit == true)
        {
          // var dealerFirst = DisplayDealerFirst(cardsInDealerHand);
          // Console.WriteLine($"The dealer is showing {DisplayDealerFirst(cardsInDealerHand)}");
          Console.WriteLine($"player total is {playerTotal} and is holding {cardsInHand}");
          Console.WriteLine("Would you like to (HIT) or (STAY)");
          var userChoice = Console.ReadLine().ToLower();  //put in user input verification
          if (userChoice != "hit" && userChoice != "stay")
          {
            Console.WriteLine("That is not a valid choice, chose again from hit or stay");
            userChoice = Console.ReadLine().ToLower();
          }
          else if (userChoice == "hit")
          {
            playerHand.Add(deck[0]);
            deck.RemoveAt(0);
            cardsInHand = CardList(playerHand);
            playerTotal = Total(playerHand);
            if (playerTotal > 21)
            {
              wantsToHit = false;
              isRunning = false;
              dealerWantsToHit = false;
            }
          }
          else if (userChoice == "stay")
          {
            wantsToHit = false;
            Console.Clear();
            Console.WriteLine($"Dealer has a total of {dealerTotal} with the following cards in hand {cardsInDealerHand}");
          }
        }
        while (dealerWantsToHit == true && dealerTotal <= 16)
        {
          dealerHand.Add(deck[0]);
          deck.RemoveAt(0);
          cardsInDealerHand = CardList(dealerHand);
          dealerTotal = Total(dealerHand);
          if (dealerTotal > 21)
          {
            dealerWantsToHit = false;
          }
          else if (dealerTotal > 17 && dealerTotal < 21)
          {
            dealerWantsToHit = false;
          }
        }
        if (playerTotal > 21)
        {

          Console.WriteLine("Sorry, you bust!");
          wantsToHit = false;
          isRunning = false;
        }
        else if (dealerTotal > 21 && playerTotal < 21)
        {

          wantsToHit = false;
          isRunning = false;
          Console.WriteLine($"Congrats, you win, dealer bust with {dealerTotal} with {cardsInDealerHand}!");
        }
        else if (playerTotal < dealerTotal)
        {

          wantsToHit = false;
          isRunning = false;
          Console.WriteLine($"Sorry, you lose. You had {playerTotal} and dealer had {dealerTotal}");
        }
        else if (playerTotal > dealerTotal)
        {

          wantsToHit = false;
          isRunning = false;
          Console.WriteLine($"Congrats, you win! You had {playerTotal} and dealer had {dealerTotal}");
        }
      }
      BlackjackHW4.PlayAgain.Replay();
    }
  }
}