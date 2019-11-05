using System;
using System.IO;
using System.Runtime.Serialization;

namespace Spacebound
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SPACEBOUND");
            Game spacebound = new Game();
            spacebound.GameLoop();
        }

        public class Game
        {
            private int level;
            private string retry;
            private string playGame;
            private string playerName;

            public Game()
            {

            }

            public string GetUserInput()
            {
                return Console.ReadLine();
            }

            public void GameLoop()
            {
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Would you like to start (Type 'yes' or 'no'): ");
                    playGame = GetUserInput().ToLower();

                    try
                    {
                        switch (playGame)
                        {
                            case "yes":
                                    RunGame();
                                    break;
                            case "no":
                                Console.WriteLine("Thank you for playing.");
                                break;
                            default:
                                throw new InvalidInputException("Your input was invalid. Please type 'yes' or 'no' only.");
                        }
                    }

                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message + " Source file: " + ex.Source);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            public String GetPlayerName()
            {
                playerName = GetUserInput();
                return playerName;
            }

            public void RunGame()
            {
                Console.WriteLine("What is your name? ");
                GetPlayerName();
                Console.WriteLine("Hi " + playerName + ", welcome to SpaceBound.");
            }

        }
    }

    [Serializable]
    internal class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message) : base(message)
        {
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
