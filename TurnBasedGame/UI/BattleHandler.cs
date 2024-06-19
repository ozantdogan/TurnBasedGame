using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.UI
{
    public class BattleHandler
    {
        private UIHandler _ui;

        public BattleHandler()
        {
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
                    _ui.ShowSkillInfo(unit, null);
                    AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));

                    int effectResult = 0;
                    if(unit.IsAlive)
                    {
                        effectResult = UnitManager.ApplyStatusEffects(unit);
                    }

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
                    _ui.ShowSkillInfo(unit, null);
                    AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));

                    while (true)
                    {
                        (int actionResult, List<Unit> updatedPlayerUnits, List<Unit> updatedMobUnits) = PerformTurn(unit, playerUnits, mobUnits);
                        playerUnits = updatedPlayerUnits;
                        mobUnits = updatedMobUnits;

                        if (actionResult > 0)
                        {
                            Thread.Sleep(LevelHandler.Pace);
                            break;
                        }
                        else if(actionResult != -2)
                            Thread.Sleep(LevelHandler.Pace);

                        _ui.ShowStatus(playerUnits, mobUnits, level);
                        AnsiConsole.MarkupLine($"[{unit.UnitType.GetColor()}]{unit.Name}[/]'s turn!");
                        _ui.ShowSkillInfo(unit, null);
                        AnsiConsole.Write(new Markup($"[gray] - {round} - [/]\n"));
                    }
                    battleResult = CheckAlives(playerUnits, mobUnits);
                    if (battleResult != 0)
                    {
                        SetPositions(playerUnits);
                        SetPositions(mobUnits);
                        break;
                    }
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

        private (int result, List<Unit> updatedPlayerUnits, List<Unit> updatedMobUnits) PerformTurn(Unit actor, List<Unit> playerTargets, List<Unit> mobTargets)
        {
            int skillChoice;
            BaseSkill selectedSkill;

            List<Unit> updatedPlayerUnits = playerTargets;
            List<Unit> updatedMobUnits = mobTargets;
            var result = 1;

            if (actor.UnitType != EnumUnitType.Player && actor.UnitType != EnumUnitType.Summon)
            {
                var mobLogic = new MobManager();
                (result, updatedPlayerUnits, updatedMobUnits) = mobLogic.ExecuteMobTurn(actor, playerTargets, mobTargets);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            var availableSkills = actor.Skills
                .Where(skill => skill.ValidUserPositions.Contains(actor.Position))
                .Where(skill => !(skill is MoveSkill) || !actor.HasMoved)
                .ToList();

            if (availableSkills.Count == 0)
            {
                Console.WriteLine("No available skills for this position.");
                return (-1, updatedPlayerUnits, updatedMobUnits);
            }

            var skillChoices = availableSkills.Select((skill, index) =>
            {
                var color = skill.PrimaryType.GetColor();
                string primaryTypeText = (skill.PrimaryType != EnumSkillType.None ? $"[{skill.PrimaryType.GetColor()}]({skill.PrimaryType.GetCode()})[/] " : string.Empty);
                string secondaryTypeText = (skill.SecondaryType != EnumSkillType.None ? $"[{skill.SecondaryType.GetColor()}]({skill.SecondaryType.GetCode()})[/] " : string.Empty);
                string manaCostText = (skill.ManaCost > 0 ? $"[cyan]({skill.ManaCost})[/] " : string.Empty);
                string healthCostText = (skill.HealthCost > 0 ? $"[deeppink2]({skill.HealthCost})[/] " : string.Empty);
                return $"{index + 1}. {skill.Name} {primaryTypeText}{secondaryTypeText}{manaCostText}{healthCostText}";
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
                return (-1, updatedPlayerUnits, updatedMobUnits);
            }

            selectedSkill = availableSkills[skillChoice];

            if (selectedSkill is MoveSkill moveSkill && !actor.HasMoved)
            {
                result = moveSkill.Execute(actor, targets: updatedPlayerUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            if (selectedSkill is RestSkill restSkill)
            {
                result = restSkill.Execute(actor);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            if (selectedSkill.SelfTarget)
            {
                result = selectedSkill.Execute(actor);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            if (selectedSkill is SummonSkill summonSkill)
            {
                result = summonSkill.Execute(actor, targets: updatedPlayerUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            List<Unit>? validTargets;
            if (selectedSkill.IsPassive)
            {
                validTargets = playerTargets
                    .Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position))
                    .OrderBy(target => target.Position)
                    .ToList();
            }
            else
            {
                validTargets = mobTargets
                    .Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position))
                    .OrderBy(target => target.Position)
                    .ToList();
            }

            if (validTargets.Count <= 0)
            {
                Logger.NoValidTargets();
                return (-1, updatedPlayerUnits, updatedMobUnits);
            }

            List<string> targetInfoChoices = validTargets
                .OrderBy(target => target.Position)
                .Select((target, index) =>
                {
                    var resistanceLevel = ResistanceManager.ResistanceLevelSelectors[selectedSkill.PrimaryType](target);
                    return $" {index + 1}.[{(target.IsAlive ? target.UnitType.GetColor() : "grey19")}] {target.Name}[/] {(target.UnitType == EnumUnitType.Player || resistanceLevel == EnumResistanceLevel.Neutral ? "" : $"[{resistanceLevel.GetColor()}]({resistanceLevel.GetCode()})[/]")}";
                })
                .ToList();

            var turnBackChoice = " 0. Back";
            var executionChoice = " 1. Use";

            string? targetInfo;
            // If the skill is AoE, add an execution choice
            if (selectedSkill.IsAoE)
            {
                var titleWithChoices = "Listed targets will be affected:\n" + string.Join("\n", targetInfoChoices);
                targetInfo = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title(titleWithChoices)
                        .AddChoices(executionChoice, turnBackChoice)
                );
            }
            else
            {
                targetInfoChoices.Add(turnBackChoice);
                targetInfo = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose a target:")
                        .AddChoices(targetInfoChoices)
                );
            }

            if (targetInfo == turnBackChoice)
            {
                return (-2, updatedPlayerUnits, updatedMobUnits);
            }
            else if (targetInfo == executionChoice) // For AoE
            {
                result = selectedSkill.Execute(actor, null, targets : validTargets);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }
            else
            {
                int targetChoice = targetInfoChoices.IndexOf(targetInfo);
                if(selectedSkill.IsPassive)
                    result = selectedSkill.Execute(actor, singleTarget: validTargets[targetChoice], playerTargets);
                else
                    result = selectedSkill.Execute(actor, singleTarget : validTargets[targetChoice], mobTargets);

                return (result, updatedPlayerUnits, updatedMobUnits);
            }
        }

        private void PostTurn(List<Unit> playerUnits, List<Unit> mobUnits)
        {
            var alivePlayerUnits = playerUnits.Where(u => u.IsAlive).OrderBy(p => p.Position).ToList();
            var aliveMobUnits = mobUnits.Where(u => u.IsAlive).OrderBy(p => p.Position).ToList();
            var allAliveUnits = alivePlayerUnits.Concat(aliveMobUnits).ToList();

            foreach (var unit in allAliveUnits)
            {
                unit.MP = Math.Min(unit.MP + 3, unit.MaxMP);
                unit.HasMoved = false;
            }

            UnitManager.SetPositions(alivePlayerUnits);
            UnitManager.SetPositions(aliveMobUnits);
        }

        private void SetPositions(List<Unit> units)
        {
            units = units.Where(u => u.IsAlive).OrderBy(p => p.Position).ToList();

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Position = i;
            }

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Position = i;
            }
        }
    }
}