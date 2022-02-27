using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectorctrl : MonoBehaviour
{
    public Animator ani_;
    string boolname;
    private bool proopen;
    public bool openover;
    // Start is called before the first frame update
    void Start()
    {
        openover = false;
        ani_ = GetComponent<Animator>();
        ani_.speed = 0;
        boolname = "projectopened";
        proopen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (proopen)
            {
                close();
            }
            else
            {
                open();
            }
        }
    }

    public void open()
    {
        if (ani_.speed == 0)
        {
            ani_.speed = 1;
        }
        ani_.SetBool(boolname, true);
        proopen = true;
    }
    public void close()
    {
        if (ani_.speed == 0)
        {
            return;
        }
        ani_.SetBool(boolname, false);
        proopen = false;
        openover = false;
    }
    public void endevent()
    {
        openover = true;
    }
}
