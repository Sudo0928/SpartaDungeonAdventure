using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PlayerLandingState : PlayerGroundedState
    {
        public PlayerLandingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            StartAnimation(stateMachine.Player.AnimationData.LandingParameterHash);
        }

        public override void Exit() 
        {
            base.Exit();

            StopAnimation(stateMachine.Player.AnimationData.LandingParameterHash);
        }
    }
}
