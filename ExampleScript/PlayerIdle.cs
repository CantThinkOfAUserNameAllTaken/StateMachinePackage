using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StateMachinePackage
{


    /// <summary>
    /// an example class for an idle state
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/StatesHolder/Examples/PlayerIdle")]
    public class PlayerIdle : State
    {
        private PlayerController playerController;
        protected override void OnEnter()
        {
        }
        protected override void OnStay()
        {
            if (playerController.movementDirection != Vector2.zero)
            {
                playerController.StateHandler.SetState("Moving");
            }
        }
        protected override void OnExit()
        {
        }

        public override void RunSetUp(GameObject StateMaster)
        {
            playerController = StateMaster.GetComponent<PlayerController>();
        }
    }
}
