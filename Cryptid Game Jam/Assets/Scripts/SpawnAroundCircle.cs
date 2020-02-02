using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnAroundCircle : MonoBehaviour
{
    public event Action OnSpawned = delegate { };
    [SerializeField]
    int numObjects = 10;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    int Circleradius = 50;
    HealthController health;
    [SerializeField]
    int startingHealth = 1;
    Vector3 center;

    public static bool isActive;

    void OnEnable()
    {
        isActive = true;
        prefab.SetActive(true);
        OnSpawned();
        InvokeRepeating("CheckActive", 11f, 6f);
        /*  Vector3 center = transform.position;
          for (int i = 0; i < numObjects; i++)
          {
              Vector3 pos = RandomCircle(center, Circleradius);
              Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
              Instantiate(prefab, pos, rot);
              prefab.SetActive(true);
          }*/
    }

    void CheckActive()
    {
        if (!prefab.activeInHierarchy)
        {
            Vector3 center = transform.position;
            prefab.transform.position = RandomCircle(center, Circleradius);
            prefab.SetActive(true);
            OnSpawned();

            health = prefab.GetComponent<HealthController>();
            if (health != null)
            {
                health.CurrentHealth = startingHealth;
                prefab.GetComponent<HealthController>().IsDead = false;

            }

        }



        Vector3 RandomCircle(Vector3 center, float radius)
        {
            float ang = UnityEngine.Random.value * 360;
            Vector3 pos;
            pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
            pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            pos.y = center.y;
            return pos;
        }

    }
}
