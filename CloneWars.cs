using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
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

    public override void OnMainMenu()
    {
        GameObject BlasterSound = Object.Instantiate(new GameObject(), GameObject.Find("Canvas").transform);
        BlasterSound.name = "CloneFireSound";
        BlasterSound.AddComponent<AudioSource>();
        ModHelper.Msg<CloneWars>("Blaster Sounds Created");
        GameObject SelectClone = Object.Instantiate(new GameObject(), GameObject.Find("Canvas").transform);
        SelectClone.name = "CloneSelection";
        SelectClone.AddComponent<AudioSource>();
        ModHelper.Msg<CloneWars>("Selection Sound Created");
        GameObject PlaceClone = Object.Instantiate(new GameObject(), GameObject.Find("Canvas").transform);
        PlaceClone.name = "PlaceClone";
        PlaceClone.AddComponent<AudioSource>();
        ModHelper.Msg<CloneWars>("Placement Sound Created");
    }

    public override void OnWeaponFire(Weapon weapon)
    {

        if (weapon.attack.tower.model.name.Contains("Clone"))
        {
            GameObject.Find("CloneFireSound").GetComponent<AudioSource>().Stop();
            GameObject.Find("CloneFireSound").GetComponent<AudioSource>().clip = ModContent.GetAudioClip<CloneWars>("DC15-" + new Random().Next(1, 5));
            GameObject.Find("CloneFireSound").GetComponent<AudioSource>().volume = ModSoundSetting;
            weapon.attack.tower.Node.graphic.GetComponent<Animator>().StopPlayback();
            weapon.attack.tower.Node.graphic.GetComponent<Animator>().Play("Fire");
            GameObject.Find("CloneFireSound").GetComponent<AudioSource>().Play();
        }
    }

    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.model.name.Contains("Clone"))
        {
            GameObject.Find("PlaceClone").GetComponent<AudioSource>().Stop();
            GameObject.Find("PlaceClone").GetComponent<AudioSource>().clip = ModContent.GetAudioClip<CloneWars>("ClonePlace" + new Random().Next(1, 5));
            GameObject.Find("PlaceClone").GetComponent<AudioSource>().volume = ModSoundSetting;
            GameObject.Find("PlaceClone").GetComponent<AudioSource>().Play();
        }
    }

    public override void OnTowerSelected(Tower tower)
    {

        if (tower.model.name.Contains("Clone"))
        {
            GameObject.Find("CloneSelection").GetComponent<AudioSource>().Stop();
            GameObject.Find("CloneSelection").GetComponent<AudioSource>().clip = ModContent.GetAudioClip<CloneWars>("Select" + new Random().Next(1, 6));
            GameObject.Find("CloneSelection").GetComponent<AudioSource>().volume = ModSoundSetting;
            GameObject.Find("CloneSelection").GetComponent<AudioSource>().Play();
        }
    }

    private static readonly ModSettingDouble ModSoundSetting = new(1)
    {
        displayName = "SoundEffects",
        slider = true,
        min = .01,
        max = 1,
        requiresRestart = false,
    };

}
    


    


