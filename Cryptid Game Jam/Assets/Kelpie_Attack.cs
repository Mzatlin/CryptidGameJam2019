using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelpie_Attack : MonoBehaviour
{
    void Kelpie_Bite(string path) 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Water Horse Bite", GetComponent<Transform>().position);
    }
}
