using UnityEngine;
using System.Collections;

public class SC_Camera : MonoBehaviour {
	
    //
    // Summary:
    //      Initializes the _Offset variable so the camera has something to move to
	void Start() {
		_Offset = transform.position - _Target.position;
	}

    //
    // Summary:
    //      Moves camera position to new position. LateUpdate() runs after all other Update() have been called.
    //      This is important because movement data for the GameObjects will be defined in Update().
	void LateUpdate() {
		Vector3 targetCamPos = _Target.position + _Offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, _Smoothing * Time.deltaTime);
	}
    //
    // Summary:
    //      The transform position of the character you want to follow
    public Transform _Target;

    //
    // Summary:
    //      How smooth the camera interpolation is
	public float _Smoothing = 5f;

    //
    // Summary:
    //      Camera's offset to the target transform position
	Vector3 _Offset;
}