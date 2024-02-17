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
    [SerializeField] GameManager GameManager;
    [SerializeField] PlayerModifi PlayerModifi;

    public bool IsRate = false;

    [DllImport("__Internal")]
    private static extern void SaveExternData(string data);

    [DllImport("__Internal")]
    private static extern void LoadExternData();

    [DllImport("__Internal")]
    private static extern void WriteToConsole(string data);

    public PlayerInfo _playerInfo;

    public static Progress Inctance;

    public void SaveData(string log = "")
    {
        WriteToConsole(string.Format("SAVE DATA: {0}", log));
        string jsonString = JsonUtility.ToJson(Inctance._playerInfo);
        WriteToConsole(string.Format("SAVE DATA JSON: {0}", jsonString));
        SaveExternData(jsonString);
    }

    public void SetPlayerData(string value)
    {
        Inctance._playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        WriteToConsole("SetPlayerData: " + JsonUtility.ToJson(Inctance._playerInfo));

        if (Inctance._playerInfo.Sound == 0)
        {
            GameManager.SoundOff();
        }
        else
        {
            GameManager.SoundOn();
        }

        PlayerModifi.SetWidthHeight(Inctance._playerInfo.Width, Inctance._playerInfo.Heigth);
    }

    public void IsCanRate(bool isRate)
    {
        IsRate = isRate;
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
