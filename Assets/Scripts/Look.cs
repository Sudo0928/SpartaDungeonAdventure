using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
