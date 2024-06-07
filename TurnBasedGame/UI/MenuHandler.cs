using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using System.Collections.Generic;
using System.Linq;
using TurnBasedGame.Main.Entities.Bosses;

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
                    $"3. Pace: {LevelHandler.Pace}",
                    $"0. Back to Menu"
                };

                var settingButtonChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Settings\n")
                        .PageSize(10)
                        .AddChoices(settingButtonTexts)
                        .HighlightStyle(new Style(Color.Red))
                );

                if (settingButtonChoice.Contains("Dummy level"))
                {
                    LevelHandler.DummyLevel = !LevelHandler.DummyLevel;
                }
                else if (settingButtonChoice.Contains("Boss level"))
                {
                    LevelHandler.BossLevel = !LevelHandler.BossLevel;
                }
                else if (settingButtonChoice.Contains("Pace"))
                {
                    var newPace = AnsiConsole.Prompt(
                        new TextPrompt<int>("Enter a decimal for the new pace: ")
                            .ValidationErrorMessage("[red]That's not a valid pace[/]")
                    );

                    LevelHandler.Pace = newPace;
                }
                else
                {
                    break;
                }
                AnsiConsole.Clear();
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
                new Nomad { UnitType = EnumUnitType.Player, Name = "Tair", DisplayName = "Tair,\nDesert Nomad" },
                new SkeletonKing { UnitType = EnumUnitType.Player, Name = "Gaiseric", DisplayName = "Gaiseric,\nthe Skeleton King" }
            };

            List<Unit> selectedUnits = new List<Unit>();
            int maxUnits = 4; // Set the number of units players can choose

            string selectedUnitColor = "Yellow";

            while (true)
            {
                // Create the table for available units
                var table = new Table()
                    .Border(TableBorder.Heavy)
                    .BorderColor(Color.Grey)
                    .Title("[bold white]Available Units[/]")
                    .AddColumn("Name")
                    .AddColumn("Class")
                    .AddColumn("HP")
                    .AddColumn("STR")
                    .AddColumn("DEX")
                    .AddColumn("INT")
                    .AddColumn("FAI")
                    .AddColumn("DMG");

                foreach (var unit in availableUnits)
                {
                    if (unit == null) continue; // Skip null units to prevent exceptions

                    bool isSelected = selectedUnits.Contains(unit);
                    var name = unit.Name ?? "Unknown"; // Handle potential null DisplayName
                    var className = unit.GetType().Name ?? ""; // Handle potential null UnitType
                    var dmgValues = $"{unit.MinDamageValue}-{unit.MaxDamageValue}";

                    table.AddRow(
                        new Markup(isSelected ? $"[{selectedUnitColor}]{name}[/]" : name),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{className}[/]" : className),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{unit.HP}[/]" : unit.HP.ToString()),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{unit.Strength}[/]" : unit.Strength.ToString()),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{unit.Dexterity}[/]" : unit.Dexterity.ToString()),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{unit.Intelligence}[/]" : unit.Intelligence.ToString()),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{unit.Faith}[/]" : unit.Faith.ToString()),
                        new Markup(isSelected ? $"[{selectedUnitColor}]{dmgValues}[/]" : dmgValues)
                    );
                }

                AnsiConsole.Write(table);

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
                    // Prompt for character selection
                    List<string> unitChoices = availableUnits
                        .Where(unit => unit != null) // Skip null units
                        .Select(unit =>
                        {
                            var name = unit.Name ?? "Unknown";
                            return selectedUnits.Contains(unit) ? $"[{selectedUnitColor}]{name}[/]" : name;
                        })
                        .ToList();

                    var selectedUnitName = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"Select a character ({maxUnits - selectedUnits.Count()} left):")
                            .PageSize(10)
                            .AddChoices(unitChoices)
                            .HighlightStyle(new Style(Color.Red))
                    );

                    // Find the selected unit
                    var unitToSelect = availableUnits.FirstOrDefault(u =>
                        selectedUnits.Contains(u) ? $"[{selectedUnitColor}]{u?.Name}[/]" == selectedUnitName : u?.Name == selectedUnitName
                    );

                    if (unitToSelect != null && !selectedUnits.Contains(unitToSelect))
                    {
                        UnitManager.AddUnit(unitToSelect, selectedUnits);
                    }
                    else if (unitToSelect != null)
                    {
                        UnitManager.RemoveUnit(unitToSelect, selectedUnits);
                    }

                    AnsiConsole.Clear();
                }
            }

            AnsiConsole.Clear();
            ArrangeUnits(selectedUnits);
            return selectedUnits;
        }

        private void ArrangeUnits(List<Unit> units)
        {
            while (true)
            {
                var table = new Table()
                    .Border(TableBorder.Heavy)
                    .BorderColor(Color.Grey)
                    .Title("[bold white]Available Units[/]")
                    .AddColumn("Name")
                    .AddColumn("Class")
                    .AddColumn("HP");

                foreach (var unit in units)
                {
                    if (unit == null) continue; // Skip null units to prevent exceptions

                    var name = unit.Name ?? "Unknown"; // Handle potential null DisplayName
                    var className = unit.GetType().Name ?? ""; // Handle potential null UnitType

                    table.AddRow(
                        new Markup(name),
                        new Markup(className),
                        new Markup(unit.HP.ToString())
                    );
                }
                AnsiConsole.Write(table);

                List<string> unitPositions = units.Select((unit, index) => $"{index + 1}. {unit.Name}").ToList();
                unitPositions.Add("[white]Start[/]");

                var selectedPosition = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select a unit to move:")
                        .PageSize(10)
                        .AddChoices(unitPositions)
                        .HighlightStyle(new Style(Color.Yellow))
                );

                if (selectedPosition.Contains("Start"))
                    break;

                int selectedIndex = unitPositions.IndexOf(selectedPosition);
                var selectedUnit = units[selectedIndex];
                int previousIndex = selectedUnit.Position;

                _ui.ShowSkillInfo(selectedUnit, null);

                // Prompt for the second unit to swap with
                var swapUnitPosition = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title($"Select a unit to swap with {selectedUnit.Name}:")
                        .PageSize(10)
                        .AddChoices(unitPositions.Where(pos => !pos.Contains(selectedUnit.Name ?? "")).ToList())
                        .HighlightStyle(new Style(Color.Red))
                );

                int swapIndex = unitPositions.IndexOf(swapUnitPosition);
                var swapUnit = units[swapIndex];  

                // Swap the selected unit with the unit at the swapIndex
                UnitManager.SetPosition(selectedUnit, units, swapIndex);
                UnitManager.SetPosition(swapUnit, units, previousIndex);
                AnsiConsole.Clear();
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
                {
                    LevelHandler.Level = 0;
                    break;
                }
            }

            return true;
        }
    }
}
