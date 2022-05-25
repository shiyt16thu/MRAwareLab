using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class only_lightctrl : MonoBehaviour
{
    private float BRIGHT_1 = 1;
    private float BRIGHT_2 = 1.5f;
    private float BRIGHT_3 = 2;
    private float BRIGHT_separation = 0.5f;
    public Light light_;
    // Start is called before the first frame update
    void Start()
    {
        light_ = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))  //点击鼠标左键开关灯
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
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            Debug.Log("space");
        //        }
    }
    public void ctrllight()//开关
    {
        if (light_.enabled)
        {
            light_.enabled = false;
        }
        else
        {
            light_.enabled = true;
        }
    }
    public void brightup()//调高亮度
    {
        if (light_.enabled == true)
        {
            if (light_.intensity != BRIGHT_3)
            {
                light_.intensity += BRIGHT_separation;
            }
        }
    }
    public void brighdown()//调低亮度
    {
        if (light_.enabled == true)
        {
            if (light_.intensity != BRIGHT_1)
            {
                light_.intensity -= BRIGHT_separation;
            }
        }
    }
    public void bright_1()//亮度调为1档
    {
        if (light_.enabled == true)
        {
            if (light_.intensity != BRIGHT_1)
            {
                light_.intensity = BRIGHT_1;
            }
        }
    }
    public void bright_2()//亮度调为2档
    {
        if (light_.enabled == true)
        {
            if (light_.intensity != BRIGHT_2)
            {
                light_.intensity = BRIGHT_2;
            }
        }
    }
    public void bright_3()//亮度调为3档
    {
        if (light_.enabled == true)
        {
            if (light_.intensity != BRIGHT_3)
            {
                light_.intensity = BRIGHT_3;
            }
        }
    }
}
