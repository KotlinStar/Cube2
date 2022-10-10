
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    private AudioSource _backgroundSound;

    void Start()
    {
        _backgroundSound = GetComponent<AudioSource>();
    }

    public void LevelSound (float volume)
    {
        _backgroundSound.volume = volume/100;
    }
}
