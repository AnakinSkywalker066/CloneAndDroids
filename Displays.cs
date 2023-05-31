using BTD_Mod_Helper.Api.Display;

namespace CloneWars
{
    public class CloneDisplay : ModCustomDisplay
    {
        public override string AssetBundleName => "trooper";
        public override string PrefabName => "CloneTrooper";
    }

    public class BoltDisplay : ModCustomDisplay
    {
        public override string AssetBundleName => "clone";
        public override string PrefabName => "Bolt";
    }

}
