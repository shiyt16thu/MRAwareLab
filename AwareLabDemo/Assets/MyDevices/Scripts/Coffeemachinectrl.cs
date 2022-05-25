using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Coffeemachinectrl : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _power;
    private int _mode=0;
    GameObject _coffee;
    Animator _ator;
    GameObject _Coffeetext;
    TMP_Text _text;
    void Start()
    {
        _power = false;
        _coffee = GameObject.Find("Coffee");
        Debug.Log(_coffee.name);
        _ator=_coffee.GetComponent<Animator>();
        _ator.speed = 0;
        _Coffeetext = GameObject.Find("Coffeemodetext");
        _text = _Coffeetext.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!_power)
                displaycoffee();
            else
                _text.text = "";
            _power ^= true;
        }
        if (_power)
        {
            if (Input.GetKeyDown(KeyCode.M))
                makebtn();
            if (Input.GetKeyDown(KeyCode.PageDown))
                switchmodebtn();
            if (Input.GetMouseButton(1))
                clear();
        }
    }
    public void makebtn()
    {
        _ator.speed = 1;
        _ator.Play("coffeemove",0,0f);
    }
    public void switchmodebtn()
    {
        if (++_mode > 3)
            _mode -= 4;
        displaycoffee();
    }
    public void displaycoffee()
    {
        if (_mode == 0)
            _text.text = "Cappuccino";
        else if (_mode == 1)
            _text.text = "Espresso";
        else if (_mode == 2)
            _text.text = "Americano";
        else if (_mode == 3)
            _text.text = "Latte";
    }
    public void clear()
    {
        _ator.Play("coffeemove", 0, 0f); 
        _ator.speed = 0;
    }

}
