using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public GameObject Ball;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - Ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = offset + Ball.transform.position;
    }
}
