using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;


namespace CloneWars.Upgrades.BottomPath
{
    public class ArmourUpgrades : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "TopUpPortait";
        public override string Icon => "Upgrade";
        public override int Cost => 1000;
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override string Description => "Lord Sidious Has Now Given The Clones Upgraded Armor(Regen Lives!)";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+10);
            var HealthIncrease = Game.instance.model.GetTowerFromId("Benjamin 6").GetDescendant<LifeRegenModel>().Duplicate();
            HealthIncrease.regenAmount = 1;
            HealthIncrease.overRegenAmount = 999;
            var attackModel = towerModel.GetAttackModel();
            attackModel.AddBehavior(HealthIncrease);

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.rate *= .6f;
            }

        }
    }
}
