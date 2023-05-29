using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace CloneWars.Upgrades.BottomPath
{
    public class TheGoodSoldier : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Top";
        public override string Icon => "Upgrade";
        public override int Cost => 2250;
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override string Description => "This Good Soldier Follows Orders";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(-5);
            
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 5;
            }
        }
    }
}
