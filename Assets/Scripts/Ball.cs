using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private BallThower ballThower;

    private void Start()
    {
        ballThower = FindObjectOfType<BallThower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            other.GetComponent<Hole>().hint.SetActive(false);
            GameManager.isActive = false;
            //ballThower.ResetBall();
        }
    }
}
