using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    [SerializeField] GameObject _bricksEffectPrefab;


    public void OnTriggerEnter (Collider other)
    {
        PlayerModifi playerModifi = other.attachedRigidbody.GetComponent<PlayerModifi>();

        if (playerModifi)
        { 
            playerModifi.HitBarrier();
            Destroy(gameObject);
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
        }

    }

}
