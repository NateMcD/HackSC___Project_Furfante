using UnityEngine;
using System.Collections;

public class DST_Source : MonoBehaviour {

    private bool destroyed = false;
    private AutoDelete[] components;
    private AudioSource source;
    private TrackHolder th;

	
	void Start () {
        components = GetComponentsInChildren<AutoDelete>();
        source = GetComponent<AudioSource>();
        th = TrackHolder.Instance;
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();
        if (source != null)
        {
            source.clip = th.explosion;
            source.playOnAwake = false;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.spread = 500.0f;
        }
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].rigidbody != null)
            {
                components[i].rigidbody.isKinematic = true;
                components[i].rigidbody.useGravity = false;
            }
        }
	}

    public void BeginDestructionSequence()
    {
        components = GetComponentsInChildren<AutoDelete>();
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i].rigidbody != null)
            {
                components[i].rigidbody.isKinematic = false;
                components[i].rigidbody.useGravity = true;
            }
        }
        ApplyPhysics();
        PlaySound();
    }

    private void ApplyPhysics()
    {
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] != null)
            {
                if (components[i].rigidbody != null)
                {
                    components[i].rigidbody.AddForce(Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f), Random.Range(-1000.0f, 1000.0f));
                }
            }
        }
    }

    private void PlaySound()
    {
        if (th == null)
            th = TrackHolder.Instance;
        if (th != null)
        {
            source.clip = th.explosion;
            source.Play();
        }
    }
}
