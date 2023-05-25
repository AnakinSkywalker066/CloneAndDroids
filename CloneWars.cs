using MelonLoader;
using BTD_Mod_Helper;
using CloneWars;
using UnityEngine;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons.Behaviors;

[assembly: MelonInfo(typeof(CloneWars.CloneWars), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CloneWars;

public class CloneWars : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CloneWars>("Clone Wars Mod Has loaded!");
        ModHelper.Msg<CloneWars>("Message Me On Discord @AnakinSkywalker066#3694 If There Are Any Bugs");
    }

    
}

  