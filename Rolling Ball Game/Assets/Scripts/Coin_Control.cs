using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Control : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,0,360 * Time.deltaTime);
    }
}
