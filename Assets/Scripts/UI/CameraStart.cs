using System.Collections;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    public float delayBeforeMove = 1f;  
    public float moveDuration = 2f;    
    public float moveDistance = 0.5f;   
    
    private Vector3 originalPosition;  

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(MoveCamera());
    }

    IEnumerator MoveCamera()
    {
        yield return new WaitForSeconds(delayBeforeMove);

        // Hareket ederken geçen süreyi takip etmek için değişken
        float elapsedTime = 0f;

        // Hedef pozisyon
        Vector3 targetPosition = originalPosition + new Vector3(moveDistance, 0, 0);

        // Kamerayı sağa doğru hareket ettir
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null; // Bir sonraki frame'de devam et
        }

        // Son pozisyonu tam olarak hedefe eşitle
        transform.position = targetPosition;
    }
}

