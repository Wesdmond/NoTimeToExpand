using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        offset = offset - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + player.transform.position;
    }
}
