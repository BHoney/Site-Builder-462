using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    //public static List<Point> pointList;
    public List<Point> neighbors;
    public List<Wall> children;
    public float x, y;
    public GameObject _wall;
    private bool initialized = false;
    private bool wallsMade = false;
    public bool isActive = false;
    public MapData mdata;


    void Start()
    {
        this.x = gameObject.transform.position.x;
        this.y = gameObject.transform.position.y;
        this.gameObject.name = string.Format("Point {0},{1}", x, y);
        //print(string.Format("{0} isActive: {1}", this.gameObject.name, this.isActive ));

    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>

    void AddNeighbor(Point Neighbor)
    {
        print(string.Format("Adding {0}", Neighbor));
        neighbors.Add(Neighbor);
    }

    void FindNeighborsRight()
    {
        RaycastHit rightHit;
        Ray rightRay = new Ray(transform.position, new Vector3(1, 0, 0));
        if (Physics.Raycast(rightRay, out rightHit))
        {
            Point right = rightHit.transform.GetComponent<Point>();
            print(right);
            AddNeighbor(right);
            //CreateWall(right);
        }

    }

    void FindNeighborsDown()
    {
        RaycastHit downHit;
        Ray downRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out downHit))
        {
            Point down = downHit.transform.GetComponent<Point>();
            print(down);
            AddNeighbor(down);
            // CreateWall(down);
        }
    }

    public void FindNeighbors(MapData data)
    {
        // int i = (int)this.x;
        // int j = (int)this.y;
        int[,] map = data.data;

        // if (map[(int)this.x+1, (int)this.y] != 0){ 
            print("Searching...");
            //Check right to see if a wall is here
            //If the wall is here, begin to search for it's end point
            for (int i = (int) this.x+1; i < data.width; i++)
            {
                // print("Checking for Wall");
                if (map[i, (int) this.y] == 1)
                {
                    //Continue until endpoint is found
                    print(string.Format("Wall segment found at x:{0}, y:{1}", i, this.y));
                    
                }
                else
                {
                    //Create new point here, connect to start point (this) as neighbors, draw wall.
                    print(string.Format("End of wall found at x:{0},y{1}", i, this.y));
                    //break;
                }
            // }
        }

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (isActive)
        {
            if (!initialized)
            {
                FindNeighborsRight();
                FindNeighborsDown();
               // FindNeighbors(mdata);
                initialized = !initialized;
            }
        }
    }


    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!wallsMade)
            {
                foreach (Point p in neighbors)
                {
                    CreateWall(p);
                }
                wallsMade = !wallsMade;
            }
        }
        if (!wallsMade)
        {
            foreach (Point p in neighbors)
            {
                CreateWall(p);
            }
            wallsMade = !wallsMade;
        }
    }

    void CreateWall(Point B)
    {

        //        print(string.Format("Creating wall {0}, {1}", this.gameObject.name, B.gameObject.name));
        Vector3 Origin;
        float xCompare = this.x - B.x;
        float yCompare = this.y - B.y;
        float Distance = new Vector3(xCompare, yCompare, 0).magnitude;

        if (xCompare == 0)
        {


            Origin = new Vector3(this.x, this.y - (yCompare / 2), 0);

            //Create a new wall object
            GameObject wall = Instantiate(_wall, Origin, Quaternion.identity) as GameObject;

            //Fetch the wall's data
            Wall newWall = wall.GetComponent<Wall>();

            //Apply the new wall to both parents
            newWall.AddParents(this, B);
            children.Add(newWall);
            B.children.Add(newWall);

            newWall.ScaleSelf(new Vector3(0.5f, Distance - .5f, 1));

        }

        if (yCompare == 0)
        {
            Origin = new Vector3(this.x - (xCompare / 2), this.y - .5f, 0);

            GameObject wall = Instantiate(_wall, Origin, Quaternion.identity) as GameObject;

            Wall newWall = wall.GetComponent<Wall>();

            newWall.AddParents(this, B);
            children.Add(newWall);
            B.children.Add(newWall);

            newWall.ScaleSelf(new Vector3(Distance, 0.5f, 1));
        }




    }





}



