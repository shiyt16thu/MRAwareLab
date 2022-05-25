using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart_Soundsctrl : MonoBehaviour
{
    public Material material_friends;
    public Material material_baobaobashi;
    public Material _material;
    public AudioSource audio_;
    public AudioClip audio_friends;
    public AudioClip audio_baobaobashi;
    private bool TVon;
    private bool audioon;
    private float volume_separation = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _material = material_friends;
        audio_ = GetComponent<AudioSource>();
        audio_.spatialBlend = 1.0f;
        audio_.volume = 0.5f;
        audio_.enabled = false;
        audio_.loop = true;
        TVon = false;
        audioon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            turnonoroff();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            audioplayorpause();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            volumeup();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            volumedown();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Switch_pattern();
        }
    }
    public void Switch_pattern()
    {
        if (!TVon)
        {
            return;
        }
        if (_material == material_friends)
        {
            _material = material_baobaobashi;
            this.GetComponent<Renderer>().sharedMaterial = _material;
            audio_.clip = audio_baobaobashi;
            if (audioon)
            {
                audio_.Play();
            }
        }
        else
        {
            _material = material_friends;
            this.GetComponent<Renderer>().sharedMaterial = _material;
            audio_.clip = audio_friends;
            if (audioon)
            {
                audio_.Play();
            }
        }
    }
    public void turnonoroff() //电视开关
    {
        if (TVon)
        {
            _material.color = Color.black;
            audio_.enabled = false;
            TVon = false;
            audioon = false;
            //            material_.DisableKeyword("_EMISSION");开一点发光更像真的电视
        }
        else
        {
            _material.color = Color.white;
            audio_.enabled = true;
            TVon = true;
            audioon = true;
            //            material_.EnableKeyword("_EMISSION");
        }
    }
    public void audioplayorpause() //音乐暂停或播放
    {
        if (TVon)
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
