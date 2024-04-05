using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Carro : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    int checkpoint = 0;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    float Distancia;

    [SerializeField]
    GameObject[] Puntos;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(Puntos[checkpoint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        NextCheckpoint();
    }

    void NextCheckpoint()
    {
        if(Vector3.Distance(transform.position, Puntos[checkpoint].transform.position) < Distancia)
        {
            checkpoint++;
            if (checkpoint >= Puntos.Length)
            {
                if(gameObject.tag == "Carro")
                {
                    gameManager.Win("Player 1", "Player 2");
                }
                else
                {
                    gameManager.Win("Player 2", "Player 1");
                }
                
                this.enabled = false;
            }
            else
            {
                agent.SetDestination(Puntos[checkpoint].transform.position);
            }
          
        }
      
    }
}
