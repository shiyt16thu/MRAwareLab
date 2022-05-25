using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVctrl : MonoBehaviour
{
    public Material material_;
    public AudioSource audio_;
    private bool TVon;
    private bool audioon;
    private float volume_separation = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        material_ = GetComponent<MeshRenderer>().material;
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
        if (Input.GetKeyDown(KeyCode.O))
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
    }
    public void turnonoroff() //���ӿ���
    {
        if (TVon)
        {
            material_.color = Color.black;
            audio_.enabled = false;
            TVon = false;
            audioon = false;
//            material_.DisableKeyword("_EMISSION");��һ�㷢�������ĵ���
        }
        else
        {
            material_.color = Color.white;
            audio_.enabled = true;
            TVon = true;
            audioon = true;
//            material_.EnableKeyword("_EMISSION");
        }
    }
    public void audioplayorpause() //������ͣ�򲥷�
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
    public void volumeup() //��������
    {
        if (audioon && audio_.volume < 1)
        {
            audio_.volume += volume_separation;
        }
    }
    public void volumedown() //������С
    {
        if(audioon && audio_.volume != 0)
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
    public void totargetvolume(float vol) //��ָ������
    {
        if(vol >= 0 && vol <= 1)
        {
            audio_.volume = vol;
        }
    }
}
