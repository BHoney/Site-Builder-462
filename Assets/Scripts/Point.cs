using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Point : MonoBehaviour
{

    public List<Point> neighbors;
    public List<Wall> children;
    public float x, y, z;
    public GameObject _wall;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        this.x = gameObject.transform.position.x;
        this.y = gameObject.transform.position.y;
        this.z = gameObject.transform.position.z;
        foreach (Point p in neighbors)
        {
            CreateWall(this, p);
        }
    }

    void CreateWall(Point A, Point B)
    {
        float Distance;
        Vector3 Origin;
        float xCompare = A.x - B.x;
        float yCompare = A.y - B.y;

        if (xCompare == 0)
        {
            Origin = new Vector3(A.x, (A.y + B.y) / 2, A.z);
			Distance = new Vector3(xCompare, yCompare, 0).magnitude;
            GameObject wall = Instantiate(_wall, Origin, Quaternion.identity) as GameObject;
            wall.GetComponent<Wall>().AddParents(A, B);
            children.Add(wall.GetComponent<Wall>());
			wall.transform.localScale += new Vector3(1, Distance, 1);
        }

		if (yCompare == 0){
			Origin = new Vector3((A.x+B.x)/2, A.y, A.z);
			Distance = new Vector3(xCompare, yCompare, 0).magnitude;
            GameObject wall = Instantiate(_wall, Origin, Quaternion.identity) as GameObject;
            wall.GetComponent<Wall>().AddParents(A, B);
            children.Add(wall.GetComponent<Wall>());
			wall.transform.localScale += new Vector3(Distance, 1, 1);
		}

        // Distance = new Vector3(A.x - B.x, A.y - B.y, A.z - B.z);
        // Vector3 Origin = new Vector3(Distance.x/2, Distance.y/2, Distance.z/2);
        //Use Half of Distance to instantiate a new Wall object
        //Use the magnitude to scale the new object
        //Add point B to neighbors and new Wall to children	



    }





}



