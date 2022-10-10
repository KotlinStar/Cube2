using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StateGame { StartGame, PlayGame, SetVolume, VictoryGame, LostGame };

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelStart, _panelGame, _panelInformation;
    [SerializeField] private GameObject _closeButton, _changeVolume, _gameStatus;
    [SerializeField] private Scenario _scenario;
    [SerializeField] private Text _setText;

    void Start()
    {
        StateSelection(StateGame.StartGame);
    }

   public void  StateSelection (StateGame _stateGame)
    {
        switch(_stateGame)
        {
            case StateGame.StartGame:
                SetPanel(_panelStart, true);
                SetPanel(_panelInformation, false);
                break;
            case StateGame.PlayGame:
                SetPanel(_panelStart, false);
                SetPanel(_panelGame, true);
                SetPanel(_panelInformation, false);
                _scenario.ArrangeTheCubes();
                break;
            case StateGame.SetVolume:
                SetPanel(_panelInformation, true);
                SetPanel(_closeButton, true);
                SetPanel(_changeVolume, true);
                SetPanel(_gameStatus, false);
                break;
            case StateGame.VictoryGame:
                SetPanel(_panelInformation, true);
                SetPanel(_closeButton, false);
                SetPanel(_changeVolume, false);
                
                SetText("Победа!");
                break;
            case StateGame.LostGame:
                SetPanel(_panelInformation, true);
                SetPanel(_closeButton, false);
                SetPanel(_changeVolume, false);
                SetText("Ошибка!");
                break;
        }
    }
    private void SetPanel (GameObject panel, bool state)
    {
        panel.SetActive(state);
    }

    private void SetText (string set)
    {
        SetPanel(_gameStatus, true);
        _setText.text = string.Format("{0}", set);
    }
}
