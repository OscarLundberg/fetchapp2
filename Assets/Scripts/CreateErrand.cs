using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateErrand : MonoBehaviour 
{
	int maxNoOfErrands = 500;
	public InputField i1;
	public InputField i2;
	public InputField i3;
	public InputField i4;
	public Main m;
	public GameObject errandMenu;



	public void OnCreateErrand () 
	{
		User u = m.u;
		if(u.errands.Count < maxNoOfErrands) 
		{
			
			Errand e = ScriptableObject.CreateInstance("Errand") as Errand;

			e.Init(i1.text, i2.text, i3.text, int.Parse(i4.text));
			u.errands.Add(e);
		}else 
		{
			// Give ErrorMsg
		}
	}



	public void OnOpenMenu () 
	{
		if(errandMenu.GetComponent<Animator>().GetBool("createNew"))
		{
			errandMenu.GetComponent<Animator>().SetBool("createNew", false);
		} 
		else  
		{
			errandMenu.GetComponent<Animator>().SetBool("createNew", true);
		}
	}
}
