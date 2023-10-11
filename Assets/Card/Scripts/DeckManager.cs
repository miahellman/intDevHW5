using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;

    public Sprite[] cardFaces; // create array -- container for mult diff sprites in this case

    public int deckCount;

    public static List<GameObject> deck = new List<GameObject>(); //create list of gameobjects, (= new) intializes it

    private void Start()
    {
        for (int i = 0; i < deckCount; i++)
        {
            //create an instance of a card from code
            GameObject newCard = Instantiate(cardPrefab, gameObject.transform); //creates instance to be child of deck gameobject (whatever object the script is attatched to becomes the parent
            Card newCardScript = newCard.GetComponent<Card>(); //create new card
            newCardScript.faceSprite = cardFaces[i % 3]; //takes remainder to decide what type of card it is
            deck.Add(newCard); //adds card to deck

        }

    }

}
