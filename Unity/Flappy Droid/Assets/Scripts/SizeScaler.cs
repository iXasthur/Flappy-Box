using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeScaler : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        float heightUnits = 2 * Camera.main.orthographicSize;
        float widthUnits = heightUnits * Camera.main.aspect;

        Transform playerTransform = player.GetComponent<Transform>();
        float playerSizeUnits = widthUnits * 0.05f;
        playerTransform.localScale = new Vector3(playerSizeUnits, playerSizeUnits, playerSizeUnits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
