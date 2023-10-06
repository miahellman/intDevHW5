using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    public enum GameState
    {
        DEAL,
        CHOOSE,
        RESOLVE
    }

    public static GameState state;

    public List<GameObject> playerHand = new List<GameObject>();

    public int playerHandCount;
    public Transform playerPos;

    private void Start()
    {
        state = GameState.DEAL;
    }

    private void Update()
    {
        switch(state)
        {
            case GameState.DEAL:
                if(playerHand.Count < playerHandCount)
                {
                    DealCard();
                }
                else
                {
                    state = GameState.CHOOSE;
                }
                break;
            case GameState.CHOOSE:
                break;
            case GameState.RESOLVE:
                break;

        }
    }

    void DealCard()
    {
        GameObject nextCard = DeckManager.deck[DeckManager.deck.Count - 1];
        Vector3 newPos = playerPos.transform.position;
        newPos.x = newPos.x + (2f * playerHand.Count);
        nextCard.transform.position = newPos;
        playerHand.Add(nextCard);
        DeckManager.deck.Remove(nextCard);
    }
}
