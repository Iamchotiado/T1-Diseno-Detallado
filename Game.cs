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
    public List<string> paths_decks { get; set; }
    public string path_cards = "cards/cards.json";
    public string path_superstars = "cards/superstars.json";
    public string path_decks = "cards/decks";
    public List<Card> available_cards { get; set; }
    public List<Superstar> available_superstars { get; set; }
    public List<String> superstars_names = new List<String>(){"Kane", "TheRock", "Undertaker", "Mankind", "Jericho", "StoneCold", "HHH"};

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
    public void deck_selection_menu(string player_number)
    {
      this.paths_decks = new List<String>();
      Console.WriteLine("-----------------------------------------------------");
      Console.WriteLine("\nPlayer " + player_number + " select your deck:\n");
      int i = 1;
      foreach (string file in Directory.EnumerateFiles(this.path_decks, "*.txt"))
      {
        // add file to decks list
        this.paths_decks.Add(file);
        // Console.WriteLine(i.ToString() + ". " + file);
        // i++;
      }
      // sort decks list
      this.paths_decks.Sort();
      // print decks list
      foreach (string file in this.paths_decks)
      {
        Console.WriteLine(i.ToString() + ". " + file);
        i++;
      }
      Console.Write("\nOption: ");
    }

    // print new game menu
    public static void new_game_menu()
    {
        Console.WriteLine("\nWelcome to the T1 program!\n");
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
      var deck_path = this.paths_decks[int.Parse(deck_option) - 1];
    
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

          dynamic converted_superstar = Convert.ChangeType(superstar, Type.GetType(type));
          Player player = new Player(card_name, new List<Card>(), converted_superstar, new List<Card>(), new List<Card>(), new List<Card>());
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
          dynamic converted_card = Convert.ChangeType(card_obj, Type.GetType(type));
          for (int i = 0; i < number_of_cards; i++)
          {
            this.players[turn].arsenal.Add(converted_card);
          }
        }
        num_lines++;
      }
      // invertir el orden de la lista de cartas para que la ultima gregada quede primero en el mazo
      this.players[turn].arsenal.Reverse();
      // check if deck is valid
      bool valid_deck = validate_deck(turn);
      if (!valid_deck)
      {
        Console.WriteLine("\nLo lamento, pero el mazo de " + this.players[turn].superstar.format_name + " es invalido\n");
        Environment.Exit(0);
      }
      
    }

    // 

    // validate deck
    public bool validate_deck(int turn)
    {
      // check if player has superstar
      if (this.players[turn].superstar == null)
      {
        Console.WriteLine("\nYou must have a superstar in your deck");
        return false;
      }
      // check if player arsenal has 60 cards
      if (this.players[turn].arsenal.Count != 60)
      {
        Console.WriteLine("\nYou must have 60 cards in your arsenal");
        return false;
      }

      // loop through arsenal(Condicion2 de cantidad de cartas de un tipo)
      foreach (Card card in this.players[turn].arsenal)
      {
        // check if card is unique
        if (card.Subtypes.Contains("Unique"))
        {
          // check if card is unique in arsenal
          int count = 0;
          foreach (Card card2 in this.players[turn].arsenal)
          {
            if (card.Title == card2.Title)
            {
              count++;
            }
          }
          if (count > 1)
          {
            Console.WriteLine("\nYou can't have more than one unique card in your arsenal");
            return false;
          }
        }
        else
        {
          // check if a card is no more than 3 times in arsenal
          int count = 0;
          foreach (Card card2 in this.players[turn].arsenal)
          {
            if (card.Title == card2.Title)
            {
              count++;
            }
          }
          if (count > 3)
          {
            if (!card.Subtypes.Contains("SetUp"))
            {
              Console.WriteLine("\nYou can't have more than 3 cards with the same name in your arsenal");
              return false;
            }
            else
            {
              Console.WriteLine("\nTienes mas de 3 cartas de setup, si se puede");
            }
          }
        }
        
      }
      // check that arsenal does not have heel and face cards at the same time
      bool has_face = false;
      bool has_heel = false;
      foreach (Card card in this.players[turn].arsenal)
      {
        if (card.Subtypes.Contains("Face"))
        {
          has_face = true;
        }
        if (card.Subtypes.Contains("Heel"))
        {
          has_heel = true;
        }
      }
      if (has_face && has_heel)
      {
        Console.WriteLine("\nYou can't have face and heel cards in your arsenal at the same time");
        return false;
      }

      // check that arsenal has no cards from other superstars
      foreach (Card card in this.players[turn].arsenal)
      {
        // loop superstars_names
        foreach (string superstar_name in this.superstars_names)
        {
          if (card.Subtypes.Contains(superstar_name) && superstar_name != this.players[turn].superstar.format_name)
          {
            Console.WriteLine("\nYou can't have cards from other superstars in your arsenal");
            return false;
          }
        }
      }
      return true;
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
        while(true)
        {
          
          create_deck(this.turn);
          Console.WriteLine(this.players[this.turn].superstar.format_name);
          Console.WriteLine(this.players[this.turn].arsenal.Count);
          // print every card in arsenal
          // foreach (Card card in this.players[this.turn].arsenal)
          // {
          //   Console.WriteLine(card.Title);
          // }
          advance_turn();
        }
      }

      else
      {
        Environment.Exit(0);
      }
      
    }


  } 



}