using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mat : MonoBehaviour
{
    public CardController controller;
    public List<GameObject> middlePoints;
    public GameObject template;

    void OnMouseDown() {
        if (controller.selectedCard.Count != 0) { //There is a card selected
            if (controller.selectedCard[0].GetComponent<Card>().number == 1) { //card is ace
                //get click coordinates
                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                GameObject newDeck = GameObject.Instantiate(template, new Vector3(worldPosition.x, worldPosition.y, 0), new Quaternion(1, 1, 1, 1));
                //this line is highly suspicious
                newDeck.GetComponent<MiddleDeck>().cardDeck.Clear();
                controller.selectedCard[0].GetComponent<Card>().cardDeck = newDeck; //redefine card's deck
                newDeck.GetComponent<MiddleDeck>().AddCard(newDeck, 1, 1);
                middlePoints.Add(newDeck);

            } 
        }
    }
}
