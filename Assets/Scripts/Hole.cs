using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public static bool isHole;
    public GameObject particle;
    public GameObject position;
    public GameObject hint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHole = true;

            if (hint.activeInHierarchy)
            {
                GameObject effect = Instantiate<GameObject>(particle, position.transform.position, Quaternion.Euler(-90, 0f, 0f));
                Destroy(effect, 1f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isHole = false;
        }
    }
}
