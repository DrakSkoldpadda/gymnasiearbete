using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private State state;
    private enum State
    {
        Idle,
        Sliding,
        Busy,
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Busy:
                break;
            case State.Sliding:
                break;
        }
    }

    //public void SetUp(bool isPlayerTeam)
    //{
    //    if (isPlayerTeam)
    //    {

    //    }
    //    else
    //    {

    //    }
    //}

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Attack(CharacterBattle targetCharacterBattle, Action onAttackComplete)
    {
        Vector3 attackDir = (targetCharacterBattle.GetPosition() - GetPosition()).normalized;
        onAttackComplete();
    }


}
