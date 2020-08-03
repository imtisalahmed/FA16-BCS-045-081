using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Demo : MonoBehaviour {
	public Text print;
	public void CheckInternetConn()
	{		
		InternetChecker.MyInternet += MyListener;
		InternetChecker.ICInstance.StartInternetCheck ();
	}

	public void MyListener(bool isInternetAvailable) 
	{
		if (isInternetAvailable) 
		{
			Debug.Log ("Internet is Available");
			print.text = "Internet is Available";
		}

		else if (!isInternetAvailable) 
		{
			Debug.Log ("Internet is not Available");
			print.text = "Internet is nottt Available";
		}
	}

	void OnDisable()
	{
		InternetChecker.MyInternet -= MyListener;
	}
}
