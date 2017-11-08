using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectSpheres : MonoBehaviour {
	public int Score = 0;
	[SerializeField]
	private Transform _follow;
	[SerializeField]
	private TextMesh _text;
	[SerializeField]
	private TextMesh _timeText;

	private float _time = 60;
	public static bool Playing = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var forward = _follow.forward;
		forward.y = 0;
		transform.forward = forward;
		transform.position = new Vector3 (_follow.position.x, -0.5f, _follow.position.z) + forward.normalized*3;

		_time -= Time.deltaTime;
		if (_time > 0) {
			_timeText.text = string.Format ("{0:D2}", Mathf.FloorToInt (_time + 1));
		} else {
			_timeText.text = "00";
			Playing = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if (!Playing)
			return;
		GameObject.Destroy (other.gameObject);
		Score++;
		if (other.GetComponent<BoxCollider> ())
			Score += 1;
		_text.text = "" + Score;
	}


	void OnSelect(){
		if (_time<=0) {
			_time = 60;
			Playing = true;
			_timeText.text = "60";
			Score = 0;
			_text.text = "0";
		}
	}
}
