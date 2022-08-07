using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int snarkCount;
    public int points;

    //dunno if we'll need this
    public List<GameObject> SolitaireDecks;
    public GameObject Snark;
    public GameObject Draw;
    public GameObject DrawPile;
    // Start is called before the first frame update

    void OnMouseDown()
    {
        Color color;
        if (ColorUtility.TryParseHtmlString("#00FFFA", out color))
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color;
        if (ColorUtility.TryParseHtmlString("#FFFFFF", out color))
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
