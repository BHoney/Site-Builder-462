using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CornerFinder : MonoBehaviour {
	 
	private int[,] pixelMap;
	public PixelScanner scanner;
	private List<int> xValues = new List<int>();
	private List<int> yValues = new List<int>();
	public int[] xCoords;
	public int[] yCoords;

	//ensure that a corner is found
	private bool checkNeighbors(int i_y, int i_x, int[,] currentMap){
		if ((currentMap [i_y + 1, i_x] == 1) || (currentMap [i_y - 1, i_x] == 1)) {
			if ((currentMap [i_y, i_x + 1] == 1) || (currentMap [i_y, i_x - 1] == 1)) {
				return true;
			}else{
				return false;
			}
		} else {
			return false;
		}
	}

	//uses a 2D array of a binary image to find where the black is and calls checkNeighbors
	//adds the x and y value to the array of values in order of discovery
	private void findingCorners(int[,] pixelMap){

		for (int y = 0; y < pixelMap.GetLength(0); y++) {
			for (int x = 0; x < pixelMap.GetLength (1); x++) {
				if (pixelMap [y, x] == 1) {
					bool isCorner = checkNeighbors (y, x, pixelMap);
					Debug.Log (isCorner);
					if(isCorner == true){
					
						xValues.Add(x);
						yValues.Add(y);

					}
				}
			}

		}

		xCoords = xValues.ToArray ();
		yCoords = yValues.ToArray ();
	
	}

	//returns the int array of x coordinates in order of discovery
	//values match with their respective y coordinate
	public int[] getXCoords(){
		return xCoords;
	}

	//returns the int array of y coordinates in order of discovery
	//values match with their respective x coordinate
	public int[] getYCoords(){
		return yCoords;
	}
	//initialization and autorun of findingCorners
	void Start(){ 
		pixelMap = scanner.GetMapData ();
		findingCorners (pixelMap);
	}
}

