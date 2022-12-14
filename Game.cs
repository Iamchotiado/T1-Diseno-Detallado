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
    public int round { get; set; }
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

    // check winner
    public void check_winner()
    {
      if (this.players[0].arsenal.Count < 1)
      {
        Console.WriteLine("Count Out Victory!");
        Console.WriteLine(this.players[1].superstar.format_name + " gana!");
        Environment.Exit(0);
      }
      else if (this.players[1].arsenal.Count < 1)
      {
        Console.WriteLine("Count Out Victory!");
        Console.WriteLine(this.players[0].superstar.format_name + " gana!");
        Environment.Exit(0);
      }
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

    // check opponent
    public int opponent()
    {
      if (this.turn == 0)
      {
        return 1;
      }
      else
      {
        return 0;
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
          Player player = new Player(card_name, new List<dynamic>(), converted_superstar, new List<dynamic>(), new List<dynamic>(), new List<dynamic>());
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

    // draw starting hand
    public void draw_starting_hand(int turn)
    {
      // Console.WriteLine("------------------------------------");
      // Console.WriteLine("Rsenal antes de sacar mano inicial " + string.Join( ",", this.players[turn].arsenal.Select(x => x.Title)));
      // Console.WriteLine("------------------------------------");
      for (int i = 0; i < int.Parse(this.players[turn].superstar.hand_size); i++)
      {
        this.players[turn].hand.Add(this.players[turn].arsenal[i]);
      }
      for (int i = 0; i < int.Parse(this.players[turn].superstar.hand_size); i++)
      {
        this.players[turn].arsenal.RemoveAt(0);
      }
      // Console.WriteLine("------------------------------------");
      // Console.WriteLine("Rsenal despues de sacar mano inicial " + string.Join( ",", this.players[turn].arsenal.Select(x => x.Title)));
      // Console.WriteLine("------------------------------------");
      // Console.WriteLine("------------------------------------");
      // Console.WriteLine("Mano Jugador " + string.Join( ",", this.players[turn].hand.Select(x => x.Title)));
      // Console.WriteLine("------------------------------------");
    }

    // decide which player goes first
    public void decide_who_goes_first()
    {
      // check the higher superstar value
      int player1_value = int.Parse(this.players[0].superstar.superstar_value);
      int player2_value = int.Parse(this.players[1].superstar.superstar_value);
      if (player1_value > player2_value)
      {
        Console.WriteLine(this.players[0].superstar.format_name + " tiene mayor superstar value que " + this.players[1].superstar.format_name + ", por lo tanto " + this.players[0].superstar.format_name + " va primero");
        this.turn = 0;
      }
      else if (player2_value > player1_value)
      {
        Console.WriteLine(this.players[1].superstar.format_name + " tiene mayor superstar value que " + this.players[0].superstar.format_name + ", por lo tanto " + this.players[1].superstar.format_name + " va primero");
        this.turn = 1;
      }
      else
      {
        Console.WriteLine("Ambas superestrellas tienen el mismo superstar value, se decide por lanzamiento de moneda el jugador que va primero");
        // random number between 0 and 1
        Random random = new Random();
        this.turn = random.Next(0, 2);
      }
    }

    // show my cards or my opponent cards
    public void show_cards()
    {
      Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " Que cartas quieres ver?\n    1. Mi mano\n    2. Mi ringside\n    3. Mi ring area<\n    4. El ringside de mi oponente\n    5. El ring area de mi oponente\n   6. Volver a menu de acciones");
      Console.WriteLine("\nEscribe el numero de la opcion que quieras: ");
      string option = Console.ReadLine();
      if (option == "1")
      {
        Console.WriteLine("\nTu mano es: \n");
        int i = 0;
        foreach (Card card in this.players[this.turn].hand)
        {
            Console.WriteLine("\n----------Card #" + i + "----------");
            Console.WriteLine("Title: " + card.Title);
            Console.WriteLine("Stats: " + "[" + card.Fortitude + "F" + "/" + card.Damage + "D" + "/" + card.StunValue + "SV" + "]");
            Console.WriteLine("Types: " + string.Join( ",", card.Types));
            Console.WriteLine("Subtypes: " + string.Join( ",", card.Subtypes));
            Console.WriteLine("Effect: " + card.CardEffect);

            i++;
        }
        Console.WriteLine("\n");
        show_cards();
      }
      else if (option == "2")
      {
        int i = 0;
        Console.WriteLine("\nTu ringside es: \n");
        foreach (Card card in this.players[this.turn].ringside)
        {
          Console.WriteLine("\n----------Card #" + i + "----------");
          Console.WriteLine("Title: " + card.Title);
          Console.WriteLine("Stats: " + "[" + card.Fortitude + "F" + "/" + card.Damage + "D" + "/" + card.StunValue + "SV" + "]");
          Console.WriteLine("Types: " + string.Join( ",", card.Types));
          Console.WriteLine("Subtypes: " + string.Join( ",", card.Subtypes));
          Console.WriteLine("Effect: " + card.CardEffect);
          i++;
        }
        Console.WriteLine("\n");
        show_cards();
      }
      else if (option == "3")
      {
        int i = 0;
        Console.WriteLine("\nTu ring area es: \n");
        foreach (Card card in this.players[this.turn].ring_area)
        {
          Console.WriteLine("\n----------Card #" + i + "----------");
          Console.WriteLine("Title: " + card.Title);
          Console.WriteLine("Stats: " + "[" + card.Fortitude + "F" + "/" + card.Damage + "D" + "/" + card.StunValue + "SV" + "]");
          Console.WriteLine("Types: " + string.Join( ",", card.Types));
          Console.WriteLine("Subtypes: " + string.Join( ",", card.Subtypes));
          Console.WriteLine("Effect: " + card.CardEffect);
          i++;
        }
        Console.WriteLine("\n");
        show_cards();
      }
      else if (option == "4")
      {
        int i = 0;
        Console.WriteLine("\nEl ringside de tu oponente es: \n");
        foreach (Card card in this.players[opponent()].ringside)
        {
          Console.WriteLine("\n----------Card #" + i + "----------");
          Console.WriteLine("Title: " + card.Title);
          Console.WriteLine("Stats: " + "[" + card.Fortitude + "F" + "/" + card.Damage + "D" + "/" + card.StunValue + "SV" + "]");
          Console.WriteLine("Types: " + string.Join( ",", card.Types));
          Console.WriteLine("Subtypes: " + string.Join( ",", card.Subtypes));
          Console.WriteLine("Effect: " + card.CardEffect);
          i++;
        }
        Console.WriteLine("\n");
        show_cards();
      }
      else if (option == "5")
      {
        int i = 0;
        Console.WriteLine("\nEl ring area de tu oponente es: \n");
        foreach (Card card in this.players[opponent()].ring_area)
        {
          Console.WriteLine("\n----------Card #" + i + "----------");
          Console.WriteLine("Title: " + card.Title);
          Console.WriteLine("Stats: " + "[" + card.Fortitude + "F" + "/" + card.Damage + "D" + "/" + card.StunValue + "SV" + "]");
          Console.WriteLine("Types: " + string.Join( ",", card.Types));
          Console.WriteLine("Subtypes: " + string.Join( ",", card.Subtypes));
          Console.WriteLine("Effect: " + card.CardEffect);
          i++;
        }
        Console.WriteLine("\n");
        show_cards();
      }
      else if (option == "6")
      {
        // volvemos a menu de acciones
      }
      else
      {
        Console.WriteLine("\nOpcion invalida, intenta de nuevo\n");
        show_cards();
      }
    }

    // play cards
    public void play_cards()
    {
      Dictionary<int, int> selected_cards_dict = new Dictionary<int, int>();
      int i = 0;
      int seleccion = 0;
      Console.WriteLine("\nEstas son las cartas que puedes jugar: \n");
      // actualizar fortitude rating jugador
      this.players[this.turn].update_fortitude_rating();

      foreach (Card card in this.players[this.turn].hand)
      {
        if (int.Parse(card.Fortitude) <= this.players[this.turn].fortitude_rating && (card.Types.Contains("Action") || card.Types.Contains("Maneuver")))
        {
          if (card.Types.Contains("Action"))
          {
            Console.WriteLine("Jugar esta carta como [ACTION]");
          }
          else if (card.Types.Contains("Maneuver"))
          {
            Console.WriteLine("Jugar esta carta como un [MANEUVER]");
          }
          Console.WriteLine("\n----------Card #" + seleccion + "----------");
          Console.WriteLine("Title: " + card.Title);
          Console.WriteLine("Stats: " + "[" + card.Fortitude + "F" + "/" + card.Damage + "D" + "/" + card.StunValue + "SV" + "]");
          Console.WriteLine("Types: " + string.Join( ",", card.Types));
          Console.WriteLine("Subtypes: " + string.Join( ",", card.Subtypes));
          Console.WriteLine("Effect: " + card.CardEffect);
          selected_cards_dict.Add(seleccion, i);
          seleccion++;
        }
        i++;
      }
      if (seleccion == 0)
      {
        Console.WriteLine("\nNo tienes cartas que puedas jugar, presiona 0 para volver atras\n");
      }
      else{
        Console.WriteLine("\nIngresa un numero entre 0 y " + (seleccion - 1).ToString() + " para elegir la carta a jugar, en caso contrario ingresa " + seleccion.ToString() + " para volver atras:");
      }
      
      int option = int.Parse(Console.ReadLine());
      Console.WriteLine("\n");
      if (option >= 0 && option < seleccion)
      {
        // seleccionamos la carta a jugar
        Console.WriteLine("Has seleccionado la carta: " + this.players[this.turn].hand[selected_cards_dict[option]].Title);
        this.players[this.turn].play_from_hand = true;
        this.players[this.turn].hand[selected_cards_dict[option]].play_card(this.players[this.turn], this.players[opponent()]);
        // si la revirtieron y termino turno
        this.players[this.turn].play_from_hand = false;
      }
      else if (option == seleccion)
      {
        // volvemos a menu de acciones
      }
      else
      {
        Console.WriteLine("\nOpcion invalida, intenta de nuevo\n");
        play_cards();
      }
    }

    // before draw segment
    public void before_draw_segment()
    {
      // if superstar is TheRock
      if (this.players[this.turn].superstar.format_name == "TheRock")
      {
        // Si tiene cartas en el RingSide
        if (this.players[this.turn].ringside.Count > 0)
        {
          Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " puede usar su superstar hability antes de robar una carta");
          Console.WriteLine("Quieres usar tu superstar hability?\n    1. Si\n   2. No");
          Console.WriteLine("Escribe el numero de la opcion que quieras: ");
          string option = Console.ReadLine();
          if (option == "1")
          {
            this.players[this.turn].superstar.use_hability(this.players[this.turn], this.players[opponent()]);
            this.players[this.turn].superstar.hability_used = true;
          }
          else if (option == "2")
          {
            Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " no usa su superstar hability");
          }
          else
          {
            Console.WriteLine("\nOpcion invalida");
            before_draw_segment();
          }
        }
        // si el Ringside esta vacio
        else
        {
          Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " no puede usar su superstar hability porque su Ringside esta vacio");
        }
      }
      // else if superstar is Kane
      else if (this.players[this.turn].superstar.format_name == "Kane")
      {
        Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " usa su superstar hability antes de robar una carta");
        this.players[this.turn].superstar.use_hability(this.players[this.turn], this.players[opponent()]);
        this.players[this.turn].superstar.hability_used = true;
      }
    }

    // draw segment
    public void draw_segment()
    {
      Console.WriteLine("\n\n-----------------------------------");
      Console.WriteLine("Turno de " + this.players[this.turn].superstar.format_name);
      Console.WriteLine("-----------------------------------");
      if (this.players[this.turn].superstar.before_draw_segment)
      {
        before_draw_segment();
      }
      // robamos dos cartas si es Mankind
      if (this.players[this.turn].superstar.format_name == "Mankind")
      {
        Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " roba dos cartas");
        this.players[this.turn].superstar.use_hability(this.players[this.turn], this.players[opponent()]);
        this.players[this.turn].superstar.hability_used = true;
      }
      // Para todos los otros superstars robamos una carta
      else
      {
        Console.WriteLine("\n" + this.players[this.turn].superstar.format_name + " roba una carta");
        this.players[this.turn].hand.Add(this.players[this.turn].arsenal[0]);
        this.players[this.turn].arsenal.RemoveAt(0);
      }
      // mostramos el menu de decision del jugador
      decission_menu();
    }

    // menu decision
    public void decission_menu()
    {
      // chequeamos si hay un ganador
      check_winner();
      
      // mostramos el menu de decision
      this.players[0].update_fortitude_rating();
      this.players[1].update_fortitude_rating();
      Console.WriteLine("\n-----------------------------------");
      Console.WriteLine("Se enfrentan: " + this.players[0].superstar.format_name + " vs " + this.players[1].superstar.format_name);
      Console.WriteLine(this.players[0].superstar.format_name + " tiene " + this.players[0].fortitude_rating + "F, " + this.players[0].hand.Count + " cartas en su mano y le quedan " + this.players[0].arsenal.Count + " cartas en su arsenal");
      Console.WriteLine(this.players[1].superstar.format_name + " tiene " + this.players[1].fortitude_rating + "F, " + this.players[1].hand.Count + " cartas en su mano y le quedan " + this.players[1].arsenal.Count + " cartas en su arsenal");
      Console.WriteLine("-----------------------------------\n");

      Console.WriteLine(this.players[this.turn].superstar.format_name + " Que quieres hacer?\n    1. Usar mi super habilidad\n    2. Ver mis cartas o las cartas de mi oponente\n    3. Jugar una carta\n    4. Terminar mi turno");
      Console.WriteLine("Escribe el numero de la opcion que quieras: ");
      string option = Console.ReadLine();
      if (option == "1")
      {
        // si son los habilities que se usan antes de robar una carta
        if (this.players[this.turn].superstar.before_draw_segment)
        {
          Console.WriteLine("\nOpcion invalida " + this.players[this.turn].superstar.format_name + " solo puede usar su superstar hability antes de robar una carta");
          decission_menu();
        }
        // si son los habilities que se usan mientras se roba una carta
        else if (this.players[this.turn].superstar.format_name == "Mankind")
        {
          Console.WriteLine("\nOpcion invalida " + this.players[this.turn].superstar.format_name + " solo puede usar su superstar hability antes de robar una carta");
          decission_menu();
        }
        // si se usa durante el turno y aun no se usa
        else
        {
          if (!this.players[this.turn].superstar.hability_used)
          {
            this.players[this.turn].superstar.hability_used = true;
            this.players[this.turn].superstar.use_hability(this.players[this.turn], this.players[opponent()]);
            decission_menu();
          }
          else
          {
            Console.WriteLine("\nOpcion invalida " + this.players[this.turn].superstar.format_name + " ya uso su superstar hability");
            decission_menu();
          }
        }
      }
      else if (option == "2")
      {
        // show cards
        show_cards();
        decission_menu();
      }
      else if (option == "3")
      {
        // play card
        play_cards();
        // si la carta fue revertida y se perdio turno
        if (this.players[this.turn].perdio_turno)
        {
          this.players[this.turn].superstar.hability_used = false;
          this.players[this.turn].perdio_turno = false;
          advance_turn();
        }
        else
        {
          decission_menu();
        }
      }
      else if (option == "4")
      {
        this.players[this.turn].superstar.hability_used = false;
        advance_turn();
      }
      else
      {
        Console.WriteLine("\nOpcion invalida, intenta de nuevo");
        decission_menu();
      }
    }

    // play game
    public void play_game()
    {
      // creamos la lista de jugadores vacia
      this.players = new List<Player>();
      // definimos el round 0
      this.round = 0;
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
          // partida
          if (this.round == 0)
          {
            create_deck(this.turn);
            draw_starting_hand(this.turn);
            advance_turn(); 
            create_deck(this.turn);
            draw_starting_hand(this.turn);
            advance_turn();
            Console.WriteLine("\n-----------------------------------");
            Console.WriteLine("Se enfrentan: " + this.players[0].superstar.format_name + " vs " + this.players[1].superstar.format_name);
            Console.WriteLine("Inicialmente " + this.players[0].superstar.format_name + " tiene " + this.players[0].fortitude_rating + "F, " + this.players[0].hand.Count + " cartas en su mano y le quedan " + this.players[0].arsenal.Count + " cartas en su arsenal");
            Console.WriteLine("Inicialmente " + this.players[1].superstar.format_name + " tiene " + this.players[1].fortitude_rating + "F, " + this.players[1].hand.Count + " cartas en su mano y le quedan " + this.players[1].arsenal.Count + " cartas en su arsenal");
            Console.WriteLine("-----------------------------------\n");
            decide_who_goes_first();
          }
          else if (this.round > 0) {
            // turno
            draw_segment();
          }
          this.round++;
        }
      }

      else
      {
        Environment.Exit(0);
      }
      
    }


  } 



}