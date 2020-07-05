using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaSpawner : MonoBehaviour
{

    public class Platform
    {
        public readonly GameObject main = new GameObject("Spawned platform");
        public readonly List<GameObject> solids = new List<GameObject>();

        public readonly float holeWidthUnits;
        
        public Platform(GameObject samplePlatform, float holeWidthUnits)
        {
            this.holeWidthUnits = holeWidthUnits;
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

            go.AddComponent<BoxCollider2D>(); // Solid part
            BoxCollider2D collider = go.AddComponent<BoxCollider2D>(); // Trigger
            collider.isTrigger = true;

            solids.Add(go);
        }

        public void MoveTo(float x, float y)
        {
            Transform transform = main.GetComponent<Transform>();
            transform.position = new Vector2(x, y);
        }
    }

    public TextMeshProUGUI scoreText;
    public GameObject player;
    public GameObject startPlatform;

    private readonly List<Platform> platforms = new List<Platform>();
    private readonly float holeWidthUnits = 1.2f;
    private float offsetY = 1.5f;
    private float nextY = 0f;
    
    private float sceneWidthUnits = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sceneWidthUnits = 2 * Camera.main.orthographicSize * Camera.main.aspect;
        
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

            int score;
            try
            {
                score = int.Parse(scoreText.text);
                score = score + 1;
            }
            catch
            {
                score = 0;
            }

            scoreText.text = score.ToString();
        }
    }

    private void SpawnNewPlatform()
    {
        Platform platform = new Platform(startPlatform, holeWidthUnits);
        float cornerX = (sceneWidthUnits - holeWidthUnits) / 2.0f - 0.25f;
        platform.MoveTo(Random.Range(-cornerX, cornerX), nextY);
        platforms.Add(platform);

        nextY = nextY - offsetY;
    }
}
