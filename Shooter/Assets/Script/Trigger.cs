using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{

	public int numberOfTrigger =1;
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "mid")
		{	
			Transform t = other.transform.parent.FindChild("end");
			Camera.mainCamera.GetComponent<RoadGenerator>().SetStartPosition(t.position, t.rotation);
			Camera.mainCamera.GetComponent<RoadGenerator>().GenerateRoad();
			Camera.mainCamera.GetComponent<RoadGenerator>().GenerateBuilding();
			
			numberOfTrigger +=1;
			Camera.mainCamera.GetComponent<RoadGenerator>().GetNumber(numberOfTrigger);
		
		}
		
		else if  (other.gameObject.tag == "midLeft")
		{
			Transform t = other.transform.parent.FindChild("endLeft");
			Camera.mainCamera.GetComponent<RoadGenerator>().SetStartPosition(t.position, t.rotation);
			Camera.mainCamera.GetComponent<RoadGenerator>().GenerateRoad();
			Camera.mainCamera.GetComponent<RoadGenerator>().GenerateBuilding();
			
			numberOfTrigger +=1;
			Camera.mainCamera.GetComponent<RoadGenerator>().GetNumber(numberOfTrigger);
		}
		
		else if   (other.gameObject.tag == "midRight")
		{
			Transform t = other.transform.parent.FindChild("endRight");
			Camera.mainCamera.GetComponent<RoadGenerator>().SetStartPosition(t.position, t.rotation);
			Camera.mainCamera.GetComponent<RoadGenerator>().GenerateRoad();
			Camera.mainCamera.GetComponent<RoadGenerator>().GenerateBuilding();
			
			numberOfTrigger +=1;
			Camera.mainCamera.GetComponent<RoadGenerator>().GetNumber(numberOfTrigger);
		}
	}

}
