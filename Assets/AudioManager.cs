using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip bgmSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip coinCollectSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip carHornSound;
    [SerializeField] AudioClip countdownSound;

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource coinCollect;
    [SerializeField] AudioSource death;
    [SerializeField] AudioSource carHorn;
    [SerializeField] AudioSource countdown;

    private void Start() {
        countdown.PlayOneShot(countdownSound);
        //play bgm after countdown stop
        bgm.clip = bgmSound;
        bgm.PlayDelayed(4.0f);
        
    }

    public void PlayJumpSound()
    {
        jump.PlayOneShot(jumpSound);
    }

    public void PlayCoinCollectSound()
    {
        coinCollect.PlayOneShot(coinCollectSound);
    }

    public void PlayDeathSound()
    {
        death.PlayOneShot(deathSound);
    }

    public void PlayCarHornSound()
    {
        carHorn.PlayOneShot(carHornSound);
    }
}

    
