using Il2CppAssets.Scripts.Unity;
using MelonLoader;
using UnityEngine;

namespace CloneWars
{
    [RegisterTypeInIl2Cpp]
    public class CloneSound : MonoBehaviour
    {
        public static void PlaySound(string name)
        {
            Game.instance.audioFactory.PlaySoundFromUnity(null, name, "FX", 1, 1);
        }
        public static void StopSound()
        {
            FindObjectOfType<AudioSource>().Stop();
        }
    }
}
