using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    /// <summary>
    /// The player's current rotation about the Y axis.
    /// </summary>
    private float YRotation = 0.0f;
    private AudioSource source;

    /// <summary>
    /// The player's current rotation about the X axis.
    /// </summary>
    private float XRotation = 0.0f;

    private float SimulationRate = 60f;
    private float RotationScaleMultiplier = 1.0f;
    /// <summary>
	/// The rate of rotation when using a gamepad.
	/// </summary>
	public float RotationAmount = 1.5f;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();
        if (source != null)
        {
            source.playOnAwake = false;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.spread = 500.0f;
            if (TrackHolder.Instance != null)
            {
                source.clip = TrackHolder.Instance.mainClip;
                source.Play();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.L1))
            Application.LoadLevel("test_nate");
        if (OVRGamepadController.GPC_GetButton(OVRGamepadController.Button.R1))
            Application.LoadLevel("testkeno");

        float rotateInfluence = SimulationRate * Time.deltaTime * RotationAmount * RotationScaleMultiplier;

        float rightAxisX = OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightXAxis);
        float rightAxisY = OVRGamepadController.GPC_GetAxis(OVRGamepadController.Axis.RightYAxis);
        if (transform.eulerAngles.z <= 180.1f && transform.eulerAngles.z >= 179.9f)
            YRotation -= rightAxisX * rotateInfluence;
        else
            YRotation += rightAxisX * rotateInfluence;
        XRotation -= rightAxisY * rotateInfluence; //Non-inverted

        //DirXform.rotation = Quaternion.Euler(XRotation, YRotation, 0.0f);
        //transform.rotation = DirXform.rotation;
        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0.0f);
	
	}
}
