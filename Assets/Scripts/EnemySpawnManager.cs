using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public string debugName;

    public Vector2[] spawnPoints;

    [SerializeField]
    private float queueTime = 2.0f;
    private float currentQueueTime;

    // Start is called before the first frame update
    void Start()
    {
        currentQueueTime = queueTime;
    }

    // Update is called once per frame
    void Update()
    {
        //GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if (!gameManager.GetPlayerWon())
        {
            if (currentQueueTime < 0f)
            {
                int spawnLocationIndex = Random.Range(0, spawnPoints.Length);
                Vector3 spawnLocation = spawnPoints[spawnLocationIndex];
                Quaternion quaternion = Quaternion.Euler(0f, 0f, 0f);
                GameObject enemy = Instantiate(enemyPrefab, spawnLocation, quaternion);
                currentQueueTime = queueTime;
            }
            else
            {
                currentQueueTime -= Time.deltaTime;
            }
        }
    }
}
