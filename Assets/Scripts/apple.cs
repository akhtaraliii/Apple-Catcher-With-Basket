using UnityEngine;

public class apple : MonoBehaviour
{
    main main;
    Transform tr;
    public AudioClip collectSound; // Sound when apple is collected

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
            // Play collection sound
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            }
            
            Destroy(this.gameObject);
            main.ScoreAdd();
        }
    }
}
