using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject[] explosionEffect;
    public static EffectManager effectManager;
    private void Awake()
    {
        effectManager = this;
    }

    public void PlayEffect(Transform transform)
    {
        Instantiate(explosionEffect[0],transform.position,transform.rotation);
    }

    public void PlayBossEffect(Transform transform)
    {
        Instantiate(explosionEffect[1], transform.position, transform.rotation);
    }
}
