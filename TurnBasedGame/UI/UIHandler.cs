using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;

namespace TurnBasedGame.Main.UI
{
    public class UIHandler
    {
        public void ShowStatus(List<Unit> playerUnits, List<Unit> mobUnits, int level)
        {
            Console.Clear();

            AnsiConsole.Write(new Markup($"[lightpink4] == {level} == [/]").Centered());

            var playerTable = new Table().Border(TableBorder.Simple).LeftAligned();
            playerTable.AddColumn(" ");
            foreach (Unit unit in playerUnits)
            {
                playerTable.AddColumn($"[{unit.UnitType.GetColor()}]{unit.DisplayName ?? " "}[/]");
            }

            #region Player effects

            var playerEffectRow = new List<string> { " " };
            foreach (Unit unit in playerUnits)
            {
                var activeStatusEffects = new List<StatusEffect>();
                activeStatusEffects.AddRange(unit.ActiveDoTEffects);
                activeStatusEffects.AddRange(unit.ActiveBuffEffects);

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

            // Add HP and MP rows
            var playerHpRow = new List<string> { "[seagreen2]HP[/]" };
            var playerMpRow = new List<string> { "[cyan]MP[/]" };
            foreach (Unit unit in playerUnits)
            {
                playerHpRow.Add($"{unit.HP}/{unit.MaxHP}");
                playerMpRow.Add($"{unit.MP}/{unit.MaxMP}"); // Assuming you have an Mp property
            }

            playerTable.AddRow(playerHpRow.ToArray());
            playerTable.AddRow(playerMpRow.ToArray());

            var mobTable = new Table().Border(TableBorder.Simple).RightAligned();
            mobTable.AddColumn(" ");
            foreach (Unit unit in mobUnits)
            {
                mobTable.AddColumn($"[{unit.UnitType.GetColor()}]{unit.DisplayName}[/]");
            }

            #region Mob effects

            var mobEffectRow = new List<string> { " " };
            foreach (Unit unit in mobUnits)
            {
                var activeStatusEffects = new List<StatusEffect>();
                activeStatusEffects.AddRange(unit.ActiveDoTEffects);
                activeStatusEffects.AddRange(unit.ActiveBuffEffects);

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
            var mobHpRow = new List<string> { "[seagreen2]HP[/]" };
            foreach (Unit unit in mobUnits)
            {
                mobHpRow.Add($"{unit.HP}/{unit.MaxHP}");
            }
            mobTable.AddRow(mobHpRow.ToArray());

            AnsiConsole.Write(mobTable);
            AnsiConsole.Write(playerTable);

        }
    }
}