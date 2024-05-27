using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace StateMachinePackage
{


    /// <summary>
    /// Example script for moving the player using this system
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public Vector2 movementDirection;

        /// <summary>
        /// the state machine that handles running and holding states
        /// </summary>
        public StateMachine StateHandler;

        public float speed;

        public void UpdateDirection(CallbackContext context)
        {
            movementDirection = context.ReadValue<Vector2>();
        }
        void Start()
        {
            StateHandler.RunSetUpForAllStates(gameObject);
            StateHandler.SetState("Idle");
        }

        // Update is called once per frame
        void Update()
        {
            StateHandler.RunState();
        }
    }

}