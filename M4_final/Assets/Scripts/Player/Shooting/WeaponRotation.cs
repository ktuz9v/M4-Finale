using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Transform Target;
    public Camera CameraLink;
    public float TargetInSkyDistance;
    void Update()
    {
        LookAtPos();
    }
    void LookAtPos()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            Target.position = hit.point;
        else
            Target.position = ray.GetPoint(TargetInSkyDistance);

        transform.LookAt(Target.position);
    }
}
