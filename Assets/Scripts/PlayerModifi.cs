using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifi : MonoBehaviour
{
    [SerializeField] int _weight;
    [SerializeField] int _height;

    float _weightMultiplier = 0.0005f;
    float _hightMultiplier = 0.01f;

    [SerializeField] Renderer _render;

    [SerializeField] Transform _topSpine;
    [SerializeField] Transform _bottomSpine;

    [SerializeField] Transform _collaiderTransform;

    [SerializeField] SoundEffect _soundEffect;


    private void Start()
    {
        SetWight(Progress.Inctance._playerInfo.Width);
        SetHeight(Progress.Inctance._playerInfo.Heigth);
    }

    void Update()
    {
        ;
    }

    public void SetWidthHeight(int width, int height)
    {
        _weight = width;
        _height = height;
        UpdateWight();
        UpdateHeight();
    }

    public void AddWeight(int value)
    {
        _weight += value;
        UpdateWight();
         _soundEffect.PumpSound();
    }

    public void AddHight(int value)
    {
        _height += value;
        UpdateHeight();
        _soundEffect.PumpSound();
    }

    public void SetWight(int value)
    {
        _weight = value;
        UpdateWight();
    }

    public void SetHeight(int value)
    {
        _height = value;
        UpdateHeight();
    }

    public void HitBarrier()
    {
        if (_height > 0)
        {
            _height -= 25;
            UpdateHeight();
        }
        else if (_weight > 0)
        {
            _weight -= 25;
            UpdateWight();
        }
        else
        {
            Die();
        }

    }

    void UpdateWight()
    {
        _render.material.SetFloat("_PushValue", _weight * _weightMultiplier);
        
    }

    void UpdateHeight()
    {
        float offsetY = _height * _hightMultiplier + 0.17f;
        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _collaiderTransform.localScale = new Vector3(1, 1.84f + _height * _hightMultiplier, 1);
    }

    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().FinishWndow();
    }


}
