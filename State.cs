using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.Rendering;
namespace StateMachinePackage
{

    /// <summary>
    /// the basic state class that contains 3 subStates, so more states are easily creatable
    /// </summary>
    public abstract class State : ScriptableObject
    {
        public delegate void SubState();

        public SubState currentSubState;

        public SubState OnStateExit;

        /// <summary>
        /// set up the state so the loop works
        /// </summary>
        private void OnEnable()
        {
            currentSubState = StateMachineEnter;
            OnStateExit = StateMachineExit;
        }
        /// <summary>
        /// called when entering the state, then goes to stay
        /// </summary>
        private void StateMachineEnter()
        {
            OnEnter();
            currentSubState = StateMachineStay;
        }

        private void StateMachineStay()
        {
            OnStay();
        }

        /// <summary>
        /// called when exiting the state 
        /// </summary>
        private void StateMachineExit()
        {
            OnExit();
            currentSubState = StateMachineEnter;
        }

        /// <summary>
        /// what happens when it stays in this state
        /// </summary>
        protected abstract void OnStay();

        /// <summary>
        /// what happens when it enters this state
        /// </summary>
        protected abstract void OnEnter();

        /// <summary>
        /// what happens when it Exits this state
        /// </summary>
        protected abstract void OnExit();

        /// <summary>
        /// the set up needed for getting references for other components
        /// </summary>
        /// <param name="StateMaster"> The GameObject your State needs to get Components from</param>
        public abstract void RunSetUp(GameObject StateMaster);
    }
}

