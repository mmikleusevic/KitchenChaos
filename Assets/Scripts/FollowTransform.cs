using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    private Transform targetTransform;

    public void SetTargetTransform(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    private void LateUpdate()
    {
        if (!targetTransform) return;

        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
}
