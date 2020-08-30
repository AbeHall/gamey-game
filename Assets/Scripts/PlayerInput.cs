using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles
public class PlayerInput : MonoBehaviour
{
    public CustomControls keyBindings;
    float timeOfFirstButton = 0f;
    bool firstButtonPressed = false;
    public int MoveX;
    public int MoveY;
    public bool Jump;
    public bool Attack;

    // Update is called once per frame
    void Update()
    {

        if(Time.time - timeOfFirstButton>1f) firstButtonPressed = false;

        // get player
        MoveX = 0;
        if (Input.GetKey(keyBindings.leftKey))
        {
            MoveX--;
        }
        if (Input.GetKey(keyBindings.rightKey))
        {
            MoveX++;
        }
        MoveY = 0;
        if (Input.GetKey(keyBindings.downKey))
        {
            // down key does nothing
            MoveY--;
        }
        if (Input.GetKey(keyBindings.upKey))
        {
            MoveY++;
        }

        //Doubletap down for platforms
        if(Input.GetKeyDown(keyBindings.downKey) && firstButtonPressed) {
             if(Time.time - timeOfFirstButton < 0.5f) {
                MoveY--;
             } else {
                 firstButtonPressed = false;
             }

         }
 
         if(Input.GetKeyDown(keyBindings.downKey) && !firstButtonPressed) {
             firstButtonPressed = true;
             timeOfFirstButton = Time.time;
         }


        Jump = Input.GetKeyDown(keyBindings.jumpKey);
        Attack = Input.GetKey(keyBindings.lightKey);
    }
}
