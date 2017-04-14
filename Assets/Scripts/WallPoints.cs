﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallPoints : MonoBehaviour {





//	adds wall WallPoints into a  list from image and returns the list
	public List<Vector3> getWallPoints(int[,] image){
		List<Vector3> wallPoints = new List<Vector3>();
		//i: number of rows
		for (int i = 0; i <= image.GetLength(0)-1; ++i) {
//			print ("rows " + image.GetLength (0) );
			// j: number of cols
			for (int j = 0; j <= image.GetLength(1)-1; ++j) {
//				print ("col " + image.GetLength (1) );
				// if the it is a black pixel(0) add it to the Vector3 array
				if(image[i,j] == 0){


					wallPoints.Add(new Vector3 (i,j,20));

				}  
				// else {
				// 	image[i,j] = 1;
				// }

			}
		}

		return wallPoints;
	}

//	prints all WallPoints
	public void printList(List<Vector3> wallPoints){

		//		print each point for each point int the List wallpoint
		foreach(Vector3 point in wallPoints)
		{
			print (point.ToString());
		}

	}


	public int[,] xIMG(int [,] image){
		//every column in the array

		for (int i = 0; i <=  image.GetLength (0) - 1; ++i) {
			// every row in the array

			for (int j = 0; j <= image.GetLength (1) - 2; ++j) {
				//				if(i == image.GetLength (0) - 1){
				//				print("yyyy");


				if (image [i,j] == 0 && image[i,j+1] == 0 ) {
//					print ("len " + xLength (image, i, j));
					image [i,j] = 0;
				} else {
					image [i,j] = 1;
				}
				//				}

			}
		}
		for (int j = 0; j <= image.GetLength(0)-1; ++j) {
			if (image [j,image.GetLength(1) - 1] == 0 && image[j,image.GetLength(1) - 2] == 0) {
				image [j,image.GetLength(1) - 1] = 0;
			}
			else{
				image [j,image.GetLength(1) - 1] = 1;
			}
		}
		return image;
	}
		

	//	returns an image containing only the y points(more than 0 neighbors? more than 1 neighbor)
	public int[,] yIMG(int [,] image){
		//every column in the array

		for (int i = 0; i <= image.GetLength (0) - 2; ++i) {
			// every row in the array

			for (int j = 0; j <= image.GetLength (1) - 1; ++j) {
				

				if (image [i, j] == 0 && image[i+1,j] == 0) {
					
					image [i, j] = 0;
				} else {
					image [i, j] = 1;
				}

			}
		}
		for (int j = 0; j <= image.GetLength (1)-1; ++j) {
			if (image [image.GetLength (0) - 1,j] == 0 && image[image.GetLength (0) - 2,j] == 0) {
				image [image.GetLength (0) - 1,j] = 0;
			}
			else{
				image [image.GetLength (0) - 1,j] = 1;
			}
		}
		return image;
	}


	//	returns the amount of continuous wall pixels int the x direction(length) starting from given row and col
	public static int xLength(int[,] image,int row,int col){
		int xCount = 0;

		for (int j = col; j <= image.GetLength(1)-1 ; ++j) {
			print ("j :" + j);
			print( "col len " + image.GetLength(1));
			if(j == image.GetLength(1) -1  && image[row,j] ==0 ){
				print ("max len " + (image.GetLength(1) -2));
				xCount++;
				print ("first return ");
				return xCount;
			}

			if(image[row,j] == 0 && image[row,j+1] == 0 ){
				print ("second return ");
				xCount++;
			}

		}
		if (image [row, col] == 0) {
			xCount++;
		}

		return xCount;
	}
//	//	returns an image containing only the x points(more than 0 neighbors? more than 1 neighbor)
//	public int[,] xIMG(int [,] image){
//	}

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



//	public GameObject bube ;
	// Use this for initialization
	void Start () {
//		GameObject bube = new GameObject("bube") ;

//		GameObject bube = GameObject.Find("Cube");
//		print ("cccc " + bube.name);


//		Create a Cube in the scene
		GameObject bube = GameObject.CreatePrimitive(PrimitiveType.Cube);

//		change the color of the cube
		bube.GetComponent<Renderer>().material.color = Color.red;

		int height = 30;
		//		change the scale of the cube + z(height)
		bube.transform.localScale += new Vector3 (0, 0, height);

		
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
	
			} ;


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

		} ;

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
			{ 1, 1 ,1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{ 1, 1 ,1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},

		} ;

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
					{ 0, 1 ,1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0},
					{ 0, 1 ,0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0},
					{ 0, 1 ,1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
					{ 0, 0 ,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		
				} ;

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

		} ;

		int[,] imagey = {	
			{ 0, 0 ,1, 0, 1, 1},
			{ 0, 0 ,1, 0, 1, 1},
			{ 0, 0 ,1, 0, 1, 1},
			{ 0, 0 ,1, 0, 1, 1},

		} ;

		int[,] imagex = {	
			{ 0, 0 ,1, 1, 1, 1},
			{ 0, 1 ,1, 0, 0, 1},
			{ 1, 1 ,1, 1, 1, 1},
			{ 0, 0 ,1, 0, 0, 1},

		} ;
//		int[,] house ={
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111},
//			{1111111110000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//			{1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111},
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111110111111111111111111111111111111111111111111101111111
//		1111111110111111111111111111111111111111111111110111111011111111111111111111111111111111111101111111
//		1111111110000000000001111111000000000000000000000111111000000000000000111111111000000000000001111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110000001111110000000000000000000000000000000000000000001111111100000000000000001111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110000000000000000000000000000000000000000000000000000000000000000000000000000001111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111110111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111110111100111111111111111111111111111111111111111111111111111111111111111111111111111101111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
//		1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
//			{1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
//		}

			List<Vector3> points = getWallPoints(image4);


//		print ("len " + xLen (imagex, 3, 0));

//			   printList(points); //for testing

//		draw a Cube for each point
				foreach(Vector3 point in points)
				{
//			point.y = 10;
			Instantiate(bube, point, Quaternion.identity);
				}

//		Vector3 p = new Vector3 (0, 0, 20);




//		get rid of the original cube drawn
//		bube.SetActive(false); //only hides the cube
			Destroy(bube);

//		bube.transform.Rotate (0,0,-200);
	}



}
