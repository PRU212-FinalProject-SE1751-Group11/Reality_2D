using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStarManage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {


        GameState gameState = GameState.Instance;
        if (gameState != null)
        {
            GameData gameData = new GameData(gameState);
            FileDataHandler.Save(gameData); // Directly call static Save method
            Debug.Log("Game state saved upon collision with SaveStar.");
        }
        Debug.Log("--------------");
    }
}
