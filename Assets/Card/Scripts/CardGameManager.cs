using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    public enum GameState
    {
        START,
        OP_DEAL,
        PLAYER_DEAL,
        OP_TURN,
        PLAYER_TURN,
        EVAL,
        DISCARD,
        RESHUFFLE
    }

    public static GameState state;

    public List<GameObject> playerHand = new List<GameObject>(); //list for player hand
    public List<GameObject> opHand = new List<GameObject>(); //list for op hand

    public int playerHandCount;
    public int opHandCount;
    public Transform opPos;
    public Transform playerPos;


    float timer = 0f;
    float pickTime = 0;
    float revealTime = 0;

    public bool inHand = false;
    bool playerPick = false;
    bool opPick = false;


    private void Start()
    {
        state = GameState.START;
    }

    private void Update()
    {
        switch(state)
        {
            case GameState.START:
                if (Input.GetKeyDown("space"))
                {
                    state = GameState.OP_DEAL;
                }

                break;
            case GameState.OP_DEAL:
                if (opHand.Count < opHandCount)
                {
                    DealOpCard();
                }
                else
                {
                    pickTime += 150f;
                    state = GameState.PLAYER_DEAL;
                }
                break;
            case GameState.PLAYER_DEAL:
                if (playerHand.Count < playerHandCount)
                {
                    DealCard();
                }
                else
                {
                    state = GameState.PLAYER_TURN;
                }
                break;
            case GameState.OP_TURN:
                if (opPick == true && playerPick == true)
                {
                    state = GameState.EVAL;
                }
                break;
            case GameState.EVAL:
                break;
            case GameState.DISCARD:
                break;
            case GameState.RESHUFFLE:
                break;

        }
    }

    void DealCard()
    {
        //deal player card
        GameObject nextCard = DeckManager.deck[DeckManager.deck.Count - 1];
        Vector3 startPos = playerPos.transform.position;
        Vector3 newPos = playerPos.transform.position;
        newPos.x = newPos.x + (2f * playerHand.Count);
        nextCard.transform.position = Vector3.Lerp(startPos, newPos, 0.5f);
        playerHand.Add(nextCard);
        DeckManager.deck.Remove(nextCard);  
        //set inhand to be true
        inHand = true;
        Debug.Log("in hand = " + inHand);
    }

    void DealOpCard()
    {
        //deal op card
        GameObject nextCard = DeckManager.deck[DeckManager.deck.Count - 1];
        Vector3 newPos = opPos.transform.position;
        newPos.x = newPos.x + (2f * opHand.Count);
        nextCard.transform.position = newPos;
        opHand.Add(nextCard);
        DeckManager.deck.Remove(nextCard);
    }

    void OpChooseCard()
    {
        Debug.Log(pickTime);

        //op submits card
        if (pickTime <= 0)
        {
            timer--;

            // Once timer reaches 50 frames (original 15 + 35)
            if (timer <= -35)
            {
                // If 3 cards are in opponent hand
                if (opHand.Count == 3)
                {
                    // Choose a random card in the opponent hand list
                   // int randomIndex = new Random().Next(0, 3);
                //    Card randomCard = opHand.[randomIndex];

                    // Move random opponent card to opponent middle
                //    randomCard.transform.position = 

                    // Play audio
                    //audioManager.PlaySound("place"); 

                    // Signify the chosen card for reveal later
                  //  randomCard.opPlayed = true;

                    // Change state to player's turn
                   // state = GameState.PLAYER_TURN;
                }

                // Reset timer
              //  timer = maxTimer;
            }

        }

     
    } 
}
