using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;  // Array of waypoint transforms

    private void Awake()
    {
        // Create an array of transforms from the child transforms of this object
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
