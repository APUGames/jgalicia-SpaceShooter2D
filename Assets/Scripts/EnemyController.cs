using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private float fallingSpeed = 2.0f;
    [SerializeField]
    private float horizontalRangeMin = -9f;
    [SerializeField]
    private float horizontalRangeMax = 9f;
    [SerializeField]
    private float endZ = -10.0f;
    [SerializeField]
    private Vector2 startLocation = Vector2.zero;
    public static int playerPoints;
    public static int pointCount;

    // Start is called before the first frame update
    void Start()
    {
        pointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckRespawn();
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (fallingSpeed * Time.deltaTime));
    }

    private void CheckRespawn()
    {
        if (transform.position.y < endZ)
        {
            //respawn at random x
            float newX = Random.Range(horizontalRangeMin, horizontalRangeMax);
            transform.position = new Vector2(newX, startLocation.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision != null && collision.gameObject.CompareTag("Bullet") && pointCount <29)
        {
            //GameManager.Instance.SetPlayerPoints(1);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Debug.Log(playerPoints);
            playerPoints++;
            pointCount++;
            GameObject.Find("WinText").GetComponent<VictoryController>().winVar(1);
        }
        if (collision != null && collision.gameObject.CompareTag("Bullet") && pointCount >= 29)
        {
            //GameManager.Instance.SetPlayerPoints(1);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Debug.Log(playerPoints);
            Debug.Log("Player win");
            //scene change to win screen
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(2);
        }
    }
}
