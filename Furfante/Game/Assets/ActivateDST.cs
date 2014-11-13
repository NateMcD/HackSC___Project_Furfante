using UnityEngine;
using System.Collections;

public class ActivateDST : MonoBehaviour {

    Transform[] trans;
	// Use this for initialization
	void Start () {
        trans = GetComponentsInChildren<Transform>();
        Rigidbody r = null;
        foreach (Transform t in trans)
        {
            if (t != null)
            {
                r = t.gameObject.AddComponent<Rigidbody>();
                if (r != null)
                {
                    r.isKinematic = true;
                    r.useGravity = false;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("space"))
            StartExplode();
	}

    void StartExplode()
    {
        Debug.Log("COLLISION!");
        Rigidbody r = null;
        foreach (Transform t in trans)
        {
            r = t.gameObject.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.isKinematic = false;
                r.useGravity = true;
            }
        }
    }
}
