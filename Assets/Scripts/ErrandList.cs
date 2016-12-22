using UnityEngine;
using System.Collections;

public class ErrandList : MonoBehaviour {

	public Main m;




	// 65.308162, 21.510283
	// 65.310390, 21.498461

	void Start () 
	{
		Debug.Log("Distance is " + RangeToErrand(65.310390f, 21.498461f) + " miles.");
	}



	//Calculations

	float RangeToErrand (float lon, float lat) 
	{
		//float curLon = m.GetComponent<User>().loc.lastData.longitude;
		//float curLat = m.GetComponent<User>().loc.lastData.latitude;

		float curLon = 65.308162f;
		float curLat = 21.510283f;

		float earthRadius = 3958.75f; // miles (or 6371.0 kilometers)
		float dLat = ToRadians(curLat-lat);
		float dLng = ToRadians(curLon-lon);
		float sindLat = Mathf.Sin(lat / 2);
		float sindLng = Mathf.Sin(lon / 2);
		float a = Mathf.Pow(sindLat, 2) + Mathf.Pow(sindLng, 2) * Mathf.Cos(ToRadians(lat)) * Mathf.Cos(ToRadians(curLat));
		float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1-a));
		float dist = earthRadius * c;

		return dist;

	}

	float ToRadians (float angleIn10thofaDegree)
	{
		// Angle in 10th of a degree
		return (angleIn10thofaDegree*Mathf.PI)/1800; 
	}
}
