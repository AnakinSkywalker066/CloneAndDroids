using MelonLoader;
using BTD_Mod_Helper;
using CloneWars;

[assembly: MelonInfo(typeof(CloneWars.CloneWars), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CloneWars;

public class CloneWars : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CloneWars>("Clone Wars Mod Has loaded!");
    }
}