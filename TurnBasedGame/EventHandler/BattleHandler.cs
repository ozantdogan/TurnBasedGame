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

        public void StartBattle(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            Console.WriteLine("Battle started!");
            var battleResult = 0;
            while (playerUnits.Any(unit => unit.IsAlive) && mobUnits.Any(unit => unit.IsAlive))
            {
                var units = ProcessTurns(playerUnits, mobUnits);
                foreach(var unit in units.Where(p => p.IsAlive)) {
                    while (true)
                    {
                        ShowStatus(playerUnits, mobUnits);
                        bool actionResult;
                        if(unit.UnitType == EnumUnitType.Player)
                        {
                            actionResult = PerformTurn(unit, mobUnits);
                        }
                        else
                        {
                            actionResult = PerformTurn(unit, playerUnits.Where(u => u.IsAlive).ToList());
                        }
                        if (actionResult)
                        {
                            Thread.Sleep(1500);
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    battleResult = CheckAlives(playerUnits, mobUnits);
                    if (battleResult != 0)
                        break;
                }
                PostTurn(units);
            }

            Console.Clear();
            ShowStatus(playerUnits, mobUnits);
            Console.WriteLine("Battle ended.");
            if (battleResult == 1)
                Console.WriteLine("Player won!");
            else if(battleResult == 2)
                Console.WriteLine("Mobs won!");
        }

        private List<Unit> ProcessTurns(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            var allUnits = playerUnits.Concat(mobUnits).Where(u => u.IsAlive).ToList();
            var groupedUnits = allUnits.GroupBy(u => u.TurnPriority).OrderByDescending(g => g.Key);
            var random = new Random();
            var shuffledUnits = new List<Unit>();

            foreach (var group in groupedUnits)
            {
                var units = group.ToList();
                units = units.OrderBy(u => random.Next()).ToList();
                shuffledUnits.AddRange(units);
            }

            return shuffledUnits;
        }

        private int CheckAlives (List <Unit> playerUnits, List<Unit> mobUnits)
        {
            if(!mobUnits.Any(unit => unit.IsAlive))
            {
                return 1;
            }

            if(!playerUnits.Any(unit => unit.IsAlive))
            {
                return 2;
            }

            return 0;
        }

        private bool PerformTurn(Unit actor, List<Unit> targets)
        {
            Console.WriteLine($"{actor.Name}'s turn!");

            int skillChoice; 
            Unit target;
            if (actor.UnitType == EnumUnitType.Player)
            {
                Console.WriteLine("Choose a target");
                int targetChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                if (targetChoice >= 0 && targetChoice < targets.Count && targets[targetChoice].IsAlive)
                {
                    target = targets[targetChoice];
                    for (int i = 0; i < actor.Skills.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {actor.Skills[i].Name}  (MP: {actor.Skills[i].ManaCost})");
                    }

                    Console.Write("Choose an action: ");
                    skillChoice = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (skillChoice < 0 || skillChoice >= actor.Skills.Count)
                    {
                        Console.WriteLine("Invalid choice!");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid target choice!");
                    return false;
                }
            }
            else // mob
            {
                var targetIndex = _random.Next(targets.Count);
                target = targets[targetIndex];
                skillChoice = _random.Next(actor.Skills.Count);
            }

            var actionCompleted = actor.Skills[skillChoice].Execute(actor, target);
            if (actionCompleted)
                return true;

            return false;
        }

        private void PostTurn(List<Unit> units)
        {
            foreach(var unit in units)
                unit.MP = Math.Min(unit.MP + 2, unit.MaxMP);
        }

        private void ShowStatus(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            //https://spectreconsole.net/
            Console.Clear();

            var playerTable = new Table();
            playerTable.Border = TableBorder.Simple;
            playerTable.AddColumn(" ").LeftAligned();
            foreach (Unit unit in playerUnits)
            {
                playerTable.AddColumn(unit.Name ?? " ").LeftAligned();
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
                mobTable.AddColumn($"[red]{unit.Name}[/]").Centered();
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