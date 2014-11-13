using UnityEngine;
using System.Collections;

public class ShootingLasers : MonoBehaviour {
    LineRenderer line;

    public float LaserDistance = 100;
    public float LaserCoolDown = 1.5f;

    private bool CanShoot = true;
    private AudioSource source;

    void Start() 
    {
        line = gameObject.GetComponent<LineRenderer>();
        source = gameObject.GetComponent<AudioSource>();
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();
        if (source != null)
        {
            source.playOnAwake = false;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.spread = 500.0f;
        }
        line.enabled = false;
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 50, Color.red);

        if (OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.R1) && CanShoot)
        {
            PlaySound();
            CanShoot = false;
            line.enabled = true;
            if (Physics.Raycast(ray, out hit, LaserDistance))
            {
                line.SetPosition(1, new Vector3(0, 0, hit.distance));
                //print("There is something in front of the object!");
                MeshCollider mc = hit.collider.gameObject.GetComponent<MeshCollider>();
                BoxCollider bc = hit.collider.gameObject.GetComponent<BoxCollider>();
                //Vector3 paramss = mc.bounds.size;
                //Debug.Log(hit.collider.gameObject.GetComponent<MeshCollider>().bounds.size);
                
                DST_Source dst = hit.collider.gameObject.GetComponent<DST_Source>();
                if (dst)
                  dst.BeginDestructionSequence();

                SMOKEZ smo = hit.collider.gameObject.GetComponent<SMOKEZ>();
                if (smo)
                    smo.SuchIsLife();
                //source.MoveTo(paramss.x, paramss.y, paramss.z, hit.transform);
                //MeshRenderer mr = hit.collider.gameObject.GetComponent<MeshRenderer>();
                //if (mr)
                //    mr.enabled = false;
                if (mc)
                {
                    if(!mc.gameObject.name.Contains("lane"))
                    mc.enabled = false;
                }
                if (bc)
                {
                    bc.enabled = false;
                }
            }
            else
                line.SetPosition(1, new Vector3(0, 0, 300));

            StartCoroutine("CoolDown");
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.7f);
        line.enabled = false;
        yield return new WaitForSeconds(LaserCoolDown);
        CanShoot = true;
    }

    private void PlaySound()
    {
        if (TrackHolder.Instance != null)
        {
            source.clip = TrackHolder.Instance.laser;
            source.Play();
        }
    }
}