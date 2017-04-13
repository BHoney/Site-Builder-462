using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallPoints : MonoBehaviour {





//	adds wall WallPoints into a  list from image and returns the list
	public List<Vector3> getWallPoints(int[,] image){
		List<Vector3> wallPoints = new List<Vector3>();
		//i: number of rows
		for (int i = 0; i <= image.GetLength(0)-1; ++i) {
			print ("rows " + image.GetLength (0) );
			// j: number of cols
			for (int j = 0; j <= image.GetLength(1)-1; ++j) {
				print ("col " + image.GetLength (1) );
				// if the it is a black pixel(0) add it to the Vector3 array
				if(image[i,j] == 0){


					wallPoints.Add(new Vector3 (j,i,20));

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



//	takes in list off points in the wall and point thats being searched for neighbors
//	returns a vector with the x+ direction and the y- direction 
//	public Vector3 getWallLengths (List<Vector3> points, Vector3 point){
////		horiztonal and verticle count 
//		int countH = 0;
//		int countV = 0;
//	
//		float xStart = point.x;
//		float yStart = point.y;
//
////		while(points.ElementAt ().x)
//
////		for (int i = 0; i <= points.Count; ++i) {
////			Vector3 v1 = points.ElementAt (i);
//		int position = points.IndexOf(point);
//		int i = 1;
//		int j = 1;
//		Vector3 v1 = points.ElementAt(position);
//		Vector3 v2 = points.ElementAt (position + i);
//		Vector3 v3 = points.ElementAt (position + j);
//
//
//
////			Vector3 v2 = points.ElementAt (i + 1);
////
////			checks if there is a neighbor in the x direction
//			while (v1.x + 1 == v2.x) {
//					countH++;
//			}
////			checks if there is a neighbor in the y direction
//			while (v1.y + 1 == v2.y) {
//				countV++;
//			}
//	
////			points.Remove (v1);
//		}
//
//		float xLength = countH - xStart;
//		float yLength = yStart - countV;//want this negetive bc we draw down only
//
//		Vector3 wallLens = new Vector2 (xLength, yLength);//lengths in x and y direction.
//		return wallLens;
////		GameObject bube = GameObject.CreatePrimitive(PrimitiveType.Cube);
////		Instantiate(bube, v1, Quaternion.identity);
//	}


//	preps the list for yPointLength: only contains y Neighbors 
	public List<Vector3> yPrep(List<Vector3> yList){

//		for(int i =0; i < ){
//			f
//		}
//	}

		List<Vector3> y = new List<Vector3> ();
		for(int i =0; i < yList.Count-1;i++){
			Vector3 v1 = yList.ElementAt (i);
////			if(i != yList.Count -2 ){
//				
//				if (i != yList.Count -1) {//
//					Vector3 v2 = yList.ElementAt (i +1);
//
//					if (v1.x != v2.x) {
//						yList.Remove (v2);
//					}
//
//				}
////			}
			/// 
		
		
			if (i < yList.Count - 2) {

				Vector3 v3 = yList.ElementAt (i + 2); 
				if (i < yList.Count - 1) {
					Vector3 v2 = yList.ElementAt (i + 1);
						if(v1.x != v2.x && v2.x != v3.x ){
							yList.Remove (v2);
						}

					}
					
				}

			}

			
//			else{
//				Vector3 v2 = yList.ElementAt (i );
//				if (v1.x != v2.x) {
//					yList.Remove (v2);
//
//				}
//
//			}
//		
//		}
		return yList;
	}


//	returns a list containing the continous line segment of the point from the list
//	TODO: error point is not in the list 
	public List<Vector3> xPointLength(List<Vector3> points, Vector3 point){
		List<Vector3> listLen = new List<Vector3>();
		int pos = points.IndexOf (point);
		print ("pos  " + pos);
		int i =0;
//		for (int i = 0; i < points.Count-1; i++) {
		while(i+pos < points.Count -1){
			while(i+pos < points.Count){
				print ("i: " + i);
				Vector3 v1 = points.ElementAt (pos+i);
				Vector3 v2 = points.ElementAt (pos+i +1);

				if (point.y == v1.y && v1.x-v2.x > -2 ) {
					
					listLen.Add (v2);
				} 
				else {
					listLen.Add (point);
					return listLen;
				}
				i++;
			}
		}

		return listLen;
	}


//	public List<Vector3> yPointLength(List<Vector3> points, Vector3 point){
//		List<Vector3> listLen = new List<Vector3>();
//		int pos = points.IndexOf (point);
//		print ("pos  " + pos);
////		listLen.Add (point);
//
//		for (int i = pos; i < points.Count; i++) {
//
//			if (i == points.Count - 1) {
//				return listLen;
//				
//			} else {
//					Vector3 v1 = points.ElementAt (i);
//					//			Vector3 v2 = points.ElementAt (pos+i);
//
//					if (point.y == v1.y) {
//						listLen.Add (v1);
//					} else {
//						return listLen;
//					}
//				}
//			}
//
//			
//		return listLen;
//	}


////	returns an image with only point with no neighbors
//	public int[,] noNeighIMG(int [,] image){
//
//
//	}

	//	returns an image containing only the y points(more than 0 neighbors? more than 1 neighbor)
	public int[,] yIMG(int [,] image){
		//every column in the array

		for (int i = 0; i <= image.GetLength (0) - 2; ++i) {
			// every row in the array

			for (int j = 0; j <= image.GetLength (1) - 1; ++j) {
//				if(i == image.GetLength (0) - 1){
//				print("yyyy");
				if (image [i, j] == 0 && image[i+1,j] == 0) {
//					print("( " + i +", " + j + " )");
					image [i, j] = 0;
				} else {
					image [i, j] = 1;
				}
//				}

			}
		}
		return image;
	}


//	//	returns an image containing only the x points(more than 0 neighbors? more than 1 neighbor)
//	public int[,] xIMG(int [,] image){
//	}



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
			{ 0, 0 ,0, 0, 0, 0},
			{ 0, 0 ,0, 0, 0, 0},
			{ 1, 1 ,1, 1, 1, 1},
			{ 0, 0 ,0, 0, 0, 0},

		} ;


//		int[,] m = yIMG(imagey);
//		List<Vector3> y = getWallPoints (m);
//
//		printList (y);
		List<Vector3> points = getWallPoints(image3);
//			   printList(points); //for testing

//		draw a Cube for each point
				foreach(Vector3 point in points)
				{
//			point.y = 10;
			Instantiate(bube, point, Quaternion.identity);
				}

//		Vector3 p = new Vector3 (0, 0, 20);

//		List<Vector3> pp = xPointLength (points, p);
////
//		printList (pp);

//		List<Vector3> y = yPrep (points);


//		List<Vector3> py = yPointLength (points, p);
//
//		printList (py);



//		get rid of the original cube drawn
//		bube.SetActive(false); //only hides the cube
			Destroy(bube);

//		bube.transform.Rotate (0,0,-200);
	}



}
