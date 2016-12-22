using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public  class User : System.Object 
{
	public string name;
	public string email;
	public LocationService loc;
	public List<Errand> errands = new List<Errand>();
}
