using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    //making a list for all the squares in the route

    Transform[] childSquares;
    public List<Transform> childSquareList = new List<Transform>();

    //Draw out the route
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        FillSquares();

        //draw our the line,set the line will be draw till the end of the map
        for (int i = 0; i < childSquareList.Count; i++)
        {
            Vector3 currentPos = childSquareList[i].position;
            if (i > 0)
            {
                Vector3 previousPos = childSquareList[i - 1].position;
                //start drwaing
                Gizmos.DrawLine(previousPos, currentPos);
            }
        }
    }

    void FillSquares()
    {
        //clear the list
        childSquareList.Clear();

        //put the suqres in arrey
        childSquares = GetComponentsInChildren<Transform>();

        //set a loop for all the child objects under the Route
        foreach(Transform child in childSquares)
        {
            if(child != transform)
            {
                childSquareList.Add(child);
            }
        }
    }
}
