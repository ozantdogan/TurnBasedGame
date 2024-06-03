using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;
using TurnBasedGame.Main.UI;

public class MoveSkill : BaseSkill
{
    public string MoveBackText = " 1. Go Back";
    public string MoveFrontText = " 2. Go Front";
    public string ReturnText = " 0. Return";

    public MoveSkill()
    {
        Name = "Move";
        IsPassive = true;
        ManaCost = 0;
    }

    public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
    {
        int currentPosition = actor.Position;
        if (currentPosition == -1) return -1; // Actor position is invalid

        if (targets == null || !targets.Any())
        {
            Logger.NoValidTargets();
            return -1;
        }

        if (actor.UnitType == EnumUnitType.Player || actor.UnitType == EnumUnitType.Summon)
        {
            var moveChoices = new List<string>();
            if (currentPosition < targets.Max(t => t.Position) && targets.Any(t => t.Position == currentPosition + 1 && t.IsAlive))
                moveChoices.Add(MoveBackText); 
            if (currentPosition > 0 && targets.Any(t => t.Position == currentPosition - 1 && t.IsAlive))
                moveChoices.Add(MoveFrontText);

            moveChoices.Add(ReturnText);

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

            if (directionChoice == ReturnText)
                return -2;

            bool moveBack = directionChoice == MoveBackText;

            // Calculate new position based on direction
            int newIndex = moveBack ? currentPosition + 1 : currentPosition - 1;

            if (targets.Any(t => t.Position == newIndex && t.IsAlive))
            {
                // Find the unit in the new position
                var targetUnit = targets.First(t => t.Position == newIndex);

                // Swap positions
                targetUnit.Position = currentPosition;
                actor.Position = newIndex;

                Logger.LogMove(actor, newIndex < currentPosition);
                actor.HasMoved = true;
                return 0;
            }

            Logger.LogMoveFail(actor, newIndex < currentPosition);
            return -1;
        }
        else
        {
            // Mob logic
            int newIndex;
            if (currentPosition == 0)
            {
                newIndex = currentPosition + 1; 
            }
            else if (currentPosition == targets.Max(t => t.Position))
            {
                newIndex = currentPosition - 1; 
            }
            else
            {
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
                actor.HasMoved = true;
                return 0;
            }

            return actor.Skills.First(p => p is RestSkill).Execute(actor);
        }
    }
}
