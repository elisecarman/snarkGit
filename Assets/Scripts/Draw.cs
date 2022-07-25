using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Draw : MonoBehaviour
{
    public List<GameObject> drawDeckUnshuffled;
    public List<GameObject> drawDeck;
    public CardController controller;

    public DrawPile draw;
    GameObject controlDeck;

    public List<GameObject> decks;

    //Start shuffles the deck and creates the solitaire decks and the snark pile
    void Start() {
        //shuffle
        drawDeck = drawDeckUnshuffled.OrderBy( x => UnityEngine.Random.value ).ToList( );
        
        decks.Add(GameObject.Find("DeckPink"));
        decks.Add(GameObject.Find("DeckGreen"));
        decks.Add(GameObject.Find("DeckBlue"));
        decks.Add(GameObject.Find("DeckRed"));
        GameObject controlDeck = GameObject.Find("DeckPurple");

        // create the four Solitaire decks in a pyramid
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < i+1; j++)
            {
                decks[i].GetComponent<Deck>().cardDeck.Add(drawDeck[drawDeck.Count-1]);
                drawDeck[drawDeck.Count-1].GetComponent<Card>().cardDeck = decks[i];
                drawDeck.RemoveAt(drawDeck.Count-1);
            }
        }

        //Create the Snark pile
        for (int i = 0; i < 10; i++)
        {
                controlDeck.GetComponent<Snark>().snarkDeck.Add(drawDeck[drawDeck.Count-1]);
                drawDeck[drawDeck.Count-1].GetComponent<Card>().cardDeck = controlDeck;
                drawDeck.RemoveAt(drawDeck.Count-1);
        }
    }  

    //Deals with behavior upon clicking draw deck
    void OnMouseDown() { 
        //if a card is in the hand, do not aknowledge that draw deck was clicked

        if (controller.selectedCard.Any())
        {
            controller.selectedCard.Clear();
        }
        
        // if the draw deck is not empty, get three (or less) cards
        if (drawDeck.Count != 0)
        {
            int removed = 3;
            //edge case: draw deck has less that three cards
            if (drawDeck.Count < 3){
                removed = drawDeck.Count;
            }
                
            for (int i = 0; i < removed; i++)
            {
                //Note: can create a helper in DrawPile so we don't awkwardly reach across two classes
                draw.drawPileDeck.Add(drawDeck[drawDeck.Count - 1]);
                drawDeck.RemoveAt(drawDeck.Count - 1);
            }

        } // if the draw deck is empty, transfer all cards from drawPileDeck back to the draw deck
        else {
            // go through all cards and get them face down (is this necessary here?)
            for (int i = 0; i < draw.drawPileDeck.Count; i++) // - 1
            {
                draw.drawPileDeck[i].GetComponent<Card>().face = 0;
            }
            // reverse order to reset
            draw.drawPileDeck.Reverse();
            // here GetRange returns a shallow copy so that we may afterwards clear drawPileDeck
            drawDeck = draw.drawPileDeck.GetRange(0, draw.drawPileDeck.Count);
                
            draw.drawPileDeck.Clear();
        }
        
    }    

    //Renders draw deck
    void Update()
    {
        if (drawDeck.Count != 0)
        {
            for (int i = 0; i < drawDeck.Count; i++)
            {
                drawDeck[i].transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
                drawDeck[i].GetComponent<Renderer>().sortingOrder = 0;
                drawDeck[i].GetComponent<Card>().face = 0;
                //0F?
                drawDeck[i].GetComponent<BoxCollider2D>().size = new UnityEngine.Vector2(0F, 0F);
            }
            //change top card sorting order
            drawDeck[drawDeck.Count-1].GetComponent<Renderer>().sortingOrder = 1;
        }
    }
}