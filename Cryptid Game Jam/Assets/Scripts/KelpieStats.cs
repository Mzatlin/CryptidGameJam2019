using UnityEngine;

[CreateAssetMenu]
public class KelpieStats : ScriptableObject
{
    [SerializeField]
    float kelpieMoveSpeed;
    [SerializeField]
    float kelpieBaseSpeed;
    public bool isAlive;

    public float KelpieMoveSpeed { get => kelpieMoveSpeed; set => kelpieMoveSpeed = value; }
    public float KelpieBaseSpeed { get => kelpieBaseSpeed; set => kelpieBaseSpeed = value; }

    // Update is called once per frame
    public void ResetSpeed()
    {
        kelpieMoveSpeed = kelpieBaseSpeed;
    }

    public void SetSpeed(float _speed)
    {
        kelpieMoveSpeed = _speed;
    }



}
