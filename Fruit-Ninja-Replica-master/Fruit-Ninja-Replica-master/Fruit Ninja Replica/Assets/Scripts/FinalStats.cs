using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinalStats : MonoBehaviour
{

    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Total Sliced: " + GameManager.score + "\nTotal Missed: " + GameManager.missed;
    }

}
