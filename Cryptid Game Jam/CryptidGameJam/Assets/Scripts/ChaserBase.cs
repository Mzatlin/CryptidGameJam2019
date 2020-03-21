using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBase : MonoBehaviour
{
    [SerializeField]
    protected Transform target;
    [SerializeField]
    protected float speed = 5f;
    protected Vector3 direction;
    
    protected virtual Vector3 FindTarget()
    {
        direction = target.transform.position - transform.position;
        direction = direction.normalized;

        return direction;
    }

    protected virtual void GoToTarget(Vector3 _direction)
    {
        transform.position += new Vector3(_direction.x * speed, 0, _direction.z * speed) * Time.fixedDeltaTime;
    }
}
