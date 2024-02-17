using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource _buttonClick;
    [SerializeField] AudioSource _gameMusic;
    [SerializeField] AudioSource _pumpSound;
    [SerializeField] AudioSource _coinSound;
    [SerializeField] AudioSource _briksSound;

    public void ButtonClick()
    {
        if (Progress.Inctance._playerInfo.Sound == 1) _buttonClick.Play();
    }

    public void PumpSound()
    {
        if (Progress.Inctance._playerInfo.Sound == 1) _pumpSound.Play();
    }

    public void CoinSound()
    {
        if (Progress.Inctance._playerInfo.Sound == 1) _coinSound.Play();
    }
    
    public void BriksSound()
    {
        if (Progress.Inctance._playerInfo.Sound == 1) _briksSound.Play();
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
