using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cardDeck;
    public CardController controller;
    public GameObject lastCard;
    public Sprite back;
    public Sprite face;
    public float cardSpace;
    public List<GameObject> cards_;
    public string script;
    public int order;

    /*void OnMouseDown()
    {
        //is this hard coded right now?
        AddCard(gameObject, 13, 1);
    }*/

    //Note: this code repeats three times and can easily be simplified
    public void AddCard(GameObject deck_, int startValue, int order)
    { //adds card

        List<GameObject> originDeck;

        if (controller.originDeck == GameObject.Find("DeckPurple"))
        {
            originDeck = controller.originDeck.GetComponent<Snark>().snarkDeck;
        }
        else if (controller.originDeck == GameObject.Find("DrawPile"))
        {
            originDeck = controller.originDeck.GetComponent<DrawPile>().drawPileDeck;
        }
        else
        {
            originDeck = controller.originDeck.GetComponent<Deck>().cardDeck;
        }


        print("CARD SPECIFICS: target - " + deck_ + " | 1st card - " + controller.selectedCard[0]);
        //if the card in our hand comes from Snark Pile


        cards_ = deck_.GetComponent<Deck>().cardDeck;
        //if the deck we are adding a card to is empty
        if (cards_.Count == 0)
        {
            //Check here that the card in hand is a king (aka == startValue == 13)
            // I will keep reading but maybe this is wrong if we are planning on incrementing startValue with cards added
            if (controller.selectedCard[0].GetComponent<Card>().number == startValue)
            {
                //add all selected cards to new deck
                for (int i = 0; i < controller.selectedCard.Count; i++)
                {
                    cards_.Add(controller.selectedCard[i]);
                }
                //remove selected cards from the origin deck
                for (int i = 0; i < controller.selectedCard.Count; i++)
                {
                    originDeck.RemoveAt(originDeck.Count - 1);
                }
            }
            // if the new deck is not empty
        }
        else
        {
            //check that the number of the first selected is one below that of the last card in the deck
            if (cards_[cards_.Count - 1].GetComponent<Card>().number - order == controller.selectedCard[0].GetComponent<Card>().number)
            {
                // check that colors alternate
                if (cards_[cards_.Count - 1].GetComponent<Card>().color != controller.selectedCard[0].GetComponent<Card>().color)
                {
                    //add cards to the new deck
                    //we may be able to just fuse the two lists instead of appending one by one
                    for (int i = 0; i < controller.selectedCard.Count; i++)
                    {
                        cards_.Add(controller.selectedCard[i]);
                        print(controller.selectedCard[i].GetComponent<Card>().cardDeck + " -> " + deck_);
                        //Do we actually need the cards to be associated with their decks? If the cardController already keeps track of this?
                        controller.selectedCard[i].GetComponent<Card>().cardDeck = deck_;
                    }
                    //remove cards from the origin deck
                    for (int i = 0; i < controller.selectedCard.Count; i++)
                    {
                        originDeck.RemoveAt(originDeck.Count - 1);
                    }
                }
            }
        }
        //If the card in our deck comes from the Draw pile
        controller.selectedCard.Clear();
    }


    public void SelCard(GameObject deck_, GameObject card_)
    {
        controller.originDeck = deck_;

        List<GameObject> originDeck;

        if (controller.originDeck == GameObject.Find("DeckPurple"))
        {
            originDeck = controller.originDeck.GetComponent<Snark>().snarkDeck;
        }
        else if (controller.originDeck == GameObject.Find("DrawPile"))
        {
            originDeck = controller.originDeck.GetComponent<DrawPile>().drawPileDeck;
        }
        else
        {
            originDeck = controller.originDeck.GetComponent<Deck>().cardDeck;
        }

     
        for (int i = 0; i < originDeck.Count; i++)
        {
            //find selected card amidst the deck and add it and its children to the selected card pile

            //can this just be done by looking at first card number and indexing at the difference of that number and selected card number
            //shorter run time
            if (originDeck[i] == card_)
            {
                for (int j = i; j < originDeck.Count; j++)
                {
                    controller.selectedCard.Add(originDeck[j]);
                }
            }
        }
    }

    void Update()
    {
        if (cardDeck.Count != 0)
        {
            for (int i = 0; i < cardDeck.Count; i++)
            {
                cardSpace = i;
                Sprite face = cardDeck[i].GetComponent<SpriteRenderer>().sprite;
                cardDeck[i].transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y - cardSpace / 2, transform.position.z);
                cardDeck[i].GetComponent<Renderer>().sortingOrder = i;
                cardDeck[i].GetComponent<BoxCollider2D>().size = new UnityEngine.Vector2(cardDeck[i].GetComponent<BoxCollider2D>().size.x, 0.16F);
                cardDeck[i].GetComponent<BoxCollider2D>().offset = new Vector2(0F, 0.18F);
            }
            cardDeck[cardDeck.Count - 1].GetComponent<Card>().face = 1;
            cardDeck[cardDeck.Count - 1].GetComponent<BoxCollider2D>().size = new UnityEngine.Vector2(cardDeck[cardDeck.Count - 1].GetComponent<BoxCollider2D>().size.x, 0.5F);
            cardDeck[cardDeck.Count - 1].GetComponent<BoxCollider2D>().offset = new Vector2(0F, 0F);
        }
    }
}

