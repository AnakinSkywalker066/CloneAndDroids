﻿using MelonLoader;
using BTD_Mod_Helper;
using CloneWars;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppSteamNative;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models;

[assembly: MelonInfo(typeof(CloneWars.CloneWars), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CloneWars;

public class CloneWars : BloonsTD6Mod
{   
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CloneWars>("Clone Wars Mod Has loaded!");
        ModHelper.Msg<CloneWars>("Message Me If There Are Any Bugs");
    }
    public override void OnWeaponFire(Weapon weapon)
    {   
        base.OnWeaponFire(weapon);
        weapon.attack.tower.Node.graphic.gameObject.GetComponent<Animator>().SetBool("isAttacking", true);
        if (weapon.attack.isPaused)
        {
            weapon.attack.tower.Node.graphic.gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
        }
        
    }
    
}
