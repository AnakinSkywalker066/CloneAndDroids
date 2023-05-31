using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.TopPath
{
    public class CloneCaptain : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Captain";
        public override string Icon => "Upgrade";
        public override int Cost => 5000;
        public override int Path => TOP;
        public override int Tier => 4;
        public override string Description => "Clones Troopers Now Have More Experience And Attack Faster.";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+5);
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 5;
                weaponModel.projectile.GetDamageModel().damage += 10;

            }
        }
    }
}
