using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [SerializeField] Text _playerName;
    [SerializeField] RawImage _photo;
    [SerializeField] GameObject _name;
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _button;
    [SerializeField] GameObject _rateGameButton;

    [DllImport("__Internal")]
    private static extern void ClickToPlayerData();
    
    [DllImport("__Internal")]
    private static extern void GetPlayerName();

    /// <summary>
    /// јвторизаци€ пользовател€ в игре
    /// </summary>
    public void Registartion()
    {
        ClickToPlayerData();
        GetPlayerName();
    }

    private void Start()
    {
        GetPlayerName();
    }

    /// <summary>
    /// јктивирует отображение имени игрока, если игрок авторизован
    /// </summary>
    public void ActivatePlayerName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            _name.SetActive(false);
            _button.SetActive(true);
            _text.SetActive(true);
        }
        else
        {
            _playerName.text = name;
            _name.SetActive(true);
            _button.SetActive(false);
            _text.SetActive(false);
        }
    }

    public void RateGameButtonHide()
    {
        _rateGameButton.SetActive(false);
    }

    public void SetPlayerInfo(string value)
    {
        Progress.Inctance.SetPlayerData(value);
    }

    public void IsCanRate(bool isRate)
    {
        Progress.Inctance.IsRate = isRate;
        _rateGameButton.SetActive(isRate);
    }

    //public void DataButton()
    //{
    //    GiveMePlayerData();
    //}

    //public void SetName(string name)
    //{

    //}

    //public void SetPhoto(string url)
    //{
    //    StartCoroutine(DownloadImage(url));
    //}

    //IEnumerator DownloadImage(string mediaUrl)
    //{
    //    UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
    //    yield return request.SendWebRequest();
    //    if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
    //        Debug.Log(request.error);
    //    else
    //        _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    //}
}
