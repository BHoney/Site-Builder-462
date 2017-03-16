using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateGen : MonoBehaviour {

    //template for 3d coordinates
   private int[] template = {0, 0, 0};

   public List<int[]> coordList = new List<int[]>();

 //  public int[] coordArray;

    //dummy input from the cornerfinder
   private int[,] pixelMap={{0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0}};
	
    //iterate through the given corner map to find corners and their matching pairs
   public List<int[]> coordinateGeneration(int [,] map)
{
    
    
    
    for(int i = 0; i < map.GetLength(0); ++i)
    {
        for(int j = 0; j < map.GetLength(1); ++j)
        {
            if( map[i,j] == 1)
            {
                    checkConnection(map, i, j);
            }
        }
    }

     //   coordArray = coordList.ToArray;
        return coordList;

}

    //check for other corners in the same row or column given the position of a corner
    public void checkConnection(int [,] map, int y, int x)
    {


        //checks the row for a matching corner
        for(int i = x; i < map.GetLength(1); i++)
        {
            if(map[y,i] == 1)
            {
                template[0] = i;
                template[1] = y;
                template[2] = 0;
                coordList.Add(template);
            }
        }

        //checks the colomn for a mathching corner
        for (int i = y; i < map.GetLength(0); i++)
        {
            if (map[i, x] == 1)
            {
                template[0] = x;
                template[1] = i;
                template[2] = 0;
                coordList.Add(template);
            }
        }
        //Debug feed
        Debug.Log(coordList);
    }

// Use this for initialization
	void Start () {

    //List<int> coordPairs = coordinateGeneration(pixelMap);

	}
	

}
