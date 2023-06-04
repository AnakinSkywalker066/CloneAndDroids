using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace CloneWars.Upgrades.BottomPath
{
    public class Order66 : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Bottom1";
        public override string Icon => "Upgrade";
        public override int Cost => 66000;
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override string Description => "Order 66 Has Now Be Received! No MOAB Class Bloon Stands A Chance";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+10);
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.rate -= .1f;
                weaponModel.projectile.pierce *= 50;
                weaponModel.projectile.scale = 2;
                weaponModel.projectile.GetDamageModel().damage *= 60;
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 200, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 220, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 350, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 300, false, true));
                weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bad", "Bad", 1, 500, false, true));

            }
        }
    }
}
