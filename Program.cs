using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> roster = new List<Pokemon>();

            //Firemoves created and added to the list
            List<Move> charMoves = new List<Move>();
            Move ember = new Move("Ember", MoveType.Fire, 40,true);
            Move fireBlast = new Move("Fire Blast", MoveType.Fire, 110,true);
            charMoves.Add(ember);
            charMoves.Add(fireBlast);

            //Water moves created and added to the list
            List<Move> squrtMoves = new List<Move>();
            Move bubble = new Move("Bubble", MoveType.Water,40,true);
            Move bite = new Move("Bite", MoveType.Normal, 60,false);
            squrtMoves.Add(bubble);
            squrtMoves.Add(bite);
            
            //Water moves created and added to the list
            List<Move> bulbMoves = new List<Move>();
            Move cut = new Move("Cut", MoveType.Normal,50,false);
            Move megaDrain = new Move("Mega Drain", MoveType.Grass,40,true);
            Move razorLeaf = new Move("Razor Leaf", MoveType.Grass,55,false);
            bulbMoves.Add(cut);
            bulbMoves.Add(megaDrain);
            bulbMoves.Add(razorLeaf);

            // INITIALIZE YOUR THREE POKEMONS HERE
            Pokemon charmander = new Pokemon("Charmander",3,52,43,50,50,39,Elements.Fire,charMoves);
            Pokemon squirtle = new Pokemon("Squirtle",2,48,65,50,50,44,Elements.Water,squrtMoves);
            Pokemon bulbasaur = new Pokemon("Bulbasaur",3,49,49,65,65,45,Elements.Grass,bulbMoves);

            //Adding the pokemons to the roster
            roster.Add(charmander);
            roster.Add(squirtle);
            roster.Add(bulbasaur);

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlease enter a command");
                switch (Console.ReadLine().ToLower())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        foreach (Pokemon pokeName in roster)
                        {
                            Console.Write("You can choose: " );
                            Console.Write(pokeName.Name, SelectColor(pokeName));
                            Console.Write(" with " + pokeName.Hp + " left\n",Color.White);
                        }
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        int pokemonValid = 0;

                        bool inFight = true;

                        Pokemon player = null;
                        Pokemon enemy = null;
                        while (pokemonValid < 2)
                        {
                            Console.Write("Choose who should fight (First your own, then make space then enemy)\n");


                            //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                            string input = Console.ReadLine();
                            string[] inputs = input.ToLower().Split(' ');

                            //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!

                            //to avoid crash if only 1 is selected
                            if (inputs.Length >1) 
                            {                            
                                switch (inputs[0])
                                {
                                    case "charmander":
                                        player = charmander;
                                        pokemonValid++;
                                        break;
                                    case "squirtle":
                                        player = squirtle;
                                            pokemonValid++;
                                            break;
                                    case "bulbasaur":
                                        player = bulbasaur;
                                            pokemonValid++;
                                            break;
                                    case "quit":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                            Console.WriteLine("First pokemon is invalid");
                                        continue;
                                }
                                switch (inputs[1])
                                {
                                    case "charmander":
                                        enemy = charmander;
                                            pokemonValid++;
                                            break;
                                    case "squirtle":
                                        enemy = squirtle;
                                            pokemonValid++;
                                            break;
                                    case "bulbasaur":
                                        enemy = bulbasaur;
                                            pokemonValid++;
                                            break;
                                    case "quit":
                                        Environment.Exit(0);
                                        break;
                                    default:
                                            Console.WriteLine("Last pokemon is invalid");
                                            continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You need to choose more than 1 pokemon to fight");
                            }
                        }

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy && player.Hp >= 1 && enemy.Hp >= 1 && inFight)
                        {

                            Console.Write("\nA wild ");
                            Console.Write(enemy.Name, SelectColor(enemy));
                            Console.Write(" appears!\n");
                            Console.Write(player.Name, SelectColor(player));
                            Console.Write(" I choose you!\n\n");

                            

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0 && inFight)
                            {
                                //PRINT POSSIBLE MOVES
                                
                                foreach (Move moveValid in player.Moves)
                                {
                                    Console.Write("You can choose: ");
                                    Console.Write(moveValid.Name + "\n", SelectColorMove(moveValid));

                                }

                                Console.WriteLine("You can choose: Run");
                               

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                bool moveIsValid = false;
                                int move = -1;
                                

                                while (moveIsValid == false) 
                                {
                                    Console.Write("\nWhat move should we use? (format: [Attack])\n");
                                    string moveInput = Console.ReadLine();

                                    //Check if the move is valid
                                    if (moveInput.ToLower() == player.Moves[0].Name.ToLower())
                                    {
                                        //setting index of the move used
                                        move = 0;
                                        moveIsValid = true;
                                    }
                                    else if(moveInput.ToLower() == player.Moves[1].Name.ToLower())
                                    { 
                                        move = 1;
                                        moveIsValid = true;
                                    }
                                    else if (player.Moves == bulbMoves)
                                    {
                                        if (moveInput.ToLower() == player.Moves[2].Name.ToLower())
                                        {
                                            move = 2;
                                            moveIsValid = true;
                                        }
                                    }
                                    else if (moveInput.ToLower() == "run") 
                                    {
                                        Console.WriteLine("You ran away for the fight");
                                        inFight = false;
                                        goto endLoop;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Move is invalid");
                                    }
                                }

                                //Metode to finde effectiveness of attack on pokemon type
                                string effectiveness = "";
                                string FindTypeEffectiveness(Pokemon attacker,Pokemon defender, int attMove)
                                {
                                    
                                    switch (player.CalculateElementalEffects(1, defender.TypeOfPokemon, attacker.Moves[attMove].TypeOfMove))
                                    {
                                        case 1 / 2:
                                            return effectiveness = "not very effective";
                                            
                                        case 2:
                                            return effectiveness = "It's super effective!";
                                            
                                        case 1:
                                            return effectiveness = "effective";
                                            
                                        default:
                                            return "";
                                            
                                    }
                                }


                                //CALCULATE AND APPLY DAMAGE
                                int damage = -1;
                                damage = player.Attack(enemy, player.Moves[move].TypeOfMove,player.Moves[move].Power,player.Moves[move].IsSpecial);

                                //print the move and damage
                                Console.Write("\n" + player.Name, SelectColor(player));
                                Console.Write(" uses ");
                                Console.Write(player.Moves[move].Name, SelectColorMove(player.Moves[move]));
                                Console.Write(". ");
                                Console.Write(enemy.Name, SelectColor(enemy));
                                Console.Write(" loses " + damage + " HP " + "it was " + FindTypeEffectiveness(player,enemy,move) + "\n");
                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                    int enemyMove = -1;
                                    int enemyDamage = -1;
                                    enemyMove = rand.Next(0,enemy.Moves.Count());
                                    enemyDamage = enemy.Attack(player, enemy.Moves[enemyMove].TypeOfMove, enemy.Moves[enemyMove].Power, enemy.Moves[enemyMove].IsSpecial);

                                    //print the move and damage
                                    Console.Write(enemy.Name, SelectColor(enemy));
                                    Console.Write(" uses ");
                                    Console.Write(enemy.Moves[enemyMove].Name, SelectColorMove(enemy.Moves[enemyMove]));
                                    Console.Write(". ");
                                    Console.Write(player.Name, SelectColor(player));
                                    Console.Write(" loses " + enemyDamage + " HP " + "it was " + FindTypeEffectiveness(enemy,player,enemyMove) + "\n\n");
                                    Console.Write(player.Name, SelectColor(player));
                                    Console.Write(" got " + player.Hp + " hp left" + " ");
                                    Console.Write(enemy.Name, SelectColor(enemy));
                                    Console.Write(" got " + enemy.Hp + " hp left\n\n");
                                }
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.Write(enemy.Name,SelectColor(enemy));
                                Console.Write(" faints, you won!\n\n");
                            }
                            else
                            {
                                Console.Write(player.Name, SelectColor(player));
                                Console.Write(" faints, you lost...\n\n");
                            }
                        }
                        if (enemy != null && player != null)
                        {
                            if (player.Hp <= 0 || enemy.Hp <= 0)
                            {
                                Console.WriteLine("One of the choosen pokemons are fainted, heal before next battle");
                                if (player.Hp <= 0)
                                {
                                    Console.Write(player.Name, SelectColor(player));
                                    Console.Write(" is fainted\n");
                                }
                                else
                                {
                                    Console.Write(enemy.Name, SelectColor(enemy));
                                    Console.Write(" is fainted\n");
                                }
                            }

                            //otherwise let's print an error message
                            else
                            {
                                Console.WriteLine("Invalid pokemons");
                            }
                        }

                        //goto so that you can run from a fight
                    endLoop:
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER
                        foreach(Pokemon poke in roster)
                        {
                            poke.Restore();
                        }
                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            Color SelectColor(Pokemon pokemon)
            {
                Color col = Color.Gray;
                switch (pokemon.TypeOfPokemon)
                {
                    case Elements.Fire:
                        col = Color.Red;
                        break;
                    case Elements.Water:
                        col = Color.Blue;
                        break;
                    case Elements.Grass:
                        col = Color.Green;
                        break;
                }
                return col;
            }
            Color SelectColorMove(Move move)
            {
                Color col = Color.Gray;
                switch (move.TypeOfMove)
                {
                    case (MoveType)Elements.Fire:
                        col = Color.Red;
                        break;
                    case (MoveType)Elements.Water:
                        col = Color.Blue;
                        break;
                    case (MoveType)Elements.Grass:
                        col = Color.Green;
                        break;
                }
                return col;
            }
        }
    }
}
