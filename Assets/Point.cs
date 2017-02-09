using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Point : MonoBehaviour {
	
	public Point[] neighbors;
	public bool selected;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		DrawWall();
	}

	/// <summary>
	/// Automatically draws walls between all points. Currently only for debugging.
	/// </summary>
	void DrawWall(){
		foreach (Point p in neighbors)
		{
			if(p!=null)
			Debug.DrawLine(this.transform.position, p.transform.position, Color.green);
		}
	}
	 /// <summary>
	/// Called when the mouse enters the GUIElement or Collider.
	/// </summary>
	void OnMouseEnter()
	{
		this.GetComponentInParent<Renderer>().material.color = Color.blue;
	}

	/// <summary>
	/// Called when the mouse is not any longer over the GUIElement or Collider.
	/// </summary>
	void OnMouseExit()
	{
		this.GetComponentInParent<Renderer>().material.color = Color.white;
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		selected = !selected;
		Debug.Log(selected);
	}
}


	
