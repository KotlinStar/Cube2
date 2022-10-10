
using UnityEngine;


public class MoveObject : MonoBehaviour
{
    [HideInInspector] public bool finishPoint;
    [SerializeField] private Scenario _scenario;
    [SerializeField] private VictoryCondition _victoryCondition;
    private RayCastCanvas _rayCastCanvas;
    private Vector2 _mousePos, _oldPosition;
    private RectTransform _screenTr;      
    private GameObject _finishObject;           
    private RectTransform _moveRect;          

    private void Start()
    {
        _rayCastCanvas = GetComponent<RayCastCanvas>();
        _screenTr = GetComponent<Canvas>().GetComponent<RectTransform>();
    }


    public void GetObject (GameObject objectMove)
    {
        _moveRect = objectMove.GetComponent<RectTransform>();
        _oldPosition = _moveRect.anchoredPosition;
    }

    public void GetFinishObject (GameObject finishObject)
    {
        _finishObject = finishObject;
    }

    public void MovingObject()          
    {
        if (_moveRect != null)
        {
            _mousePos.x = (Input.mousePosition.x * _screenTr.sizeDelta.x) / Screen.width;
            _mousePos.y = (Input.mousePosition.y * _screenTr.sizeDelta.y) / Screen.height;
            _moveRect.anchoredPosition = new Vector2(_mousePos.x, _mousePos.y);
        }
    }

    public void PointerUp ()
    {
        if (_moveRect != null)
        {
            if (!finishPoint)
            {
                _moveRect.anchoredPosition = _oldPosition;
            }
            else
            {
                _moveRect.transform.position = _finishObject.transform.position;

                if(_finishObject.CompareTag(_scenario._cellTag))
                {
                    _finishObject.tag = _scenario._fullCellsTag;
                    _moveRect.transform.gameObject.tag = _scenario._finishTag;
                    _victoryCondition.ConditionVictory(_finishObject);
                }
            }
        }

        finishPoint = false;
        _rayCastCanvas.currentObject = null;
        _moveRect = null;
    }
}
