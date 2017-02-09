using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScanner : MonoBehaviour {

	public Texture2D map;
	private int map_height, map_width;
	private Vector2 pos;
	// Use this for initialization
	void Start () {
		GetMapData();
	}
	
	 int[,] GetMapData()
	{
		int [,] mapData = new int[map.width,map.height];
		int walker = 0;
		Color[] mapPixelData = map.GetPixels();
		//Debug.Log(mapPixelData[0]);
		for(int y = 0; y > map.height; y++){
			for(int x = 0; x > map.width*y; x++ ){
				if(mapPixelData[walker] == Color.white){
					mapData[x,y] = 0;
				}
				else if(mapPixelData[walker] == Color.black){
					mapData[x,y] = 1;
				}
				walker++;
			}
		}
		Debug.Log("Map Data Retrieved.");
		return mapData;	
		 }
	}
