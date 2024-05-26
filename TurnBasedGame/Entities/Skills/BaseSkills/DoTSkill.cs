namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
    public class DoTSkill : AttackSkill
    {
        public int DamagePerTurn { get; set; }
        public int Duration { get; set; }
        public double DoTModifier { get; set; }
    }
}
