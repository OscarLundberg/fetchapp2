using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Connect : MonoBehaviour {

	private string name;
	private string email;
	private string password;
	private string hash = "99873123545987";
	private WWW w;
	private WWWForm form;

	public int pwMinLength;
	public Main main;
	public string URL = "localhost/accounts/register.php";
	public string formText;
	public bool login { get; set; }
	public InputField input1;
	public InputField input2;
	public InputField input3;
	public InputField input4;
	public GameObject loginScreen;
	public Text errorText;

	void Start () 
	{
		form = new WWWForm();
	}

	void Update () 
	{
		
	}

	//Enables login mode
	void Login() 
	{
		login = true;
		ConnectToDB();
	}
		
	//Passes user info to main, for further use during runtime
	void LoggedIn(string name, string email) 
	{
		loginScreen.GetComponent<Animator>().SetBool("loggedIn", true);

		User u = new User();
		u.name = name;
		u.email = email;
		u.loc = new LocationService();
		main.Init(u);
	}

	//Communicates with database for registration and login
	public void ConnectToDB () 
	{
		form.AddField("myform_hash", hash);

		if (login) 
		{
			form.AddField("myform_nick", "123");
			form.AddField("myform_email", input2.text);
			form.AddField("myform_pass", input3.text);
			form.AddField("myform_login", 1);

		} else 
		{
			if(input3.text.Length < pwMinLength) 
			{
				errorText.text = "Password needs to be at least " + pwMinLength + " characters.";
				errorText.enabled = true;
			}else 
			{
				if(input3.text == input4.text) 
				{
					form.AddField("myform_nick", input1.text);
					form.AddField("myform_email", input2.text);				
					form.AddField("myform_pass", input3.text);
					form.AddField("myform_login", 0);

				} else 
				{
					errorText.text = "Passwords must match.";
					errorText.enabled = true;
				}
			}
		}                                

		StartCoroutine(WaitForDB());
	}
		
	//Wait for DB script to be executed before trying to use return information
	IEnumerator WaitForDB () 
	{
		w = new WWW (URL, form);
		yield return w;
	
		formText = w.text;

		if(w.error != null) 
		{
			Debug.Log(w.error);
		} else 
		{
			
			w.Dispose(); //clear our form in game
			Debug.Log("Dispose");
		}
			
		string[] phpReturns = {"email", "reg", "log", "invp", "inve", "sec"};

		foreach(string s in phpReturns) 
		{
			if(formText.Contains(s)) 
			{
				Execute(s);
			}
		}
	}

	void Execute (string action) 
	{
		switch (action) 
		{
		case "email":
			errorText.text = "Email is already registered.";
			errorText.enabled = true;
			break;

		case "reg":
			Login();
			Debug.Log("Registering");
			break;

		case "log":
			Debug.Log("logging in");
			LoggedIn(input2.text, input3.text);
			break;

		case "invp":
			errorText.text = "Invalid password.";
			errorText.enabled = true;
			break;

		case "inve":
			errorText.text = "User not found.";
			errorText.enabled = true;
			break;

		case "sec":
			errorText.text = "Security error.";
			errorText.enabled = true;
			break;
		}
	}

}