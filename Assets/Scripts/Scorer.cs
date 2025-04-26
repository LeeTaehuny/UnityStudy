using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int Hits = 0;
    void OnCollisionEnter(Collision collision)
    {
        Hits++;
        Debug.Log("You've bumped into a thing this many times : " + Hits);
    }
}
