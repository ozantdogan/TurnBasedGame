using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
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

        public bool StartBattle(List<Unit> playerUnits, List<Unit> mobUnits, int level)
        {
            Console.WriteLine("Battle started!");
            var battleResult = 0;
            var round = 0;
            while (playerUnits.Any(unit => unit.IsAlive) && mobUnits.Any(unit => unit.IsAlive))
            {
                var units = ProcessTurns(playerUnits, mobUnits);
                round++;
                foreach (var unit in units.Where(p => p.IsAlive))
                {
                    while (true)
                    {
                        unit.ApplyBuffEffects();
                        unit.ApplyDoTEffects();

                        _ui.ShowStatus(playerUnits, mobUnits, level);
                        AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));

                        if(unit.HP <= 0)
                        {
                            Console.WriteLine($"{unit.Name} is dead");
                            break;
                        }

                        int actionResult;
                        if (unit.UnitType == EnumUnitType.Player)
                        {
                            actionResult = PerformTurn(unit, mobUnits, playerUnits);
                        }
                        else
                        {
                            actionResult = PerformTurn(unit, playerUnits.Where(u => u.IsAlive).ToList(), mobUnits.Where(u => u.IsAlive).ToList());
                        }

                        if (actionResult > 0)
                        {
                            Thread.Sleep(2500);
                            break;
                        }
                        Thread.Sleep(2500);
                    }
                    battleResult = CheckAlives(playerUnits, mobUnits);
                    if (battleResult != 0)
                        break;
                }
                PostTurn(units);
            }

            Console.Clear();
            _ui.ShowStatus(playerUnits, mobUnits, level);
            Console.WriteLine("Battle ended.");
            if (battleResult == 1)
            {
                Console.WriteLine("You won!");
                Thread.Sleep(1500);
            }
            else if (battleResult == 2)
            {
                Console.WriteLine("Game Over");
                Thread.Sleep(1500);
                return true;
            }

            return false;
        }

        private List<Unit> ProcessTurns(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            playerUnits.RemoveAll(u => !u.IsAlive);
            mobUnits.RemoveAll(u => !u.IsAlive);

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

        private int CheckAlives(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            if (!mobUnits.Any(unit => unit.IsAlive))
            {
                return 1;
            }

            if (!playerUnits.Any(unit => unit.IsAlive))
            {
                return 2;
            }

            return 0;
        }

        private int PerformTurn(Unit actor, List<Unit> enemyTargets, List<Unit> friendlyTargets)
        {
            Console.WriteLine($"{actor.Name}'s turn!");

            int skillChoice;
            Unit target;
            if (actor.UnitType == EnumUnitType.Player)
            {
                var skillChoices = actor.Skills.Select((skill, index) =>
                {
                    var color = skill.PrimaryType.GetColor();
                    string primaryTypeText = (skill.PrimaryType != EnumSkillType.None ? $"[{skill.PrimaryType.GetColor()}]({skill.PrimaryType.GetCode()})[/] " : string.Empty);
                    string secondaryTypeText = (skill.SecondaryType != EnumSkillType.None ? $"[{skill.SecondaryType.GetColor()}]({skill.SecondaryType.GetCode()})[/] " : string.Empty);
                    string manaCostText = (skill.ManaCost > 0 ? $"[cyan]({skill.ManaCost})[/]" : string.Empty);
                    return $"{index + 1}. {skill.Name} {primaryTypeText}{secondaryTypeText}{manaCostText}";
                }).ToArray(); 

                var skillChoiceIndex = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an action:")
                        .AddChoices(skillChoices)
                );

                skillChoice = Array.IndexOf(skillChoices, skillChoiceIndex);

                if (skillChoice < 0 || skillChoice >= actor.Skills.Count)
                {
                    Console.WriteLine("Invalid choice!");
                    return -1;
                }

                if (actor.Skills[skillChoice] is MoveSkill moveSkill)
                    return moveSkill.Execute(actor, friendlyTargets);

                if (actor.Skills[skillChoice] is RestSkill restSkill)
                    return restSkill.Execute(actor);

                if (actor.Skills[skillChoice].SelfTarget)
                    return actor.Skills[skillChoice].Execute(actor);

                if (actor.Skills[skillChoice].TargetIndexes != null && actor.Skills[skillChoice].TargetIndexes.Count() > 0)
                {
                    if (actor.Skills[skillChoice].PassiveFlag)
                        return actor.Skills[skillChoice].Execute(actor, friendlyTargets);
                    else
                        return actor.Skills[skillChoice].Execute(actor, enemyTargets);
                }

                if (actor.Skills[skillChoice].PassiveFlag)
                {
                    var targetChoices = friendlyTargets.Select((target, index) => $"{index + 1}. {target.Name}").ToArray();
                    var targetChoiceIndex = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Choose a target:")
                            .AddChoices(targetChoices)
                    );

                    // Convert the choice back to the index
                    int targetChoice = Array.IndexOf(targetChoices, targetChoiceIndex);

                    if (targetChoice >= 0 && targetChoice < friendlyTargets.Count && friendlyTargets[targetChoice].IsAlive)
                    {
                        target = friendlyTargets[targetChoice];
                    }
                    else
                    {
                        Console.WriteLine("Invalid target choice!");
                        return -1;
                    }
                }
                else
                {
                    var targetChoices = enemyTargets
                        .Select((target, index) =>
                        {
                            var resistanceLevel = EnumResistanceLevel.Neutral; 

                            EnumSkillType primaryType = actor.Skills[skillChoice].PrimaryType;
                            if (primaryType != EnumSkillType.None && ResistanceManager.ResistanceLevelSelectors.ContainsKey(primaryType))
                            {
                                var selector = ResistanceManager.ResistanceLevelSelectors[primaryType];
                                resistanceLevel = selector(target);
                            }

                            string resistanceText = resistanceLevel != EnumResistanceLevel.Neutral ? $"[gray] ({resistanceLevel})[/]" : "";
                            return $"{index + 1}. {target.Name}{resistanceText}";
                        })
                        .ToArray();

                    // Prompt the user to choose a target
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
                        return -1;
                    }
                }
            }
            else // mob
            {
                if (friendlyTargets.Count(t => t.IsAlive) > 1 && _random.Next(100) < 10)
                {
                    skillChoice = _random.Next(actor.Skills.Count);
                    if (actor.Skills[skillChoice] is MoveSkill moveSkill)
                    {
                        bool moveLeft = _random.Next(2) == 0;
                        int newIndex = moveLeft ? friendlyTargets.IndexOf(actor) - 1 : friendlyTargets.IndexOf(actor) + 1;
                        if (newIndex >= 0 && newIndex < friendlyTargets.Count)
                        {
                            return moveSkill.Execute(actor, friendlyTargets);
                        }
                    }
                }
                
                var nonMoveSkills = actor.Skills.Where(skill => !(skill is MoveSkill) && !(skill is RestSkill)).ToList();
                skillChoice = _random.Next(nonMoveSkills.Count) + 3;
                if (actor.Skills[skillChoice].TargetIndexes != null && actor.Skills[skillChoice].TargetIndexes.Count() > 0)
                {
                    if (actor.Skills[skillChoice].PassiveFlag)
                        return actor.Skills[skillChoice].Execute(actor, friendlyTargets);
                    else
                        return actor.Skills[skillChoice].Execute(actor, enemyTargets);
                }

                var targetIndex = _random.Next(enemyTargets.Count);
                target = enemyTargets[targetIndex];
            }

            var actionCompleted = actor.Skills[skillChoice].Execute(actor, target);
            if (actionCompleted != -1)
                return 1;

            return -1;
        }


        private void PostTurn(List<Unit> units)
        {
            foreach (var unit in units.Where(u => u.IsAlive))
                unit.MP = Math.Min(unit.MP + 5, unit.MaxMP);
        }
    }
}