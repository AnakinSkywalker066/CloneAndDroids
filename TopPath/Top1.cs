using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.TopPath
{
    public class Comando : ModUpgrade<CloneTrooper>
    {
        public override int Cost => 750;
        public override int Path => TOP;
        public override int Tier => 1;
        public override string Description => "Throws two cards at a time";
        public override void ApplyUpgrade(TowerModel towerModel)
        { 
            
        }
        
    }
}
