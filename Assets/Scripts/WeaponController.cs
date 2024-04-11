using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject prefab;
    public Transform holsterTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("pew");
            Quaternion quaternion = Quaternion.Euler(0f, 0f, 90f);
            Instantiate(prefab, holsterTransform.position, quaternion);
        }
    }
}
