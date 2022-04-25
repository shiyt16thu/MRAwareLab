using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart_sensorctrl : MonoBehaviour
{
    public GameObject player;
    public Bounds sensor_area;
    public bool judge_inarea;
    // Start is called before the first frame update
    void Start()
    {
        sensor_area = this.GetComponent<BoxCollider>().bounds;
        judge_inarea = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player_pos = player.transform.position;
        if (!judge_inarea && sensor_area.Contains(player_pos))
        {
            Debug.Log("player enter");
            judge_inarea = true;
        }
        else if (judge_inarea && !sensor_area.Contains(player_pos))
        {
            Debug.Log("player quit");
            judge_inarea = false;
        }
    }
}
