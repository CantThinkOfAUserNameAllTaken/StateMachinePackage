using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace StateMachinePackage
{


    /// <summary>
    /// the handler for states on a gameObject
    /// </summary>
    [System.Serializable]
    public class StateMachine
    {
        private State _currentState;

        [SerializeField]
        private List<StatesHolder> possibleStates;

        /// <summary>
        /// makes the possible states a dictionary for easy access
        /// </summary>
        public Dictionary<string, State> possibleStatesDictionary = new Dictionary<string, State>();

        [HideInInspector]
        public State CurrentState { get => _currentState; }

        /// <summary>
        /// set the current State of the GameObject
        /// </summary>
        /// <param name="StateName"> the state name entered in the inspector</param>
        public void SetState(string StateName)
        {
            if (_currentState != null)
            {
                _currentState.OnStateExit();
            }
            if (!possibleStatesDictionary.ContainsKey(StateName))
            {
                Debug.LogError("State Does Not Exist");
                return;
            }
            _currentState = possibleStatesDictionary[StateName];
        }

        /// <summary>
        /// runs the Setup for all states entered into this StateMachine, and adds them to the Dictionary
        /// </summary>
        /// <param name="stateMaster">The GameObject your State needs to get Components from</param>
        public void RunSetUpForAllStates(GameObject stateMaster)
        {
            foreach (StatesHolder state in possibleStates)
            {
                state.heldState.RunSetUp(stateMaster);
                possibleStatesDictionary.Add(state.StateName, state.heldState);
            }
        }

        /// <summary>
        /// runs the current States SubState, normally OnStay
        /// </summary>
        public void RunState()
        {
            _currentState.currentSubState();
        }
        /// <summary>
        /// contains a state and its name
        /// </summary>
        [System.Serializable]
        public struct StatesHolder
        {
            public string StateName;
            public State heldState;
        }

    }

}