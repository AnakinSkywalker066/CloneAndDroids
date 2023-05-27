using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.TopPath
{

    public class CloneCorporal : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "TopUpPortait";
        public override string Icon => "Top";
        public override int Cost => 750;
        public override int Path => TOP;
        public override int Tier => 1;
        public override string Description => "Clones Troopers Now Have More Experience.";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+5);
            foreach(var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.rate *= .8f;
                weaponModel.projectile.pierce += 5;
                weaponModel.projectile.GetDamageModel().damage += 5;
                
            }
        }
    }
}
