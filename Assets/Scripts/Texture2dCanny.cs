using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture2dCanny : MonoBehaviour {

	public Texture2D theTexture;
	public int[,] binaryPixels;
	private Color [,] pixels;
	private Color [] pixelArray;
	private int width;
	private int height;


	// Use this for initialization
	void Start () {

		width = theTexture.width;
		height = theTexture.height;

		//get the pixels of the Texture/floorplan
		pixelArray = theTexture.GetPixels();

		//change to 2d array
		pixels = singleArrayToDouble (pixelArray);

		//change into integer 2d array
		binaryPixels = ColorArrayToBinaryIntArray (pixels);

		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {

				Debug.Log(binaryPixels[j,i]);
			
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//turns a flattened Color array into a 2D Color Array
	public Color[,] singleArrayToDouble( Color[] flattenedPixelArray){

		Color[,] pixels = new Color[width, height];

		for (int y = 0; y < height; y++) {
		
			for (int x = 0; x < width; x++) {
			
				pixels [x, y] = flattenedPixelArray [x * width + y];
			
			}
		}
			
		return pixels;

	}

	//2d Colors Array to a Binary int 2d array
	public int[,] ColorArrayToBinaryIntArray( Color[,] pixels){
		
		int[,] binaryPixels = new int[width,height];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				if (pixels [x, y] == Color.white) {
					binaryPixels [x,y] = 0;
				} else {
					binaryPixels [x, y] = 1;
				}
			}
		}
	
		return binaryPixels;
	
	}

}
