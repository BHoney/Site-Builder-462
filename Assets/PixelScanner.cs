using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScanner : MonoBehaviour {

	public Texture2D map;
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
		
		
		for(int y = 0; y < map.height; y++){
			// Debug.Log(string.Format("new y:{0}", y));
			for(int x = 0; x < map.width ; x++ ){
				if(mapPixelData[walker] == Color.white){
					mapData[x,y] = 0;
				}
				else{
					mapData[x,y] = 1;
				}
				walker++;
			}
		}
		//Debug.Log(string.Format("Map Data Retrieved. {0} entries", mapData.Length));
		 Debug.Log(string.Format("Map Data: {0}, Color {1}", mapData[1,1], mapPixelData[10]));
		return mapData;	
		 }
	}
