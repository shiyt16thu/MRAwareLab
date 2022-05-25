using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class only_materialctrl : MonoBehaviour
{
    public Material material_;
    private bool lighton;
    // Start is called before the first frame update
    void Start()
    {
        lighton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ctrllight();
        }
    }
    public void ctrllight()//¿ª¹Ø
    {
        if (lighton)
        {
            lighton = false;
            material_.DisableKeyword("_EMISSION");
        }
        else
        {
            lighton = true;
            material_.EnableKeyword("_EMISSION");
        }
    }
}
