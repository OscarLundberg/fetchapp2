using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour 
{
	public Text profile;
	public User u;

	public void Init (User u) 
	{
		profile.text = u.name;
		this.u = u;
	}


	public void WaitForDB (string url, WWWForm f) 
	{
		StartCoroutine(Wait(url, f));

	}

	IEnumerator Wait(string URL, WWWForm form) 
	{
		Debug.Log("Waiting");
		WWW w = new WWW(URL, form);
		yield return w;

		Debug.Log("PHP returned: " + w.text);
		if(w.error != null) 
		{
			Debug.Log(w.error);

		} else 
		{
			w.Dispose(); //clear our form in game
			Debug.Log("Dispose");
		}
	}
}
