using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

	public float speed = 0.5f;
	public Renderer rend;
	void Start()
	{
		rend = GetComponent<Renderer> ();
	}
	void Update()
	{
		float offset = Time.time * speed;
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		//Vector2 offset = new Vector2 (Time.time * RectOffset, 0);
		//rend.material.mainTextureOffset = new Vector2 (Time.time * RectOffset, 0);
	}
}
