using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.UI
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
                    _ui.ShowStatus(playerUnits, mobUnits, level);
                    AnsiConsole.MarkupLine($"[{unit.UnitType.GetColor()}]{unit.Name}[/]'s turn!");
                    AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));

                    var effectResult = unit.ApplyStatusEffects();
                    battleResult = CheckAlives(playerUnits, mobUnits);

                    if (effectResult == 0)
                    {
                        Thread.Sleep(LevelHandler.Pace);
                        continue;
                    }

                    if (battleResult != 0)
                        break;

                    Thread.Sleep(LevelHandler.Pace);

                    _ui.ShowStatus(playerUnits, mobUnits, level);
                    AnsiConsole.MarkupLine($"[{unit.UnitType.GetColor()}]{unit.Name}[/]'s turn!");
                    AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));

                    while (true)
                    {
                        int actionResult = 1;
                        if (unit.UnitType == EnumUnitType.Player)
                        {
                            actionResult = PerformTurn(unit, mobUnits.Where(u => u.IsAlive).ToList(), playerUnits.Where(u => u.IsAlive).ToList());
                        }
                        else
                        {
                            actionResult = PerformTurn(unit, playerUnits.Where(u => u.IsAlive).ToList(), mobUnits.Where(u => u.IsAlive).ToList());
                        }

                        if (actionResult > 0)
                        {
                            Thread.Sleep(LevelHandler.Pace);
                            break;
                        }
                        Thread.Sleep(LevelHandler.Pace);

                        _ui.ShowStatus(playerUnits, mobUnits, level);
                        AnsiConsole.MarkupLine($"[{unit.UnitType.GetColor()}]{unit.Name}[/]'s turn!");
                        AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));

                    }
                    battleResult = CheckAlives(playerUnits, mobUnits);
                    if (battleResult != 0)
                        break;
                }
                PostTurn(playerUnits, mobUnits);
                battleResult = CheckAlives(playerUnits, mobUnits);
                if (battleResult != 0)
                    break;
            }

            Console.Clear();
            _ui.ShowStatus(playerUnits, mobUnits, level);
            Console.WriteLine("Battle ended.");
            if (battleResult == 1)
            {
                Console.WriteLine("You won!");
                Thread.Sleep(LevelHandler.Pace);
            }
            else if (battleResult == 2)
            {
                Console.WriteLine("Game Over");
                Thread.Sleep(LevelHandler.Pace);
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
            int skillChoice;
            Unit target;
            BaseSkill selectedSkill;

            if (actor.UnitType == EnumUnitType.Player)
            {
                var availableSkills = actor.Skills.
                    Where(skill => skill.ValidUserPositions.Contains(actor.Position))
                    .Where(skill => !(skill is MoveSkill) || !actor.HasMoved)
                    .ToList();

                if (availableSkills.Count == 0)
                {
                    Console.WriteLine("No available skills for this position.");
                    return -1;
                }

                var skillChoices = availableSkills.Select((skill, index) =>
                {
                    var color = skill.PrimaryType.GetColor();
                    string primaryTypeText = (skill.PrimaryType != EnumSkillType.None ? $"[{skill.PrimaryType.GetColor()}]({skill.PrimaryType.GetCode()})[/] " : string.Empty);
                    string secondaryTypeText = (skill.SecondaryType != EnumSkillType.None ? $"[{skill.SecondaryType.GetColor()}]({skill.SecondaryType.GetCode()})[/] " : string.Empty);
                    string manaCostText = (skill.ManaCost > 0 ? $"[cyan]({skill.ManaCost})[/]" : string.Empty);
                    return $"{index + 1}. {skill.Name} {primaryTypeText}{secondaryTypeText}{manaCostText}";
                }).ToArray();

                var skillChoiceText = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an action:")
                        .AddChoices(skillChoices)
                );

                skillChoice = Array.IndexOf(skillChoices, skillChoiceText);

                if (skillChoice < 0 || skillChoice >= availableSkills.Count)
                {
                    Console.WriteLine("Invalid choice!");
                    return -1;
                }

                selectedSkill = availableSkills[skillChoice];

                if (skillChoice < 0 || skillChoice >= actor.Skills.Count)
                {
                    Console.WriteLine("Invalid choice!");
                    return -1;
                }

                if (selectedSkill is MoveSkill moveSkill && !actor.HasMoved)
                    return moveSkill.Execute(actor, friendlyTargets);

                if (selectedSkill is RestSkill restSkill)
                    return restSkill.Execute(actor);

                if (selectedSkill.SelfTarget)
                    return selectedSkill.Execute(actor);

                if (selectedSkill.TargetIndexes != null && selectedSkill.TargetIndexes.Count() > 0 || selectedSkill.AreaSkill)
                {
                    if (selectedSkill.PassiveFlag)
                        return selectedSkill.Execute(actor, friendlyTargets);
                    else
                        return selectedSkill.Execute(actor, enemyTargets);
                }

                if (selectedSkill.PassiveFlag)
                {
                    var targetChoices = friendlyTargets
                        .OrderBy(target => target.Position)
                        .Select((target, index) => $"{index + 1}. {target.Name}")
                        .ToArray(); 
                    
                    var targetChoiceIndex = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Choose a target:")
                            .AddChoices(targetChoices)
                    );

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
                    var validTargets = enemyTargets.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position)).ToList();

                    if (validTargets.Count == 0)
                    {
                        Console.WriteLine("No valid targets available for this skill.");
                        return -1;
                    }

                    var targetChoices = validTargets
                        .OrderBy(target => target.Position)
                        .Select((target, index) =>
                        {
                            var resistanceLevel = ResistanceManager.ResistanceLevelSelectors[selectedSkill.PrimaryType](target);
                            return $"{index + 1}. {target.Name} {(resistanceLevel == EnumResistanceLevel.Neutral ? "" : "(" + resistanceLevel + ")")}";
                        })
                        .ToArray();
                        
                    var targetChoiceText = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Choose a target:")
                            .AddChoices(targetChoices)
                    );

                    var targetChoiceIndex = Array.IndexOf(targetChoices, targetChoiceText);
                    if (targetChoiceIndex < 0 || targetChoiceIndex >= validTargets.Count)
                    {
                        Console.WriteLine("Invalid target choice!");
                        return -1;
                    }

                    // Convert the choice back to the index
                    target = validTargets[targetChoiceIndex];
                    return selectedSkill.Execute(actor, target);
                }
            }
            else if (actor.UnitType == EnumUnitType.Dummy)// dummy
            {
                return new RestSkill().Execute(actor);
                //return new MoveSkill().Execute(actor, friendlyTargets);
            }
            else // Mob units
            {
                var mobLogic = new MobLogic();
                return mobLogic.ExecuteMobTurn(actor, enemyTargets, friendlyTargets);
            }

            var actionCompleted = selectedSkill.Execute(actor, target);
            if (actionCompleted != -1)
                return 1;

            return -1;
        }


        //todo positionların setlenmesi + ölenlerin kaldırılması
        private void PostTurn(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            var alivePlayerUnits = playerUnits.Where(u => u.IsAlive).OrderBy(p => p.Position).ToList();
            var aliveMobUnits = mobUnits.Where(u => u.IsAlive).OrderBy(p => p.Position).ToList();
            var allAliveUnits = alivePlayerUnits.Concat(aliveMobUnits).ToList();

            foreach (var unit in allAliveUnits)
            {
                unit.MP = Math.Min(unit.MP + 5, unit.MaxMP);
                unit.HasMoved = false;
            }

            for (int i = 0; i < alivePlayerUnits.Count; i++)
            {
                alivePlayerUnits[i].Position = i; 
            }

            for (int i = 0; i < aliveMobUnits.Count; i++)
            {
                aliveMobUnits[i].Position = i;
            }
        }
    }
}