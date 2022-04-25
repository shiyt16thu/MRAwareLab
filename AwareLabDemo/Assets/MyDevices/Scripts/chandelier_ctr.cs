using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier_ctr : MonoBehaviour
{
    private float BRIGHT_1 = 1;
    private float BRIGHT_2 = 1.5f;
    private float BRIGHT_3 = 2;
    private float BRIGHT_separation = 0.5f;
    public Light light_;
    public Material material_;
    // Start is called before the first frame update
    void Start()
    {
        light_ = this.GetComponent<Light>();
        material_ = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
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
            material_.DisableKeyword("_EMISSION");
        }
        else
        {
            light_.enabled = true;
            material_.EnableKeyword("_EMISSION");
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
