using UnityEngine;
using UnityEngine.Serialization;

public class RemoteCamera : MonoBehaviour
{
    [Header("Ubicaciones:")]
    [SerializeField] private Transform remotePoint;
    [SerializeField] private Transform localPoint;
    [SerializeField] private Transform playerCamera;
    
    void Update()
    {
        var offset = playerCamera.position - localPoint.position;

        var rotationOffset = Quaternion.Angle(remotePoint.rotation, localPoint.rotation);
        var portalRotationOffset = Quaternion.AngleAxis(rotationOffset, Vector3.up);
        var cameraRotation = portalRotationOffset * playerCamera.forward;
        
        transform.position = remotePoint.position + offset;
        transform.rotation = Quaternion.LookRotation(cameraRotation, Vector3.up);
    }
}
