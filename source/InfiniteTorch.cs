using System.Collections.Generic;
using BepInEx;
using HarmonyLib;

namespace TebInfiniteTorches
{
    /// <summary>
    /// Set fireplaces to have infinite fuel when they load
    /// </summary>
    [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.Awake))]
    static class InfiniteFuel
    {
        [HarmonyPostfix]
        static void InfiniteFuelPrefix(Fireplace __instance)
        {
            if (Plugin.GetInfiniteFuel())
            {
                __instance.m_infiniteFuel = true;
            }
        }
    }

    /// <summary>
    /// Change the result of the CheckWet method
    /// </summary>
    [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.CheckWet))]
    static class WeatherBlock
    {
        [HarmonyPrefix]
        static bool WeatherBlockPrefix(Fireplace __instance)
        {
            if (Plugin.GetWeather())
            {
                __instance.m_wet = false;
                return false;
            }

            return true;
        }
    }
}
