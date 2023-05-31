using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace CloneWars.Upgrades.TopPath
{
    public class CloneLieutenant : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Cody";
        public override string Icon => "Upgrade";
        public override int Cost => 2250;
        public override int Path => TOP;
        public override int Tier => 3;
        public override string Description => "Clones Sergeants Are Now Able To Destroy Enemy With Ease.";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+5);
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 10;
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 4, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 4, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 4, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 4, false, true));
            }
        }
    }
}
