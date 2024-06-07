﻿using Spectre.Console;
using System.Drawing;
using System.Text;
using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.UI
{
    public class UIHandler
    {
        public void ShowStatus(List<Unit> playerUnits, List<Unit> mobUnits, int level)
        {
            Console.Clear();

            AnsiConsole.Write(new Markup($"[lightpink4] == {level} == [/]").Centered());

            #region Players

            var playerTable = new Table().Border(TableBorder.Simple).LeftAligned();
            playerTable.AddColumn(" ");
            playerUnits = playerUnits.OrderByDescending(p => p.Position).ToList();
            // Add columns for each player unit, in reverse order
            foreach (var unit in playerUnits)
            {
                playerTable.AddColumn($"[{(unit.IsAlive ? unit.UnitType.GetColor() : "grey19")}]{unit.DisplayName ?? " "}[/]");
            }

            #region Player effects

            var playerEffectRow = new List<string> { " " };

            // Add player effects for each unit, in reverse order
            foreach(var unit in playerUnits)
            {
                var activeStatusEffects = new List<StatusEffect>();
                activeStatusEffects.AddRange(unit.StatusEffects);

                if (activeStatusEffects.Any()) // Check if the list is not empty
                {
                    var combinedEffects = string.Join(" ", activeStatusEffects.Select(effect =>
                        $"[{effect.EffectType.GetColor()}]{effect.EffectType.GetCode()}{(effect.Duration == 0 ? "" : $"({effect.Duration})")}[/]"));

                    playerEffectRow.Add(combinedEffects);
                }
                else
                {
                    playerEffectRow.Add(" ");
                }
            }

            playerTable.AddRow(playerEffectRow.ToArray());

            #endregion

            //var playerLevelRow = new List<string> { "[lightsteelblue1] Lv[/]" };
            //var playerHpRow = new List<string> { "[seagreen2] HP[/]" };
            //var playerMpRow = new List<string> { "[cyan] MP[/]" };

            var playerLevelRow = new List<string> { "" };
            var playerHpRow = new List<string> { "" };
            var playerMpRow = new List<string> { "" };

            foreach (var unit in playerUnits)
            {
                playerLevelRow.Add($"{unit.Level.CurrentLevel}");
                playerHpRow.Add($"[{GetHpColor(unit)}]{unit.HP}[/][grey35]/{unit.MaxHP}[/]");
                playerMpRow.Add($"[{GetMpColor(unit)}]{unit.MP}[/][grey35]/{unit.MaxMP}[/]"); 
            }

            playerTable.AddRow(playerLevelRow.ToArray());
            playerTable.AddRow(playerHpRow.ToArray());
            playerTable.AddRow(playerMpRow.ToArray());

            #endregion

            #region Mobs

            var mobTable = new Table().Border(TableBorder.Simple).RightAligned();
            mobTable.AddColumn(" ");
            mobUnits = mobUnits.OrderBy(p => p.Position).ToList();
            foreach (Unit unit in mobUnits)
            {
                mobTable.AddColumn($"[{(unit.IsAlive ? unit.UnitType.GetColor() : "grey19")}]{unit.DisplayName ?? " "}[/]");
            }

            #region Mob effects

            var mobEffectRow = new List<string> { " " };
            foreach (Unit unit in mobUnits)
            {
                var activeStatusEffects = new List<StatusEffect>();
                activeStatusEffects.AddRange(unit.StatusEffects);

                if (activeStatusEffects.Any()) // Check if the list is not empty
                {
                    var combinedEffects = string.Join(" ", activeStatusEffects.Select(effect =>
                        $"[{effect.EffectType.GetColor()}]{effect.EffectType.GetCode()}{(effect.Duration == 0 ? "" : $"({effect.Duration})")}[/]"));

                    mobEffectRow.Add(combinedEffects);
                }
                else
                {
                    mobEffectRow.Add(" ");
                }
            }
            mobTable.AddRow(mobEffectRow.ToArray());

            #endregion

            // Add HP rows for mobs
            var mobLevelRow = new List<string> { "" };
            var mobHpRow = new List<string> { "" };
            foreach (Unit unit in mobUnits)
            {
                mobLevelRow.Add($"{unit.Level.CurrentLevel}");
                mobHpRow.Add($"[{GetHpColor(unit)}]{unit.HP}[/][grey35]/{unit.MaxHP}[/]");
            }

            mobTable.AddRow(mobLevelRow.ToArray());
            mobTable.AddRow(mobHpRow.ToArray());

            #endregion

            AnsiConsole.Write(mobTable);
            AnsiConsole.Write(playerTable);

        }

        public void ShowTitle()
        {
            AnsiConsole.Write(
            new FigletText("Turn Based Game")
                .Centered()
                .Color(Spectre.Console.Color.Red));

        }

        private string GetHpColor(Unit unit)
        {
            var hpColor = "seagreen2";
            if (unit.HP > unit.MaxHP * 0.33 && unit.HP <= unit.MaxHP * 0.66)
                hpColor = "darkorange";
            else if (unit.HP > 0 && unit.HP <= unit.MaxHP * 0.33)
                hpColor = "deeppink2";
            else if (unit.HP <= 0)
                hpColor = "grey35";

            return hpColor;
        }

        private string GetMpColor(Unit unit)
        {
            var mpColor = "cyan";
            if (unit.HP <= 0)
                mpColor = "grey35";

            return mpColor;
        }
        public void ShowSkillInfo(Unit unit, BaseSkill? singleSkill)
        {
            var infoTable = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Spectre.Console.Color.Grey)
                .Title($"[bold white]{unit.Name}'s skills[/]");
            infoTable.AddColumn(" ");

            var costRow = new List<string> { "Cost:" };
            var dmgTypesRow = new List<string> { "Affinity:" };
            var subskillTypeRow = new List<string> { "Type:" };
            var userPositionsRow = new List<string> { "Rank:" };
            var targetPositionsRow = new List<string> { "Target:" };
            var dmgModifierRow = new List<string> { "Modifier:" };
            var effectsRow = new List<string> { "Effect:" };

            var unitSkills = new List<BaseSkill>();

            if(singleSkill != null)
                unitSkills.Add(singleSkill);
            else
                unitSkills.AddRange(unit.Skills.
                    Where(skill => !(skill is MoveSkill) && !(skill is RestSkill)));

            foreach (var skill in unitSkills)
            {
                infoTable.AddColumn($"{skill.Name}");
            }

            foreach (var skill in unitSkills)
            {
                #region cost
                string manaCost = (skill.ManaCost > 0 ? $"[cyan]{skill.ManaCost}[/]" : $"[gray]-[/]");
                string healthCost = (skill.HealthCost > 0 ? $"[gray]/[/][deeppink2]{skill.HealthCost}[/]" : string.Empty);
                string costText = manaCost + healthCost;

                costRow.Add(costText);
                #endregion cost

                #region affinity
                string dmgTypesText = $"[{skill.PrimaryType.GetColor()}]{skill.PrimaryType.GetCode()}[/]" + 
                    (skill.SecondaryType != EnumSkillType.None ? $"[gray]/[/][{skill.SecondaryType.GetColor()}]{skill.SecondaryType.GetCode()}[/]" : string.Empty);

                dmgTypesRow.Add(dmgTypesText);
                #endregion affinity

                #region type
                var parentType = skill.GetType().BaseType;
                if (parentType != null)
                {
                    string parentTypeName = parentType.Name;
                    string extractedName = parentTypeName.Replace("Skill", ""); 
                    subskillTypeRow.Add(extractedName);
                }
                else
                {
                    subskillTypeRow.Add($"[gray]-[/]"); 
                }
                #endregion type

                #region user positions
                string positions = "o o o o";
                var stringBuilder = new StringBuilder(positions);

                foreach (var pos in skill.ValidUserPositions)
                {
                    if (pos >= 0 && pos < 4) // Only consider positions 0, 1, 2, and 3
                    {
                        // Calculate the reversed position index in the string (6, 4, 2, 0)
                        int index = (3 - pos) * 2;

                        // Replace 'o' with '[yellow]o[/]'
                        stringBuilder.Remove(index, 1);
                        stringBuilder.Insert(index, "[darkorange]o[/]");
                    }
                }

                userPositionsRow.Add(stringBuilder.ToString());
                #endregion user positions

                #region target positions
                if (!skill.SelfTarget)
                {
                    var targetStringBuilder = new StringBuilder();
                    var validPositions = new HashSet<int>(skill.ValidTargetPositions);
                    var targetColor = skill.IsPassive ? "springgreen1" : "red3";

                    for (int i = 0; i < 4; i++)
                    {
                        if (validPositions.Contains(i))
                        {
                            targetStringBuilder.Append($"[{targetColor}]o[/]");
                        }
                        else
                        {
                            targetStringBuilder.Append("o");
                        }

                        if (i < 3)
                        {
                            targetStringBuilder.Append(" ");
                        }
                    }
                    targetPositionsRow.Add(targetStringBuilder.ToString());
                }
                else
                {
                    targetPositionsRow.Add("Self");
                }

                #endregion target positions

                #region dmg modifier

                var dmgModifierText = ((int)(skill.DamageModifier * 100 - 100)).ToString() + "%";
                if((int)(skill.DamageModifier * 100 - 100) >= 0)
                    dmgModifierText = "+" + dmgModifierText;
                dmgModifierRow.Add(dmgModifierText);

                #endregion dmg modifier
            }

            infoTable.AddRow(costRow.ToArray());
            infoTable.AddRow(dmgTypesRow.ToArray());
            infoTable.AddRow(subskillTypeRow.ToArray());
            infoTable.AddRow(userPositionsRow.ToArray());
            infoTable.AddRow(targetPositionsRow.ToArray());
            infoTable.AddRow(dmgModifierRow.ToArray());

            AnsiConsole.Write(infoTable);
        }
    }
}