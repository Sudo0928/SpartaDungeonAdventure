using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class PlayerLightStoppingState : PlayerStoppingState
    {
        public PlayerLightStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
        {
        }

        #region IState Methods
        public override void Enter()
        {
            base.Enter();

            stateMachine.ReusableData.MovementDecelerationForce = movementData.StopData.LightDecelerationForce;

            stateMachine.ReusableData.CurrentJumpForce = airborneData.JumpData.WeakForce;
        }
        #endregion
    }
}
