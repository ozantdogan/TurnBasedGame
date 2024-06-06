using TurnBasedGame.Main.UI;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuHandler menu = new MenuHandler();
            menu.ShowMainMenu();
        }
    }
}