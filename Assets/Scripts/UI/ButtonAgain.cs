using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAgain : MonoBehaviour
{
    [SerializeField] private PanelManager _panelManager;

    public void PressButtonAgain ()
    {
        _panelManager.StateSelection(StateGame.PlayGame);
    }
}
