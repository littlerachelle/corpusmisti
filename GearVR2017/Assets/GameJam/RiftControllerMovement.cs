using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftControllerMovement : MonoBehaviour {

    public Transform headTransform;

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //UnityEngine.VR

        Vector3 relMove = Vector3.zero;

        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (primaryAxis.magnitude > 0.1f)
        {
            Vector3 move = new Vector3(primaryAxis.x, 0.0f, primaryAxis.y) * speed;
            Vector3 headDir = headTransform.forward;
            headDir.y = 0;
            Quaternion lookDir = Quaternion.LookRotation(headDir.normalized);
            relMove = lookDir * move;
        }
	    GetComponent<CharacterController>().SimpleMove(relMove);
    }
}
