using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace CloneWars.Upgrades.TopPath
{
    public class CloneSergeant : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Sarge";
        public override string Icon => "Upgrade";
        public override int Cost => 1250;
        public override int Path => TOP;
        public override int Tier => 2;
        public override string Description => "Clones Corporals Have Gain The Trust Of The Galactic Republic. Now See Camouflaged Enemies.";
        public override void ApplyUpgrade(TowerModel towerModel)
        {

            towerModel.AddBehavior(new OverrideCamoDetectionModel("CamoDetect", true));
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 5;
                weaponModel.projectile.GetDamageModel().damage += 5;
                weaponModel.rate *= .8f;
            }
        }
    }
}
