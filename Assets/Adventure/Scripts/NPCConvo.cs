using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCConvo : MonoBehaviour
{
    public string myDialogue;

    private void OnMouseDown()
    {
        AdventureGameManager.TriggerConvo(myDialogue);
    }

}
