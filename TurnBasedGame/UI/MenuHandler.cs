using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;

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
                    .PageSize(10) // Adjust the page size if needed
                    .AddChoices(menuButtonTexts)
                    .HighlightStyle(new Style(Color.Red)) // Set the selection color to red
            );

            AnsiConsole.Clear(); // Clear the screen before displaying the centered prompt

            if (menuButtonChoice.Contains("Play"))
            {
                var i = Play();
                if (i)
                {
                    AnsiConsole.Clear();
                    ShowMainMenu();
                }
            }
            else if(menuButtonChoice.Contains("Settings"))
            {
                while (true)
                {
                    List<string> settingButtonTexts = new List<string>()
                    {
                        $"1. Dummy level: {(LevelHandler.DummyLevel ? $"ON" : $"OFF")}",
                        $"2. Boss level: {(LevelHandler.BossLevel ? $"ON" : $"OFF")}",
                        $"0. Back to Menu",
                    };

                    var settingButtonChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Settings\n")
                            .PageSize(10) // Adjust the page size if needed
                            .AddChoices(settingButtonTexts)
                            .HighlightStyle(new Style(Color.Red)) // Set the selection color to red
                    );

                    AnsiConsole.Clear(); // Clear the screen before displaying the centered prompt

                    if(settingButtonChoice.Contains("Dummy level"))
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
            else if(menuButtonChoice.Contains("Exit"))
            {
                return;
            }
        }

        private bool Play()
        {
            Console.Clear();
            Unit knight = new Defender() { UnitType = EnumUnitType.Player, Name = "Roderick", DisplayName = "Roderick,\nthe Defender" }.SetLevel(1);
            Unit cleric = new Cleric() { HP = 30, UnitType = EnumUnitType.Player, Name = "Flora", DisplayName = "Flora,\nthe Cleric", TurnPriority = 1 }.SetLevel(1);
            Unit rogue = new Rogue() { HP = 30, UnitType = EnumUnitType.Player, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" }.SetLevel(1);
            Unit scholar = new Scholar() { HP = 30, UnitType = EnumUnitType.Player, Name = "Tudor", DisplayName = "Tudor,\nthe Wizard" }.SetLevel(1);
            Unit nomad = new Nomad() { UnitType = EnumUnitType.Player, Name = "Nomad", DisplayName = "Desert\nNomad" }.SetLevel(1);

            List<Unit> playerUnits = new List<Unit>();
            List<Unit> mobUnits = new List<Unit>();

            UnitManager.AddUnit(knight, playerUnits);
            //UnitManager.AddUnit(nomad, playerUnits);
            UnitManager.AddUnit(rogue, playerUnits);
            UnitManager.AddUnit(scholar, playerUnits);
            UnitManager.AddUnit(cleric, playerUnits);

            foreach (var playerUnit in playerUnits)
                playerUnit.Skills.Reverse();

            while(true)
            {
                LevelHandler.AddMobs(mobUnits);
                BattleHandler battle = new BattleHandler();
                var i = battle.StartBattle(playerUnits, mobUnits, LevelHandler.Level);
                LevelHandler.Rest(playerUnits);
                LevelHandler.IncreaseLevel();
                mobUnits.Clear();

                if (i || LevelHandler.Level > 6)
                    break;
            }

            return true;
        }
    }
}
