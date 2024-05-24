using Spectre.Console;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main
{
    public class BattleHandler
    {
        private Random _random;

        public BattleHandler()
        {
            _random = new Random();
        }

        // Method to start the battle
        public void StartBattle(Unit playerUnit, Unit mobUnit)
        {
            Console.WriteLine("Battle started!");

            // Main battle loop
            while (playerUnit.HP > 0 && mobUnit.HP > 0)
            {
                ShowStatus(playerUnit, mobUnit);
                PerformTurn(playerUnit, mobUnit);
                if (mobUnit.HP <= 0)
                {
                    Console.WriteLine("Monster defeated!");
                    break;
                }
                Thread.Sleep(2000);
                Console.Clear();

                ShowStatus(playerUnit, mobUnit);
                PerformMonsterTurn(mobUnit, playerUnit);
                if (playerUnit.HP <= 0)
                {
                    Console.WriteLine("Player defeated!");
                    break;
                }
                Thread.Sleep(2000);
                Console.Clear();
                PostTurn(playerUnit, mobUnit);
            }

            Console.Clear();
            ShowStatus(playerUnit, mobUnit);
            Console.WriteLine("Battle ended.");
        }

        private void PostTurn(Unit playerUnit, Unit mobUnit)
        {
            playerUnit.MP = Math.Min(playerUnit.MP + 2, playerUnit.MaxMP);
        }

        // Method to perform a turn
        private void PerformTurn(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name}'s turn!");

            // Display available actions
            for (int i = 0; i < actor.Skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actor.Skills[i].Name}");
            }

            while (true)
            {
                // Let the player choose an action
                Console.Write("Choose an action: ");
                int choice = Convert.ToInt32(Console.ReadLine()) - 1;

                // Ensure the choice is valid
                if (choice < 0 || choice >= actor.Skills.Count)
                    Console.WriteLine("Invalid choice!");
                else
                {
                    // Execute the chosen action
                    var actionCompleted = actor.Skills[choice].Execute(actor, target);
                    if (actionCompleted)
                        break;
                }
            }
        }

        private void PerformMonsterTurn(Unit mobUnit, Unit playerUnit)
        {
            Console.WriteLine($"{mobUnit.Name}'s turn!");

            // Choose a random action for the monster
            int randomActionIndex = _random.Next(mobUnit.Skills.Count);
            mobUnit.Skills[randomActionIndex].Execute(mobUnit, playerUnit);
        }

        private void ShowStatus(Unit playerUnit, Unit mobUnit)
        {
            //https://spectreconsole.net/

            //Console.WriteLine($"{playerUnit.Code}" + new string(' ', 9) + $"{mobUnit.Code}");
            //Console.WriteLine($"HP: {playerUnit.HP}" + new string(' ', 10-playerUnit.HP.ToString().Length) + $"HP: {mobUnit.HP}");
            //Console.WriteLine($"MP: {playerUnit.MP}" + new string(' ', 10 - playerUnit.MP.ToString().Length) + $" ");
            
            //var layout = new Layout("Root")
            //    .SplitColumns(
            //    new Layout("Left"),
            //    new Layout("Right")).Size(1);

            //layout["Left"].Update(new Panel(Align.Center(new Markup($"{playerUnit.Name}"),VerticalAlignment.Top)).Expand());
            //layout["Left"].Update(new Panel(Align.Center(new BarChart().Width(playerUnit.HP).AddItem("HP: ", playerUnit.HP, Color.Green), VerticalAlignment.Middle)).Expand());

            //AnsiConsole.Write(layout);

            var playerTable = new Table();
            playerTable.AddColumn(" ");
            playerTable.AddColumn(playerUnit.Code).LeftAligned();
            playerTable.AddRow("[bold][seagreen2]HP[/][/]", $"{playerUnit.HP}");
            playerTable.AddRow("[bold][skyblue2]MP[/][/]", $"{playerUnit.MP}");

            var mobTable = new Table();
            mobTable.AddColumn(" ");
            mobTable.AddColumn($"[red]{mobUnit.Code}[/]").Centered();
            mobTable.AddRow("[bold][seagreen2]HP[/][/]", $"{mobUnit.HP}");

            AnsiConsole.Write(mobTable);
            AnsiConsole.Write(playerTable);

        }
    }
}