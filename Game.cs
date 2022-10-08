using Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

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

    // play game
    public void play_game()
    {
      // print menu inicial
      new_game_menu();
      var option = Console.ReadLine();
      if (option == "1")
      {
        // create players
        // this.create_players();
        // player
        // var player = this.players[this.turn];
        // print deck selection menu
        deck_selection_menu((this.turn + 1).ToString());
        var deck_option = Console.ReadLine();
        var deck_path = this.paths_hands[int.Parse(deck_option) - 1];

        // read deck file
        var deck = File.ReadAllLines(deck_path, Encoding.UTF8);
        foreach (string line in deck)
        {
            Console.WriteLine(line);
        }
        this.available_cards = deserialize_cards_json(this.path_cards);
        this.available_superstars = deserialize_superstars_json(this.path_superstars);
        for (int i = 0; i < this.available_superstars.Count; i++)
        {
          Console.WriteLine(this.available_superstars[i].type);
        }
      }
    }


  } 



}