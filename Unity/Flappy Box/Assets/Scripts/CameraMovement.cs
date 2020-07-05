using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, player.transform.position.y + 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, player.transform.position.y + 2, -10);
    }
}
