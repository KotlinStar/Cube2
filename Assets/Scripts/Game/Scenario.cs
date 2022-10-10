using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public int numberScenario;
    [SerializeField] private string _tagCell;
    [SerializeField] private GameObject _cubePrefab, _creatingPanel, _largePocket;
    [SerializeField] private DataScenario _dataScenario;
    [Space]
    [Header("Tags Game")]
    public string _cellTag;
    public string _fullCellsTag;
    public string _finishTag;
    public string _cubeTag;
    public string _smallPocket;
    [Space]
    [SerializeField] private GameObject[] _arrayCell;
    private GameObject[] _finishCube;

    private void Start()
    {
        _arrayCell = GameObject.FindGameObjectsWithTag(_tagCell);
    }

    private void RanameTagsCells ()
    {
        RemoveCubes();
        for (int i = 0; i < _arrayCell.Length; i++)
        {
            _arrayCell[i].tag = _cellTag;
        }
    }

    private void RemoveCubes ()
    {
        _finishCube = GameObject.FindGameObjectsWithTag(_finishTag);
        for(int i = 0; i < _finishCube.Length; i++)
        {
            Destroy(_finishCube[i]);
        }
    }

    public void ArrangeTheCubes ()
    {
        RanameTagsCells();

        for (int i = 0; i < _arrayCell.Length; i++)
        {
            int number = int.Parse(_arrayCell[i].name);
            
            for(int j = 0; j <_dataScenario.List[numberScenario - 1].NumberFullCell.Count; j++)
            {
                if(number == _dataScenario.List[numberScenario - 1].NumberFullCell[j])
                {
                    GameObject cube = Instantiate(_cubePrefab, _arrayCell[i].transform.position, Quaternion.identity, _creatingPanel.transform);
                    cube.tag = _finishTag;
                    _arrayCell[i].tag = _fullCellsTag;
                }
            }
        }
        CreateCubeLargePocket();
    }

    private void CreateCubeLargePocket ()
    {
        Instantiate(_cubePrefab, _largePocket.transform.position, Quaternion.identity, _creatingPanel.transform);
    }
}
