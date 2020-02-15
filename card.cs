namespace BlackjackHW4
{
  public class Card
  {
    // Properties
    // rank
    public string Rank { get; set; }
    // suit
    public string Suit { get; set; }
    // color
    public string ColorOfTheCard { get; set; }


    // Method
    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }

    public string DisplayDealerFirst()
    {
      return $"{Rank[0]} of {Suit[0]}";
    }

    public int GetCardValue()
    {
      if (Rank == "ace")
      {
        return 11;
      }
      else if (Rank == "Queen" || Rank == "King" || Rank == "Jack")
      {
        return 10;
      }
      else
      {
        return int.Parse(Rank);
      }
    }
  }
}