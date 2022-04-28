using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundNames{
    Fire,
    Explosion
}

public class SoundMenager : MonoBehaviour
{
    [System.Serializable]
    private class Sound
    {
        public SoundNames Name;
        public float Volume = 1;
        public AudioSource Source;
    }

    [SerializeField] private Sound[] Sounds;

    public static SoundMenager SingleTone { get; private set; }

    private void Awake()
    {
        if (SingleTone != null) Debug.LogError("SingleToneExeption");
        SingleTone = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) PlaySoundByName(SoundNames.Fire, 1);
        if (Input.GetKeyDown(KeyCode.Y)) PlaySoundByName(SoundNames.Explosion, 1);
    }

    public void PlaySoundByName(SoundNames name, float volume = 1)
    {
        foreach (var item in Sounds)
        {
            if(item.Name == name)
            {
                item.Source.volume = item.Volume * volume;
                item.Source.Play();
                return;
            }
        }
    }
}
