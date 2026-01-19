using UnityEngine;

public class FieldCamera : MonoBehaviour
{
    #region field
    [SerializeField] Transform target;
    float followSpeed = 3.0f;
    #endregion

    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        Follow();
    }

    #region method
    void Follow()
    {
        if (target == null) return;

        Vector3 targetPos = transform.position;

        targetPos.x = target.position.x;
        targetPos.y = target.position.y;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            followSpeed * Time.deltaTime
            );
    }
    #endregion
}
