using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace CloneWars.Upgrades.TopPath
{
    public class CloneCommander : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Icon5";
        public override string Icon => "Upgrade";
        public override int Cost => 42000;
        public override int Path => TOP;
        public override int Tier => 5;
        public override string Description => "Clones Troopers After A Long Journey Have Now Become An Infamous Clone Commander.(Cripple MOAB Ability!)";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var CrippleMoab = Game.instance.model.GetTowerFromId("SniperMonkey-500").GetWeapon().projectile.GetBehavior<SlowMaimMoabModel>().Duplicate();
            CrippleMoab.badDuration = 1;
            CrippleMoab.bfbDuration = 3;
            CrippleMoab.ddtDuration = 1;
            CrippleMoab.moabDuration = 5;
            CrippleMoab.zomgDuration = 2;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(CrippleMoab);
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.rate *= 2;
                weaponModel.projectile.pierce += 5;
                weaponModel.projectile.GetDamageModel().damage *= 20;
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 100, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 120, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 250, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 200, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 1, 400, false, true));

            }

        }
    }
}
