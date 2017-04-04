using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	//MapData map = new MapData();
	CoordinateGen cord = new CoordinateGen();
	cornerMatch corners = new cornerMatch();
	PixelScanner p = new PixelScanner();
	public Texture2D m;
	public GameObject points;
	public GameObject walls;
	public GameObject tester;


	// Use this for initialization
	void Start () {
		// Debug.Log("Fetching Map");
		MapData map = new MapData();
		map = p.GetMapData(m);
		// Debug.Log("Map Fetched");
		corners._point = points;
		corners.tester = tester;
		corners.original = map;
		map.data = corners.cornerMatcher(map.data);
		cord.coordinateGeneration(map.data);
	}

}
