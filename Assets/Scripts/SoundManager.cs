using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audioSourceSE;
    public AudioClip[] audioClips;

    public enum SE
    {
        Boom,
        Shoot,
        Max,
    };

    public void PlaySE(SE se)
    {
        int index = (int)se;
        audioSourceSE.PlayOneShot(audioClips[index]);
    }
}
