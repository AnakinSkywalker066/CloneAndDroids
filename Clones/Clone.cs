﻿using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Random = System.Random;

namespace CloneWars.Clones;

public class CloneTrooper : ModTower
{
    public override TowerSet TowerSet => TowerSet.Military;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 500;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override string Portrait => "Icon";
    public override string Icon => "Icon";
    public override bool DontAddToShop => false;
    public override string Description => "FOR THE REPUBLIC";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)1;
        towerModel.ApplyDisplay<CloneDisplay>();
        towerModel.GetDescendant<DamageModel>().immuneBloonProperties = 0;
        towerModel.GetBehavior<DisplayModel>().scale = towerModel.GetBehavior<DisplayModel>().scale * 1f;
        //Scale required for custom models to be recognized
        towerModel.displayScale = 20;
        towerModel.radius = 30;
        towerModel.range = 40;

        foreach (var weaponModel in towerModel.GetWeapons())
        {
            weaponModel.ejectX = 0.866709f;
            weaponModel.ejectZ = 25.2906f;
            weaponModel.projectile.ApplyDisplay<BoltDisplay>();
            weaponModel.Rate = .5f;
            weaponModel.projectile.pierce = 10;
            weaponModel.projectile.GetDamageModel().damage = 1;
            weaponModel.projectile.scale = .9f;
        }
        
    }

    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.SniperMonkey).towerIndex;
    }

    public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
}
[HarmonyPatch(typeof(Weapon), nameof(Weapon.SpawnDart))]
internal static class Weapon_SpawnDart
{
    [HarmonyPostfix]
    public static void Postfix(Weapon __instance)
    {
        if (__instance.attack.tower.model.name.Contains("Clone"))
        {
            __instance.attack.tower.Node.graphic.GetComponent<Animator>().StopPlayback();
            __instance.attack.tower.Node.graphic.GetComponent<Animator>().Play("Fire");
            ModContent.GetAudioClip<CloneWars>("DC15-" + new Random().Next(1, 5)).Play();  
        }
    }
}
