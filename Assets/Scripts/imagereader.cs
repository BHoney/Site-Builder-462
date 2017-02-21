using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//using UnityEngine.Windows;

public class imagereader : MonoBehaviour {

	private InputField input;


	public Texture2D texture = null;

	void Awake()
	{
		input = GameObject.Find ("InputField").GetComponent<InputField> ();
	}
	public void getInput(string picture)
	{
		Debug.Log ("the picture file name is " + picture);
		input.text = "";

//		if (texture != null) {
			texture = LoadPNG (picture);
//		}


	}



	public static Texture2D LoadPNG(string filePath) {

		Texture2D tex = null;
		byte[] fileData;

		Debug.Log ("loading.... " + filePath);

		if (File.Exists(filePath))     
		{

			Debug.Log ("file exists ");
			fileData = File.ReadAllBytes(filePath);
			tex = new Texture2D(2, 2);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}

	void OnGUI() {
		if (GUILayout.Button("Press Me"))
			Debug.Log("Hello!");

//		if (texture != null) {
			GUI.DrawTexture (new Rect (20, 20, texture.width/2, texture.height/2), texture);
		
//		}


	}

}
