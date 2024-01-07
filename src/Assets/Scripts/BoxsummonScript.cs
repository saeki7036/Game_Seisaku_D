using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class BoxsummonScript : MonoBehaviour
{
    public GameObject Box;

    public int Max_Value = 2;
    public float Next_Box_Time = 15f;

    private int Current_Value;
    private float Interval;
    private bool Interval_Check;

    // Start is called before the first frame update
    void Start()
    {
        Current_Value = Max_Value;
        Interval_Check = true;
        Interval = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Interval_Check && Next_Box_Time < Interval) 
        {
            Interval_Check = true;
            Interval = 0f;
        }
        else if(!Interval_Check && Next_Box_Time >= Interval)
            Interval += Time.deltaTime;

        if (Gamepad.current.xButton.wasPressedThisFrame)
        {
            if(Current_Value > 0 && Interval_Check)
            {
                Interval_Check = false;
                Current_Value--;
                GameObject box = Instantiate(Box, new Vector3(transform.position.x, 0f, transform.position.z - 1.2f), Quaternion.identity);
            }
        }
    }
}
