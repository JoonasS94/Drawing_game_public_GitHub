using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerTutorial : MonoBehaviour
{

    public GameObject go1;
    public GameObject go2;

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(go1.transform.position, go2.transform.position);

        if (dist > 0.15f)
        {
            go2.transform.position = new Vector3(go1.transform.position.x, -0.0035f, go1.transform.position.z);
        }
    }
}
