using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTarget : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 2f;
    private Vector3 direction;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        direction = target.transform.position - transform.position;
        direction = direction.normalized;
        transform.position += new Vector3(direction.x * speed, 0, direction.z*speed) * Time.fixedDeltaTime;
    }
}
