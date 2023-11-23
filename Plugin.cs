using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

using TutorialMod.Patches;

namespace TutorialMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TutorialModBase : BaseUnityPlugin
    {
        private const string modGUID = "whistle.tutorialmod";
        private const string modName = "NillersMod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TutorialModBase? Instance;

        internal ManualLogSource? mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("TutorialMod loaded!");

            harmony.PatchAll(typeof(TutorialModBase));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}