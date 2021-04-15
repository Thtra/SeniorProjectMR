using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysicsEnabler : MonoBehaviour
{
    private SphereCollider myCollider;
    // Start is called before the first frame update

    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        myCollider = PolyImport.GetComponent<SphereCollider>();
        if (Input.GetKeyUp("up"))
        {
            myCollider.enabled = !myCollider.enabled;
        }
    }
}
