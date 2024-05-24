using Spectre.Console;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers;

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
        public void StartBattle(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            Console.WriteLine("Battle started!");
            // Main battle loop
            while (playerUnits.Any(unit => unit.IsAlive) && mobUnits.Any(unit => unit.IsAlive))
            {
                // Assuming for simplicity that the first alive unit in each list participates in each turn
                Unit playerUnit = playerUnits.First(unit => unit.IsAlive);
                Unit mobUnit = mobUnits.First(unit => unit.IsAlive);

                ShowStatus(playerUnits, mobUnits);
                PerformTurn(playerUnit, mobUnit);

                Thread.Sleep(2000);
                Console.Clear();

                ShowStatus(playerUnits, mobUnits);
                PerformTurn(mobUnit, playerUnit);

                Thread.Sleep(2000);
                Console.Clear();

                PostTurn(playerUnit, mobUnit);
            }

            Console.Clear();
            Console.WriteLine("Battle ended.");
        }

        private void PostTurn(Unit playerUnit, Unit mobUnit)
        {
            playerUnit.MP = Math.Min(playerUnit.MP + 2, playerUnit.MaxMP);
        }

        private void PerformTurn(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name}'s turn!");
            while (true)
            {
                int choice;
                if (actor.UnitType == EnumUnitType.Player)
                {
                    // Display available actions
                    for (int i = 0; i < actor.Skills.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {actor.Skills[i].Name}  (MP: {actor.Skills[i].ManaCost})");
                    }

                    // Let the player choose an action
                    Console.Write("Choose an action: ");
                    choice = Convert.ToInt32(Console.ReadLine()) - 1;

                    // Ensure the choice is valid
                    if (choice < 0 || choice >= actor.Skills.Count)
                        Console.WriteLine("Invalid choice!");
                }
                else
                {
                    // Choose a random action for the monster
                    choice = _random.Next(actor.Skills.Count);
                }

                var actionCompleted = actor.Skills[choice].Execute(actor, target);
                if (actionCompleted)
                    break;
            }
        }

        private void ShowStatus(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            //https://spectreconsole.net/

            var playerTable = new Table();
            playerTable.Border = TableBorder.Simple;
            playerTable.AddColumn(" ").LeftAligned();
            foreach (Unit unit in playerUnits)
            {
                playerTable.AddColumn(unit.Code).LeftAligned();
            }

            var playerHpRow = new List<string> { "[seagreen2]HP[/]" };
            var playerMpRow = new List<string> { "[skyblue2]MP[/]" };
            foreach (Unit unit in playerUnits)
            {
                playerHpRow.Add(unit.HP.ToString());
                playerMpRow.Add(unit.MP.ToString()); // Assuming you have an Mp property
            }

            playerTable.AddRow(playerHpRow.ToArray());
            playerTable.AddRow(playerMpRow.ToArray());

            var mobTable = new Table();
            mobTable.Border = TableBorder.Simple;
            mobTable.AddColumn(" ").Centered();
            foreach (Unit unit in mobUnits)
            {
                mobTable.AddColumn($"[red]{unit.Code}[/]").Centered();
            }
            var mobHpRow = new List<string> { "[seagreen2]HP[/]" };
            foreach (Unit unit in mobUnits)
            {
                mobHpRow.Add(unit.HP.ToString());
            }
            mobTable.AddRow(mobHpRow.ToArray());

            AnsiConsole.Write(mobTable);
            AnsiConsole.Write(playerTable);

        }
    }
}