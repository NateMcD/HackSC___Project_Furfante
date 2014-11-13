using UnityEngine;
using System.Collections;

[System.Serializable]
public class AddMeshColliders : MonoBehaviour {

    public bool shouldAddColliders = false;
    public GameObject smo;
	// Use this for initialization
	void Start () {
#if !UNITY_EDITOR
        shouldAddColliders = true;
#endif
        if (shouldAddColliders)
        {
            Transform[] children = GetComponentsInChildren<Transform>();
            foreach (Transform t in children)
            {
                if (t.GetComponent<MeshCollider>() == null)
                {
                    t.gameObject.AddComponent<MeshCollider>();
                    //t.gameObject.AddComponent<DST_Source>();
                }
                if (t.gameObject.name.Contains("poly") || t.gameObject.name.Contains("walk") ||t.gameObject.name.Contains("block") ||t.gameObject.name.Contains("road") || t.gameObject.name.Contains("ground"))
                { }
                else
                {
                    //t.gameObject.AddComponent<DST_Source>();
                    t.gameObject.AddComponent<SMOKEZ>();
                    GameObject smokes = Instantiate(smo) as GameObject;
                    smokes.transform.parent = t.transform;
                    smokes.transform.position= Vector3.zero;
                    smokes.SetActive(false);
                }
                
                    
            }
        }
        else
            Debug.Log("This is not setting up the colliders!");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
