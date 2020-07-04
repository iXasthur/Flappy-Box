using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{

    public class Platform
    {

        public GameObject main = new GameObject("Spawned platform");
        public List<GameObject> solids = new List<GameObject>();

        public readonly float holeWidthUnits = 1.2f;

        public Platform(GameObject samplePlatform)
        {
            CreateSolid(samplePlatform);
            CreateSolid(samplePlatform);
        }

        public void CreateSolid(GameObject samplePlatform)
        {
            GameObject go = new GameObject("Solid" + solids.Count.ToString());

            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            renderer.sprite = samplePlatform.GetComponent<SpriteRenderer>().sprite;

            Transform transform = go.GetComponent<Transform>();
            Vector2 v = samplePlatform.GetComponent<Transform>().localScale;
            transform.localScale = new Vector2(v.x, v.y);
            transform.parent = main.GetComponent<Transform>();
            if (solids.Count == 0)
            {
                transform.position = new Vector2((renderer.bounds.size.x + holeWidthUnits) / 2.0f, 0);
            } else
            {
                transform.position = new Vector2((renderer.bounds.size.x + holeWidthUnits) / -2.0f, 0);
            }

            go.AddComponent<BoxCollider2D>();

            solids.Add(go);
        }

        public void MoveTo(float x, float y)
        {
            Transform transform = main.GetComponent<Transform>();
            transform.position = new Vector2(x, y);
        }
    }

    public GameObject player;
    public GameObject startPlatform;

    private readonly List<Platform> platforms = new List<Platform>();

    private float offsetY = 1.5f;
    private float nextY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        nextY = startPlatform.transform.position.y;
        nextY = nextY - offsetY;

        SpawnNewPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < nextY + offsetY)
        {
            SpawnNewPlatform();
        }
    }

    private void SpawnNewPlatform()
    {
        Debug.Log("Spawning new platform");

        Platform platform = new Platform(startPlatform);
        platform.MoveTo(Random.Range(-1, 2), nextY);

        platforms.Add(platform);

        nextY = nextY - offsetY;
    }
}
