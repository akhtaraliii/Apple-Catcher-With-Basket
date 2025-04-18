using UnityEngine;

public class generator : MonoBehaviour
{
    float timer = 1;
    public GameObject[] gm;
    main main;

    void Start()
    {
        main = GameObject.Find("scripts").GetComponent<main>();
    }


    void Update()
    {
        // Don't spawn if game is over
        if (main.GameOver)
            return;
            
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            int chance = Random.Range(1, 101);
            float pos_x = Random.Range(-6.0f, 6.0f);

            if (chance <= 70)
            {
                Instantiate(gm[0], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }
            else
            {
                Instantiate(gm[1], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }

            timer = 0.7f;
        }
    }
}
