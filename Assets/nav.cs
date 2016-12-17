using UnityEngine;
using System.Collections;

public class nav : MonoBehaviour 
{
	public GameObject menu;
	public AudioListener alis;


	public void menuClick () 
	{
		Animator ani = menu.GetComponent<Animator>();
		if(ani.GetBool("menuActivated")) 
		{
			ani.SetBool("menuActivated", false);
		}
		else 
		{
			ani.SetBool("menuActivated", true);
		}

	}

	public void muteClick () 
	{
		alis.enabled = false;
	}
}
