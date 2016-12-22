using UnityEngine;
using UnityEngine.Advertisements;
public class ad : MonoBehaviour
{
	public string androidID = "1239370";

	void Start () 
	{
		Advertisement.Initialize(androidID);
		ShowAd();
	}
		
	void ShowAd() 
	{
		if(Advertisement.IsReady()) 
		{
			Advertisement.Show();
		}else 
		{
			Debug.Log("Not Ready");
		}
	}
}


