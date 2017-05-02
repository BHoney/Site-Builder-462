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

<<<<<<< HEAD
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
=======
		
	//returns image of walls in x direction
	public int[,] xIMG(int [,] image){
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {


			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {
>>>>>>> angelsbranch

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

<<<<<<< HEAD
        //		bube.transform.Rotate (0,0,-200);
    }
=======

	//	returns the amount of continuous wall pixels int the x direction(length) starting from given row and col




	//returns the length of the wall in the x++ direction
	public static int xLen(int[,] image,int row,int col){
		int j =col;
		int count = 0;
		while(image[row,j] == 0 && j != image.GetLength(1) -1){
			j++;
			count++;

		}
		if(j == image.GetLength(1) -1 && image[row,j] ==0){
			count++;
		}

		return count;

	}

	//returns the length of the wall in the y++ direction
	public static int yLen(int [,]image, int row,int col){
		int j =row;
		int count = 0;
		while(image[j,col] == 0.0 && j != (image.GetLength(0) -1)){
			//				System.out.println("HERE");
			//				if(j != image[0].length -1){
			j++;
			//				}
			count++;

		}
		if(j == (image.GetLength(0) -1) && image[j,col] == 0){
			count++;
		}

		return count;

	}






	//returns the length of the wall in the x-- direction
	public static int xLenRev(int[,] image,int row,int col){
		int j = col;
//		int j = image.GetLength(1) -1;
		int count = 0;
		while(image[row,j] == 0 && j != 0){
			j--;
			count++;

		}
		if(j == 0 && image[row,j] ==0){
			count++;
		}

		return count;

	}



	//	returns gap size(continous 1's) from given postion
	public int getXGapLen(int[,]image,int row, int col){


		int j =col;
		int count = 0;
		while(image[row,j] == 1 && j != image.GetLength(1) -1){
			j++;
			count++;

		}
		if(j == image.GetLength(1) -1 && image[row,j] ==1){
			count++;
		}

		return count;
	}










//	modified from http://stackoverflow.com/questions/6539571/how-to-resize-multidimensional-2d-array-in-c to add all new entries as 1's

	public int[,] ResizeArray(int[,] original, int rows, int cols)
	{
		int[,] newArray = new int[rows,cols];
		int minRows = Math.Min(rows, original.GetLength(0));
		int minCols = Math.Min(cols, original.GetLength(1));
		for (int i = 0; i < minRows; i++) {
			for (int k = minCols; k < newArray.GetLength (1); k++) {
				newArray [i, k] = 1;
			}
			for (int j = 0; j < minCols; j++) {
				newArray [i, j] = original [i, j];
			}

		}
		return newArray;
	}

//	returns the number of wall segments of given row
	public static int xLineSegs(int [,] image, int row){
		
		int iswall = 0;
		int count = 0;

			for (int j = 0; j <= image.GetLength (1)-1 ; ++j) {
				//				print ("j " + j + "len " + (image.GetLength(1) -1));
				if(j == image.GetLength(1) -1 && row != image.GetLength (0)-1){

					iswall = 0;
				}
				//its a wall
				if (iswall == image[row,j]) {
					count++;
					iswall = -1;

				}
				if (iswall == -image [row,j]) {
					iswall = 0;
				}

			}
		
		return count;
		
	}

	//	returns the maximum number of wall segments from a
	public static int maxLineSegs(int [,]image){

//		int iswall = 0;
//		int count = 0;
		int max = 0;
		int temp = 0;
		for (int i = 0; i <= image.GetLength (0)-1 ; ++i) {

			temp = xLineSegs(image, i);
			if(temp > max){
			max = temp;
			
			}

		}
		return max;

	}


//	public static int xLineSegs(int [,] image, int row){
//
//		int iswall = 0;
//		int count = 0;
//
//		for (int j = 0; j <= image.GetLength(1)-1 ; ++j) {
//			//				print ("j " + j + "len " + (image.GetLength(1) -1));
//			if(j == image.GetLength(1) -1 && row != image.GetLength(1)-1){
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


//	returns the max pixels contained in a line 
	public int maxLinePixs(int[,] image){
//		int [,]image2 =copyIMG (image);
		int count = 0;
//		int temp = 0;
		int max = 0;
		for (int i = 0; i <= image.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image.GetLength (1) - 1; ++j) {
				if (j == image.GetLength (1) - 1) {
					count = 0;
//					print ("end");
				}
				if(image[i,j] == 0){
					count++;
					if(count > max){
						max = count;
					}
				

				}
//				return max;
			}
		}
		return max;
	}

	public Material brick;
	//draws walls in x direction using a cube object per wall
	public void drawX(int[,]image, int xScale,int yScale){
		int hi = 12;
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {

				print ("drawing x");
//				if 0 create a cube 
				if (image2 [i,j] == 0  ) {
					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//					xcube.GetComponent<Renderer>().material.color = Color.blue;
//					GameObject xcube = GameObject.Find("bube");
					Renderer rend = xcube.GetComponent<Renderer>();
//					Material newMat = Resources.Load("Industrial_stone_Brick", typeof(Material)) as Material;
					rend.material =brick;

					int start = j ; // start at col j
					int length = xLen (image2,i,j) ; // get len in x direction(xwall) of given point(first 0 in x direction)
					int end = length + start - 1; //end point of xwall
					float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



					// x = length-1 (wall len -1 bc scale starts at 1)
					xcube.transform.localScale += new Vector3 (length-1 + xScale ,hi,0 + yScale);
//					xcube.transform.


					// get rid of remaining wall to avoid drawing cube for each 0 point
					for(int k =0; k < length; k++){
						image2 [i, j + k] = 1;
					}

					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
					Instantiate(xcube,new Vector3(midPoint + xScale,hi/2,i +yScale  ) , Quaternion.identity);


				
					Destroy (xcube);
				} 


			}
		}
	}

	public void drawX2(int[,]image){
		int hi = 12;
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {

				print ("drawing x");
				//				if 0 create a cube 
				if (image2 [i,j] == 0  ) {
					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
										xcube.GetComponent<Renderer>().material.color = Color.blue;
					//					GameObject xcube = GameObject.Find("bube");
//					Renderer rend = xcube.GetComponent<Renderer>();
					//					Material newMat = Resources.Load("Industrial_stone_Brick", typeof(Material)) as Material;
//					rend.material =brick;

					int start = j; // start at col j
					int length = xLen (image2,i,j); // get len in x direction(xwall) of given point(first 0 in x direction)
					int end = length + start - 1; //end point of xwall
					float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



					// x = length-1 (wall len -1 bc scale starts at 1)
					xcube.transform.localScale += new Vector3 (length-1,hi,0);

					// get rid of remaining wall to avoid drawing cube for each 0 point
					for(int k =0; k < length; k++){
						image2 [i, j + k] = 1;
					}
					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
					Instantiate(xcube,new Vector3(midPoint + 20,hi/2,i +20) , Quaternion.identity);
					Destroy (xcube);
				} 


			}
		}
	}

	//draws walls in x direction using a cube object per wall
	public void drawY(int[,]image){
		int hi = 12;
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {

				print ("drawing Y");
				//				if 0 create a cube 
				if (image2 [i,j] == 0  ) {
					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					xcube.GetComponent<Renderer>().material.color = Color.black;
					//					GameObject xcube = GameObject.Find("bube");

					int start = j; // start at col j
					int length = yLen (image2,i,j); // get len in x direction(xwall) of given point(first 0 in x direction)
					int end = length + start - 1; //end point of xwall
					float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



					// x = length-1 (wall len -1 bc scale starts at 1)
					xcube.transform.localScale += new Vector3 (0,hi,length-1);

					// get rid of remaining wall to avoid drawing cube for each 0 point
					for(int k =0; k < length; k++){
						image2 [i + k, j] = 1;
					}
					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
					Instantiate(xcube,new Vector3(midPoint,hi/2,i) , Quaternion.identity);
					Destroy (xcube);
				} 


			}
		}
	}



	//draws flat x image
	public void drawXF(int[,]image){
		int hi = 2;
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {

				//				if 0 create a cube 
				if (image2 [i,j] == 0  ) {
					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					xcube.GetComponent<Renderer>().material.color = Color.white;
//					xcube.transform.localPosition += new Vector3(0, -30, 0);
					xcube.transform.localScale += new Vector3 (0, (float)-.8,0 );
					int start = j; // start at col j
					int length = xLen (image2,i,j); // get len in x direction(xwall) of given point(first 0 in x direction)
					int end = length + start - 1; //end point of xwall
					float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



					// x = length-1 (wall len -1 bc scale starts at 1)
					xcube.transform.localScale += new Vector3 (length-1,0,0);

					// get rid of remaining wall to avoid drawing cube for each 0 point
					for(int k =0; k < length; k++){
						image2 [i, j + k] = 1;
					}
					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
					Instantiate(xcube,new Vector3(midPoint,30,i) , Quaternion.identity);
					Destroy (xcube);
				} 


			}
		}
	}


//	returns copy of int[,] image
	public int [,]copyIMG(int[,] image){
		int[,] copy = image.Clone() as int[,];
		return copy;
	}


//	retruns the amount of wall segments from an ximage
	public int xWallSegTotal(int[,] image){
		int iswall = 0;
		int count = 0;
		for (int i = 0; i <= image.GetLength (0)-1 ; ++i) {

			for (int j = 0; j <= image.GetLength (1)-1 ; ++j) {
//				print ("j " + j + "len " + (image.GetLength(1) -1));
				if(j == image.GetLength(1) -1 && i != image.GetLength (0)-1){

					iswall = 0;
				}
				//its a wall
				if (iswall == image[i,j]) {
					count++;
					iswall = -1;

				}
				if (iswall == -image [i,j]) {
					iswall = 0;
				}

			}
		}
		return count;
	}

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







	//		turns int[][] to Double[][]
	public static Double [,] intArrToDouble(int[,]image){

		Double [,] image2 =new Double[image.GetLength(0),image.GetLength(1)];

		for(int i = 0; i < image.GetLength(0);i++){
			for(int j = 0; j < image.GetLength(1); j++){
				image2[i,j] = (double) image[i,j];
			}

		}

		return image2;
	}


	//doube[,] to List<List<Double>>
	public static List<List<Double>> intArrToList<Double>( Double[,] array)
	{
		var result = new List<List<Double>>();
		var lengthX = array.GetLength(0);
		var lengthY = array.GetLength(1);

//		print (lengthY = array.GetLength (1));
		// the reason why we get lengths of dimensions before looping through
		// is because we would like to use `List<T>(int length)` overload
		// this will prevent constant resizing of its underlying array and improve performance
		for(int i = 0; i < lengthX;  i++)            
		{
			var listToAdd = new List<Double>(lengthY);

			for(int i2 = 0; i2 < lengthY; i2++)
			{
				listToAdd.Add(array[i, i2]);
			}

			result.Add(listToAdd);
		}       




//
//
//		foreach (var sublist in result)
//		{
//			foreach (var obj in sublist)
//			{
//				print(obj);
//			}
//		}
		return result;
	}     




	//gets the xlen of in a list of list<double>
	public static int xDoubleLen(List<List<Double>> imgList,int row,int col){
		int j =col;
		int count = 0;
		while(imgList.ElementAt(row).ElementAt(j) == ( 0.0) && j != imgList.ElementAt(row).Count() -1){
			//				System.out.println("HERE");
			//				if(j != image[0].length -1){
			j++;
			//				}
			count++;

		}
		if(j == imgList.ElementAt(row).Count() -1 && imgList.ElementAt(row).ElementAt(j) == (0.0)){
			count++;
		}

		return count;

	}



//	public static void scaleX(int[,] image, int scale){
//	}
//
//	public static int[,] scaleX(int[,] image, int scale)

		public static int[,] scaleX(int[,] image, int scale){
			Double [,]  image2 = intArrToDouble(image);
		List<List<Double>> imageList = intArrToList(image2);
			int maxWallSegs = maxLineSegs(image);
//		String[,] scaledIMGString = new String[image.GetLength(0),image.GetLength(1) + scale*maxWallSegs];
		int[,] scaledIMG = new int[image.GetLength(0),image.GetLength(1) + scale*maxWallSegs];
			//			ArrayList scaledIMGListimage = new ArrayList(image[0].length + scale*maxWallSegs);

	
			for(int i = 0; i < imageList.Count();i++){
	
		for(int j = 0; j < imageList.ElementAt(i).Count();j++){
						
				if(imageList.ElementAt(i).ElementAt(j) == (0.0)){
//					print ("true");
						int len = xDoubleLen(imageList, i,j);
//						//						System.out.println("len " + len);
						List<Double> arrList = new List<Double>(); // list used to add wall pix
					List<Double> fixedList =  imageList.ElementAt(i);// grab list(becomes fixed list from get )
//						//						System.out.println(arrList.size());
					for(int m = 0 ; m < fixedList.Count(); m++){
						arrList.Add((Double) fixedList.ElementAt(m)); // copy fixed list to flexible list
//							//							System.out.println(fixedList.get(m));
//	
//	
						}
//						//						System.out.println(arrList.size());
//						//						System.out.println(arrList + "\n Size "+  arrList.size() +  "  max " + (image[0].length + scale*maxWallSegs ));
//	
//						//						System.out.println(arrList);
						for(int k = 0; k < scale; k++){
						arrList.Insert(j, 0.0); // add wall pix for scale
//	
						}
					while(arrList.Count() < (image.GetLength(1) + scale*maxWallSegs )){//set extra spaces to 1(not wall)
//							//							System.out.println("smaller");
						arrList.Add(1.0);
						}
//						//						System.out.println(arrList);
//	
					while(arrList.Count() > (image.GetLength(1) + scale*maxWallSegs)){ // remove extra ones arrays equal sizes
						arrList.RemoveAt(arrList.Count()-1);
						}
//						//						System.out.println( "LAst " +  arrList);
//	
					if(len == image.GetLength(1)){ // if the wall is the length set scaled row to all zeros
						for(int p = 0; p < arrList.Count();p++){
//								arrList.set(p,0.0);
							arrList[p] = 0.0;
							}
						}
//						imageList.set(i,arrList);//set to scaled
					imageList[i] = arrList;
						j = j + len + scale;	//j now at the end of the wall					
					}
//	
				}
//				//				System.out.println(imageList.get(i));
			}
//	
//	
		for(int s = 0; s < imageList.Count();s++){
			for(int t = 0; t < imageList.ElementAt(s).Count();t++){
//				scaledIMGString[s][t] =  (imageList.ElementAt(s).ElementAt(t)).toString();//add to string image
	
//					scaledIMG[s][t] = Integer.parseInt(scaledIMGString[s][t].replace(".0", "")); //parse to int		
				scaledIMG[s,t] = Convert.ToInt32(imageList.ElementAt(s).ElementAt(t));
	
				}
			}
//	
//	
//			printIMG(scaledIMG);
			return scaledIMG;
		}


	// gets the line segments in given column
	public static int yLineSegs(int [,] image, int col){

		int iswall = 0;
		int count = 0;

		for (int j = 0; j <= image.GetLength(0)-1 ; ++j) {
			//				print ("j " + j + "len " + (image.GetLength(1) -1));
			if(j == image.GetLength(0) -1 && col != image.GetLength(1)-1){

				iswall = 0;
			}


			//its a wall
			if (iswall == image[j,col]) {
				count++;
				iswall = -1;

			}
			if (iswall == -image [j,col]) {
				iswall = 0;
			}

		}

		return count;

	}


	//gets max y line segments of image
	public static int maxLineSegsY(int [,]image){

		//		int iswall = 0;
		//		int count = 0;
		int max = 0;
		int temp = 0;
		for (int i = 0; i <= image.GetLength(1)-1 ; ++i) {

			temp = yLineSegs (image, i);
			if(temp > max){
				max = temp;

			}

		}
		return max;

	}



	public static List<Double> getCol2(List<List<Double>> imageList, int col){
		List<Double> cols = new List<Double>( imageList.Count());
		for(int i = 0; i <imageList.Count();i++ ){

			cols.Add( imageList.ElementAt(i).ElementAt(col)  );
			//					System.out.println(" add at " + col);
			//				}
		}
		return cols;
	}





	public static int[,] scaleY(int[,] image, int scale){



//		String[,] scaledIMGString = new String[image.GetLength(0),image.GetLength(1) + scale*maxWallSegs];
//		int[,] scaledIMG = new int[image.GetLength(0),image.GetLength(1) + scale*maxWallSegs];


		Double [,]  image2 = intArrToDouble(image);
		List<List<Double>> imageList = intArrToList(image2);
		List<List<Double>> imageList2 = new List<List<Double>>();
		int maxWallSegs = maxLineSegsY(image);
		String[,] scaledIMGString = new String[image.GetLength(0)+ scale*maxWallSegs,image.GetLength(1)];
		int[,] scaledIMG = new int[image.GetLength(0)+ scale*maxWallSegs,image.GetLength(1) ];
//		int[][] scaledIMG = new int[image.GetLength(0)+ scale*maxWallSegs][image[0].length ];
		//			ArrayList scaledIMGListimage = new ArrayList(image[0].length + scale*maxWallSegs);
		//			int arrSize = 0;



		for(int m = 0; m < imageList.ElementAt(0).Count();m++){
			imageList2.Add(getCol2(imageList,m));
			//					System.out.println(getCol2(imageList,m));
		}

		//	}



		for(int i = 0; i < imageList2.Count();i++){

			for(int j = 0; j < imageList2.ElementAt(0).Count();j++){
				//					imageList2.add(getCol2(imageList,j));
				//					System.out.println("j " + j);
				//					System.out.println( "imagelis2222 \n" + imageList2 +  "\n");
				//					List colList = new ArrayList();
				//					colList.addAll(getCol2(imageList,j));// 
				//					System.out.println("ColList " +  colList + "\n");
				if(imageList2.ElementAt(i).ElementAt(j) == (0.0)){
					
					int len = xDoubleLen(imageList2, i,j);

					//						System.out.printf("[%d][%d]  \nlen %d",i,j, len);
					List<Double> colList = imageList2.ElementAt(i);
					//						 List colList = getCol2(imageList, j);// 

					//						System.out.println("col list \n" + colList + "\n");


					List<Double> arrList = new List<Double>(); // list used to add wall pix
					//						List fixedList =  (List) imageList.get(i).get(j);// grab list(becomes fixed list from get )

					for(int m = 0 ; m <  colList.Count(); m++){
						arrList.Add((Double)  colList.ElementAt(m)); // copy fixed list to flexible list
					}



					for(int k = 0; k < scale; k++){
						arrList.Insert(j, 0.0); // add wall pix for scale

					}
					while(arrList.Count() < (image.GetLength(0) + scale*maxWallSegs) ){//set extra spaces to 1(not wall)
						arrList.Add(1.0);
					}

					while(arrList.Count() > (image.GetLength(0)  + scale*maxWallSegs)){ // remove extra ones make arrays equal sizes
						arrList.RemoveAt(arrList.Count()-1);
//						arrList.remove(arrList.size()-1);
					}

					if(len == image.GetLength(0)){ // if the wall is the length set scaled row to all zeros
						for(int p = 0; p < arrList.Count();p++){
//							arrList[p] = 0.0;
							arrList[p] = 0.0;
//							arrList.set(p,0.0);
						}
					}



//					imageList2.set(i,arrList);//set to scaled
					imageList2[i] = arrList;
					j = j + len + scale;	//j now at the end of the wall					
				}

			}

		}


		for(int s = 0; s < imageList2.Count();s++){
			for(int t = 0; t < imageList2.ElementAt(s).Count();t++){
				scaledIMGString[t,s] =  (imageList2.ElementAt(s).ElementAt(t)).ToString();//add to string image


				//switch s and t 
//				scaledIMG[t][s] = Integer.parseInt(scaledIMGString[t][s].replace(".0", "")); //parse to int	
				scaledIMG[t,s] = Convert.ToInt32(scaledIMGString[t,s]);

			}
		}


//		printIMG(scaledIMG);
		return scaledIMG;
	}




	//turns a flattened Color array into a 2D Color Array
	public Color[,] singleArrayToDouble( Color[] flattenedPixelArray,int width, int height){

		Color[,] pixels = new Color[width, height];

		for (int y = 0; y < height; y++) {

			for (int x = 0; x < width; x++) {

				pixels [x, y] = flattenedPixelArray [x * width + y];

			}
		}

		return pixels;

	}

	//2d Colors Array to a Binary int 2d array
	public int[,] ColorArrayToBinaryIntArray( Color[,] pixels,int width, int height){

		int[,] binaryPixels = new int[width,height];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				if (pixels [x, y] == Color.white) {
					binaryPixels [x,y] = 1;
				} else {
					binaryPixels [x, y] = 0;
				}
			}
		}

		return binaryPixels;

	}
	public Texture2D b;
	//		public Texture2D theTexture;
	//		public int[,] binaryPixels;
	//		private Color [,] pixels;
	//		private Color [] pixelArray;
	//		private int width;
	//		private int height;

//	public GameObject bube ;
	// Use this for initialization
	void Start () {
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
		Texture2D b = LoadPNG("/Users/angelrodriguez/Desktop/house.png");
		int width = b.width;
		int height = b.height;

		//get the pixels of the Texture/floorplan
		Color []pixelArray = b.GetPixels();

		//change to 2d array
		Color [,]pixels = singleArrayToDouble (pixelArray, width,height);

		//change into integer 2d array
		int[,]binaryPixels = ColorArrayToBinaryIntArray (pixels,width,height);

		GameObject floor = GameObject.Find("Floor");
		floor.transform.localPosition += new Vector3(width/2, 0, height/2);
		floor.transform.localScale += new Vector3 (width,0,height);

//		drawX (binaryPixels);
//		drawXF(binaryPixels);
//		drawX2(imagex);
		int[,] m = {
			{ 1, 0, 0, 0, 1 },
			{ 1, 0, 0, 1, 0 },
			{ 1, 1, 0, 0, 0 },
		};
//		int[,] img = scaleX(binaryPixels, 90);

//		drawXF (m);

		drawXF (binaryPixels);
		drawX (binaryPixels, 10,10 );

//		drawXF (scaleX (scaleY (imagex, 8),8));



	}
>>>>>>> angelsbranch


//	void OnGUI() {
//
//		//		(new Rect (20, 20, texture.width/2, texture.height/2)
//
//		Rect rect = new Rect(Screen.width/4, 200, Screen.width/2, Screen.height/2);//Rect to put the texture on
//		if (b!= null) {
//			GUI.DrawTexture(rect, b,ScaleMode.StretchToFill);//draws the texture on the rect
//
//			GUI.Button(new Rect(800, 660, 130, 30), "Hide Image");
//
//
//		}
//
//
//
//
//	}
}
