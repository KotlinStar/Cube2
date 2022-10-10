using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DataScenario", fileName = "DataScenario")]

public class DataScenario : ScriptableObject
{
    [SerializeField] private List<ScenarioData> _scenarioList;
    public List<ScenarioData> List { get => _scenarioList; set => _scenarioList = value; }
}

[System.Serializable]

public class ScenarioData
{
    [SerializeField] private string _name;
    [SerializeField] private List<int> _numberFullCell;
    [SerializeField] private int _vicroryCell;

    public string Name { get => _name; set => _name = value; }

    public int VictoryCell { get => _vicroryCell; set => _vicroryCell = value; }
    public List<int> NumberFullCell { get => _numberFullCell; set => _numberFullCell = value; }
}

