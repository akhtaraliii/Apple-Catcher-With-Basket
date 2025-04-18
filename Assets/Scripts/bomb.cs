using UnityEngine;

public class bomb : MonoBehaviour
{
    main main;
    Transform tr;
    public AudioClip explosionSound; // Sound when bomb hits basket

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("scripts").GetComponent<main>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!main.GameOver)
        {
            tr.position -= new Vector3(0f, 0.12f, 0f);
        }

        if (tr.position.y < -3.9f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!main.GameOver && collision.gameObject.name == "basket")
        {
            // Play explosion sound
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
            }
            
            main.LoseLife(); // Reduce life instead of immediate game over
            Destroy(this.gameObject); // Destroy the bomb
        }
    }
}