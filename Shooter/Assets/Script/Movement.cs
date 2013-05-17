using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	bool isTurning;
	bool willTurn = false;
	
	float minPolled;
	float maxPolled = 1f;
	
	Vector3 from;
	Vector3 to;
	
	void Update ()
	{	
		if (willTurn == true)
		{
			minPolled += Time.deltaTime;
			float r = minPolled/maxPolled;
			transform.rotation = Quaternion.Lerp(Quaternion.Euler(from), Quaternion.Euler(to), r);
			if (r >= 1)
			{
			minPolled = 0;
			willTurn = false;	
			}
		}
		else
		{
		transform.position += transform.forward *  .1f;
		PlayerMovement();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(Time.time + other.gameObject.tag + " " + other.gameObject.name);
		if (other.gameObject.tag == "turn")
		{
			isTurning = true;
			PlayerMovement();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "turn")
		{
			isTurning = false;
		}
	}
	
	void PlayerMovement()
	{
		if (isTurning == true)
		{
			// rotate left
			if (Input.GetKeyDown(KeyCode.Q))
			{
				willTurn = true;
				from = transform.rotation.eulerAngles;
				to =  transform.rotation.eulerAngles +  Quaternion.Euler(0,-90,0).eulerAngles;
				isTurning = false;
			}
			// rotate right
			if (Input.GetKeyDown(KeyCode.E))
			{
				willTurn = true;
				from = transform.rotation.eulerAngles;
				to = transform.rotation.eulerAngles +  Quaternion.Euler(0,90,0).eulerAngles;
				isTurning = false;
			}
		}
		
			// move up
			if (Input.GetKeyDown(KeyCode.W))
			{
			}
		// move down
			if (Input.GetKeyDown(KeyCode.S))
			{
			}

		// left
			if (Input.GetKeyDown(KeyCode.A))
			{
			}
		// move right
			if (Input.GetKeyDown(KeyCode.D))
			{
			}
		
		}
}
