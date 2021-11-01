
using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    public Transform target;
    float maxSmoothSpeed = 0.85f;
    float smoothSpeed;
    float distanceFromTarget;
    [SerializeField] float maxDistanceFromTarget;
    float normalizedPercentage;

    private void Update()
    {
        distanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
        normalizedPercentage = maxDistanceFromTarget / distanceFromTarget;
        if(normalizedPercentage > 1)
        {
            normalizedPercentage = 1;
        }
        if(distanceFromTarget < 7f)
        {
            normalizedPercentage = 0.1f;
        }
        
    }
    private void LateUpdate()
    {
        smoothSpeed = maxSmoothSpeed * normalizedPercentage;
        Vector3 desiredPosition = target.position;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }



}
