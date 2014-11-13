using UnityEngine;
using System.Collections;

[System.Serializable]
public class DST : MonoBehaviour {

    void Start()
    {
        Transform[] transformers = FindObjectsOfType<Transform>();
        for (int i = 0; i < transformers.Length; i++)
        {
            if (transformers[i] != null)
            {
                if (transformers[i].gameObject.name.StartsWith("C"))
                {
                    if (transformers[i].gameObject.name.Contains("Cube"))
                    {
                        Rigidbody rb = transformers[i].gameObject.GetComponent<Rigidbody>();
                        if (rb == null)
                        {
                            rb = transformers[i].gameObject.AddComponent<Rigidbody>();
                        }
                        rb.isKinematic = true;
                        rb.useGravity = false;
                        AutoDelete ad = transformers[i].gameObject.GetComponent<AutoDelete>();
                        if (ad == null)
                        {
                            ad = transformers[i].gameObject.AddComponent<AutoDelete>();
                        }
                    }
                }
            }
        }
    }
	
}
