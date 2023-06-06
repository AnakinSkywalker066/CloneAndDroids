using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.MiddlePath
{
    public class CloneCadet : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Middle1";
        public override string Icon => "Upgrade";
        public override int Cost => 1000;
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override string Description => "This Clone Is Just Getting Started(Lower Fire Rate, More Pierce!)";
        public override void ApplyUpgrade(TowerModel towerModel)
        {

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 10;
                weaponModel.rate -= .1f;
            }
        }
    }
}
