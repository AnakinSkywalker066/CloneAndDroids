﻿using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using System.Collections.Generic;
using System.Linq;

namespace CloneWars;

public class CloneTrooper : ModTower
{
    public override TowerSet TowerSet => TowerSet.Military;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 500;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 0;
    public override string Portrait => "Basic";
    public override string Icon => "Icon";
    public override string Description => "FOR THE REPUBLIC. The Bloons Will Know The Power Of The Republic!";
    public override string DisplayName => "Clone Trooper";
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {

        towerModel.ApplyDisplay<CloneDisplay>();
        //Scale required for custom models to be recognized
        towerModel.displayScale = 20;
        towerModel.radius = 15;
        towerModel.range = 30;
        //Scale required for custom model to be recognized
        foreach (var weaponModel in towerModel.GetWeapons())
        {
            weaponModel.ejectX = 0.866709f;
            weaponModel.ejectZ = 24.2906f;
            weaponModel.projectile.ApplyDisplay<BoltDisplay>();
            weaponModel.Rate = 1;
            weaponModel.projectile.pierce = 10;
            weaponModel.projectile.GetDamageModel().damage = 1;
            weaponModel.projectile.scale = 1;
            weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        }
    }

    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.SniperMonkey).towerIndex;
    }

    public override bool IsValidCrosspath(int[] tiers) =>
       ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
}

