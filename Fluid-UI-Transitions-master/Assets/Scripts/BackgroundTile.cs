using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    public GameObject[] dots;
    GameObject dot;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDots());
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (dot == null)
    //         Initialize();
    // }
    public void destroyed()
    {
        dot = null;
    }
    void Initialize()
    {
        int dotToUse = Random.Range(0, dots.Length);
        dot = Instantiate(dots[dotToUse], transform.position, Quaternion.identity);
        dot.transform.parent = this.transform;
        dot.name = this.gameObject.name;
    }
    IEnumerator SpawnDots()
    {
        while (true)
        {
            if (dot == null)
            {
                int dotToUse = Random.Range(0, dots.Length);
                dot = Instantiate(dots[dotToUse], transform.position, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = this.gameObject.name;
                StartCoroutine(FadeIn());
            }
            yield return new WaitForSeconds(0.1f);
        }


    }
    IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 1; f += 0.1f)
        {
            Color c = dot.GetComponent<SpriteRenderer>().color;
            c.a = f;
            dot.GetComponent<SpriteRenderer>().color = c;
            yield return new WaitForSeconds(.1f);
        }
    }
}
