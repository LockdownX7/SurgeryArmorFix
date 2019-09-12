using Harmony;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace SurgeryArmorFix
{
    class Harmony_HealthUtility
    {
        [HarmonyPatch(typeof(HealthUtility), "GiveRandomSurgeryInjuries")]
        class HealthUtility_SurgeriesBypassArmor
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                foreach (var code in instructions)
                {
                    if (code.operand == AccessTools.Field(typeof(DamageDefOf), "Cut")
                        || code.operand == AccessTools.Field(typeof(DamageDefOf), "Scratch")
                        || code.operand == AccessTools.Field(typeof(DamageDefOf), "Stab")
                        || code.operand == AccessTools.Field(typeof(DamageDefOf), "Crush"))
                    {
                        code.operand = AccessTools.Field(typeof(DamageDefOf), "SurgicalCut");
                    }
                    yield return code;
                }
            }
        }
    }
}
