using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public Transform player;
	private Vector3 _defaultGravity;

	// Use this for initialization
	void Start () {
		_defaultGravity = Physics.gravity;
	}

	private IEnumerator Spherer(){
		var t = PrimitiveType.Sphere;
		if (Random.Range (0, 3) == 0) {
			t = PrimitiveType.Cube;
		}

		var sphere = CreateSphere (t);
		yield return new WaitForSeconds(8);
		if(sphere)
			Destroy (sphere);
	}

	private GameObject CreateSphere(PrimitiveType t){
		var sphere = GameObject.CreatePrimitive (t);
		sphere.layer = 9;
		sphere.transform.position = new Vector3(player.position.x+Random.Range(-2.5f,2.5f), 1.5f, player.position.z)+player.forward*Random.Range(2.1f,4f);
		sphere.transform.localScale = Vector3.one / 4;
		sphere.transform.parent = transform;
		sphere.AddComponent<Rigidbody> ();
		var renderer = sphere.GetComponent<Renderer> ();
		var color = (Vector4)Random.onUnitSphere;
		color[3] = 1;
		for (int i = 0; i < 3; i++) {
			if (color [i] < 0) {
				color [i] = -color [i];
			}
		}
		renderer.material.color = color;
		return sphere;
	}

	private float _timer = 0;
	private float _timerMax = 2f;

	// Update is called once per frame
	void FixedUpdate () {
		if (!CollectSpheres.Playing) {
			_timer = 0;
			_timerMax = 2;
			Physics.gravity = _defaultGravity;
			return;
		}

		_timer += Time.fixedDeltaTime;
		if (_timer > _timerMax) {
			_timer -= _timerMax;
			StartCoroutine (Spherer());
			_timerMax = Mathf.Clamp (0.99f * _timerMax, 0.15f, 4);
			Physics.gravity = Vector3.up*Mathf.Clamp (Physics.gravity.y * 1.01f, -30, -1);
		}
	}
}
