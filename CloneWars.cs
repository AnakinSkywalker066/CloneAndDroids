using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Extensions;
using CloneWars;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using MelonLoader;
using UnityEngine;
using Random = System.Random;

[assembly: MelonInfo(typeof(CloneWars.CloneWars), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CloneWars;

public class CloneWars : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CloneWars>("Clone Wars Mod Has loaded!");
        ModHelper.Msg<CloneWars>("Message Me On Discord @AnakinSkywalker066#3694 If There Are Any Bugs");
        ModHelper.Msg<CloneWars>("This Mod Include A lot of Custom SoundEffects And Pictures");
    }

    public override void OnWeaponFire(Weapon weapon)
    {
        if (weapon.attack.tower.model.name.Contains("Clone"))
        {
            weapon.attack.tower.Node.graphic.GetComponent<Animator>().StopPlayback();
            weapon.attack.tower.Node.graphic.GetComponent<Animator>().Play("Fire");
            ModContent.GetAudioClip<CloneWars>("DC15-" + new Random().Next(1, 5)).Play();
        }
    }

    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.model.name.Contains("Clone"))
        {
            ModContent.GetAudioClip<CloneWars>("ClonePlace" + new Random().Next(1, 5)).Play();
        }
    }

    public override void OnTowerSelected(Tower tower)
    {

        if (tower.model.name.Contains("Clone"))
        {
            ModContent.GetAudioClip<CloneWars>("Select" + new Random().Next(1, 6)).Play();
        }
    }
}

