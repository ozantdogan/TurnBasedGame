using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Abstract
{
    public interface ISkill
    {
        bool Execute(Unit actor, Unit target);
        bool Execute(Unit actor, List<Unit> targets);
    }
}
