using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RashoLaserP2 : MonoBehaviour
{
    [SerializeField]
    GameObject VFXCarro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Carro2"))
        {
            other.GetComponent<NavMeshAgent>().speed = 15f;
            other.GetComponent<AudioSource>().Play();
            VFXCarro.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Carro2"))
        {
            other.GetComponent<NavMeshAgent>().speed = 0f;
            other.GetComponent<AudioSource>().Stop();
            VFXCarro.SetActive(false);
        }
    }
}
