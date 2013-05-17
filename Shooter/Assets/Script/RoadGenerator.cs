using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RoadGenerator : MonoBehaviour
{

	public GameObject[] roadPrefabs;
	public GameObject[] buildingPrefabs;
	
	GameObject currentRoad;
	GameObject previousRoad;
	
	Vector3 startPos = Vector3.zero;
	Vector3 buildingPos;
	Quaternion startRotation = Quaternion.identity;
	
	Dictionary <int,List<GameObject>> roadBank = new Dictionary<int, List<GameObject>>();
	Dictionary <int, List <GameObject>> buildingBank = new Dictionary<int, List<GameObject>>();
	float TriggerNum = 1;
	
	void Start()
	{
		
		for (int x = 0; x < roadPrefabs.Length; x++)
		{
			roadBank.Add(x, new List <GameObject>());
			for (int num = 0; num <= 5; num++)
			{
				roadBank[x].Add (Instantiate(roadPrefabs[x], Vector3.zero, Quaternion.identity) as GameObject);
				roadBank[x][roadBank [x].Count-1].SetActive(false);
			}
		}
		
		for (int y = 0; y < buildingPrefabs.Length; y++)
		{
			buildingBank.Add (y, new List<GameObject>());	
			for (int w = 0; w <=2; w++)
			{
				buildingBank[y].Add (Instantiate(buildingPrefabs[y], Vector3.zero, Quaternion.identity) as GameObject);
				buildingBank[y][buildingBank[y].Count-1].SetActive(false);
			}
		}
		
		GenerateRoad();
		GenerateBuilding(); 
		
	}
	
	public void SetStartPosition(Vector3 v, Quaternion q)
	{
		startPos = v;
		startRotation = q;
	}
	
	void Update()
	{
		
	}
	
	public void GenerateRoad()
	{
		Debug.Log(TriggerNum + " " + currentRoad);
		int arrayRange = TriggerNum % 10 != 0 ? 0 : Random.Range(1, roadPrefabs.Length);
		currentRoad = roadBank[arrayRange][0];
		roadBank[arrayRange].Remove(currentRoad);
		roadBank[arrayRange].Add(currentRoad);
		currentRoad.SetActive(true);
		
		currentRoad.transform.position = startPos;
		currentRoad.transform.rotation = startRotation;
		
			if(previousRoad)
			{
				currentRoad.transform.position -= (currentRoad.transform.Find("start").transform.position - startPos);		
			}

			previousRoad = currentRoad;
	}
	
	public void GenerateBuilding()
	{
		foreach (Transform child in currentRoad.transform)
		{
			int arrayRange = Random.Range(0, buildingPrefabs.Length);
			if (child.gameObject.name == "drawBuilding")
			{				
				GameObject building1 = buildingBank[arrayRange][0];
				buildingBank[arrayRange].Remove(building1);
				buildingBank[arrayRange].Add(building1);
				building1.SetActive(true);
				
				building1.transform.position = child.gameObject.transform.position;
			}
		}
	}
	
	public void GetNumber (int num)
	{
		TriggerNum = num;
	}

}
