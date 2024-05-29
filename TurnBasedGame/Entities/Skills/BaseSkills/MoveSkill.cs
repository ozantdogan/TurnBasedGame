using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

public class MoveSkill : BaseSkill
{
    public bool MoveLeft { get; set; }

    public MoveSkill()
    {
        Name = "Move";
        ManaCost = 0;
    }

    public override int Execute(Unit actor, List<Unit> targets)
    {
        int currentPosition = actor.Position;
        if (currentPosition == -1) return -1; // Actor position is invalid

        if (actor.UnitType == EnumUnitType.Player)
        {
            var moveChoices = new List<string>();
            if (currentPosition < targets.Max(t => t.Position) && targets.Any(t => t.Position == currentPosition + 1 && t.IsAlive))
                moveChoices.Add("Back"); 
            if (currentPosition > 0 && targets.Any(t => t.Position == currentPosition - 1 && t.IsAlive))
                moveChoices.Add("Front"); 

            if (moveChoices.Count == 0)
            {
                Console.WriteLine("No available moves.");
                return -1;
            }

            // Prompt user to choose a direction
            var directionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose a direction to move:")
                    .AddChoices(moveChoices)
            );

            bool moveBack = directionChoice == "Back";

            // Calculate new position based on direction
            int newIndex = moveBack ? currentPosition + 1 : currentPosition - 1;

            if (targets.Any(t => t.Position == newIndex && t.IsAlive))
            {
                // Find the unit in the new position
                var targetUnit = targets.First(t => t.Position == newIndex);

                // Swap positions
                targetUnit.Position = currentPosition;
                actor.Position = newIndex;

                Console.WriteLine($"{actor.Name} moved {(moveBack ? "back" : "front")}.");
                actor.HasMoved = true;
                return 0;
            }

            Console.WriteLine($"Cannot move {(moveBack ? "front" : "back")}.");
            return -1;
        }
        else
        {
            // Mob logic
            int newIndex;
            if (currentPosition == 0)
            {
                newIndex = currentPosition + 1; // If mob is at the front, move towards the back
            }
            else if (currentPosition == targets.Max(t => t.Position))
            {
                newIndex = currentPosition - 1; // If mob is at the back, move towards the front
            }
            else
            {
                // Randomly choose to move forward or backward
                newIndex = _random.Next(2) == 0 ? currentPosition - 1 : currentPosition + 1;
            }

            if (newIndex >= 0 && newIndex < targets.Count && targets.Any(t => t.Position == newIndex && t.IsAlive) && !actor.HasMoved)
            {
                // Find the unit in the new position
                var targetUnit = targets.First(t => t.Position == newIndex);

                // Swap positions
                targetUnit.Position = currentPosition;
                actor.Position = newIndex;


                Logger.LogMove(actor, newIndex < currentPosition);
                //Console.WriteLine($"{actor.Name} moved {(newIndex < currentPosition ? "front" : "back")}.");
                actor.HasMoved = true;
                return 0;
            }

            return actor.Skills.First(p => p is RestSkill).Execute(actor);
        }
    }

    public override int Execute(Unit actor, Unit target)
    {
        throw new NotImplementedException();
    }

    public override int Execute(Unit actor)
    {
        throw new NotImplementedException();
    }
}
