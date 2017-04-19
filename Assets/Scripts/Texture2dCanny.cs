using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2dCanny : MonoBehaviour {

	public Texture2D theTexture;
	Color[,] pixels;
	Color [] pixelArray;

	// Use this for initialization
	void Start () {
		pixelArray = theTexture.GetPixels();
		pixels = singleArrayToDouble (pixelArray);

		for (int x = 0; x < theTexture.width; x++) {
			for (int y = 0; y < theTexture.height; y++) {
				
				Debug.Log (pixels[x, y].grayscale);

			}
		
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Color[,] singleArrayToDouble( Color[] flattenedPixelArray){

		Color[,] pixels = new Color[theTexture.width, theTexture.height];

		for (int x = 0; x < theTexture.width; x++) {
		
			for (int y = 0; y < theTexture.height; y++) {
			
				pixels [x, y] = flattenedPixelArray [x * theTexture.width + y];
			
			}
		}

		return pixels;

	}

}
