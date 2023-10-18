using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private BallThower ballThower;
    public AudioClip _BallInHoleSFX;

    private void Start()
    {
        ballThower = FindObjectOfType<BallThower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            if (other.GetComponent<Hole>().hint.activeInHierarchy)
            {
                AudioManager.instance.PlaySFXSound(_BallInHoleSFX);
                other.GetComponent<Hole>().hint.SetActive(false);
                GameManager.isActive = false;
            }
            ballThower.ResetBall();
        }
    }
}
