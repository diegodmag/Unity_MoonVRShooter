using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class canMove : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private GameController controller;
    

    // Update is called once per frame
    void Update()
    {
        if (GameController.currentGameStatus == GameController.GameStates.Playing)
        {
            this.gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 2;
        }
        else
        {
            this.gameObject.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0;
        }

    }
}
