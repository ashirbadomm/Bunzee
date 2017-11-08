using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoWalk : MonoBehaviour {
	
private bool walking = false;

	public bool moveforward;

	private int count;
	public Text counttext;

	public float speed = 10.0f;

	void Start()
	{		count = 0;
		setCountText ();
	}

	void Update()
	{

		if (transform.position.y < -20) {
			Application.LoadLevel ("GameOver");
			/*transform.position = spawnpoint;
			moveforward = false;*/
		}

		if (Input.GetButtonDown ("Fire1")) {
			moveforward = !moveforward;
		}

		if (moveforward) {
			transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

		}


	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp")) {
		
			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}

	}

	void setCountText()
	{
		counttext.text = "COUNT: " + count.ToString ();
	
	}
}