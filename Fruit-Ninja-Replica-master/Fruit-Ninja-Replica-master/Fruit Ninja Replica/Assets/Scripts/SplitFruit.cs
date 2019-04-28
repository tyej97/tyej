using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitFruit : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.fruitSize)
        {
            case 0:
                this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                break;
            case 1:
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 2:
                this.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                break;
        }

        GameManager.IncreaseScore();
    }

    
}
