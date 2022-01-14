using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, -0.005f, 0);
        if(transform.position.y < -10f)
        {
            transform.position = new Vector3(0, 10f, 0);
        }
    }
}
