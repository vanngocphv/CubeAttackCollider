using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCube : MonoBehaviour
{
    public static event System.Action OnGameOverTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnGameOverTrigger?.Invoke();
            //Debug.Log("The game has been finished by player, thanks you for playing");
        }
    }

    
}
