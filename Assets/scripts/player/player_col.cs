using UnityEngine;

public class player_col : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fruit"))
        {
            var item = other.GetComponent<items>();

            if (item != null)
            {
                item.hit();
            }
        }

        if (other.CompareTag("quai"))
        {
            var quai = other.GetComponent<quai>();

            if (quai != null)
            {
                quai.hit();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("quai"))
        {
            hit();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }

    public void hit()
    {
        die();
    }
}
