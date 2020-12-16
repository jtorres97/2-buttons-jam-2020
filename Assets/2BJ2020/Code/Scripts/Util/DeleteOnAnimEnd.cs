using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnAnimEnd : MonoBehaviour
{
    public float delay = 0f;

    private void Start () 
    {
        Destroy (gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
    }
}
