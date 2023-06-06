using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.BottomPath
{
    public class JediTakeOver : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Middle4";
        public override string Icon => "Upgrade";
        public override int Cost => 5000;
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override string Description => "Lord Sidious Now Has Complete Control Of The Republic(More Range And Damage!)";
        public override void ApplyUpgrade(TowerModel towerModel)
        {

            towerModel.IncreaseRange(+10);

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 10;
            }
        }
    }
}
