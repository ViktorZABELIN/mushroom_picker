using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource _buttonClick;
    [SerializeField] AudioSource _gameMusic;
    [SerializeField] AudioSource _pumpSound;

    public void ButtonClick()
    {
        if (Progress.Inctance._playerInfo.Sound == 1) _buttonClick.Play();
    }

    public void PumpSound()
    {
        if (Progress.Inctance._playerInfo.Sound == 1) _pumpSound.Play();
    }

    public void GameMusicOn()
    {
        _gameMusic.Play();
    }

    public void GameMusicOff()
    {
        _gameMusic.Stop();
    }

}
