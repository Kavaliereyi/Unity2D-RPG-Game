using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    private float isCurFacingRight;
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isCurFacingRight = player.facingDir;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsWallDetected())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        if(xInput != 0 && player.facingDir != xInput)
            stateMachine.ChangeState(player.idleState);

        if (player.facingDir != isCurFacingRight)
            player.Flip();

        if (yInput < 0)
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y * .7f);

        if(player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
