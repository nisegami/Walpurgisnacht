using System;
using UnityEngine;

public class RheaIdleState : RheaState
{
    override public void Enter(RheaStateInput input, CharacterStateTransitionInfo info = null)
    {
        prevHorizontalMovement = 0;
        input.anim.Play("Idle");
    }

    override public void Update(RheaStateInput input)
    {
        input.cc.HandlePlaceCircle();

        // Spells
        if (SpellMap.Instance.GetSpellDown(input.cc.playerNumber, SpellType.INTRIN))
        {
            character.ChangeState<RheaShieldState>();
        }

        if (SpellMap.Instance.GetSpellDown(input.cc.playerNumber, SpellType.PRIM))
        {
            MatchManager.Instance.StartLastWord(input.cc.playerNumber);
        }

        if (SpellMap.Instance.GetSpellDown(input.cc.playerNumber, SpellType.MOVE))
        {
            character.ChangeState<RheaDashState>();
        }

        HandleMoveAnimation(input);
    }

    override public void FixedUpdate(RheaStateInput input)
    {
        input.cc.HandleMovement();
    }
}