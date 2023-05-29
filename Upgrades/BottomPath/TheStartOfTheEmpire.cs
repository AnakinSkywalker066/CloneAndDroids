﻿using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace CloneWars.Upgrades.BottomPath
{
    public class TheStartOfTheEmpire : ModUpgrade<CloneTrooper>
    {
        public override string Portrait => "Bottom1";
        public override string Icon => "Upgrade";
        public override int Cost => 750;
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override string Description => "Lord Sidious Places A Inhibitor Chip In All Clones At Birth";
        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.IncreaseRange(+5);
        }
    }
}
