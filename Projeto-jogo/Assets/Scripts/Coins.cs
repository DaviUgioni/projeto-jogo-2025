using UnityEngine;

public class Coins : MonoBehaviour
{
    public int points = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            {
            Debug.Log("Colidiu! ");
            points = points + 10;
            Debug.Log(points);
            }
    }

}
