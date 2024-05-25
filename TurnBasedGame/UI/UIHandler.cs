using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.UI
{
    public class UIHandler
    {
        public void ShowStatus(List<Unit> playerUnits, List<Unit> mobUnits, int level)
        {
            //https://spectreconsole.net/
            Console.Clear();

            AnsiConsole.Write(new Markup($"[lightpink4] == {level} == [/]").Centered());
            var playerTable = new Table();
            playerTable.Border = TableBorder.Simple;
            playerTable.AddColumn(" ").LeftAligned();
            foreach (Unit unit in playerUnits)
            {
                playerTable.AddColumn($"[lightcyan1]{unit.DisplayName ?? " "}[/]").LeftAligned();
            }

            var playerHpRow = new List<string> { "[seagreen2]HP[/]" };
            var playerMpRow = new List<string> { "[cyan]MP[/]" };
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
                mobTable.AddColumn($"[red]{unit.DisplayName}[/]").RightAligned();
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
