using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePoints : MonoBehaviour
{
    [SerializeField][Range(1, 300)]
    private int n;

    [SerializeField][Range(0f, 3f)]
    private float turnFraction;

    private int radius;

    public GameObject point;

    // Used during development when adjusting values via Inspector
    // private int n_cache;
    // private float turn_cache;

    private GameObject[] points;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[300];
        turnFraction = (1 + Mathf.Sqrt(5)) / 2;
        n = 300;
        radius = 30;

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

        // n_cache = n;
        // turn_cache = turnFraction;
    }

    // Used during development when adjusting values via Inspector
    // void Update()
    // {
    //     if (n != n_cache || turnFraction != turn_cache) {

    //         for (int i = 0; i < n; i++) {
    //         float dst = Mathf.Sqrt((i + 0.5f) / n) * radius;
    //         float theta = 2 * Mathf.PI * i * turnFraction; // (1 + Mathf.Sqrt(5));

    //         float x = dst * Mathf.Cos(theta);
    //         float y = dst * Mathf.Sin(theta);

    //         points[i].SetActive(true);
    //         points[i].transform.position = new Vector3(x, y, 0);
    //         }

    //         for (int i = n; i < 300; i++) {
    //             points[i].SetActive(false);
    //         }

    //         n_cache = n;
    //         turn_cache = turnFraction;
    //     }
    // }

    public void RefreshNumPoints(float numPoints)
    {
        if (numPoints < 300) {

            for (int i = 0; i < numPoints; i++) {
            float dst = Mathf.Sqrt((i + 0.5f) / numPoints) * radius;
            float theta = 2 * Mathf.PI * i * turnFraction; // (1 + Mathf.Sqrt(5));

            float x = dst * Mathf.Cos(theta);
            float y = dst * Mathf.Sin(theta);

            points[i].SetActive(true);
            points[i].transform.position = new Vector3(x, y, 0);
            }

            for (int i = (int) numPoints; i < 300; i++) {
                points[i].SetActive(false);
            }

            n = (int) numPoints;
        }
    }

    public void RefreshTurnFrac(float turnFrac)
    {
        if (0 <= turnFrac && turnFrac <= 3) {

            for (int i = 0; i < n; i++) {
            float dst = Mathf.Sqrt((i + 0.5f) / n) * radius;
            float theta = 2 * Mathf.PI * i * turnFrac; // (1 + Mathf.Sqrt(5));

            float x = dst * Mathf.Cos(theta);
            float y = dst * Mathf.Sin(theta);

            points[i].transform.position = new Vector3(x, y, 0);
            }

            turnFraction = turnFrac;
        }
    }
}
