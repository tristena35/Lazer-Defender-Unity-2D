using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    float minSpinSpeed = 200f;
    float maxSpinSpeed = 1000f;
    float speedOfSpin;
    

    // Update is called once per frame
    void Update()
    {
        speedOfSpin = Random.Range(minSpinSpeed, maxSpinSpeed);
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}
