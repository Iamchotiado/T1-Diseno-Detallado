namespace Objects{
    class Player
    {
        public string name { get; set; }
        public List<Card> hand { get; set; }
        public Card superstar { get; set; }
        public List<Card> arsenal { get; set; }
        public List<Card> ringside { get; set; }
        public List<Card> ring_area { get; set; }

        public Player (string name, List<Card> hand, Card superstar, List<Card> arsenal, List<Card> ringside, List<Card> ring_area)
        {
            this.name = name;
            this.hand = hand;
            this.superstar = superstar;
            this.arsenal = arsenal;
            this.ringside = ringside;
            this.ring_area = ring_area;
        }
    }

    class Superstar {
        public string type { get; set; }
        public string hand_size { get; set; }
        public string superstar_value { get; set; }
        public string superstar_ability { get; set; }

        public Superstar (string type, string hand_size, string superstar_value, string superstar_ability)
        {
            this.type = type;
            this.hand_size = hand_size;
            this.superstar_value = superstar_value;
            this.superstar_ability = superstar_ability;
        }
    }

    // class HHH herits from Superstar
    class HHH : Superstar {
        public HHH(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "10", "3", superstar_ability)
        {
        }
    }

    // class Jericho herits from Superstar
    class CHRISJERICHO : Superstar {
        public CHRISJERICHO(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "7", "3", superstar_ability)
        {
        }
    }

    // class Kane herits from Superstar
    class KANE : Superstar {
        public KANE(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "7", "2", superstar_ability)
        {
        }
    }

    // class Mankind herits from Superstar
    class MANKIND : Superstar {
        public MANKIND(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "2", "4", superstar_ability)
        {
        }
    }

    // class StoneCold herits from Superstar
    class STONECOLDSTEVEAUSTIN : Superstar {
        public STONECOLDSTEVEAUSTIN(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "7", "5", superstar_ability)
        {
        }
    }

    // class TheRock herits from Superstar
    class THEROCK : Superstar {
        public THEROCK(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "5", "5", superstar_ability)
        {
        }
    }

    // class Undertaker herits from Superstar
    class THEUNDERTAKER : Superstar {
        public THEUNDERTAKER(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "6", "4", superstar_ability)
        {
        }
    }





    class Card {
        public string Title { get; set; }
        public List <String> Types { get; set; }
        public List <String> Subtypes { get; set; }
        public string Fortitude { get; set; }
        public string CardEffect { get; set; }
        public string Damage { get; set; }
        public string StunValue { get; set; }

        public Card (string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue)
        {
            this.Title = Title;
            this.Types = Types;
            this.Subtypes = Subtypes;
            this.Fortitude = Fortitude;
            this.CardEffect = CardEffect;
            this.Damage = Damage;
            this.StunValue = StunValue;
        }

    // class NoEffectCard herits from Card
    class NoEffectCard : Card {
        public NoEffectCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DiscardCard herits from Card
    class DiscardCard : Card {
        public DiscardCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DamageFortitudeChangersCard herits from Card
    class DamageFortitudeChangersCard : Card {
        public DamageFortitudeChangersCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class IrreversibleManeuversCard herits from Card
    class IrreversibleManeuversCard : Card {
        public IrreversibleManeuversCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AllowDrawCard herits from Card
    class AllowDrawCard : Card {
        public AllowDrawCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SpecialReversalsCard herits from Card
    class SpecialReversalsCard : Card {
        public SpecialReversalsCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }
    // class SearchCard herits from Card
    class SearchCard : Card {
        public SearchCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class CollateralDamageCard herits from Card
    class CollateralDamageCard : Card {
        public CollateralDamageCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RecoverDamageCard herits from Card
    class RecoverDamageCard : Card {
        public RecoverDamageCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class OtherCard herits from Card
    class OtherCard : Card {
        public OtherCard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }
}

}; // end namespace Objects