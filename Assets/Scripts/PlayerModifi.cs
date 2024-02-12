using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModifi : MonoBehaviour
{
    [SerializeField] int _weight;
    [SerializeField] int _hight;

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
        float offsetY = _hight * _hightMultiplier + 0.17f;
        _topSpine.position = _bottomSpine.position + new Vector3(0, offsetY, 0);
        _collaiderTransform.localScale = new Vector3(1, 1.84f + _hight * _hightMultiplier, 1);

       // if (Input.GetKeyDown(KeyCode.W))
       // {
          //  AddWeight(20);
       // }

       // if (Input.GetKeyDown(KeyCode.S))
       // {
          //  AddHight(20);
       // }
    }

    public void AddWeight(int value)
    {
        _weight += value;
        UpdateWight();
        if (value > 0)
        {
            _soundEffect.PumpSound();
        }
    }

    public void AddHight(int value)
    {
        _hight += value;
        if (value > 0)
        {
            _soundEffect.PumpSound();
        }
    }

    public void SetWight(int value)
    {
        _weight += value;
        UpdateWight();
        if (value > 0)
        {
            _soundEffect.PumpSound();
        }
    }

    public void SetHeight(int value)
    {
        _hight += value;
        if (value > 0)
        {
            _soundEffect.PumpSound();
        }
    }

    public void HitBarrier()
    {
        if (_hight > 0)
        {
            _hight -= 25;
            Debug.Log("Высота изменилась");
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

    void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().FinishWndow();
    }


}
