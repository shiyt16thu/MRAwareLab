using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweeperctrl : MonoBehaviour
{
    private bool power;
    private bool running;
    private GameObject light_;
    private Material lightmat;
    private Animator ani_;
    // Start is called before the first frame update
    void Start()
    {
        light_ = GameObject.Find("sweeperlight");

        lightmat = light_.GetComponent<MeshRenderer>().material;
        ani_ = GetComponent<Animator>();
        ani_.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            powerbutton();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            runbutton();
        }
    }
    public void powerbutton()
    {
        if (power)
        {
            lightmat.DisableKeyword("_EMISSION");
            if (running)
            {
                ani_.speed = 0;
                running = false;
            }
        }
        else
            lightmat.EnableKeyword("_EMISSION");
        power ^= true;
    }
    public void runbutton()
    {
        if (!power)
        {
            return;
        }
        if (running)
        {
            running = false;
            ani_.speed = 0;
        }
        else
        {
            running = true;
            ani_.speed = 1;
        }
    }
}
