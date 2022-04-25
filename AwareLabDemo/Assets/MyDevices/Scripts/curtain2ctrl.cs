using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curtain2ctrl : MonoBehaviour
{
    public Animator ani_;
    string boolname;
    private bool curopen;
    // Start is called before the first frame update
    void Start()
    {
        ani_ = GetComponent<Animator>();
        ani_.speed = 0;
        boolname = "curtain2open";
        curopen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (curopen)
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
        curopen = true;
    }
    public void close()
    {
        if (ani_.speed == 0)
        {
            return;
        }
        ani_.SetBool(boolname, false);
        curopen = false;
    }
}
