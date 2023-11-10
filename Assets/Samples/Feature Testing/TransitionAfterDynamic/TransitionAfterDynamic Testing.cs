using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;

public class TransitionAfterDynamicTesting : MonoBehaviour
{
    private StateMachine fsm;

    class MyState : State
    {
        public override void OnEnter()
        {
            Debug.Log($"MyState");
            AddAction("Test" , () => print("Test"));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fsm = new StateMachine();
        fsm.AddState("A" , onEnter : _ => print("A"));
        fsm.AddState("MyState" , new MyState());
        // fsm.AddTransition(new TransitionAfter("A","B" ,2));
        fsm.AddTransition(new TransitionAfterDynamic("A" , "MyState" , _ => Random.Range(3 , 4)));

        fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnLogic();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fsm.OnAction("Test");
        }
    }
}