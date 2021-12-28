using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip bouncingClip, deathClip, countdownClip, gameOverClip, goollClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void BouncingSound()
    {
        soundFX.clip = bouncingClip;
        soundFX.Play();
    }

    public void CountdownSound()
    {
        soundFX.clip = countdownClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void GoollSound()
    {
        soundFX.clip = goollClip;
        soundFX.Play();
    }
}
