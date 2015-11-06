using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	static T _instance = null;
	public static T Instance {
		get 
		{
			if(_instance == null) 
			{
				_instance = GameObject.FindObjectOfType<T> ();
			}
			return _instance;
		}
	}

}
