using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Level = 1;
    public int Coins = 0;
    public int Width = 0;
    public int Heigth = 0;
    public int Sound = 1;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExternData(string data);

    [DllImport("__Internal")]
    private static extern void LoadExternData();

    public PlayerInfo _playerInfo;

    /*
    public int Level { get { return _playerInfo.Level; } set { _playerInfo.Level = value; } }
    public int Coins { get { return _playerInfo.Coins; } set { _playerInfo.Coins = value; } }
    public int Width { get { return _playerInfo.Width; } set { _playerInfo.Width = value; } }
    public int Heigth { get { return _playerInfo.Heigth; } set { _playerInfo.Heigth = value; } }
    public int Sound { get { return _playerInfo.Sound; } set { _playerInfo.Sound = value; } }
    /**/

    public static Progress Inctance;

    public void SaveData()
    {
        string jsonString = JsonUtility.ToJson(Inctance._playerInfo);
        SaveExternData(jsonString);
    }

    public void SetPlayerData(string value)
    {
        Inctance._playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

    private void Awake()
    {
        if (Inctance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Inctance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (Inctance != null)
        {
            Inctance._playerInfo = new PlayerInfo();
            LoadExternData();
        }
    }
}
