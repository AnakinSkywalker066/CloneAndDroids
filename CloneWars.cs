using BTD_Mod_Helper;
using CloneWars;
using MelonLoader;

[assembly: MelonInfo(typeof(CloneWars.CloneWars), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CloneWars;

public class CloneWars : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CloneWars>("Clone Wars Mod Has loaded!");
        ModHelper.Msg<CloneWars>("Message Me On Discord @AnakinSkywalker066#3694 If There Are Any Bugs");
        ModHelper.Msg<CloneWars>("This Mod Include Alot of Custom SoundEffects");
    }


}

