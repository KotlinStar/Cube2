
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    [SerializeField] private PanelManager _panelManager;

    public void PressButtonStartGame()
    {
        _panelManager.StateSelection(StateGame.PlayGame);
    }
}
