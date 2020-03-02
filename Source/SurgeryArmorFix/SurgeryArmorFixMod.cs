using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Verse;

namespace SurgeryArmorFix
{
    [StaticConstructorOnStartup]
    public class SurgeryArmorFixMod
    {
        static SurgeryArmorFixMod()
        {
            var harmony = new Harmony("lockdownx7.rimworld.surgeryarmorfix");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
