using UnityEngine;
using System.Collections;

public class createBuilding : MonoBehaviour
{
	
	public GameObject building;
	public int numberOfBuildings = 5;
	// Use this for initialization
	void Start ()
	{
		
		BuildingPositioning();
		Debug.Log (building);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void BuildingPositioning()
	{
		GameObject parentBuilding = new GameObject();
		parentBuilding.transform.position = Vector3.zero;
		int x = 1;
		
		for (int i = 0; i < numberOfBuildings; i++)
		{
			
			Vector3 scale = transform.localScale;
			Vector3 bldgposition;
			scale.x = Random.Range(1f,4f);
			scale.z = Random.Range(1f,4f);
			scale.y = Random.Range(2f,10f);
			
			GameObject buildings = Instantiate(building, Vector3.zero, Quaternion.identity) as GameObject;
			buildings.transform.localScale = scale;
			
			bldgposition.x =Random.Range(1f,2f);
			bldgposition.y = buildings.transform.localScale.y/2;
			bldgposition.z = Random.Range(1f,2f);
			
			x+=2;
			buildings.transform.position = bldgposition;
			
			buildings.transform.parent= parentBuilding.transform;
		}
	}
}
