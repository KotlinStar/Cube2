using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private PanelManager _panelManager;   
    [Header("Data Scenario")]
    [SerializeField] private DataScenario _dataScenario;
    private Scenario _scenario;
    private DisappearingCubes _disappearingCubes;

    private void Start()
    {
        _scenario = GetComponent<Scenario>();
        _disappearingCubes = GetComponent<DisappearingCubes>();
    }

    public void ConditionVictory (GameObject _finishObject)
    {
        if (int.Parse(_finishObject.name) == _dataScenario.List[_scenario.numberScenario - 1].VictoryCell)
        {
            Debug.Log("Victory");
            _disappearingCubes.Disappearing();
        }
        else
        {
            _panelManager.StateSelection(StateGame.LostGame);
            Debug.Log("Fault");
        }
    }
}
