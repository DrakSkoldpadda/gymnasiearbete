using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public Transform playerCharacter;
    public Transform enemyCharacter;

    private CharacterBattle playerCharacterBattle;
    private CharacterBattle enemyCharacterBattle;
    private State state;

    private enum State
    {
        WaitingForPlayer,
        Busy,
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerCharacterBattle = SpawnCharacter(playerCharacter, true);
        enemyCharacterBattle = SpawnCharacter(enemyCharacter, false);

        state = State.WaitingForPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && state == State.WaitingForPlayer)
        {
            state = State.Busy;
            playerCharacterBattle.Attack(enemyCharacterBattle, () => { state = State.WaitingForPlayer; });
        }
    }

    private CharacterBattle SpawnCharacter(Transform character, bool isPlayerTeam)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(-6.5f, 0.5f);
        }
        else
        {
            position = new Vector3(6.5f, 0.5f);
        }
        Transform characterTransform = Instantiate(character, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        //characterBattle.SetUp(isPlayerTeam);

        return characterBattle;
    }
}
