using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryController : MonoBehaviour
{
    public Text VictoryText;

    public int pointCounter;
    // Start is called before the first frame update
    void Start()
    {
        VictoryText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(pointCounter>=10)
        {
            VictoryText.gameObject.SetActive(true);
        }

    }
    public void winVar(int num)
    {
        pointCounter += num;
    }
}
