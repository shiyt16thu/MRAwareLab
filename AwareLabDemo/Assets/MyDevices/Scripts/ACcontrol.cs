using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    private int _temp = 25;
    private int _mode = 4;
    private bool _power=false;
    GameObject _ACtemptext;
    TMP_Text _temptext;
    GameObject _ACmodetext;
    TMP_Text _modetext;

    void Start()
    {
        _ACtemptext = GameObject.Find("ACTemptext");
        _temptext = _ACtemptext.GetComponent<TMP_Text>();
        _ACmodetext = GameObject.Find("ACModetext");
        _modetext = _ACmodetext.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (_power)
            {
                _temptext.text = "";
                _modetext.text = _temptext.text;
            }
            else
            {
                _temptext.text = _temp.ToString();
                displaymode();
            }
            _power ^= true;
        }
            
        if (_power)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
                tempdown();
            if (Input.GetKeyDown(KeyCode.UpArrow))
                tempup();
            if (Input.GetKeyDown(KeyCode.PageUp))
                switchmode();
        }
    }

    public void tempup()
    {
        if(_temp < 30)_temp++;
        _temptext.text = _temp.ToString();
    }
    public void tempdown()
    {
        if (_temp > 18) _temp--;
        _temptext.text = _temp.ToString();

    }
    public void switchmode()
    {
        if (++_mode > 4) _mode -= 5;
        displaymode();
    }
    public void displaymode()
    {
        if (_mode == 0)
            _modetext.text = "COOL";
        else if (_mode == 1)
            _modetext.text = "HEAT";
        else if (_mode == 2)
            _modetext.text = "DRY";
        else if (_mode == 3)
            _modetext.text = "WIND";
        else if (_mode == 4)
            _modetext.text = "AUTO";
    }
}
