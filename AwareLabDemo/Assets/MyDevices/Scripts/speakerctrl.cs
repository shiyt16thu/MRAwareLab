using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speakerctrl : MonoBehaviour
{
    public AudioSource audio_;
    private bool speakeron;
    private bool audioon;
    private float volume_separation = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        audio_ = GetComponent<AudioSource>();
        audio_.spatialBlend = 1.0f;
        audio_.volume = 0.5f;
        audio_.enabled = false;
        audio_.loop = true;
        speakeron = false;
        audioon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            turnonoroff();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioplayorpause();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            volumeup();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            volumedown();
        }
    }
    public void turnonoroff() //电视开关
    {
        if (speakeron)
        {
            audio_.enabled = false;
            speakeron = false;
            audioon = false;
        }
        else
        {
            audio_.enabled = true;
            speakeron = true;
            audioon = true;
        }
    }
    public void audioplayorpause() //音乐暂停或播放
    {
        if (speakeron)
        {
            if (audioon)
            {
                audio_.Pause();
                audioon = false;
            }
            else
            {
                audio_.Play();
                audioon = true;
            }
        }
    }
    public void volumeup() //音量增大
    {
        if (audioon && audio_.volume < 1)
        {
            audio_.volume += volume_separation;
        }
    }
    public void volumedown() //音量减小
    {
        if (audioon && audio_.volume != 0)
        {
            if (audio_.volume >= volume_separation)
            {
                audio_.volume -= volume_separation;
            }
            else
            {
                audio_.volume = 0;
            }
        }
    }
    public void totargetvolume(float vol) //到指定音量
    {
        if (vol >= 0 && vol <= 1)
        {
            audio_.volume = vol;
        }
    }
}
