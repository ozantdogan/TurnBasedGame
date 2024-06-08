using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using System.Collections.Generic;
using System.Linq;
using TurnBasedGame.Main.Entities.Bosses;
using System.Xml.Linq;

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
                " Play",
                " Settings",
                " Exit"
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
                Environment.Exit(0);
            }
        }

        private void ShowSettingsMenu()
        {
            while (true)
            {
                List<string> settingButtonTexts = new List<string>()
                {
                    $"1. Level: {LevelHandler.LevelType}",
                    $"2. Pace: {LevelHandler.Pace}",
                    $"[gray]Main Menu[/]"
                };

                var settingButtonChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Settings\n")
                        .PageSize(10)
                        .AddChoices(settingButtonTexts)
                        .HighlightStyle(new Style(Color.Red))
                );

                if (settingButtonChoice.Contains("Level"))
                {
                    // Iterate through the EnumLevel values
                    Array enumValues = Enum.GetValues(typeof(EnumLevel));
                    if (enumValues.Length > 0)
                    {
                        int currentIndex = Array.IndexOf(enumValues, LevelHandler.LevelType);
                        int nextIndex = (currentIndex + 1) % enumValues.Length;
                        object? nextValue = enumValues.GetValue(nextIndex);

                        if (nextValue is EnumLevel nextLevel)
                        {
                            LevelHandler.LevelType = nextLevel;
                            AnsiConsole.MarkupLine($"Level changed to: {LevelHandler.LevelType}");
                        }
                    }
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
                new Nomad { UnitType = EnumUnitType.Player, Name = "Ali", DisplayName = "Ali,\nDesert Nomad" },
                new Occultist { UnitType = EnumUnitType.Player, Name = "Occultist", DisplayName = "Occultist" },
                new SkeletonKing { UnitType = EnumUnitType.Player, Name = "Gaiseric", DisplayName = "Gaiseric,\nthe Skeleton King" },
                new RedDragon { UnitType = EnumUnitType.Player, Name = "Green Dragon", DisplayName = "Green\nDragon" }
            };

            List<Unit> selectedUnits = new List<Unit>();
            int maxUnits = 4; // Set the number of units players can choose

            string selectedUnitColor = "cyan2";

            while (true)
            {
                var table = new Table().Border(TableBorder.AsciiDoubleHead).BorderColor(Color.Grey15);
                table.AddColumn(" ");

                foreach (var unit in availableUnits)
                {
                    bool isSelected = selectedUnits.Contains(unit);
                    var name = unit.Name ?? "Unknown";
                    table.AddColumn(isSelected ? $"[italic][{selectedUnitColor}]{name}[/][/]" : $"[italic]{name}[/]");
                }

                var hpMpRow = new List<string> { "[gray]HP/MP[/]" };
                var classRow = new List<string> { "[gray]Class[/]" };
                var strRow = new List<string> { "[gray]STR[/]" };
                var dexRow = new List<string> { "[gray]DEX[/]" };
                var intRow = new List<string> { "[gray]INT[/]" };
                var faithRow = new List<string> { "[gray]FAI[/]" };
                var dmgRow = new List<string> { "[gray]DMG[/]" };

                foreach (var unit in availableUnits)
                {
                    var className = unit.GetType().Name ?? "";
                    var dmgValues = $"{unit.MinDamageValue}-{unit.MaxDamageValue}";
                    bool isSelected = selectedUnits.Contains(unit);

                    hpMpRow.Add(isSelected ? $"[{selectedUnitColor}]{unit.HP}/{unit.MP}[/]" : $"[seagreen2]{unit.HP}[/][gray]/[/][cyan]{unit.MP}[/]");
                    classRow.Add(isSelected ? $"[{selectedUnitColor}]{className}[/]" : className);
                    strRow.Add(isSelected ? $"[{selectedUnitColor}]{unit.Strength}[/]" : unit.Strength.ToString());
                    dexRow.Add(isSelected ? $"[{selectedUnitColor}]{unit.Dexterity}[/]" : unit.Dexterity.ToString());
                    intRow.Add(isSelected ? $"[{selectedUnitColor}]{unit.Intelligence}[/]" : unit.Intelligence.ToString());
                    faithRow.Add(isSelected ? $"[{selectedUnitColor}]{unit.Faith}[/]" : unit.Faith.ToString());
                    dmgRow.Add(isSelected ? $"[{selectedUnitColor}]{dmgValues}[/]" : dmgValues);
                };

                table.AddRow(hpMpRow.ToArray());
                table.AddRow(classRow.ToArray());
                table.AddRow(strRow.ToArray());
                table.AddRow(dexRow.ToArray());
                table.AddRow(intRow.ToArray());
                table.AddRow(faithRow.ToArray());
                table.AddRow(dmgRow.ToArray());

                AnsiConsole.Write(table);

                if (selectedUnits.Count == maxUnits)
                {
                    var confirmSelection = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("You have selected the maximum number of units. Do you want to continue?")
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

                    unitChoices.Add("[darkred_1]Continue[/]");
                    unitChoices.Add("[gray]Main Menu[/]");

                    var selectedUnitName = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title($"Select a character ({maxUnits - selectedUnits.Count} left):")
                            .PageSize(10)
                            .AddChoices(unitChoices)
                            .HighlightStyle(new Style(Color.Red))
                    );

                    if (selectedUnitName.Contains("Continue") && selectedUnits.Count > 0)
                    {
                        break;
                    }
                    else if (selectedUnitName.Contains("Continue") && selectedUnits.Count <= 0)
                    {
                        AnsiConsole.Markup("[red]You must select at least one character[/]");
                        Thread.Sleep(500);
                        AnsiConsole.Clear();
                        SelectCharacters();
                    }

                    if (selectedUnitName.Contains("Menu"))
                    {
                        AnsiConsole.Clear();
                        ShowMainMenu();
                    }

                    // Find the selected unit
                    var unitToSelect = availableUnits.FirstOrDefault(u =>
                        selectedUnits.Contains(u) ? $"[{selectedUnitColor}]{u?.Name}[/]" == selectedUnitName : u?.Name == selectedUnitName
                    );

                    if (unitToSelect != null)
                    {
                        // Show unit skills info
                        _ui.ShowSkillInfo(unitToSelect, null);

                        var unitInput = string.Empty;
                        unitInput = !selectedUnits.Contains(unitToSelect) ? "Add" : "Remove";

                        // Prompt for add/remove or back
                        var action = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Choose an action:")
                                .AddChoices($"{unitInput}", "[darkgoldenrod]Back[/]", "[gray]Main Menu[/]")
                                .HighlightStyle(new Style(Color.Red))
                        );

                        if (action == unitInput)
                        {
                            if (!selectedUnits.Contains(unitToSelect))
                            {
                                UnitManager.AddUnit(unitToSelect, selectedUnits);
                            }
                            else
                            {
                                UnitManager.RemoveUnit(unitToSelect, selectedUnits);
                            }
                        }
                        else if (action.Contains("Menu"))
                        {
                            AnsiConsole.Clear();
                            ShowMainMenu();
                        }

                        // Clear console before showing the updated list again
                        AnsiConsole.Clear();
                    }
                }
            }

            AnsiConsole.Clear();
            if (selectedUnits.Count > 1)
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
                unitPositions.Add("[darkred_1]Start[/]");
                unitPositions.Add("[gray]Main Menu[/]");

                var selectedPosition = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select a unit to move:")
                        .PageSize(10)
                        .AddChoices(unitPositions)
                        .HighlightStyle(new Style(Color.Red))
                );

                if (selectedPosition.Contains("Start"))
                    break;

                if (selectedPosition.Contains("Menu"))
                {
                    Console.Clear();
                    ShowMainMenu();
                }

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
                if (unitPositions[swapIndex].Contains("Start"))
                    break;

                if (unitPositions[swapIndex].Contains("Menu"))
                {
                    AnsiConsole.Clear();
                    ShowMainMenu();
                }

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
