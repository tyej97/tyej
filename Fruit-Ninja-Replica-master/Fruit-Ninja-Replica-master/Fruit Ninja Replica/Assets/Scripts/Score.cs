using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text slicedBox;

    // Start is called before the first frame update
    void Start()
    {
        slicedBox.text = "Sliced: 0\nMissed: 0";
    }

    // Update is called once per frame
    void Update()
    {
        slicedBox.text = "Sliced: " + GameManager.score + "\nMissed: " + GameManager.missed;
    }
}
