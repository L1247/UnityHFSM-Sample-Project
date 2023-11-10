using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;

public class TransitionAfterDynamicTesting : MonoBehaviour
{
    private StateMachine fsm;

    // Start is called before the first frame update
    void Start()
    {
        fsm = new StateMachine();
        fsm.AddState("A" , onEnter : _ => print("A"));
        fsm.AddState("B" , onEnter : _ => print("B"));
        // fsm.AddTransition(new TransitionAfter("A","B" ,2));
        fsm.AddTransition(new TransitionAfterDynamic("A" , "B" , _ => Random.Range(3 , 4)));

        fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnLogic();
    }
}