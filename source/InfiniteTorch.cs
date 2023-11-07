using System.Collections.Generic;
using BepInEx;
using HarmonyLib;

namespace TebInfiniteTorches
{
    public static class HarmonyPatches
    {
        public static void PrefixIsBurning(Fireplace __instance)
        {
            if (Plugin.GetInfiniteFuel())
            {
                __instance.m_infiniteFuel = true;
            }
            else
            {
                __instance.m_infiniteFuel = false;
            }
        }

        public static void PrefixWet(Fireplace __instance)
        {
            if (Plugin.GetWeather())
            {
                __instance.m_wet = false;
            }
            else
            {
                __instance.m_wet = true;
            }
        }
    }
}
