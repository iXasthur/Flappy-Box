using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBordersMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject left;
    public GameObject right;
    
    // Start is called before the first frame update
    void Start()
    {
        float heightUnits = 2 * Camera.main.orthographicSize;
        float widthUnits = heightUnits * Camera.main.aspect;

        Transform transformLeft = left.GetComponent<Transform>();
        transformLeft.position = new Vector2(-(widthUnits + transformLeft.localScale.x)/2.0f, 0);
        
        Transform transformRight = right.GetComponent<Transform>();
        transformRight.position = new Vector2((widthUnits + transformRight.localScale.x)/2.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, player.transform.position.y + 2, -10);
    }
}
