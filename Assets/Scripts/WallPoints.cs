using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;

public class WallPoints : MonoBehaviour
{

    public GameObject walls = new GameObject();
    public GameObject flatImages = new GameObject();


    //	adds wall WallPoints into a  list from image and returns the list
    public List<Vector3> getWallPoints(int[,] image)
    {
        List<Vector3> wallPoints = new List<Vector3>();
        //i: number of rows
        for (int i = 0; i <= image.GetLength(0) - 1; ++i)
        {
            //			print ("rows " + image.GetLength (0) );
            // j: number of cols
            for (int j = 0; j <= image.GetLength(1) - 1; ++j)
            {
                //				print ("col " + image.GetLength (1) );
                // if the it is a black pixel(0) add it to the Vector3 array
                if (image[i, j] == 0)
                {


                    wallPoints.Add(new Vector3(j, 20, i));

                }
                // else {
                // 	image[i,j] = 1;
                // }

            }
        }

        return wallPoints;
    }

    //	prints all WallPoints
    public void printList(List<Vector3> wallPoints)
    {

        //		print each point for each point int the List wallpoint
        foreach (Vector3 point in wallPoints)
        {
            print(point.ToString());
        }

    }
    public void printList1(List<Color> wallPoints)
    {

        //		print each point for each point int the List wallpoint
        foreach (Color point in wallPoints)
        {
            print(point.ToString());
        }

    }
    public void print2dArr(int[,] arr)
    {

        int rowLength = arr.GetLength(0);
        int colLength = arr.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                print(string.Format("{0} ", arr[i, j]));
            }
            print("\n");
        }
        //		Console.ReadLine();
    }

    //returns image of walls in x direction
    public int[,] xIMG(int[,] image)
    {
        int[,] image2 = copyIMG(image);
        for (int i = 0; i <= image2.GetLength(0) - 1; ++i)
        {


            for (int j = 0; j <= image2.GetLength(1) - 2; ++j)
            {


                if (image2[i, j] == 0 && image2[i, j + 1] == 0)
                {
                    image2[i, j] = 0;
                }
                //			*****************add this if we want to get rid of those with no neighbors (single pix wall)*********
                //				else {
                //					image [i,j] = 1;
                //				}
                //			*****************add this if we want to get rid of those with no neighbors (single pix wall)*********
            }
        }
        for (int j = 0; j <= image2.GetLength(0) - 1; ++j)
        {
            if (image2[j, image2.GetLength(1) - 1] == 0 && image2[j, image2.GetLength(1) - 2] == 0)
            {
                image2[j, image2.GetLength(1) - 1] = 0;
            }
            //			*****************add this if we want to get rid of those with no neighbors (single pix wall)*********
            //			else{
            //				image2 [j,image2.GetLength(1) - 1] = 1;
            //			}
            //			*****************add this if we want to get rid of those with no neighbors(single pix wall)*********
        }
        return image2;
    }


    //	returns an image containing only the y points(more than 0 neighbors? more than 1 neighbor)
    public int[,] yIMG(int[,] image)
    {


        for (int i = 0; i <= image.GetLength(0) - 2; ++i)
        {

            for (int j = 0; j <= image.GetLength(1) - 1; ++j)
            {


                if (image[i, j] == 0 && image[i + 1, j] == 0)
                {

                    image[i, j] = 0;
                }
                //				else {
                //					image [i, j] = 1;
                //				}

            }
        }
        for (int j = 0; j <= image.GetLength(1) - 1; ++j)
        {
            if (image[image.GetLength(0) - 1, j] == 0 && image[image.GetLength(0) - 2, j] == 0)
            {
                image[image.GetLength(0) - 1, j] = 0;
            }
            //			else{
            //				image [image.GetLength (0) - 1,j] = 1;
            //			}
        }
        return image;
    }


    //	returns the amount of continuous wall pixels int the x direction(length) starting from given row and col




    //returns the length of the wall in the x++ direction
    public static int xLen(int[,] image, int row, int col)
    {
        int j = col;
        int count = 0;
        while (image[row, j] == 0 && j != image.GetLength(1) - 1)
        {
            j++;
            count++;

        }
        if (j == image.GetLength(1) - 1 && image[row, j] == 0)
        {
            count++;
        }

        return count;

    }

    //returns the length of the wall in the x-- direction
    public static int xLenRev(int[,] image, int row, int col)
    {
        int j = col;
        //		int j = image.GetLength(1) -1;
        int count = 0;
        while (image[row, j] == 0 && j != 0)
        {
            j--;
            count++;

        }
        if (j == 0 && image[row, j] == 0)
        {
            count++;
        }

        return count;

    }

    //	public void scaleX(int[,] image, int scale){
    //		int hi = 20;
    ////		int[,] scaledIMG;
    //		int [,]image2 =copyIMG (image);
    //		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {
    //
    //			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {
    //
    //				//				if 0 create a cube 
    //				if (image2 [i,j] == 0  ) {
    //					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //					xcube.GetComponent<Renderer>().material.color = Color.cyan;
    //
    //					int start = j * scale; // start at col j 
    //					int length = xLen (image2,i,j) ; // get len in x direction(xwall) of given point(first 0 in x direction)
    //					int newLen = xLen (image2,i,j)+scale ;//length after scale increase
    //					int end;
    //					float midPoint;
    //					//if the wall is the size max length
    //					if (length == image2.GetLength (1) ) {
    //						print ("long wall ");
    ////						float s = (float)(start+ scale)/2;
    //						int maxLen = (xWallSeg(image2)*scale) + newLen; 
    ////						 end = newLen + scale - 1 + scale; // max end pos 
    //						end = maxLen;
    //						xcube.transform.localScale += new Vector3 (  maxLen ,hi,0);//newlen +
    //						midPoint= (float)(scale + end) / 2;//get mid point for instant. cube
    //						print ("end: " + end);
    //					} else {
    //						 end = newLen + start - 1; //end point of xwall
    //						xcube.transform.localScale += new Vector3 (newLen-1,hi,0);
    //						midPoint= (float)(start + end) / 2;//get mid point for instant. cube
    //					}
    //
    //					// get rid of remaining wall to avoid drawing cube for each 0 point
    //					for(int k =0; k < length ; k++){
    //						image2 [i, j + k] = 1;
    //					}
    //					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
    //					Instantiate(xcube,new Vector3(midPoint,hi/2,i) , Quaternion.identity);
    //					Destroy (xcube);
    //				} 
    //
    //
    //			}
    //		}
    //	}

    //	returns gap size(continous 1's) from given postion
    public int getXGapLen(int[,] image, int row, int col)
    {


        int j = col;
        int count = 0;
        while (image[row, j] == 1 && j != image.GetLength(1) - 1)
        {
            j++;
            count++;

        }
        if (j == image.GetLength(1) - 1 && image[row, j] == 1)
        {
            count++;
        }

        return count;
    }


    //	public int[,] scaleX(int[,] image, int scale){
    //		
    //			int [,]image2 =copyIMG (image);
    //		int rows = (image2.GetLength (0) - 1);
    //		int newCols = (image2.GetLength (1) - 1 + scale);
    //		image2 = ResizeArray (image2,rows,newCols  );
    //		for (int i = 0; i <= image2.GetLength (0) - 1; ++i) {
    //		
    //			for (int j = image2.GetLength (1) - 2; j >= 0; j--) {
    //				if (image2 [i,j] == 0) {
    //					int wallStart = j;
    //					int len = xLenRev (image2,i,j);
    //					int wallSegs = xLineSegs (image2, i);
    //					int wallEnd = j - len - 1;
    //
    ////					image [i] [];
    //					for(int k =0; k < len; k++){
    //						image2 [i, j - k] = 1;
    //					}
    ////					image2 [i, j + wallSegs * scale] = image2 [i, j];
    ////					image2 [i, wallEnd];
    //
    //				}
    //			}
    //		}
    //		return image2;
    //	}

    //	modified from http://stackoverflow.com/questions/6539571/how-to-resize-multidimensional-2d-array-in-c to add all new entries as 1's

    public int[,] ResizeArray(int[,] original, int rows, int cols)
    {
        int[,] newArray = new int[rows, cols];
        int minRows = Math.Min(rows, original.GetLength(0));
        int minCols = Math.Min(cols, original.GetLength(1));
        for (int i = 0; i < minRows; i++)
        {
            for (int k = minCols; k < newArray.GetLength(1); k++)
            {
                newArray[i, k] = 1;
            }
            for (int j = 0; j < minCols; j++)
            {
                newArray[i, j] = original[i, j];
            }

        }
        return newArray;
    }

    //	returns the number of wall segments of given row
    public int xLineSegs(int[,] image, int row)
    {

        int iswall = 0;
        int count = 0;

        for (int j = 0; j <= image.GetLength(1) - 1; ++j)
        {
            //				print ("j " + j + "len " + (image.GetLength(1) -1));
            if (j == image.GetLength(1) - 1 && row != image.GetLength(0) - 1)
            {

                iswall = 0;
            }
            //its a wall
            if (iswall == image[row, j])
            {
                count++;
                iswall = -1;

            }
            if (iswall == -image[row, j])
            {
                iswall = 0;
            }

        }

        return count;

    }

    //	returns the maximum number of wall segments from a
    //	public int xLineSegs(int [,] image, int row){
    //
    //		int iswall = 0;
    //		int count = 0;
    //
    //		for (int j = 0; j <= image.GetLength (1)-1 ; ++j) {
    //			//				print ("j " + j + "len " + (image.GetLength(1) -1));
    //			if(j == image.GetLength(1) -1 && row != image.GetLength (0)-1){
    //
    //				iswall = 0;
    //			}
    //			//its a wall
    //			if (iswall == image[row,j]) {
    //				count++;
    //				iswall = -1;
    //
    //			}
    //			if (iswall == -image [row,j]) {
    //				iswall = 0;
    //			}
    //
    //		}
    //
    //		return count;
    //
    //	}

    //draws walls in x direction using a cube object per wall
    public void drawX(int[,] image)
    {

        int hi = 2;
        int[,] image2 = copyIMG(image);
        for (int i = 0; i <= image2.GetLength(0) - 1; ++i)
        {

            for (int j = 0; j <= image2.GetLength(1) - 2; ++j)
            {

                print("drawing x");
                //				if 0 create a cube 
                if (image2[i, j] == 0)
                {
                    GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    xcube.GetComponent<Renderer>().material.color = Color.blue;
                    //					GameObject xcube = GameObject.Find("bube");

                    int start = j; // start at col j
                    int length = xLen(image2, i, j); // get len in x direction(xwall) of given point(first 0 in x direction)
                    int end = length + start - 1; //end point of xwall
                    float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



                    // x = length-1 (wall len -1 bc scale starts at 1)
                    xcube.transform.localScale += new Vector3(length - 1, hi, 0);

                    // get rid of remaining wall to avoid drawing cube for each 0 point
                    for (int k = 0; k < length; k++)
                    {
                        image2[i, j + k] = 1;
                    }
                    //create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
                    GameObject newWall = Instantiate(xcube, new Vector3(midPoint, hi / 2, i), Quaternion.identity);
                   	newWall.transform.SetParent(walls.transform);
                    Destroy(xcube);
                }


            }
        }
    }


	public void showWalls(bool trigger){
		if(trigger == true){
			walls.gameObject.SetActive(true);
		}
		else{
			walls.gameObject.SetActive(false);
		}
	}

    //draws flat x image
    public void drawXF(int[,] image)
    {
        GameObject flatImage = new GameObject();
        int hi = 2;
        int[,] image2 = copyIMG(image);
        for (int i = 0; i <= image2.GetLength(0) - 1; ++i)
        {

            for (int j = 0; j <= image2.GetLength(1) - 2; ++j)
            {

                //				if 0 create a cube 
                if (image2[i, j] == 0)
                {
                    GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    xcube.GetComponent<Renderer>().material.color = Color.red;
                    //					xcube.transform.localPosition += new Vector3(0, -30, 0);
                    xcube.transform.localScale += new Vector3(0, (float)-.8, 0);
                    int start = j; // start at col j
                    int length = xLen(image2, i, j); // get len in x direction(xwall) of given point(first 0 in x direction)
                    int end = length + start - 1; //end point of xwall
                    float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



                    // x = length-1 (wall len -1 bc scale starts at 1)
                    xcube.transform.localScale += new Vector3(length - 1, 0, 0);

                    // get rid of remaining wall to avoid drawing cube for each 0 point
                    for (int k = 0; k < length; k++)
                    {
                        image2[i, j + k] = 1;
                    }
                    //create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
                    GameObject newCube = Instantiate(xcube, new Vector3(midPoint, -1, i), Quaternion.identity);
                    newCube.transform.SetParent(flatImage.transform);
                    Destroy(xcube);
                }


            }
        }
    }


    //	returns copy of int[,] image
    public int[,] copyIMG(int[,] image)
    {
        int[,] copy = image.Clone() as int[,];
        return copy;
    }


    //	retruns the amount of wall segments from an ximage
    public int xWallSeg(int[,] image)
    {
        int iswall = 0;
        int count = 0;
        for (int i = 0; i <= image.GetLength(0) - 1; ++i)
        {

            for (int j = 0; j <= image.GetLength(1) - 1; ++j)
            {
                //				print ("j " + j + "len " + (image.GetLength(1) -1));
                if (j == image.GetLength(1) - 1 && i != image.GetLength(0) - 1)
                {

                    iswall = 0;
                }
                //its a wall
                if (iswall == image[i, j])
                {
                    count++;
                    iswall = -1;

                }
                if (iswall == -image[i, j])
                {
                    iswall = 0;
                }

            }
        }
        return count;
    }

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;// initiate texture
        byte[] fileData;

        Debug.Log("loading.... " + filePath);
        if (File.Exists(filePath)) //if the file exists..    
        {
            Debug.Log("file exists ");
            fileData = File.ReadAllBytes(filePath);//reads all the byes in the file
            tex = new Texture2D(2, 2);//creates in temperary texture
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
    //	public GameObject bube ;
    // Use this for initialization
    void Start()
    {
        //		GameObject bube = new GameObject("bube") ;

        //		GameObject bube = GameObject.Find("bube");
        //		bube.transform.localPosition += new Vector3(0, -50, 0);

        //		print ("cccc " + bube.name);


        //		Create a Cube in the scene
        //		GameObject bube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //		change the color of the cube
        //		bube.GetComponent<Renderer>().material.color = Color.red;


        //		Shader brick1 = Shader.Find("Industrial_stone_Brick_1");
        //		bube.GetComponent<Renderer>().material.shader = brick1 ;

        //		bube.GetComponent<Renderer>().material = new Material(Shader.Find("Industrial_stone_Brick"));

        //		Texture2D brick = LoadPNG("/Users/angelrodriguez/Desktop/brick.jpeg");

        //		bube.GetComponent<Renderer>().material.mainTexture=brick; 
        int hi = 10;
        //		change the scale of the cube + z(height)
        //		GameObject bube = GameObject.Find("bube");
        //		bube.transform.localScale += new Vector3 (0, (float)-.8,0);
        Texture2D b = LoadPNG("/Users/angelrodriguez/Downloads/House_2.png");

        int[,] image1 = {
                { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

            };


        int[,] image2 = {
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1},
            { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1},
            { 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0},
            { 1, 1, 1, 1, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

        };

        int[,] image3 = {
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0},
            { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 1, 1, 1, 0, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 1, 1 ,0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 1, 1 ,0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1},
            { 1, 1 ,0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            { 1, 1 ,1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
            { 1, 1 ,1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},

        };

        int[,] image4 = {
                    { 0, 0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0},
                    { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0},
                    { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0},
                    { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0},
                    { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0},
                    { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0},
                    { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    { 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    { 0, 1, 1, 0, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    { 0, 1 ,0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
                    { 0, 1 ,0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0},
                    { 0, 1 ,0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0},
                    { 0, 1 ,1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0},
                    { 0, 0 ,0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0},
                    { 0, 1 ,1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0},
                    { 0, 1 ,0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
                    { 0, 1 ,1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
                    { 0, 0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

                };

        int[,] image5 = {
            { 0, 0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 1, 1, 1, 1 , 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0},
            { 0, 0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},

        };

        int[,] imagey = {
            { 0, 0 ,1, 0, 1, 1},
            { 0, 0 ,1, 0, 1, 1},
            { 0, 0 ,1, 0, 1, 1},
            { 0, 0 ,1, 0, 1, 1},

        };

        int[,] imagex = {
            { 0, 0 ,0, 0, 0, 0},
            { 0, 1 ,1, 0, 0, 1},
            { 1, 1 ,1, 1, 1, 1},
            { 0, 0 ,1, 0, 0, 0},

        };

        //		print (getXGapLen (imagex, 3, 2));
        //		int row = imagex.GetLength(0)-1;
        //		int newCol = imagex.GetLength(1) + 3;
        //		int[,] newArr = ResizeArray (imagex, row, newCol);
        //		print(newArr [0,6]);

        //		scaleX (imagex, 3);
        //		print(xLenRev(imagex,3,5));


        int[,] imagex2 = {
            { 0, 0 ,0, 0, 0, 0},
            { 0, 1 ,1, 0, 0, 1},
            { 1, 1 ,1, 1, 1, 1},
            { 0, 0 ,1, 0, 0, 0},

        };

        int[,] xwall = {
            { 0,0,0,0,1,0,1,1},
            { 0,0,1,0,1,0,1,0},
        };


        //		 Rect sourceRect;
        Texture2D h = LoadPNG("/Users/angelrodriguez/Desktop/bp1.jpg");

        //		int width = Mathf.FloorToInt(h.width);
        //		int height = Mathf.FloorToInt(h.height);
        //
        //		Color[] pix = h.GetPixels(0, 0, width, height);
        //		var cl = pix.ToList();
        //
        //		printList1 (cl);
        //		h.SetPixels(pix);
        //		h.Apply();
        //		GetComponent<Renderer>().material.mainTexture = h;


        //			List<Vector3> points = getWallPoints(imagex);


        //		print ("len " + xLen (imagex, 3, 0));

        //			   printList(points); //for testing

        //		draw a Cube for each point
        //				foreach(Vector3 point in points)
        //				{
        //			Instantiate(bube, point, Quaternion.identity);
        //				}

        //		xwall [0, 2];
        //		int len = xLen (imagex, 0,0);
        //		print ("len " + len);
        //
        //		print ("max len " + imagex.GetLength (1));
        //		print(xLineSegs(xwall,1));
        drawXF(xIMG(imagex));

        drawX(xIMG(imagex));



        //		scaleX (xIMG(imagex), 10);



        //		get rid of the original cube drawn
        //		bube.SetActive(false); //only hides the cube
        //			Destroy(bube);
        //		Destroy (xcube);

        //		bube.transform.Rotate (0,0,-200);
    }



}
