using System.Collections;
using UnityEngine;

public class RollingObstacles : MonoBehaviour
{
    public float rollingSpeed = 5f;
    public float rotationSpeed = 100f;
    public float leftWallZ = -1.49f;
    public float rightWallZ = 2.35f;

    private int direction = 1; 

    private void Start()
    {
        StartCoroutine(RollObstacles());
    }

    private IEnumerator RollObstacles()
    {
        while (true)
        {
            
            transform.Translate(Vector3.right * direction * rollingSpeed * Time.deltaTime);
            
            if (direction == 1 && transform.position.z > rightWallZ)
            {
                direction = -1;
            }
            else if (direction == -1 && transform.position.z < leftWallZ)
            {
                direction = 1;
            }

            yield return null;
        }
    }

    
}
