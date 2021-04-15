using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairOnOff : MonoBehaviour
{
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (state == 0)
            {
                gameObject.active = true;
                state = 1;
            }
            else if (state == 1)
            {
                gameObject.active = false;
                state = 0;
            }
        }
    }
}
