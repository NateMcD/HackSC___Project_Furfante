using UnityEngine;
using System.Collections;

public class ApplyDST : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform[] trans = GetComponentsInChildren<Transform>();
        foreach (Transform t in trans)
        {
            if (t.gameObject.GetComponent<Rigidbody>() == null)
            {
                t.gameObject.AddComponent<Rigidbody>();
            }

            if (t.gameObject.GetComponent<AutoDelete>() == null)
            {
                t.gameObject.AddComponent<AutoDelete>();
            }
            //t.gameObject.AddComponent<BoxCollider>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
