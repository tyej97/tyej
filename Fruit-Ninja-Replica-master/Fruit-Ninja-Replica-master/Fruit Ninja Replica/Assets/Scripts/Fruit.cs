using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	public GameObject fruitSlicedPrefab;
	public float startForce = 15f;

	Rigidbody2D rb;

	void Start ()
	{
        switch (GameManager.fruitSize)
        {
            case 0: this.gameObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                break;
            case 1:
                this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 2:
                this.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                break;
        }

		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
			Destroy(slicedFruit, 3f);
            GameManager.DecreaseMissed();
			Destroy(gameObject);
		}
	}

    private void OnDestroy()
    {
        GameManager.IncreaseMissed();
    }

}
