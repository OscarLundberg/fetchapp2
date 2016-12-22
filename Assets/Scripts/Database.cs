using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;

public class Database : MonoBehaviour {

	public void RegisterAccount (string nameStr, string emailStr, string pwStr)
	{
		//INSERT INTO 'fetch-db'.'accounts'('name', 'email','password') VALUES (nameStr, emailStr, pwStr);
	}

	public bool ValidateLogin (string email, string password) 
	{
		WWW accountsData = new WWW ("http://localhost/accounts/accountsData.php");
		string accountString = accountsData.text;


		if(accountString.Contains(email) && accountString.Contains(password)) {
			
			return true;
		}else {return false;}
	}
}
