using UnityEngine;

// @author Marshall Mason
public class MenuDataHolder : MonoBehaviour
{
    [HideInInspector]
    public bool isServer = false;

    [HideInInspector]
    public int numObstacles;

    [HideInInspector]
    public float maxX, maxY, maxZ, minX, minY, minZ;

    public void InstantiateObstacle(Vector3 location, GameObject obstacle)
    {
        Instantiate(obstacle, location, Quaternion.identity);
    }
	
}
