
using UnityEngine;

public class ButtonChangeVolume : MonoBehaviour
{
    [SerializeField] private PanelManager _panelManager;

    public void PressButtonChangeVolume ()
    {
        _panelManager.StateSelection(StateGame.SetVolume);
    }
}
