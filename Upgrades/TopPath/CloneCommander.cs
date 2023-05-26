using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace CloneWars.Upgrades.TopPath
{
    public class CloneCommander : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Top5";
        public override string Icon => "CloneUpgrade";
        public override int Cost => 35000;
        public override int Path => TOP;
        public override int Tier => 5;
        public override string Description => "Clones Troopers After A Long Journey Have Now Become A Infamous Clone Commander";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var KnockbackMarine = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
            KnockbackMarine.chance = 0.05f;
            KnockbackMarine.affectMoab = true;
            KnockbackMarine.distanceMin = 30;
            KnockbackMarine.distanceMax = 60;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(KnockbackMarine);
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 5;
                weaponModel.projectile.GetDamageModel().damage += 5;
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 55, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 80, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 230, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 190, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 1, 390, false, true));
                
            }

        }
    }
}
