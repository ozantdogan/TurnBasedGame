using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Abstract
{
    public interface ISkill
    {
        int Execute(Unit actor);
        //int Execute(Unit actor, Unit target);
        //int Execute(Unit actor, List<Unit> targets);
        int Execute(Unit actor, Unit? singleTarget, List<Unit>? targets);
    }
}
