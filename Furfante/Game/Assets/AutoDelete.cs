using UnityEngine;
using System.Collections;

public class AutoDelete : MonoBehaviour {
    Vector3 currentPos;
	// Use this for initialization
	void Start () {
        currentPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentPos != transform.position)
        {
            StartCoroutine(AutoDeleteSelf(Random.Range(30.0f, 250.0f) * (Random.Range(0.0f, 2.0f) / 2.0f)));
        }
	}

    IEnumerator AutoDeleteSelf(float f)
    {
        yield return new WaitForSeconds(f);
        if (gameObject.name.Contains("Cube"))
            gameObject.SetActive(false);
        yield return new WaitForSeconds(f);
        Destroy(gameObject);
    }
}
