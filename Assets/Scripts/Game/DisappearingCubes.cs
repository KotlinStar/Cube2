using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisappearingCubes : MonoBehaviour
{
    [SerializeField] private PanelManager _panelManager;
    [SerializeField] private float _speedDisappearing;
    [SerializeField] private GameObject[] _arrayFinish;
    private Scenario _scenario;

    private void Start()
    {
        _scenario = GetComponent<Scenario>();
    }

    public void Disappearing ()
    {
        ArrayCubes();
        StartCoroutine(CubeDisappearing());
    }

    private void ArrayCubes ()
    {
        _arrayFinish = GameObject.FindGameObjectsWithTag(_scenario._finishTag);
    }

    private IEnumerator CubeDisappearing ()
    {
        for (; ;)
        {
            yield return new WaitForSeconds(_speedDisappearing);
            for (int i = 0; i < _arrayFinish.Length; i++)
            {
                Color color = _arrayFinish[i].GetComponent<Image>().color;
                color.a -= Time.deltaTime;
                _arrayFinish[i].GetComponent<Image>().color = color;
                if(color.a <= 0)
                {
                    _panelManager.StateSelection(StateGame.VictoryGame);
                    StopAllCoroutines();
                    yield return null;
                }
            }
        }
    }
}
