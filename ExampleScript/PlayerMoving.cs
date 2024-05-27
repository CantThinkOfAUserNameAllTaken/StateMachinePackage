using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace StateMachinePackage
{


    /// <summary>
    /// an Example script for a state for moving the player
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/StatesHolder/Examples/PlayerMoving")]
    public class PlayerMoving : State
    {
        public Rigidbody2D rb;

        public PlayerController playerController;

        public SpriteRenderer playerSprite;
        protected override void OnEnter()
        {
            Moving();
            playerSprite.color = Color.black;
        }

        private void Moving()
        {
            rb.velocity = playerController.movementDirection * playerController.speed * Time.deltaTime;
        }

        protected override void OnStay()
        {
            Moving();
            if (playerController.movementDirection == Vector2.zero)
            {
                playerController.StateHandler.SetState("Idle");
            }
        }
        protected override void OnExit()
        {
            playerSprite.color = Color.red;
        }

        public override void RunSetUp(GameObject player)
        {
            rb = player.GetComponent<Rigidbody2D>();
            playerController = player.GetComponent<PlayerController>();
            playerSprite = player.GetComponent<SpriteRenderer>();
        }
    }

}