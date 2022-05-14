using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int MoveMode = 1;
    public ColliderController s;
    public Vector2 before;
    public Vector2 after;
    public Vector3 O;
    public float delta = 0f;
    // Start is called before the first frame update
    void Start()
    {
        before = transform.position;
        after = transform.Find("OO").transform.position;
        O = transform.Find("O").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        DoorMove();
    }

    void DoorMove()
    {
        if (MoveMode == 1)
        {
            if (s.isPress == true) transform.localPosition = Vector2.MoveTowards(transform.localPosition, after, 0.1f);
            else transform.localPosition = Vector2.MoveTowards(transform.localPosition, before, 0.1f);
        }
        else if(MoveMode == 2)
        {
            if (s.isPress == true)
            {
                if (delta < 90)
                {
                    delta += 1f;
                    transform.RotateAround(O, new Vector3(0, 0, 1), 1f);
                }
            }
            else
            {
                if (delta > 0)
                {
                    delta -= 1f;
                    transform.RotateAround(O, new Vector3(0, 0, 1), -1f);
                }
            }
        }
        else
        {
            if (s.isPress == true)
            {
                if (delta > -90)
                {
                    delta -= 1f;
                    transform.RotateAround(O, new Vector3(0, 0, 1), -1f);
                }
            }
            else
            {
                if (delta < 0)
                {
                    delta += 1f;
                    transform.RotateAround(O, new Vector3(0, 0, 1), 1f);
                }
            }
        }
    }
}