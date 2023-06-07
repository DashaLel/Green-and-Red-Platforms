using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(3, 8, -3);
   

  
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
