using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow_VanLoc : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;          

    [Header("Follow Settings")]
    [SerializeField] private Vector2 offset = new Vector2(0f, 1f); 
    [SerializeField] private float smoothSpeed = 5f;             
    [SerializeField] private bool clampX = false;               
    [SerializeField] private Vector2 minXMaxX = new Vector2(-999, 999);

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 desired = new Vector3(
            target.position.x + offset.x,
            target.position.y + offset.y,
            -10f);
        if (clampX)
            desired.x = Mathf.Clamp(desired.x, minXMaxX.x, minXMaxX.y);

        
        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
    }
}
