using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePoints : MonoBehaviour
{
    [Range(1, 300)]
    public int n;

    [Range(0f, 3f)]
    public float turnFraction = (1 + Mathf.Sqrt(5)) / 2;

    public int radius;

    public GameObject point;

    private int n_cache;
    private float turn_cache;
    private GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[300];
        for (int i = 0; i < 300; i++) {
            points[i] = Object.Instantiate(point, Vector3.zero, Quaternion.identity);
        }

        for (int i = 0; i < 300; i++) {
            float dst = Mathf.Sqrt((i + 0.5f) / 300) * radius;
            float theta = 2 * Mathf.PI * i * turnFraction; // (1 + Mathf.Sqrt(5));

            float x = dst * Mathf.Cos(theta);
            float y = dst * Mathf.Sin(theta);

            points[i].transform.position = new Vector3(x, y, 0);
        }

        n_cache = n;
        turn_cache = turnFraction;
    }

    // Update is called once per frame
    void Update()
    {
        if (n != n_cache || turnFraction != turn_cache) {

            for (int i = 0; i < n; i++) {
            float dst = Mathf.Sqrt((i + 0.5f) / n) * radius;
            float theta = 2 * Mathf.PI * i * turnFraction; // (1 + Mathf.Sqrt(5));

            float x = dst * Mathf.Cos(theta);
            float y = dst * Mathf.Sin(theta);

            points[i].SetActive(true);
            points[i].transform.position = new Vector3(x, y, 0);
            }

            for (int i = n; i < 300; i++) {
                points[i].SetActive(false);
            }

            n_cache = n;
            turn_cache = turnFraction;
        }
    }
}
