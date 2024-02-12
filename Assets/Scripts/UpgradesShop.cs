using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesShop : MonoBehaviour
{
    [SerializeField] CoinManager _coinManager;

    PlayerModifi _playerModifi;
    
    private void Start()
    {
        _playerModifi = FindObjectOfType<PlayerModifi>();
    }

    public void BuyWight()
    {
        if (Progress.Inctance._playerInfo.Coins >= 20)
        {
            _coinManager.SpendMoney(20);
            Progress.Inctance._playerInfo.Width += 25;
            _playerModifi.SetWight(Progress.Inctance._playerInfo.Width);
        }
    }

    public void BuyHeight()
    {
        if (Progress.Inctance._playerInfo.Coins >= 20)
        {
            _coinManager.SpendMoney(20);
            Progress.Inctance._playerInfo.Heigth += 25;
            _playerModifi.SetHeight(Progress.Inctance._playerInfo.Heigth);
        }
    }
}
