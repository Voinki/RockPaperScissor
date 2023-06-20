
namespace Rock_Paper_Scissors
{
    internal class RPS
    {
        static void Main(string[] args)
        {
            Console.Write("Please select [r]ock , [p]aper or [s]cissors : ");
            string playerInput;
            string yesOrNoInput;
            bool continuePlaying = true;
            bool wrongInput = false;
            int playerScore = 0;
            int computerScore = 0;
            int draws = 0;

            while (continuePlaying)
            {
                if (wrongInput)
                {
                    Console.WriteLine("Invalid input , please try again.");
                    Console.WriteLine("Would you like to play again ? [yes/no] ");
                    yesOrNoInput = Console.ReadLine();
                    switch (yesOrNoInput)
                    {
                        case "yes":
                            Console.Write("Please select [r]ock , [p]aper or [s]cissors : ");
                            wrongInput = false;
                            continue;
                        case "no":
                            continuePlaying = false;
                            Console.WriteLine("Thanks for playing!");
                            return;
                        default:
                            wrongInput = true;
                            continue;
                    }
                }

                Random opponentRandom = new Random();
                int opponentRandomNumber = opponentRandom.Next(1, 4);
                string computerMove = ComputerRandomNum(opponentRandomNumber);
                playerInput = Console.ReadLine();

                if (CheckIfPlayerWins(playerInput, computerMove))
                {
                    Console.WriteLine($"Your opponent chose : {computerMove}");
                    Console.WriteLine("You win!");
                    Console.WriteLine("Would you like to play again ? [yes/no] ");
                    playerScore++;
                    yesOrNoInput = Console.ReadLine();
                    switch (yesOrNoInput)
                    {
                        case "yes":
                            Console.Write("Please select [r]ock , [p]aper or [s]cissors : ");
                            continue;

                        case "no":
                            continuePlaying = false;
                            Console.WriteLine("Thanks for playing!");
                            break;

                        default:
                            wrongInput = true;
                            break;
                    }
                }

                else if (CheckIfComputerWins(playerInput, computerMove))
                {
                    Console.WriteLine($"Your opponent chose : {computerMove}");
                    Console.WriteLine("You lose!");
                    Console.WriteLine("Would you like to play again ? [yes/no]");
                    computerScore++;
                    yesOrNoInput = Console.ReadLine();

                    switch (yesOrNoInput)
                    {
                        case "yes":
                            Console.Write("Please select [r]ock , [p]aper or [s]cissors : ");
                            continue;

                        case "no":
                            continuePlaying = false;
                            Console.WriteLine("Thanks for playing!");
                            break;

                        default:
                            wrongInput = true;
                            break;
                    }
                }

                else if (CheckForDraw(playerInput, computerMove))
                {
                    Console.WriteLine($"Your opponent chose : {computerMove}");
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("Would you like to play again ? [yes/no]");
                    draws++;
                    yesOrNoInput = Console.ReadLine();

                    switch (yesOrNoInput)
                    {
                        case "yes":
                            Console.Write("Please select [r]ock , [p]aper or [s]cissors : ");
                            continue;

                        case "no":
                            continuePlaying = false;
                            Console.WriteLine("Thanks for playing!");
                            break;

                        default:
                            wrongInput = true;
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Invalid input , please try again.");
                    Console.Write("Please select [r]ock , [p]aper or [s]cissors : ");
                    continue;
                }
            }

            if (playerScore > computerScore)
            {
                Console.WriteLine($"Congratulations!You win with a total score of {playerScore} to {computerScore}");
                Console.WriteLine($"You had {draws} draws.");
            }

            else if (computerScore > playerScore)
            {
                Console.WriteLine($"You lose with a total score of {computerScore} to {playerScore}");
                Console.WriteLine($"You had {draws} draws.");
                Console.WriteLine("Better luck next time!");
                //TODO: maybe remove "Thanks for playing!" from the switch cases and add it here at the end
            }

            else
            {
                Console.WriteLine($"It's a draw!You both had {computerScore} points.");
                Console.WriteLine($"You had {draws} draws.");
            }
        }
        static string ComputerRandomNum(int numberOpp)
        {
            if (numberOpp == 1)
            {
                return "rock";
            }
            else if (numberOpp == 2)
            {
                return "paper";
            }
            else
            {
                return "scissors";
            }
        }
        static bool CheckIfPlayerWins(string? playerInput, string computerMove)
        {
            if ((playerInput == "r" || playerInput == "R" && computerMove == "scissors") ||
                    (playerInput == "p" || playerInput == "P" && computerMove == "rock") ||
                    (playerInput == "s" || playerInput == "S" && computerMove == "paper"))
            {
                return true;
            }
            return false;
        }
        static bool CheckIfComputerWins(string? playerInput, string computerMove)
        {
            if ((playerInput == "r" || playerInput == "R" && computerMove == "paper") ||
                            (playerInput == "p" || playerInput == "P" && computerMove == "scissors") ||
                            (playerInput == "s" || playerInput == "S" && computerMove == "rock"))
            {
                return true;
            }
            return false;
        }
        static bool CheckForDraw(string? playerInput, string computerMove)
        {
            if ((playerInput == "r" || playerInput == "R" && computerMove == "rock") ||
                            (playerInput == "p" || playerInput == "P" && computerMove == "paper") ||
                            (playerInput == "s" || playerInput == "S" && computerMove == "scissors"))
            {
                return true;
            }
            return false;
        }

    }
}
