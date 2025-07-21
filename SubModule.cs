using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace ROT_LinuxFix;

public class SubModule : MBSubModuleBase
{
    protected override void OnSubModuleLoad()
    {
        base.OnSubModuleLoad();
        var harmony = new Harmony("org.exsdev.bannerlord.rotlinuxfix");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(GameTexts), "FindText")]
static class Patch_FindText
{
    private static readonly Dictionary<string, TextObject> wellknown = new(){
        { "str_party_morale", new TextObject("{=alMmQrhK}Party Morale")},
        { "str_starving", new TextObject("{=jZYUdkXF}Starving")},
        { "str_notable_relations", new TextObject("{=WhuufgY5}Notable Relations")},
        { "str_governor_criminal", new TextObject("{=OhLXo0gb}Criminal Governor")},
        { "str_notable_governor", new TextObject("{=Fa2nKXxI}Governor")},
        { "str_security", new TextObject("{=MqCH7R4A}Security")},
        { "str_loyalty", new TextObject("{=YO0x7ZAo}Loyalty")},
        { "str_loyalty_drift", new TextObject("{=fEJQcb4U}Loyalty Drift")},
        { "str_corruption", new TextObject("{=GKO2ogal}Corruption")},
        { "str_enemy_not_attackable_tooltip", new TextObject("{=oYUAuLO7}You have sworn not to attack.")},
    };

    [HarmonyPrefix]
    public static bool Prefix(string id, string? variation, ref TextObject __result)
    {
        try
        {
            // Attempt to find the id in the game texts
            __result = Original_FindText(id, variation);
        }
        catch (Exception ex)
        {
            if (wellknown.ContainsKey(id))
            {
                __result = wellknown[id];
                return false;
            }

            // If an exception occurs, return at least something instead of crashing
            var msg = $"Searching for string '{id}' failed: {ex.Message}. Returning '{id}'\n\n{ex.StackTrace}";
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Red));
            Console.WriteLine(msg);

            MessageBox.Show(msg, "ROT-LinuxFix", MessageBoxButtons.OK, MessageBoxIcon.Information);

            __result = new TextObject(id);
        }
        return false;
    }

    [HarmonyReversePatch(HarmonyReversePatchType.Snapshot)]
    [HarmonyPatch(typeof(GameTexts), "FindText")]
    static TextObject Original_FindText(string id, string? variation = null)
    {
        // Will be replaced at runtime by Harmony
        throw new NotImplementedException();
    }
}
