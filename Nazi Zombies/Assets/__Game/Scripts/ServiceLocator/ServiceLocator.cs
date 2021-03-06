using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Services are in the children of this gameObject
public class ServiceLocator : MonoBehaviour
{
	public static ServiceLocator Instance { get; private set; }
	public Ballistics Ballistics { get; private set; }

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Multiple Service Locators!");
			Destroy(this);
		}
		References();
	}
	private void References()
	{
		Ballistics = GetComponentInChildren<Ballistics>();
	}

}
