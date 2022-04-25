using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smartglassctrl : MonoBehaviour
{
    private bool _transparent;
    private Material _transmat,_frostmat;
    private Shader _frostshader, _transshader;
    // Start is called before the first frame update
    void Start()
    {
        _transparent = true;
        _transshader = GetComponent<Renderer>().material.shader; 
        _frostshader = Shader.Find("Custom/smart");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            frostbtn();
    }

    public void frostbtn()
    {
        if (_transparent)
            GetComponent<Renderer>().material.shader = _frostshader;
        else 
            GetComponent<Renderer>().material.shader = _transshader;

        _transparent ^= true;
    } 
}
    
