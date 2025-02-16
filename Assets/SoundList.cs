using AudioSystem;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    #region Singleton

    public static SoundList instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Instance of" + name + " is already in scene.");
            Destroy(this);
        }
        else instance = this;
    }

    #endregion

    public SoundData music;

    public void PlaySound(SoundData sound)
    {
        SoundManager.Instance.CreateSoundBuilder()
            .WithRandomPitch()
            .WithPosition(transform.position)
            .Play(sound);
    }

    public void Music()
    {
        SoundManager.Instance.CreateSoundBuilder()
        .Play(music);
    }

    public void Start()
    {
       // Music();
    }
}
