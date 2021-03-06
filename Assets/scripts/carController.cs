﻿using UnityEngine;
using System.Collections;

public class carController : MonoBehaviour {

	public float carSpeed;
	public float maxPos = 2.2f;

	Vector3 position;
	public uiManager ui;
	public AudioManager am;

	bool currntPlatformAndroid = false;

	Rigidbody2D rb;

	void Awake(){

		rb = GetComponent<Rigidbody2D> ();

		#if UNITY_ANDROID
				currntPlatformAndroid = true;
		#else
				currentPlatformAndroid = false;
		#endif


		am.carSound.Play ();
	
	}
	
	void Start () {

		position = transform.position;

		if (currntPlatformAndroid == true) {
			Debug.Log ("Android");
		} 
		else {
			Debug.Log ("Windows");
		}
	}

	void Update () {


		if (currntPlatformAndroid == true) {
            //android specific code

            // do sterowanie Left and Right BUTTON tutaj nie ma nic. Funkcje są Triggerowane z BUTTONÓW !!!!!!!!!!!!!!!!!!!!

            //TouchMove (); // funkcja do sterowania autem w prawo i lewo po osie x, naciskają palcem na telefonie w daną połowkę ekranu
            //funkcji powyżej używaałam gdy nie miałam funkcji AcceletometerMove :)  = Czyli sterowania za pomocą ochylania naszego telefonu.
            AccelerometerMove();
		}

		else {

			position.x += Input.GetAxis ("Horizontal") * carSpeed * Time.deltaTime; // thanx to: Time.deltaTime (This property provides the time between the current and previous frame) it is frame independent and it always keep moving with the same speed.
            position.x = Mathf.Clamp (position.x, -2.2f, 2.2f); //  ograniczenie wartości x do -2,2f  i 2,2f
			transform.position = position;
		}

		position = transform.position;
		position.x = Mathf.Clamp (position.x, -2.2f, 2.2f);
		transform.position = position;

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Enemy Car") {
			//Destroy (gameObject);

			gameObject.SetActive(false);

			ui.gameOverActivated();
			am.carSound.Stop();
		}
	}

    // poruszanie samochodem za pomoca pochylania telefonu w prawo i w lewo
	void AccelerometerMove(){

		float x = Input.acceleration.x;
		Debug.Log ("X = " + x);


		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();	
		} 
		else {
			SetVelocityZero();
		}

	}

	void TouchMove(){

		if (Input.touchCount > 0) {

			Touch touch = Input.GetTouch (0); // pierwszy dotyk na ekraniu

			float middle = Screen.width / 2; // połowa ekranu w osi x

			if (touch.position.x < middle && touch.phase == TouchPhase.Began) {
				MoveLeft ();
			} 
			else if (touch.position.x > middle && touch.phase == TouchPhase.Began) {
				MoveRight ();
			}
		
		} 

		else {
			SetVelocityZero();
		}

	}


	public void MoveLeft(){
		rb.velocity = new Vector2 (-carSpeed, 0);
	}
	
	public void MoveRight(){
		
		rb.velocity = new Vector2 (carSpeed, 0);
	}
	
	public void SetVelocityZero(){
		rb.velocity = Vector2.zero;
	}

	/*void AccelerometerMove(){
		float x = Input.acceleration.x;
		
		Debug.Log (" X: " + x);
		
		if (x < -0.1f) {
			MoveLeft ();
		} else if (x > 0.1f) {
			MoveRight ();
		} 
		else {
			SetVelocityZero();
		}
		
	}*/

	


}
