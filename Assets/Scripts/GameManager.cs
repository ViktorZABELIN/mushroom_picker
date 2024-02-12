using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] CoinManager _coinManager;

    [SerializeField] GameObject soundOffButton;
    [SerializeField] GameObject soundOnButton;
    [SerializeField] SoundEffect soundEffect;


    [DllImport("__Internal")]
    private static extern void RateYandexGame();

    [DllImport("__Internal")]
    private static extern void WriteToConsole(string data);

    public void Update()
    {
        _levelText.text = string.Format("Level {0}", Progress.Inctance._playerInfo.Level);
    }

    public void Play()
    {
        startMenu.SetActive(false);
        FindObjectOfType<PlayerBeholder>().Play();
    }

    public void FinishWndow()
    {
        _finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        Progress.Inctance._playerInfo.Level++;
        SceneManager.LoadScene(0);
        if (Progress.Inctance._playerInfo.Sound == 0)
        {
            SoundOff();
        }
        else
        {
            SoundOn();
        }
        Progress.Inctance.SaveData();
    }

    public void RateGame()
    {
        RateYandexGame();
    }

    public void SaveData()
    {
        Progress.Inctance.SaveData();
    }

    public void SoundOff()
    {
        Progress.Inctance._playerInfo.Sound = 0;
        soundOffButton.SetActive(false);
        soundOnButton.SetActive(true);
        soundEffect.GameMusicOff();

    }

    public void SoundOn()
    {
        Progress.Inctance._playerInfo.Sound = 1;
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
        soundEffect.GameMusicOn();
    }

}
