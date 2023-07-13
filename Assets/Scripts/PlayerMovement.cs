using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movespeed = 30.0f;

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(Horizontal, 0, Vertical) * Time.deltaTime, Space.World);
    }
}
