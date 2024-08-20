using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRandomIcon : MonoBehaviour
{
    private float speed;

    private void OnEnable()
    {
        speed = Random.Range(-0.05f, 0.05f);
    }

    private void Update()
    {
        this.gameObject.transform.Rotate(0f, 0f, speed);
    }
}
