/// <summary>
/// Object pooler.
/// List cac loai platform. Cach thuc hoat dong:
/// 1. Ta co PlatformGeneratorPoint --> Se random cac platform cho toi diem nay
/// 2. Ta co PlatformDestructionPoint --> Se inactive cac platform o phia sau diem nay
/// 3. Phuong thuc Random
/// 3.1. KHong se dung Instanciate va Delete do ton bo nho --> Cang lau cang xu ly cham
/// 3.2 Su dung ObjectPooler chua 1 list cac platform, se active platform duoc random va inactive cac platform muon xoa
/// 3.3 Sau khi platform bi inactive, cac platform duoc random sau se chon 1 trong cac platform bi inactive nay, tao vi tri moi
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmount;

	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> ();
		// Lay cac loai Platform vao list pooledObjects
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	}
	
	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			if (!pooledObjects[i] .activeInHierarchy) 
			{ //active in the screen?
				return pooledObjects[i];
			}
		}
		GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;
	}

}
