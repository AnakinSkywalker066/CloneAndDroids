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
        public override string Description => "Just Like This Clone Can Remove Clankers. This Trooper Can Remove Fortifications.";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            /*var FortifyRemove = Game.instance.model.GetTowerFromId("MortarMonkey-004").GetWeapon().projectile.GetBehavior<RemoveBloonModifiersModel>().Duplicate();
            FortifyRemove.cleanseFortified = true;
            FortifyRemove.cleanseLead = false;
            FortifyRemove.cleanseRegen = false;
            FortifyRemove.cleanseCamo = false;
            var AttackModel = towerModel.GetAttackModel();
            AttackModel.weapons[0].projectile.AddBehavior(FortifyRemove);*/
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce += 10;
                
            }
        }
    }
}
