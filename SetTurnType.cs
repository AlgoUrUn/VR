using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnType : MonoBehaviour
{
    public ActionBasedContinuousTurnProvider ContinuousTurn;
    public ActionBasedSnapTurnProvider snapTurn;

    public void SetTypeFromIndex (int index)
    {
        if(index == 0)
        {
            snapTurn.enabled = false;
            ContinuousTurn.enabled = true;
        }
       else if(index == 1)
        {
            snapTurn.enabled = true;
            ContinuousTurn.enabled = false;
        }
    }
    
}
