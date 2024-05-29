using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Helpers.Enums;

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
                activeStatusEffects.AddRange(unit.ActiveDoTEffects);
                activeStatusEffects.AddRange(unit.ActiveBuffEffects);

                if (activeStatusEffects.Any() || unit.IsStunned) // Check if the list is not empty
                {
                    var combinedEffects = string.Join(" ", activeStatusEffects.Select(effect =>
                        $"[{effect.EffectType.GetColor()}]{effect.EffectType.GetCode()}{(effect.Duration == 0 ? "" : $"({effect.Duration})")}[/]"));

                    if (unit.IsStunned)
                    {
                        var stunnedEffect = EnumEffectType.STUNNED;
                        combinedEffects += $"[{stunnedEffect.GetColor()}]{stunnedEffect.GetCode()}{(unit.StunDuration == 0 ? "" : $"({unit.StunDuration})")}[/]";
                    }

                    playerEffectRow.Add(combinedEffects);
                }
                else
                {
                    playerEffectRow.Add(" ");
                }
            }

            playerTable.AddRow(playerEffectRow.ToArray());

            #endregion

            var playerLevelRow = new List<string> { "[lightsteelblue1] Lv[/]" };
            var playerHpRow = new List<string> { "[seagreen2] HP[/]" };
            var playerMpRow = new List<string> { "[cyan] MP[/]" };
            foreach (var unit in playerUnits)
            {
                playerLevelRow.Add($"{unit.Level.CurrentLevel}");
                playerHpRow.Add($"{unit.HP}/{unit.MaxHP}");
                playerMpRow.Add($"{unit.MP}/{unit.MaxMP}"); 
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
                activeStatusEffects.AddRange(unit.ActiveDoTEffects);
                activeStatusEffects.AddRange(unit.ActiveBuffEffects);

                if (activeStatusEffects.Any() || unit.IsStunned) // Check if the list is not empty
                {
                    var combinedEffects = string.Join(" ", activeStatusEffects.Select(effect =>
                        $"[{effect.EffectType.GetColor()}]{effect.EffectType.GetCode()}{(effect.Duration == 0 ? "" : $"({effect.Duration})")}[/]"));

                    if (unit.IsStunned)
                    {
                        var stunnedEffect = EnumEffectType.STUNNED;
                        combinedEffects += $"[{stunnedEffect.GetColor()}]{stunnedEffect.GetCode()}{(unit.StunDuration == 0 ? "" : $"({unit.StunDuration})")}[/]";
                    }

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
            var mobLevelRow = new List<string> { "[lightsteelblue1] Lv[/]" };
            var mobHpRow = new List<string> { "[seagreen2] HP[/]" };
            foreach (Unit unit in mobUnits)
            {
                mobLevelRow.Add($"{unit.Level.CurrentLevel}");
                mobHpRow.Add($"{unit.HP}/{unit.MaxHP}");
            }

            mobTable.AddRow(mobLevelRow.ToArray());
            mobTable.AddRow(mobHpRow.ToArray());

            #endregion

            AnsiConsole.Write(mobTable);
            AnsiConsole.Write(playerTable);

        }
    }
}