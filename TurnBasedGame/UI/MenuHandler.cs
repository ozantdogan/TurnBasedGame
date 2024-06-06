using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using System.Collections.Generic;
using System.Linq;

namespace TurnBasedGame.Main.UI
{
    public class MenuHandler
    {
        private UIHandler _ui;

        public MenuHandler()
        {
            _ui = new UIHandler();
        }

        public void ShowMainMenu()
        {
            _ui.ShowTitle();
            List<string> menuButtonTexts = new List<string>()
            {
                "                                                       Play",
                "                                                       Settings",
                "                                                       Exit"
            };

            var menuButtonChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(10)
                    .AddChoices(menuButtonTexts)
                    .HighlightStyle(new Style(Color.Red))
            );

            AnsiConsole.Clear();

            if (menuButtonChoice.Contains("Play"))
            {
                var selectedUnits = SelectCharacters();
                if (selectedUnits != null && selectedUnits.Count > 0)
                {
                    var i = Play(selectedUnits);
                    if (i)
                    {
                        AnsiConsole.Clear();
                        ShowMainMenu();
                    }
                }
            }
            else if (menuButtonChoice.Contains("Settings"))
            {
                ShowSettingsMenu();
            }
            else if (menuButtonChoice.Contains("Exit"))
            {
                return;
            }
        }

        private void ShowSettingsMenu()
        {
            while (true)
            {
                List<string> settingButtonTexts = new List<string>()
                {
                    $"1. Dummy level: {(LevelHandler.DummyLevel ? "ON" : "OFF")}",
                    $"2. Boss level: {(LevelHandler.BossLevel ? "ON" : "OFF")}",
                    $"0. Back to Menu"
                };

                var settingButtonChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Settings\n")
                        .PageSize(10)
                        .AddChoices(settingButtonTexts)
                        .HighlightStyle(new Style(Color.Red))
                );

                AnsiConsole.Clear();

                if (settingButtonChoice.Contains("Dummy level"))
                {
                    LevelHandler.DummyLevel = !LevelHandler.DummyLevel;
                }
                else if (settingButtonChoice.Contains("Boss level"))
                {
                    LevelHandler.BossLevel = !LevelHandler.BossLevel;
                }
                else
                {
                    break;
                }
            }

            AnsiConsole.Clear();
            ShowMainMenu();
        }

        private List<Unit> SelectCharacters()
        {
            List<Unit> availableUnits = new List<Unit>
            {
                new Defender { UnitType = EnumUnitType.Player, Name = "Roderick", DisplayName = "Roderick,\nthe Defender" },
                new Cleric { UnitType = EnumUnitType.Player, Name = "Flora", DisplayName = "Flora,\nthe Cleric" },
                new Rogue { UnitType = EnumUnitType.Player, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" },
                new Scholar { UnitType = EnumUnitType.Player, Name = "Tudor", DisplayName = "Tudor,\nthe Wizard" },
                new Nomad { UnitType = EnumUnitType.Player, Name = "Tair", DisplayName = "Tair,\nDesert Nomad" }
            };

            List<Unit> selectedUnits = new List<Unit>();
            int maxUnits = 4; // Set the number of units players can choose

            string selectedUnitColor = "teal";

            while (true)
            {
                // Create the table for available units
                var table = new Table()
                    .Border(TableBorder.Heavy)
                    .BorderColor(Color.Grey)
                    .Title("[bold white]Available Units[/]")
                    .AddColumn("Name")
                    .AddColumn("Class")
                    .AddColumn("HP");

                foreach (var unit in availableUnits)
                {
                    if (unit == null) continue; // Skip null units to prevent exceptions

                    bool isSelected = selectedUnits.Contains(unit);
                    var name = unit.Name ?? "Unknown"; // Handle potential null DisplayName
                    var className = unit.GetType().Name ?? ""; // Handle potential null UnitType


                    table.AddRow(
                        new Markup(isSelected ? $"[{selectedUnitColor}]{name}[/]" : name),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{className}[/]" : className),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{unit.HP}[/]" : unit.HP.ToString())
                    );
                }

                AnsiConsole.Write(table);

                // Prompt for character selection
                List<string> unitChoices = availableUnits
                    .Where(unit => unit != null) // Skip null units
                    .Select(unit =>
                    {
                        var displayName = unit.DisplayName ?? "Unknown";
                        return selectedUnits.Contains(unit) ? $"[{selectedUnitColor}]{displayName}[/]" : displayName;
                    })
                    .ToList();

                var selectedUnitName = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"Select a character ({maxUnits - selectedUnits.Count()} left):")
                        .PageSize(10)
                        .AddChoices(unitChoices)
                        .HighlightStyle(new Style(Color.LightSkyBlue1))
                );

                // Find the selected unit
                var unitToSelect = availableUnits.FirstOrDefault(u =>
                    selectedUnits.Contains(u) ? $"[{selectedUnitColor}]{u?.DisplayName}[/]" == selectedUnitName : u?.DisplayName == selectedUnitName
                );

                if (unitToSelect != null && !selectedUnits.Contains(unitToSelect))
                {
                    selectedUnits.Add(unitToSelect);
                }
                else if (unitToSelect != null)
                {
                    selectedUnits.Remove(unitToSelect);
                }

                if (selectedUnits.Count == maxUnits)
                {
                    var confirmSelection = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("You have selected all characters. Do you want to confirm the selection?")
                            .AddChoices("Yes", "No")
                            .HighlightStyle(new Style(Color.Red))
                    );

                    if (confirmSelection == "Yes")
                    {
                        break;
                    }
                    else
                    {
                        selectedUnits.Clear();
                        AnsiConsole.Clear();
                    }
                }
                else
                {
                    AnsiConsole.Clear();
                }
            }

            ArrangeUnits(selectedUnits);
            return selectedUnits;
        }


        private void ArrangeUnits(List<Unit> units)
        {
            while (true)
            {
                List<string> unitPositions = units.Select((unit, index) => $"{index + 1}. {unit.DisplayName}").ToList();

                var selectedPosition = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select a unit to move:")
                        .PageSize(10)
                        .AddChoices(unitPositions)
                        .HighlightStyle(new Style(Color.Yellow))
                );

                int selectedIndex = unitPositions.IndexOf(selectedPosition);

                var newPosition = AnsiConsole.Prompt(
                    new TextPrompt<int>($"Enter the new position for {units[selectedIndex].DisplayName} (1-{units.Count}):")
                        .ValidationErrorMessage("[red]That's not a valid position[/]")
                        .Validate(pos => pos >= 1 && pos <= units.Count)
                );

                UnitManager.SetPosition(units[selectedIndex], units, newPosition - 1);
                AnsiConsole.Clear();

                var continueArranging = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Do you want to rearrange more units?")
                        .AddChoices("Yes", "No")
                        .HighlightStyle(new Style(Color.Green))
                ) == "Yes";


                if (!continueArranging)
                {
                    break;
                }
            }
        }

        private bool Play(List<Unit> selectedUnits)
        {
            Console.Clear();
            List<Unit> playerUnits = new List<Unit>(selectedUnits);
            List<Unit> mobUnits = new List<Unit>();

            foreach (var playerUnit in playerUnits)
                playerUnit.Skills.Reverse();

            while (true)
            {
                LevelHandler.AddMobs(mobUnits);
                BattleHandler battle = new BattleHandler();
                var result = battle.StartBattle(playerUnits, mobUnits, LevelHandler.Level);
                LevelHandler.Rest(playerUnits);
                LevelHandler.IncreaseLevel();
                mobUnits.Clear();

                if (result || LevelHandler.Level > 6)
                    break;
            }

            return true;
        }
    }
}
