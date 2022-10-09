namespace Objects{
    class Player
    {
        public string name { get; set; }
        public List<Card> hand { get; set; }
        public dynamic superstar { get; set; }
        public List<Card> arsenal { get; set; }
        public List<Card> ringside { get; set; }
        public List<Card> ring_area { get; set; }
        public int fortitude_rating { get; set; }

        public Player (string name, List<Card> hand, dynamic superstar, List<Card> arsenal, List<Card> ringside, List<Card> ring_area)
        {
            this.name = name;
            this.hand = hand;
            this.superstar = superstar;
            this.arsenal = arsenal;
            this.ringside = ringside;
            this.ring_area = ring_area;
            this.fortitude_rating = 0;
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
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public HHH(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "10", "3", superstar_ability)
        {
            this.format_name = "HHH";
            this.before_draw_segment = false;
        }
    }

    // class Jericho herits from Superstar
    class CHRISJERICHO : Superstar {
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public CHRISJERICHO(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "7", "3", superstar_ability)
        {
            this.format_name = "Jericho";
            this.before_draw_segment = false;
        }
    }

    // class Kane herits from Superstar
    class KANE : Superstar {
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public KANE(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "7", "2", superstar_ability)
        {
            this.format_name = "Kane";
            this.before_draw_segment = true;
        }
    }

    // class Mankind herits from Superstar
    class MANKIND : Superstar {
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public MANKIND(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "2", "4", superstar_ability)
        {
            this.format_name = "Mankind";
            this.before_draw_segment = false;
        }
    }
    // class StoneCold herits from Superstar
    class STONECOLDSTEVEAUSTIN : Superstar {
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public STONECOLDSTEVEAUSTIN(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "7", "5", superstar_ability)
        {
            this.format_name = "StoneCold";
            this.before_draw_segment = false;
        }
    }

    // class TheRock herits from Superstar
    class THEROCK : Superstar {
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public THEROCK(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "5", "5", superstar_ability)
        {
            this.format_name = "TheRock";
            this.before_draw_segment = true;
        }
    }

    // class Undertaker herits from Superstar
    class THEUNDERTAKER : Superstar {
        public string format_name { get; set; }
        public bool before_draw_segment { get; set; }
        public THEUNDERTAKER(string type, string hand_size, string superstar_value, string superstar_ability) : base(type, "6", "4", superstar_ability)
        {
            this.format_name = "Undertaker";
            this.before_draw_segment = false;
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
    }

    // class Chop herits from Card
    class Chop : Card {
        public Chop(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Punch herits from Card
    class Punch : Card {
        public Punch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class HeadButt herits from Card
    class HeadButt : Card {
        public HeadButt(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RoundhousePunch herits from Card
    class RoundhousePunch : Card {
        public RoundhousePunch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Haymaker herits from Card
    class Haymaker : Card {
        public Haymaker(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BackBodyDrop herits from Card
    class BackBodyDrop : Card {
        public BackBodyDrop(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BigBoot herits from Card
    class BigBoot : Card {
        public BigBoot(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ShoulderBlock herits from Card
    class ShoulderBlock : Card {
        public ShoulderBlock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Kick herits from Card
    class Kick : Card {
        public Kick(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class CrossBodyBlock herits from Card
    class CrossBodyBlock : Card {
        public CrossBodyBlock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Ensugiri herits from Card
    class Ensugiri : Card {
        public Ensugiri(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RunningElbowSmash herits from Card
    class RunningElbowSmash : Card {
        public RunningElbowSmash(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DropKick herits from Card
    class DropKick : Card {
        public DropKick(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DiscusPunch herits from Card
    class DiscusPunch : Card {
        public DiscusPunch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Superkick herits from Card
    class Superkick : Card {
        public Superkick(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SpinningHeelKick herits from Card
    class SpinningHeelKick : Card {
        public SpinningHeelKick(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Spear herits from Card
    class Spear : Card {
        public Spear(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Clothesline herits from Card
    class Clothesline : Card {
        public Clothesline(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ChairShot herits from Card
    class ChairShot : Card {
        public ChairShot(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Hurricanrana herits from Card
    class Hurricanrana : Card {
        public Hurricanrana(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ArmBarTakedown herits from Card
    class ArmBarTakedown : Card {
        public ArmBarTakedown(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class HipToss herits from Card
    class HipToss : Card {
        public HipToss(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ArmDrag herits from Card
    class ArmDrag : Card {
        public ArmDrag(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RussianLegSweep herits from Card
    class RussianLegSweep : Card {
        public RussianLegSweep(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SnapMare herits from Card
    class SnapMare : Card {
        public SnapMare(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class GutBuster herits from Card
    class GutBuster : Card {
        public GutBuster(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BodySlam herits from Card
    class BodySlam : Card {
        public BodySlam(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BackBreaker herits from Card
    class BackBreaker : Card {
        public BackBreaker(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DoubleLegTakedown herits from Card
    class DoubleLegTakedown : Card {
        public DoubleLegTakedown(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class FiremansCarry herits from Card
    class FiremansCarry : Card {
        public FiremansCarry(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class HeadlockTakedown herits from Card
    class HeadlockTakedown : Card {
        public HeadlockTakedown(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BellytoBellySuplex herits from Card
    class BellytoBellySuplex : Card {
        public BellytoBellySuplex(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AtomicFacebuster herits from Card
    class AtomicFacebuster : Card {
        public AtomicFacebuster(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AtomicDrop herits from Card
    class AtomicDrop : Card {
        public AtomicDrop(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class InverseAtomicDrop herits from Card
    class InverseAtomicDrop : Card {
        public InverseAtomicDrop(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class VerticalSuplex herits from Card
    class VerticalSuplex : Card {
        public VerticalSuplex(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BellytoBackSuplex herits from Card
    class BellytoBackSuplex : Card {
        public BellytoBackSuplex(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class PumpHandleSlam herits from Card
    class PumpHandleSlam : Card {
        public PumpHandleSlam(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ReverseDDT herits from Card
    class ReverseDDT : Card {
        public ReverseDDT(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SamoanDrop herits from Card
    class SamoanDrop : Card {
        public SamoanDrop(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SitOutPowerbomb herits from Card
    class SitOutPowerbomb : Card {
        public SitOutPowerbomb(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Bulldog herits from Card
    class Bulldog : Card {
        public Bulldog(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class FishermansSuplex herits from Card
    class FishermansSuplex : Card {
        public FishermansSuplex(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DDT herits from Card
    class DDT : Card {
        public DDT(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class PowerSlam herits from Card
    class PowerSlam : Card {
        public PowerSlam(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Powerbomb herits from Card
    class Powerbomb : Card {
        public Powerbomb(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class PressSlam herits from Card
    class PressSlam : Card {
        public PressSlam(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class CollarElbowLockup herits from Card
    class CollarElbowLockup : Card {
        public CollarElbowLockup(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class WristLock herits from Card
    class WristLock : Card {
        public WristLock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ArmBar herits from Card
    class ArmBar : Card {
        public ArmBar(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ChinLock herits from Card
    class ChinLock : Card {
        public ChinLock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BearHug herits from Card
    class BearHug : Card {
        public BearHug(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class FullNelson herits from Card
    class FullNelson : Card {
        public FullNelson(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ChokeHold herits from Card
    class ChokeHold : Card {
        public ChokeHold(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class StepOverToeHold herits from Card
    class StepOverToeHold : Card {
        public StepOverToeHold(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AnkleLock herits from Card
    class AnkleLock : Card {
        public AnkleLock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class StandingSideHeadlock herits from Card
    class StandingSideHeadlock : Card {
        public StandingSideHeadlock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class CobraClutch herits from Card
    class CobraClutch : Card {
        public CobraClutch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BowArrow herits from Card
    class BowArrow : Card {
        public BowArrow(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ChickenWing herits from Card
    class ChickenWing : Card {
        public ChickenWing(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Sleeper herits from Card
    class Sleeper : Card {
        public Sleeper(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class CamelClutch herits from Card
    class CamelClutch : Card {
        public CamelClutch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BostonCrab herits from Card
    class BostonCrab : Card {
        public BostonCrab(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class GuillotineStretch herits from Card
    class GuillotineStretch : Card {
        public GuillotineStretch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AbdominalStretch herits from Card
    class AbdominalStretch : Card {
        public AbdominalStretch(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class TortureRack herits from Card
    class TortureRack : Card {
        public TortureRack(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class FigureFourLegLock herits from Card
    class FigureFourLegLock : Card {
        public FigureFourLegLock(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class StepAside herits from Card
    class StepAside : Card {
        public StepAside(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class EscapeMove herits from Card
    class EscapeMove : Card {
        public EscapeMove(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class BreaktheHold herits from Card
    class BreaktheHold : Card {
        public BreaktheHold(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RollingTakedown herits from Card
    class RollingTakedown : Card {
        public RollingTakedown(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class KneetotheGut herits from Card
    class KneetotheGut : Card {
        public KneetotheGut(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ElbowtotheFace herits from Card
    class ElbowtotheFace : Card {
        public ElbowtotheFace(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class CleanBreak herits from Card
    class CleanBreak : Card {
        public CleanBreak(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ManagerInterferes herits from Card
    class ManagerInterferes : Card {
        public ManagerInterferes(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Disqualification herits from Card
    class Disqualification : Card {
        public Disqualification(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class NoChanceinHell herits from Card
    class NoChanceinHell : Card {
        public NoChanceinHell(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Hmmm herits from Card
    class Hmmm : Card {
        public Hmmm(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DontThinkTooHard herits from Card
    class DontThinkTooHard : Card {
        public DontThinkTooHard(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class WhaddyaGot herits from Card
    class WhaddyaGot : Card {
        public WhaddyaGot(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class NotYet herits from Card
    class NotYet : Card {
        public NotYet(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class JockeyingforPosition herits from Card
    class JockeyingforPosition : Card {
        public JockeyingforPosition(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class IrishWhip herits from Card
    class IrishWhip : Card {
        public IrishWhip(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class FlashinthePan herits from Card
    class FlashinthePan : Card {
        public FlashinthePan(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    //  class ViewofVillainy herits from Card
    class ViewofVillainy : Card {
        public ViewofVillainy(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ShakeItOff herits from Card
    class ShakeItOff : Card {
        public ShakeItOff(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class OfferHandshake herits from Card
    class OfferHandshake : Card {
        public OfferHandshake(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RollOutoftheRing herits from Card
    class RollOutoftheRing : Card {
        public RollOutoftheRing(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DistracttheRef herits from Card
    class DistracttheRef : Card {
        public DistracttheRef(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Recovery herits from Card
    class Recovery : Card {
        public Recovery(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SpitAtOpponent herits from Card
    class SpitAtOpponent : Card {
        public SpitAtOpponent(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class GetCrowdSupport herits from Card
    class GetCrowdSupport : Card {
        public GetCrowdSupport(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Comeback herits from Card
    class Comeback : Card {
        public Comeback(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class EgoBoost herits from Card
    class EgoBoost : Card {
        public EgoBoost(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DeludingYourself herits from Card
    class DeludingYourself : Card {
        public DeludingYourself(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Stagger herits from Card
    class Stagger : Card {
        public Stagger(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Diversion herits from Card
    class Diversion : Card {
        public Diversion(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class MarkingOut herits from Card
    class MarkingOut : Card {
        public MarkingOut(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class PuppiesPuppies herits from Card
    class PuppiesPuppies : Card {
        public PuppiesPuppies(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ShaneOMac herits from Card
    class ShaneOMac : Card {
        public ShaneOMac(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class MaintainHold herits from Card
    class MaintainHold : Card {
        public MaintainHold(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class PatGerry herits from Card
    class PatGerry : Card {
        public PatGerry(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AustinElbowSmash herits from Card
    class AustinElbowSmash : Card {
        public AustinElbowSmash(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class LouTheszPress herits from Card
    class LouTheszPress : Card {
        public LouTheszPress(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DoubleDigits herits from Card
    class DoubleDigits : Card {
        public DoubleDigits(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class StoneColdStunner herits from Card
    class StoneColdStunner : Card {
        public StoneColdStunner(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class OpenUpaCanofWhoopA herits from Card
    class OpenUpaCanofWhoopA : Card {
        public OpenUpaCanofWhoopA(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class UndertakersChokeslam herits from Card
    class UndertakersChokeslam : Card {
        public UndertakersChokeslam(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class UndertakersFlyingClothesline herits from Card
    class UndertakersFlyingClothesline : Card {
        public UndertakersFlyingClothesline(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class UndertakerSitsUp herits from Card
    class UndertakerSitsUp : Card {
        public UndertakerSitsUp(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class UndertakersTombstonePiledriver herits from Card
    class UndertakersTombstonePiledriver : Card {
        public UndertakersTombstonePiledriver(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class PowerofDarkness herits from Card
    class PowerofDarkness : Card {
        public PowerofDarkness(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class HaveaNiceDay herits from Card
    class HaveaNiceDay : Card {
        public HaveaNiceDay(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DoubleArmDDT herits from Card
    class DoubleArmDDT : Card {
        public DoubleArmDDT(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class TreeofWoe herits from Card
    class TreeofWoe : Card {
        public TreeofWoe(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class MandibleClaw herits from Card
    class MandibleClaw : Card {
        public MandibleClaw(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class MrSocko herits from Card
    class MrSocko : Card {
        public MrSocko(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class LeapingKneetotheFace herits from Card
    class LeapingKneetotheFace : Card {
        public LeapingKneetotheFace(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Facebuster herits from Card
    class Facebuster : Card {
        public Facebuster(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class IAmtheGame herits from Card
    class IAmtheGame : Card {
        public IAmtheGame(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Pedigree herits from Card
    class Pedigree : Card {
        public Pedigree(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ChynaInterferes herits from Card
    class ChynaInterferes : Card {
        public ChynaInterferes(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class SmackdownHotel herits from Card
    class SmackdownHotel : Card {
        public SmackdownHotel(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class TakeThatMoveShineItUpRealNiceTurnThatSumbtchSidewaysandStickItStraightUpYourRoodyPooCandyA herits from Card
    class TakeThatMoveShineItUpRealNiceTurnThatSumbtchSidewaysandStickItStraightUpYourRoodyPooCandyA : Card {
        public TakeThatMoveShineItUpRealNiceTurnThatSumbtchSidewaysandStickItStraightUpYourRoodyPooCandyA(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class RockBottom herits from Card
    class RockBottom : Card {
        public RockBottom(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ThePeoplesEyebrow herits from Card
    class ThePeoplesEyebrow : Card {
        public ThePeoplesEyebrow(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class ThePeoplesElbow herits from Card
    class ThePeoplesElbow : Card {
        public ThePeoplesElbow(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class KanesChokeslam herits from Card
    class KanesChokeslam : Card {
        public KanesChokeslam(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class KanesFlyingClothesline herits from Card
    class KanesFlyingClothesline : Card {
        public KanesFlyingClothesline(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class KanesReturn herits from Card
    class KanesReturn : Card {
        public KanesReturn(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class KanesTombstonePiledriver herits from Card
    class KanesTombstonePiledriver : Card {
        public KanesTombstonePiledriver(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class HellfireBrimstone herits from Card
    class HellfireBrimstone : Card {
        public HellfireBrimstone(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Lionsault herits from Card
    class Lionsault : Card {
        public Lionsault(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class Y2J herits from Card
    class Y2J : Card {
        public Y2J(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class DontYouNeverEVER herits from Card
    class DontYouNeverEVER : Card {
        public DontYouNeverEVER(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class WallsOfJericho herits from Card
    class WallsOfJericho : Card {
        public WallsOfJericho(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }

    // class AyatollahofRocknRolla herits from Card
    class AyatollahofRocknRolla : Card {
        public AyatollahofRocknRolla(string Title, List <String> Types, List <String> Subtypes, string Fortitude, string CardEffect, string Damage, string StunValue) : base(Title, Types, Subtypes, Fortitude, CardEffect, Damage, StunValue)
        {
        }
    }


}; // end namespace Objects