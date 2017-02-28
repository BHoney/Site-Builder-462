using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Point[] parents = new Point[2];
    public bool selected;


    /// <summary>
    /// Adds the parent points to the wall's internal array.
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>

    public void AddParents(Point A, Point B)
    {
        parents[0] = A;
        parents[1] = B;

    }

    /// <summary>
    /// Get the wall's parents.
    /// </summary>
    /// <returns>Point[] parents</returns>
    public Point[] GetParents()
    {
        return parents;
    }

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        selected = !selected; //Toggle selected wall.
        if (selected)
        {
            foreach (Point p in parents)
            {
                p.GetComponent<Renderer>().material.color = Color.green; //Highlight all parents
            }
			this.gameObject.GetComponent<Renderer>().material.color = Color.blue; //Highlight this wall.

        }
    }
}

