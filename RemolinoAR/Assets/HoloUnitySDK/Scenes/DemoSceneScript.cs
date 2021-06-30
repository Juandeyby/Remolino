using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSceneScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * 30);
    }
}
