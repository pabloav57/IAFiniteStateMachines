using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new State.Idle(this.gameObject, agent, anim, player); // Aquí cambiamos a State.Idle
    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
