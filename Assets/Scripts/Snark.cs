using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snark : MonoBehaviour
{
    public List<GameObject> snarkDeck;
    public CardController controller;
    
    void Update()
    {
        if (snarkDeck.Count != 0)
        {
            for (int i = 0; i < snarkDeck.Count; i++)
            {
                int cardSpace = i;
                snarkDeck[i].transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
                snarkDeck[i].GetComponent<Renderer>().sortingOrder = i;
                snarkDeck[i].GetComponent<BoxCollider2D>().size = new UnityEngine.Vector2(0F, 0F);
                
            }
            snarkDeck[snarkDeck.Count-1].GetComponent<Card>().face = 1;
            snarkDeck[snarkDeck.Count-1].GetComponent<BoxCollider2D>().size = new UnityEngine.Vector2(0.4F, 0.5F);
        }
    }
}