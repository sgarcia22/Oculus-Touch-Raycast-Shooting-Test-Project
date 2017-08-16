using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

	//Tutorial Help from: Leading Ones, youtube.com/watch?v=kD47gUJO7jA
	//And Bracer Jack: youtube.com/watch?v=FD9HZB0Jn1w

	public AudioClip pistolAudioClip;
	public AudioSource pistolAudioSource;

	public GameObject rightPistol;
	public GameObject leftPistol;
	public GameObject bullet;
	public GameObject rightBulletEmitter;
	public GameObject leftBulletEmitter;

	public Transform rightGunBarrelTransform;
	public Transform leftGunBarrelTransform;

	public float bulletForwardForce;

	private GameObject tempBullet;
	//Seconds before the next shot can be taken
	private float secondsToNextShoot = 0.5f;
	//Keeps track of the current time
	private float currentTime;
	//Will store previous time that shot was fired
	private float previousTime = 0f;
	//Shooting Force
	private float shootForce = 20f;

	void Start () {
		//Get sound effects for pistol
		pistolAudioSource = GetComponent<AudioSource> ();
		pistolAudioSource.clip = pistolAudioClip;
	}

	void Update () {
		//Time before taking the next shot
		currentTime = Time.time;
		//Get position and location of controllers for smooth movement of pistols
		rightPistol.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
		rightPistol.transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

		leftPistol.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
		leftPistol.transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);

		if (OVRInput.Get (OVRInput.Button.SecondaryIndexTrigger) && ((currentTime - previousTime) > secondsToNextShoot)) {
			//Play gun sound effect and instantiate bullet
			previousTime = currentTime;
			shootBullet(true);
			pistolAudioSource.Play ();

		}
		else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && ((currentTime - previousTime) > secondsToNextShoot)) {
			previousTime = currentTime;
			shootBullet(false);
			pistolAudioSource.Play ();
		}
	}

	private void shootBullet(bool right) {
		if (right == true) {
			//Instantiate bullet
			GameObject tempBullet = Instantiate (bullet, rightGunBarrelTransform.position, rightGunBarrelTransform.rotation);
			tempBullet.GetComponent<Rigidbody> ().AddForce (tempBullet.transform.forward * shootForce);

		} else {
			GameObject tempBullet = Instantiate (bullet, leftGunBarrelTransform.position, leftGunBarrelTransform.rotation);
			tempBullet.GetComponent<Rigidbody> ().AddForce (tempBullet.transform.forward * shootForce);
		}
	}


	//TODO: Bullet is shot facing upwards & not enough mass 



















	//Raycast better used for lasers not instantiating bullets
	/*
	private void RaycastGun(bool right) {

		RaycastHit hit;
		//Raycast that shoots a bullet forward from where the right barrel is pointing
		if (right == true && Physics.Raycast (rightGunBarrelTransform.position, rightGunBarrelTransform.forward, out hit, weaponRange)) {
			GameObject tempbullet = Instantiate (bullet, rightGunBarrelTransform);
			//If the bullet collides with the block
			if (hit.collider.gameObject.CompareTag ("Cube")) {
				Destroy (hit.collider.gameObject);
			}
		}
		//Raycast that shoots a bullet forward from where the left barrel is pointing
		else if (right == false && Physics.Raycast (leftGunBarrelTransform.position, leftGunBarrelTransform.forward, out hit, weaponRange)) {
				//If the bullet collides with the block
				if (hit.collider.gameObject.CompareTag ("Cube")) {
					Destroy (hit.collider.gameObject);
			}
		}

	}

	private void shootBullet(bool right) {

		GameObject rightTemporaryBullerHandler;
		if (right == true) {
			//Instantiate Bullet
			rightTemporaryBullerHandler = Instantiate (bullet, rightBulletEmitter.transform.position, leftBulletEmitter.transform.rotation) as GameObject;
			//Instantiate under Parent
			rightTemporaryBullerHandler.transform.parent = gameObject.transform;
			//Get Rigidbody
			Rigidbody rightTemporaryRigidbody;
			rightTemporaryRigidbody = rightTemporaryBullerHandler.GetComponent<Rigidbody> ();
			//Add force to bullet
			rightTemporaryRigidbody.AddForce(transform.forward * bulletForwardForce);
			//Destroy after 10 seconds
			Destroy(rightTemporaryBullerHandler, 10.0f);

		}
		else {
		}

	} */



}
