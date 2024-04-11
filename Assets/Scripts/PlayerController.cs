
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private void Awake()
    {
        Debug.Log("I'm awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am a player");
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        transform.Translate(speed * Time.deltaTime * new Vector2(horizontalDirection, verticalDirection));

      
    }  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("player loses");
            //change scene to loss screen
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SceneManager.LoadScene(3);
        }
    }
       

}
