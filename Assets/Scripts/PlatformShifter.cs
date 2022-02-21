using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShifter : MonoBehaviour
{
    private PlatformEffector2D platformEffector;

    void Start()
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            platformEffector.rotationalOffset = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            platformEffector.rotationalOffset = 180f;
        }
    }
}
