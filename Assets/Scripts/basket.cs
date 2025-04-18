using UnityEngine;

public class basket : MonoBehaviour
{
    Transform tr;
    main main;

    void Start()
    {
        tr = GetComponent<Transform>();
        main = GameObject.Find("scripts").GetComponent<main>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Don't move if game is over
        if (main.GameOver)
            return;

        if (Input.GetKey("right") == true)
        {
            if (tr.position.x < 6.5f) tr.position += new Vector3(0.2f, 0f, 0f);
        }

        if (Input.GetKey("left") == true)
        {
            if (tr.position.x > -6.5f) tr.position += new Vector3(-0.2f, 0f, 0f);
        }
    }
}
