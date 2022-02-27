using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _power;
    private int _mode = 0;
    Material _light1, _light2,_light3, _light4;
    Animator _ani;
    void Start()
    {
        _power = false;
        on();
        _ani = GetComponent<Animator>();
        _ani.speed = 0;
        _light1 = GameObject.Find("sweeperlight (1)").GetComponent<MeshRenderer>().material;
        _light2 = GameObject.Find("sweeperlight (2)").GetComponent<MeshRenderer>().material;
        _light3 = GameObject.Find("sweeperlight (3)").GetComponent<MeshRenderer>().material;
        _light4 = GameObject.Find("sweeperlight (4)").GetComponent<MeshRenderer>().material;
        Debug.Log(_light1.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!_power)
                displaycoffee();
            else
                off();
            _power ^= true;
        }
        if (_power)
        {
            if (Input.GetKeyDown(KeyCode.M))
                makebtn();
            if (Input.GetKeyDown(KeyCode.PageDown))
                switchmodebtn();
        }
    }
    public void makebtn()
    {
        on();
        _ani.Play("coffeemove", 0, 0f);
        displaycoffee();
    }
    public void switchmodebtn()
    {
        if (++_mode > 3)
            _mode -= 4;
        displaycoffee();
    }
    public void displaycoffee()
    {
        off();
        if (_mode == 0)
            _light1.EnableKeyword("_EMISSION");
        else if (_mode == 1)
            _light2.EnableKeyword("_EMISSION");
        else if (_mode == 2)
            _light3.EnableKeyword("_EMISSION");
        else if (_mode == 3)
            _light4.EnableKeyword("_EMISSION");
    }

    private void off()
    {
        _light1.DisableKeyword("_EMISSION");
        _light2.DisableKeyword("_EMISSION");
        _light3.DisableKeyword("_EMISSION");
        _light4.DisableKeyword("_EMISSION");
    }
    private void on()
    {
        _light1.EnableKeyword("_EMISSION");
        _light2.EnableKeyword("_EMISSION");
        _light3.EnableKeyword("_EMISSION");
        _light4.EnableKeyword("_EMISSION");
    }

}
