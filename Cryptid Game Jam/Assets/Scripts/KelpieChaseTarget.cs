using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpieChaseTarget : ChaserBase
{
    [SerializeField]
    KelpieStats kelpieStats;

    void Start()
    {
        speed = kelpieStats.KelpieBaseSpeed;
    }

    private void FixedUpdate()
    {
        GoToTarget(base.FindTarget());
    }

    protected override void GoToTarget(Vector3 _direction)
    {
        speed = kelpieStats.KelpieMoveSpeed;
        transform.position += new Vector3(_direction.x * speed, 0, _direction.z * speed) * Time.fixedDeltaTime;
    }


}
