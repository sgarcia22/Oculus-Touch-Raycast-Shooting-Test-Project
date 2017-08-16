using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour {

/*	private ControllerInput input;
	public Transform rightGunTransform;
	public Transform leftGunTransform;*/
	private float secondsToDestroy = 3.0f;

	void Start () {
	/*	rightGunTransform = input.rightGunBarrelTransform;
		leftGunTransform = input.leftGunBarrelTransform;
		gameObject.GetComponent<Rigidbody>().AddForce (rightGunTransform.transform.position, ForceMode.Impulse); */
		//Destroy bullet after a certain number of seconds
		Destroy (gameObject, secondsToDestroy);
	}
		
}
