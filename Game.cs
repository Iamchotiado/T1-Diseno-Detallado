using Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace Stream
{
  class Game {
    public List<Player> players { get; set; }
    public int turn { get; set; }
    public List<string> paths_hands = new List<string>() { "cards/decks/HHH.txt", "cards/decks/JERICHO.txt", "cards/decks/KANE.txt", "cards/decks/MANKIND.txt", "cards/decks/STONE_COLD.txt", "cards/decks/THE_ROCK.txt", "cards/decks/UNDERTAKER.txt" };
    public string path_cards = "cards/cards.json";
    public string path_superstars = "cards/superstars.json";
    public List<Card> available_cards { get; set; }
    public List<Superstar> available_superstars { get; set; }
    public List<String> disable_characters = new List<String>() { "&", "!", "'", "?", "-", "%", "$", ".", ",", "*" };

    public Game(int turn)
    {
      this.turn = turn;
    }

    // advance turn
    public void advance_turn()
    {
      if (this.turn == 0)
      {
        this.turn = 1;
      }
      else
      {
        this.turn = 0;
      }
    }
    // print selection deck menu
    static void deck_selection_menu(string player_number)
    {
      Console.WriteLine("Player " + player_number + " select your deck:");
      Console.WriteLine("1. HHH");
      Console.WriteLine("2. Jericho");
      Console.WriteLine("3. Kane");
      Console.WriteLine("4. Mankind");
      Console.WriteLine("5. Stone Cold");
      Console.WriteLine("6. The Rock");
      Console.WriteLine("7. Undertaker");
      Console.Write("Option: ");
    }

    // print new game menu
    static void new_game_menu()
    {
        Console.WriteLine("Welcome to the T1 program!");
        Console.WriteLine("Seleccione una opcion:");
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Salir");
        Console.Write("Option: ");
    }

    // deserialize cards json file
    public static List<Card> deserialize_cards_json(string path)
    {
      string json = File.ReadAllText(path);
      List<Card> cards = JsonConvert.DeserializeObject<List<Card>>(json);
      return cards;
    }

    // deserialize superstars json file
    public static List<Superstar> deserialize_superstars_json(string path)
    {
      string json = File.ReadAllText(path);
      List<Superstar> superstars = JsonConvert.DeserializeObject<List<Superstar>>(json);
      return superstars;
    }

    // search superstar
    public static Superstar search_superstar(List<Superstar> superstars, string name)
    {
      foreach (Superstar superstar in superstars)
      {
        if (superstar.type == name)
        {
          return superstar;
        }
      }
      Console.WriteLine("Superstar not found");
      return null;
    }

    // search card
    public static Card search_card(List<Card> cards, string name)
    {
      foreach (Card card in cards)
      {
        if (card.Title == name)
        {
          return card;
        }
      }
      Console.WriteLine("Card not found");
      return null;
    }

    // get superstar card name
    public static string get_superstar_card_name(string line)
    {
      string[] words = line.Split(" ");
      string name = "";
      for (int i = 0; i < words.Length - 2; i++)
      {
        name += words[i];
      }
      return name;
    }

    // get class card name
    public string get_class_card_name(string line)
    {
      string[] words = line.Split(" ");
      string name = "";
      string clean_word = " ";
      for (int i = 1; i < words.Length; i++)
      {
        string word = words[i];
        // check if words[i] contains a disable_character
        for (int j = 0; j < word.Length; j++)
        {
          clean_word = String.Join("", word.Split('&', '!', '?', '-', '%', '$', '.', ',', '*', '\''));
        }

        name += clean_word;
      }
      return name;
    }
    // get card name
    public static string get_card_name(string line)
    {
      string[] words = line.Split(" ");
      string name = "";
      for (int i = 1; i < words.Length; i++)
      {
        if (i != (words.Length - 1))
        {
          name += words[i] + " ";
        }
        else
        {
          name += words[i];
        }
      }
      return name;
    }

    



    // create deck
    public void create_deck(int turn)
    {
      deck_selection_menu((this.turn + 1).ToString());
      var deck_option = Console.ReadLine();
      var deck_path = this.paths_hands[int.Parse(deck_option) - 1];
    
      // List<Card> deck = new List<Card>();

      string[] lines = File.ReadAllLines(deck_path, Encoding.UTF8);
      int num_lines = 0;
      string[] card;
      string card_name;
      int number_of_cards;
      string class_name;
      foreach (string line in lines)
      {
        if (num_lines == 0)
        {
          // se agrega el superstar al jugador
          card_name = get_superstar_card_name(line);
          Superstar superstar_attr = search_superstar(this.available_superstars, card_name);
          string type = "Objects." + card_name;
          Object superstar = Activator.CreateInstance(Type.GetType(type), superstar_attr.type, superstar_attr.hand_size, superstar_attr.superstar_value, superstar_attr.superstar_ability);
          Player player = new Player(card_name, new List<Card>(), (Superstar)superstar, new List<Card>(), new List<Card>(), new List<Card>());
          this.players.Add(player);
        }
        else
        {
          card = line.Split(" ");
          number_of_cards = int.Parse(card[0]);
          class_name = get_class_card_name(line);
          card_name = get_card_name(line);
          Card card_attr = search_card(this.available_cards, card_name);
          string type = "Objects." + class_name;
          Object card_obj = Activator.CreateInstance(Type.GetType(type), card_attr.Title, card_attr.Types, card_attr.Subtypes, card_attr.Fortitude, card_attr.CardEffect, card_attr.Damage, card_attr.StunValue);
          for (int i = 0; i < number_of_cards; i++)
          {
            this.players[turn].arsenal.Add((Card)card_obj);
          }
        }
        num_lines++;
      }
    }
    // play game
    public void play_game()
    {
      // creamos la lista de jugadores vacia
      this.players = new List<Player>();
      // cargamos todos los datos de las cartas y superstars
      this.available_cards = deserialize_cards_json(this.path_cards);
      this.available_superstars = deserialize_superstars_json(this.path_superstars);

      // print menu inicial
      new_game_menu();
      var option = Console.ReadLine();
      if (option == "1")
      {
        create_deck(this.turn);
        Console.WriteLine(this.players[0].superstar.type);
        Console.WriteLine(this.players[0].arsenal.Count);


        // // read deck file
        // var deck = File.ReadAllLines(deck_path, Encoding.UTF8);
        // foreach (string line in deck)
        // {
        //     Console.WriteLine(line);
        // }
        
      }
    }


  } 



}