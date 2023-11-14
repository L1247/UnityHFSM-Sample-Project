using UnityEngine;
using UnityHFSM;

namespace Samples.TriggerAgain
{
    public class TriggerAgain : MonoBehaviour
    {
        private StateMachine stateMachine;

        private void Start()
        {
            stateMachine = new StateMachine();
            stateMachine.AddState("A" , onEnter : _ => print("A"));
            stateMachine.AddState("B" , onEnter: _=> print("B"));
            stateMachine.SetStartState("A");
            stateMachine.AddTriggerTransitionFromAny("B" , to: "B" );
            stateMachine.Init();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.Trigger("B");
            }
        }
    }
}