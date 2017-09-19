using System;
using System.Collections.Generic;

namespace NumberGuessingGame
{
    public class Game
    {
        bool playing = true;
        int wins = 0;
        int losses = 0;
        public void Play()
        {
            int upperBound;
            int userGuess;
            int playCount = 0;
            int possibleTries = 10;
            int guesses = 0;


            Console.Clear();
            Console.WriteLine("Hello and welcome to the game!");
            Console.WriteLine("Please provide an upper bound");


            do
            {
                if (Int32.TryParse(Console.ReadLine(), out upperBound))
                {
                    playCount++;
                    Random randomGen = new Random();
                    int target = randomGen.Next(1, upperBound);
                    Console.WriteLine($"\nUpper Bound Set! Number chosen!\nYou have {possibleTries} guesses.\nReady, Set, Guess!\n");

                    while (possibleTries > 0)
                    {

                        if (Int32.TryParse(Console.ReadLine(), out userGuess))
                        {
                            if (userGuess > upperBound)
                            {
                                Console.WriteLine($"Um... did you forget what the limit is? You entered {upperBound} as the upper bound. Your guess must be less than or equal to that.");
                                Console.WriteLine("GuessAgain\n");
                            }
                            else if (userGuess == target)
                            {
                                Console.WriteLine("Correct! You win!\n");
                                wins++;
                                guesses++;
                                possibleTries--;
                                PlayAgain();

                            }
                            else if (userGuess > target)
                            {
                                Console.WriteLine($"Too high, you have {possibleTries} left. try again...\n");
                                guesses++;
                                possibleTries--;

                            }
                            else if (userGuess < target)
                            {
                                Console.WriteLine($"Too low, you have {possibleTries} left. try again...\n");
                                guesses++;
                                possibleTries--;
                            }
                        }
                    }
                    // at this point the user has run out of tries
                    losses++;
                    Console.WriteLine("Dang, you loose.");
                    PlayAgain();

                }
                else
                {
                    Console.WriteLine("Enter a number you dork");
                } // end of game logic
            } while (playing == true);

        }

        public void PlayAgain()
        {
            Console.WriteLine("Would you like to play again? (Y/N)");

            string userChoice = Console.ReadLine().ToUpper();
            if (userChoice == "Y")
            {
                Play();
            }
            else if (userChoice == "N")
            {
                playing = false;
                Console.WriteLine($"Sorry to see you go. Thanks for playing! you had {wins} win(s) and {losses} loss(es)");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Not a valid selection. Try again");
                PlayAgain();
            }
        }


    }//End of class

}