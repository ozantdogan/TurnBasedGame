using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Helpers.Enums;

public class MoveSkill : BaseSkill
{
    public bool MoveLeft { get; set; }

    public MoveSkill(string name, bool moveLeft)
    {
        Name = name;
        MoveLeft = moveLeft;
        ManaCost = 0;
    }

    public override bool Execute(Unit actor, List<Unit> targets)
    {
        int currentIndex = targets.IndexOf(actor);
        if (currentIndex == -1) return false; // Actor not found in the list

        int newIndex = MoveLeft ? currentIndex - 1 : currentIndex + 1;
        if(actor.UnitType == EnumUnitType.Mob)
            newIndex = MoveLeft ? currentIndex + 1 : currentIndex - 1;

        if (newIndex >= 0 && newIndex < targets.Count && targets[newIndex].IsAlive)
        {
            // Swap positions
            var temp = targets[newIndex];
            targets[newIndex] = actor;
            targets[currentIndex] = temp;

            Console.WriteLine($"{actor.Name} moved {(MoveLeft ? "left" : "right")}.");
            return true;
        }

        Console.WriteLine($"Cannot move {(MoveLeft ? "left" : "right")}.");
        return false;
    }

    public override bool Execute(Unit actor, Unit target)
    {
        throw new NotImplementedException();
    }
}
