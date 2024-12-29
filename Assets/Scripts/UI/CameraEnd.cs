using System.Collections;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    public float moveBackDuration = 4f; 
    public float moveBackDistance = 5f; 
    public float moveUpDuration = 3f; 
    public float moveUpDistance = 3f; 

    private Vector3 initialPosition; 

    void Start()
    {
        initialPosition = transform.position; 
        StartCameraMovement(); 
    }

    public void StartCameraMovement()
    {
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        Vector3 targetBackPosition = initialPosition - transform.forward * moveBackDistance;
        float elapsedTime = 0f;

        while (elapsedTime < moveBackDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetBackPosition, elapsedTime / moveBackDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetBackPosition;

        Vector3 targetUpPosition = targetBackPosition + Vector3.up * moveUpDistance;
        elapsedTime = 0f;

        while (elapsedTime < moveUpDuration)
        {
            transform.position = Vector3.Lerp(targetBackPosition, targetUpPosition, elapsedTime / moveUpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetUpPosition;
    }
}
