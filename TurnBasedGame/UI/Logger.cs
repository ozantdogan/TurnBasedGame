using Spectre.Console;
using System.Xml.Linq;
using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.UI
{
    public static class Logger
    {
        public static string damageColor = "white";
        public static string criticalDamageColor = "khaki3";
        public static void LogAction(Unit actor, Unit target, BaseSkill skill)
        {
            AnsiConsole.MarkupLine(actor == target
                   ? $"{FormatUnit(actor)} used {FormatSkill(skill)} on self!"
                   : $"{FormatUnit(actor)} used {FormatSkill(skill)} on {FormatUnit(target)}!");
        }
        public static void LogAction(Unit actor, BaseSkill skill)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} used {FormatSkill(skill)}!");
        }

        public static void LogStatusEffectApplied(Unit unit, StatusEffect effect)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(unit)} has {FormatEffect(effect)} effect!");
        }

        public static void LogHeal(Unit unit, int healDealt)
        {
            AnsiConsole.MarkupLine($"({FormatUnit(unit)} has +{healDealt} HP)");
        }

        public static void LogDodge(Unit target)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(target)} managed to dodge the attack!");
        }

        public static void LogMiss(Unit actor)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} missed the attack!");
        }

        public static void LogStun(Unit unit)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(unit)} is stunned!");
        }

        public static void LogDamage(Unit actor, Unit target, double totalDamageDealt, double critModifier)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} dealt {FormatDamage(totalDamageDealt, critModifier)} to {FormatUnit(target)} " +
                                   $"({target.HP} HP left)");
        }

        public static void LogDeath(Unit unit)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(unit)} is dead");
        }

        public static void LogEffectDamage(Unit unit, StatusEffect effect, int damageDealt)
        {
            AnsiConsole.MarkupLine($"{FormatEffectDamage(effect)} {FormatUnit(unit)} took {FormatDamage(damageDealt)}");
        }

        public static void LogEffectDeath(Unit unit, StatusEffect effect)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(unit)} has died due to {FormatEffect(effect)}");
        }

        public static void LogRest(Unit actor)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} chose to rest this round");
        }

        public static void LogMove(Unit actor, bool moveFront)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} moved {(moveFront ? "front" : "back")}.");
        }

        public static void LogMoveFail(Unit actor, bool moveFront)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} cannot move {(moveFront ? "front" : "back")}.");
        }

        public static void NotEnoughMana(Unit actor, BaseSkill skill)
        {
            AnsiConsole.MarkupLine($"{FormatUnit(actor)} does not have enough mana to use {FormatSkill(skill)}!");
        }

        public static void NoValidTargets()
        {
            AnsiConsole.MarkupLine($"No valid targets available for this skill.");
        }

        private static string FormatUnit(Unit unit)
        {
            string color = EnumExtensions.GetColor(unit.UnitType);
            return $"[{color}]{unit.Name}[/]";
        }

        private static string FormatSkill(BaseSkill skill)
        {
            string color = EnumExtensions.GetColor(skill.PrimaryType);
            return $"[{color}]{skill.ExecutionName}[/]";
        }

        private static string FormatEffect(StatusEffect effect)
        {
            string color = EnumExtensions.GetColor(effect.EffectType);
            return $"[{color}]{effect.EffectType.GetDisplayName()}[/]";
        }

        private static string FormatEffectDamage(StatusEffect effect)
        {
            string color = EnumExtensions.GetColor(effect.EffectType);
            return $"[{color}]({effect.EffectType.GetDisplayName()})[/]";
        }

        private static string FormatDamage(double damageDealt, double critModifier = 1.0)
        {
            string dealtDamageColor = critModifier > 1.0 ? criticalDamageColor : damageColor;
            return $"[{dealtDamageColor}]{(int)damageDealt} DAMAGE[/]";
        }
    }
}
