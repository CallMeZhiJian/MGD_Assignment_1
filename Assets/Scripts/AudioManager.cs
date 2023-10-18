using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource _BGMSource;
    public AudioSource _SFXSource;

    public AudioData[] audioData;

    public AudioClip _ButtonPressedSFX;
    public static bool isPressedButton;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isPressedButton)
        {
            PlaySFXSound(_ButtonPressedSFX);
            isPressedButton = false;
        }
    }

    public void ChangeSceneBGM()
    {
        for (int i = 0; i < audioData.Length; i++)
        {
            _BGMSource.Stop();
            if (SceneManager.GetActiveScene().name == audioData[i].name)
            {
                _BGMSource.clip = audioData[i].soundClip;
                _BGMSource.Play();
                break;
            }
        }
    }
        
    public void PlaySFXSound(AudioClip clip)
    {
        _SFXSource.PlayOneShot(clip);
    }

}

[System.Serializable]
public class AudioData
{
    public string name;
    public AudioClip soundClip;
}
