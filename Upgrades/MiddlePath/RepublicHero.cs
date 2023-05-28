using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.MiddlePath
{
    public class RepublicHero : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Top";
        public override string Icon => "Upgrade";
        public override int Cost => 25000;
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override string Description => "The Republic Need A Hero A This Trooper Is Ready";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+20);
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce *= 10;
                weaponModel.rate -= .1f;
            }
        }
    }
}
