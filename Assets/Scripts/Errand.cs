using UnityEngine;
using System.Collections;
using System.Text;

public class Errand : ScriptableObject {

	public User u;
	public string formText;

	private string URL = "http://localhost/errands/registerErrand.php";
	private WWWForm form;


	public void Init (string product, string targetLoc, string targetTime, int offer)
	{
		u = GameObject.FindWithTag("user").GetComponent<Main>().u;

		this.product = product;
		this.targetLoc = targetLoc;
		this.targetTime = targetTime;
		this.offer = offer;

		author = SetAuthor();
		authenticator = SetAuthenticator();
		Debug.Log(authenticator);
		Upload();
	}
	 
	private string author { get; set; }
	private int ID {  get; set; }
	private string product {  get; set; }
	private string targetLoc {  get; set; }
	private string targetTime {  get; set; }
	private int offer {  get; set; }
	private string fetcher  {  get; set; }
	private bool finished  { get; set;}
	private string authenticator  {  get; set; }

	private string SetAuthor () 
	{
		return u.email;
	}

	private string SetAuthenticator () 
	{
		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		StringBuilder sb = new System.Text.StringBuilder();
		for(int i = 0; i < 4; i++) 
		{ 
			int y = (int) (Random.Range(0, chars.Length));
			sb.Append(chars[y]);
		}
		return sb.ToString();
	}

	void Upload() 
	{
		Debug.Log("Uploading");
		form = new WWWForm();
		form.AddField("form_poster", author);
		form.AddField("form_product", product);
		form.AddField("form_firm", targetLoc);
		form.AddField("form_offer", offer.ToString());
		form.AddField("form_time", targetTime);
		form.AddField("form_LON", u.loc.lastData.longitude.ToString());
		form.AddField("form_LAT", u.loc.lastData.latitude.ToString());
		form.AddField("form_auth", authenticator);

		GameObject.FindWithTag("user").GetComponent<Main>().WaitForDB(URL, form);
	}
}
