using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightChanger : MonoBehaviour
{
    private float BRIGHT_1 = 1;
    private float BRIGHT_2 = 1.5f;
    private float BRIGHT_3 = 2;
    private float BRIGHT_separation = 0.5f;
    private float light_separation = 10f / 255f;
    private Color color_warm_separation = new Color(10f/255f, 0, 0);
    private Color color_cold_separation = new Color(0, 0, 10f / 255f);

    public Light _light;
    // Start is called before the first frame update
    void Start()
    {
        if (_light is null)
        {
            _light = GetComponent<Light>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ctrllight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bright_1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bright_2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bright_3();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            brightup();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            brighdown();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLighttempreture_warm();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLighttempreture_cold();
        }
    }


    public void ChangeLightColor(string color)
    {
        switch(color)
        {
            case "Blue":
                _light.color = Color.blue;
                break;
            case "Red":
                _light.color = Color.red;
                break;
            default:
                _light.color = Color.white;
                break;
        }
    }
    public void ChangeLighttempreture_warm()
    {
        if (_light.enabled)
        {
            if (_light.color.r + light_separation > 1 || _light.color.b - light_separation < 0)
            {
                return;
            }
            _light.color = _light.color + color_warm_separation - color_cold_separation;
        }
    }
    public void ChangeLighttempreture_cold()
    {
        if (_light.enabled)
        {
            if (_light.color.b + light_separation > 1 || _light.color.r - light_separation < 0)
            {
                return;
            }
            _light.color = _light.color + color_cold_separation - color_warm_separation;
        }
    }
    public void ctrllight()//开关
    {
        if (_light.enabled)
        {
            _light.enabled = false;
        }
        else
        {
            _light.enabled = true;
        }
    }
    public void brightup()//调高亮度
    {
        if (_light.enabled == true)
        {
            if (_light.intensity != BRIGHT_3)
            {
                _light.intensity += BRIGHT_separation;
            }
        }
    }
    public void brighdown()//调低亮度
    {
        if (_light.enabled == true)
        {
            if (_light.intensity != BRIGHT_1)
            {
                _light.intensity -= BRIGHT_separation;
            }
        }
    }
    public void bright_1()//亮度调为1档
    {
        if (_light.enabled == true)
        {
            if (_light.intensity != BRIGHT_1)
            {
                _light.intensity = BRIGHT_1;
            }
        }
    }
    public void bright_2()//亮度调为2档
    {
        if (_light.enabled == true)
        {
            if (_light.intensity != BRIGHT_2)
            {
                _light.intensity = BRIGHT_2;
            }
        }
    }
    public void bright_3()//亮度调为3档
    {
        if (_light.enabled == true)
        {
            if (_light.intensity != BRIGHT_3)
            {
                _light.intensity = BRIGHT_3;
            }
        }
    }
}
