using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;
    [SerializeField] float screenWidthInUnits = 16f;

    // Cached References
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX - 1);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
