﻿using Spectre.Console;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main
{
    public class BattleHandler
    {
        private Random _random;
        private UIHandler _ui;

        public BattleHandler()
        {
            _random = new Random();
            _ui = new UIHandler();
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
                        _ui.ShowStatus(playerUnits, mobUnits);
                        bool actionResult;
                        if(unit.UnitType == EnumUnitType.Player)
                        {
                            actionResult = PerformTurn(unit, mobUnits, playerUnits);
                        }
                        else
                        {
                            actionResult = PerformTurn(unit, playerUnits.Where(u => u.IsAlive).ToList(), mobUnits.Where(u => u.IsAlive).ToList());
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
            _ui.ShowStatus(playerUnits, mobUnits);
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

        private bool PerformTurn(Unit actor, List<Unit> enemyTargets, List<Unit> friendlyTargets)
        {
            Console.WriteLine($"{actor.Name}'s turn!");

            int skillChoice;
            Unit target;
            if (actor.UnitType == EnumUnitType.Player)
            {
                // Display skill choices using Spectre.Console
                var skillChoices = actor.Skills.Select((skill, index) => $"{index + 1}. {skill.Name}  [cyan]({skill.ManaCost})[/]").ToArray();
                var skillChoiceIndex = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an action:")
                        .AddChoices(skillChoices)
                );

                // Convert the choice back to the index
                skillChoice = Array.IndexOf(skillChoices, skillChoiceIndex);

                if (skillChoice < 0 || skillChoice >= actor.Skills.Count)
                {
                    Console.WriteLine("Invalid choice!");
                    return false;
                }

                if (actor.Skills[skillChoice] is MoveSkill moveSkill)
                {
                    return moveSkill.Execute(actor, friendlyTargets);
                }

                // Display target choices using Spectre.Console
                var targetChoices = enemyTargets.Select((target, index) => $"{index + 1}. {target.Name}").ToArray();
                var targetChoiceIndex = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose a target:")
                        .AddChoices(targetChoices)
                );

                // Convert the choice back to the index
                int targetChoice = Array.IndexOf(targetChoices, targetChoiceIndex);

                if (targetChoice >= 0 && targetChoice < enemyTargets.Count && enemyTargets[targetChoice].IsAlive)
                {
                    target = enemyTargets[targetChoice];
                }
                else
                {
                    Console.WriteLine("Invalid target choice!");
                    return false;
                }
            }
            else // mob
            {
                skillChoice = _random.Next(actor.Skills.Count);
                var targetIndex = _random.Next(enemyTargets.Count);
                target = enemyTargets[targetIndex];
            }

            var actionCompleted = actor.Skills[skillChoice].Execute(actor, target);
            if (actionCompleted)
                return true;

            return false;
        }


        private void PostTurn(List<Unit> units)
        {
            foreach(var unit in units)
                unit.MP = Math.Min(unit.MP + 10, unit.MaxMP);
        }
    }
}