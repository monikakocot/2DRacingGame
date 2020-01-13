using UnityEngine;
using System.Collections;

public class trackMove : MonoBehaviour {

	public float speed = 1.5f;
	Vector2 offset;


	

	
	void Start () {
		#if UNITY_ANDROID
		speed = 0.5f;
		#endif

		#if UNITY_STANDALONE_WIN
		speed = 1.5f;
		#endif 
	}
	

	void Update () {
		offset = new Vector2 (0, Time.time * speed); // wraz z czasem cała wartość będzie się zwiększać to Time.time się zwiększa. Time.time to: This is the time in seconds since the start of the game.

        GetComponent<Renderer> ().material.mainTextureOffset = offset; //The texture offset of the main texture.
    }
}
