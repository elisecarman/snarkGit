using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    public List<GameObject> drawPileDeck;
    public CardController controller;
    
    //Renders drawPileDeck (the pile on the right of the draw deck)
    void Update()
    {
        if (drawPileDeck.Count != 0)
        {
            for (int i = 0; i < drawPileDeck.Count; i++)
            {
                int cardSpace = i;
                drawPileDeck[i].transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
                drawPileDeck[i].GetComponent<Renderer>().sortingOrder = i;
                
            }
            drawPileDeck[drawPileDeck.Count-1].GetComponent<Card>().face = 1;
            drawPileDeck[drawPileDeck.Count-1].GetComponent<BoxCollider2D>().size = new UnityEngine.Vector2(0.4F, 0.5F);
        }
    }
}