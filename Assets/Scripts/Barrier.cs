using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    [SerializeField] GameObject _bricksEffectPrefab;

    private SoundEffect _briksSound;

    private void Start()
    {
        _briksSound = GameObject.Find("Global audio").GetComponent<SoundEffect>();
    }

    public void OnTriggerEnter (Collider other)
    {
        PlayerModifi playerModifi = other.attachedRigidbody.GetComponent<PlayerModifi>();

        if (playerModifi)
        { 
            playerModifi.HitBarrier();
            _briksSound.BriksSound();
            Destroy(gameObject);
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
        }

    }

}
