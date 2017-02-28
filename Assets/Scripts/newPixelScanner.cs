using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPixelScanner : MonoBehaviour {

	[SerializeField]
	private Texture2D texture;



	// Use this for initialization
	void Start () {
		
	}

	void PixelToGreyScale(){
		int [,] pixelMap = new int[texture.width,texture.height];
		int walker = 0;
		Color[] colorMap = texture.GetPixels();

		for(int y = 0; y <texture.width; y ++){
			for(int x = 0; x < texture.height; x++){
				float colorAvg = (colorMap[walker].r+colorMap[walker].b+colorMap[walker].g) / 3;
				Debug.Log(colorAvg);
				pixelMap[x,y] = (int) colorAvg; 
			}
		}
	}
	
	
}
