using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Unity.Towers.Behaviors.Attack;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CloneWars.Clones;

public class CloneTrooper : ModTower
{
    public override TowerSet TowerSet => TowerSet.Military;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 0;
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
        towerModel.displayScale = 25f;
        towerModel.isGlobalRange = true;
        towerModel.range = 30f;
        
        foreach (var weaponModel in towerModel.GetWeapons())
        {
            weaponModel.projectile.ApplyDisplay<BoltDisplay>();
            weaponModel.Rate = 0.5f;
            weaponModel.projectile.pierce = 10;
            weaponModel.projectile.GetDamageModel().damage = 1;
            
            weaponModel.projectile.scale = 1f;
        }
    }

    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.SniperMonkey).towerIndex;
    }
    public override bool IsValidCrosspath(int[] tiers) =>
       ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);

   
}
