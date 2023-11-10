using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;

public class GhostTesting : MonoBehaviour
{
    private StateMachine fsm;

    // Start is called before the first frame update
    void Start()
    {
        fsm = new StateMachine();
        fsm.AddState("A" , onEnter : s => print("A"));
        // 進入後快速切換
        fsm.AddState("B" , new State(onEnter : _ => print("B") , isGhostState : true));
        fsm.AddState("C" , onEnter : _ => print("C"));

        fsm.AddTransition("A" , "B" );
        fsm.AddTransition("B" , "C" , onTransition:_ => print("to C"));

        fsm.Init();    // Prints "A"
        fsm.OnLogic(); // Prints "B" and then "C"
        Debug.Log($"{fsm.GetActiveHierarchyPath()}");
    }

}
