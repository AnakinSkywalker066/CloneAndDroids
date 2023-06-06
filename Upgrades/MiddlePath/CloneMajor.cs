using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.MiddlePath
{
    public class CloneMajor : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Top";
        public override string Icon => "Upgrade";
        public override int Cost => 1250;
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override string Description => "This Soldier Is Good At Following Orders...(Lower Fire Rate + More Pierce!)";
        public override void ApplyUpgrade(TowerModel towerModel)
        {

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 5;
                weaponModel.rate -= .1f;

            }
        }
    }
}
