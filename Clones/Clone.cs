using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers;
using UnityEngine;

namespace CloneWars.Clones;

public class Clone : ModTower
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
        
        ///^^^ Tower Place Sound
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = (BloonProperties)1;
        towerModel.ApplyDisplay<CloneDisplay>();
        towerModel.GetDescendant<DamageModel>().immuneBloonProperties = 0;
        towerModel.GetBehavior<DisplayModel>().scale = towerModel.GetBehavior<DisplayModel>().scale * 1f;
        //Scale required for custom models to be recognized
        towerModel.displayScale = 25f;
        towerModel.isGlobalRange = true;
        foreach (var weaponModel in towerModel.GetWeapons())
        {
            weaponModel.Rate = 0.5f;
            weaponModel.projectile.pierce = 10;
            weaponModel.projectile.GetDamageModel().damage = 1;
            weaponModel.projectile.scale = 1f;
            weaponModel.animateOnMainAttack = true;
        }
    }
    
    public static void OnWeaponFire(Tower tower)
    {
        if (tower.towerModel.name.Contains("Clone"))
        {   
            tower.Node.graphic.GetComponent<Animator>().StopPlayback();
            tower.Node.graphic.GetComponent<Animator>().Play("Fire");
        }
    }
    
}
