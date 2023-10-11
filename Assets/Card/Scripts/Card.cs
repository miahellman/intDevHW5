using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Sprite faceSprite;

    Sprite backSprite;

    SpriteRenderer myRenderer;

    bool mouseClick = false;
   

    private void Start()
    {
        
        myRenderer = GetComponent<SpriteRenderer>();
        backSprite = myRenderer.sprite;
    }

    private void Update()
    {
        if(mouseClick) 
        {
            myRenderer.sprite = faceSprite;
            Debug.Log(myRenderer.sprite);
        }
    }

    private void OnMouseDown()
    {
        mouseClick = true;
    }
}
