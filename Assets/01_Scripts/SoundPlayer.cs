using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource sfx;

    public AudioClip[] bgmClips;

    public int startBgmIndex = 0;

    void Start()
    {
        ChangeBGM(startBgmIndex);
    }

    public void ChangeBGM(int index)
    {
        bgm.Stop();
        bgm.clip = bgmClips[index];
        bgm.Play();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        sfx.PlayOneShot(audioClip);
    }
}
