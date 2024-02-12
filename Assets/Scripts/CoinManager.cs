using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = Progress.Inctance._playerInfo.Coins.ToString();
    }

    public void AddOne()
    {
        Progress.Inctance._playerInfo.Coins++;
        _text.text = Progress.Inctance._playerInfo.Coins.ToString();

    }

    public void SpendMoney(int value)
    {
        Progress.Inctance._playerInfo.Coins -= value;
        _text.text = Progress.Inctance._playerInfo.Coins.ToString();
    }


}
