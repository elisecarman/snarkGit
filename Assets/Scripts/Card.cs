using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int playerID;
    public int number;
    public int suit;
    public int color;
    public int face = 0;


    public GameObject cardDeck;
    public GameObject mat;
    
    public Draw draw;
    public Deck deck;
    public MiddleDeck middleDeck;
    public CardController cardController;

    public int spriteNumber;
    public Sprite sprite;
    public Sprite back; 
    public Sprite[] cards;
    
    // sprite images are organized as such:
    // Suite 1: [0,1,2,3,4,5,6,7,8,9,10,11,12]
    // Suite 2: [13,.. 25] .. and so on
    //this function assign sprite depending on cards suit and number
    void assignSprite() {
        if (suit == 3) {
            spriteNumber = 0;
        } if (suit == 2) {
            spriteNumber = 13;
        } if (suit == 1) {
            spriteNumber = 26;
        } if (suit == 0) {
            spriteNumber = 39; 
        }

        Sprite[] cards = Resources.LoadAll<Sprite>("Sprites/Cards/Classic New/Cards");
        sprite = cards[spriteNumber+number-1];
        back = Resources.Load<Sprite>("Sprites/Cards/Classic New/Back");
        print(sprite);
        
    }

    //at beginning of game, sprites are assigned, 
    void Start() {
        assignSprite();

        //what
        cardDeck = GameObject.Find("DrawPile");
        mat = GameObject.Find("Game Mat");
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        draw.drawDeckUnshuffled.Add(gameObject);
    }

    void Update() {
        if (face == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        } else {
            gameObject.GetComponent<SpriteRenderer>().sprite = back;
        }

        if (cardController.selectedCard.Contains(gameObject)){

            Color color;
            if (ColorUtility.TryParseHtmlString("#00FFFA", out color))
            {
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }

        }
        else
        {
            Color color;
            if (ColorUtility.TryParseHtmlString("#FFFFFF", out color))
            {
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    public void OnMouseDown() {
        print("CARD CLICKED: " + gameObject + " | FACE: " + face);
        //card can only be clicked if it's face up
        //use SelCard method in Decks

        if (face == 1) {
            //card is from Snark or Draw Pile
            if (mat.GetComponent<Mat>().middlePoints.Contains(cardDeck))
            //if (cardDeck == GameObject.Find("DeckMiddle(Clone)"))
            {
                print("yas");
                if (cardController.selectedCard.Any()) {
                    cardDeck.GetComponent<MiddleDeck>().AddCard(cardDeck, 1, 1);
                }
                else
                {return;}
            }
            else if (cardDeck == GameObject.Find("DeckPurple")||cardDeck == GameObject.Find("DrawPile")) {
                if (cardController.selectedCard.Any()) {
                    cardController.selectedCard.Clear();
                } 
                else {
                    
                    deck.GetComponent<Deck>().SelCard(cardDeck, gameObject);
                }
            } else {
                if (cardController.selectedCard.Any()) { 
                        deck.GetComponent<Deck>().AddCard(cardDeck, 13, 1);
                } else {
                    deck.GetComponent<Deck>().SelCard(cardDeck, gameObject);
                }
            }
        }
    }
}

