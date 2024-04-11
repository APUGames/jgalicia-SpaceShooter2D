using UnityEngine;

public class Laser : MonoBehaviour
{
    public float endTranslationPositionY;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);

        if (transform.position.y > endTranslationPositionY)
        {
            Destroy(gameObject);
        }
    }
}
