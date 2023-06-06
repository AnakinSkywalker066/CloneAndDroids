using BTD_Mod_Helper;
using CloneWars;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Unity.Audio;
using Il2CppInterop.Runtime.Injection;
using MelonLoader;
using UnityEngine;
using static BTD_Mod_Helper.Api.ModContent;
[assembly: MelonInfo(typeof(CloneWars.CloneWars), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CloneWars;

public class CloneWars : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ClassInjector.RegisterTypeInIl2Cpp<CloneSound>();
    }

    public override void OnWeaponFire(Weapon weapon)
    {

        if (weapon.attack.tower.model.name.Contains("Clone"))
        {
            weapon.attack.tower.Node.graphic.GetComponent<Animator>().StopPlayback();
            weapon.attack.tower.Node.graphic.GetComponent<Animator>().Play("Fire");
            CloneSound.StopSound();
            CloneSound.PlaySound("DC15-" + new System.Random().Next(1, 5));
        }
    }

    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.model.name.Contains("Clone"))
        {
            CloneSound.StopSound();
            CloneSound.PlaySound("ClonePlace" + new System.Random().Next(1, 5));
        }
    }

    public override void OnTowerSelected(Tower tower)
    {

        if (tower.model.name.Contains("Clone"))
        {
            CloneSound.StopSound();
            CloneSound.PlaySound("Select" + new System.Random().Next(1, 6));
        }
    }

    public override void OnAudioFactoryStart(AudioFactory audioFactory)
    {
        var bundle = GetBundle<CloneWars>("blaster");
        var bundleRequest = bundle.LoadAllAssetsAsync<AudioClip>();
        foreach (UnityEngine.Object asset in bundleRequest.allAssets)
        {
            audioFactory.RegisterAudioClip(asset.name, asset.Cast<AudioClip>());
        }
    }
}