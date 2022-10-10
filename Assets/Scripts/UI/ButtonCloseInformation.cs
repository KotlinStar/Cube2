using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseInformation : MonoBehaviour
{
    [SerializeField] private GameObject _panelInformation;

    public void PressButtonPanelInformation ()
    {
        _panelInformation.SetActive(false);
    }
}
