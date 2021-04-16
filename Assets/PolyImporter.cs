using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyToolkit;
public class PolyImporter : MonoBehaviour
{

    [SerializeField] public string polyAssetLink = "Enter Poly Asset Link Here";
    [SerializeField] public float ImportSize = .2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject PolyImport
    {

        get
        {
            return GameObject.Find("PolyImport");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick) == true)
        {
            Debug.Log("Requesting asset");
            PolyApi.GetAsset("assets/" + polyAssetLink, GetAssetCallback);

        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.99f)
        {
            Destroy(this.PolyImport);
        }
    }

    private void GetAssetCallback(PolyStatusOr<PolyAsset> result)
    {
        Debug.Log("Asset imported");

        PolyImportOptions options = PolyImportOptions.Default();
        options.rescalingMode = PolyImportOptions.RescalingMode.FIT;
        options.desiredSize = ImportSize;

        PolyApi.Import(result.Value, options, ImportAssetCallback);
    }

    private void ImportAssetCallback(PolyAsset asset, PolyStatusOr<PolyImportResult> result)
    {
        result.Value.gameObject.AddComponent<ManipulatedObject>();
        result.Value.gameObject.AddComponent<Rigidbody>().useGravity = false;
        result.Value.gameObject.AddComponent<SphereCollider>();
    }
}
