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
		//get the input field from scene
		input = GameObject.Find ("InputField").GetComponent<InputField> ();
	}

	//fucntion takes in string which is a file path and calls LoadPNG on the file path
	public void getInput(string picture)
	{
		Debug.Log ("the picture file name is " + picture);
		input.text = "";

		texture = LoadPNG (picture);

	}


	//loads image using file path creating a 2D texture
	public static Texture2D LoadPNG(string filePath) {
		
		Texture2D tex = null;// initiate texture
		byte[] fileData;

		Debug.Log ("loading.... " + filePath);
		if (File.Exists(filePath)) //if the file exists..    
		{
			Debug.Log ("file exists ");
			fileData = File.ReadAllBytes(filePath);//reads all the byes in the file
			tex = new Texture2D(2, 2);//creates in temperary texture
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}

	void OnGUI() {

//		(new Rect (20, 20, texture.width/2, texture.height/2)

		Rect rect = new Rect(40, 40, Screen.width/2, Screen.height/2);//Rect to put the texture on
		if (texture != null) {
			GUI.DrawTexture(rect, texture,ScaleMode.StretchToFill);//draws the texture on the rect
		}




	}

}
