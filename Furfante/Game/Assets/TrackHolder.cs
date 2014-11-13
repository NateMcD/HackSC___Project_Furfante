using UnityEngine;
using System.Collections;

[System.Serializable]
public class TrackHolder : MonoBehaviour {

    public AudioClip explosion;
    public AudioClip laser;
    public AudioClip collapse;
    public AudioClip wind;
    public AudioClip mainClip;

    public static TrackHolder Instance;

    void Awake()
    {
        Instance = this;
    }

    void OnDestroy()
    {
        Instance = null;
    }
	
}
