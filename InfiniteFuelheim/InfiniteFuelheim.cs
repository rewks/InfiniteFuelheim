using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace InfiniteFuelheim {

    [BepInPlugin(UUID, NAME, VERSION)]
    [BepInProcess("valheim.exe")]
    public class InfiniteFuelheim : BaseUnityPlugin {
        private const string UUID = "c7f210ac-d4be-4401-b59f-f9c8ea8c98a8";
        private const string NAME = "InfiniteFuelheim";
        private const string VERSION = "1.0.0";

        private readonly Harmony harmony = new Harmony(UUID);

        void Awake() {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(Fireplace), nameof(Fireplace.Awake))]
        class fuel_patch {
            static void Prefix(ref float ___m_secPerFuel) {
                ___m_secPerFuel = 157680000; // 5 years in seconds
            }
        }

    }
}
