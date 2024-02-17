using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject _CoinEffect;
    [SerializeField] float speed;
    
    private SoundEffect _coinSound;

    private void Start()
    {
        _coinSound = GameObject.Find("Global audio").GetComponent<SoundEffect>();
    }

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        _coinSound.CoinSound();
        // Instantiate(_CoinEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
