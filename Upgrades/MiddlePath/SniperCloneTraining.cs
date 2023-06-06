using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.MiddlePath
{

    public class SniperCloneTraining : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Middle3";
        public override string Icon => "Upgrade";
        public override int Cost => 1500;
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override string Description => "THe Clone Begins To Train To Be A Sniper On The Front Lines(Lower Firerate, More Damage and Pierce!)";
        public override void ApplyUpgrade(TowerModel towerModel)
        {

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 10;
                weaponModel.rate -= .1f;
                weaponModel.projectile.GetDamageModel().damage += 5;

            }
        }
    }

}
