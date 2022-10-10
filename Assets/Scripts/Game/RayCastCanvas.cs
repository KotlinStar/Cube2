
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum TagGame { Cell, Cube };

public class RayCastCanvas : MonoBehaviour
{
	[HideInInspector] public GameObject currentObject;
	[SerializeField] private Scenario _scenario;
	private MoveObject _moveObject;
	private TagGame _tagGame;
	private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;

    void Start()
    {
		_moveObject = GetComponent<MoveObject>();
		m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }


    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.Mouse0))
		{
			m_PointerEventData = new PointerEventData(m_EventSystem) { position = Input.mousePosition };
            List<RaycastResult> results = new List<RaycastResult>();
			m_Raycaster.Raycast(m_PointerEventData, results);

			_moveObject.finishPoint = false;
			foreach (RaycastResult result in results)
			{
				if (result.gameObject.CompareTag(_scenario._cellTag) || result.gameObject.CompareTag(_scenario._smallPocket))
                {
					_moveObject.finishPoint = true;
					_moveObject.GetFinishObject(result.gameObject);
				}

				if(result.gameObject.CompareTag(_scenario._cubeTag))
                {
					if (currentObject != result.gameObject)
					{
						currentObject = result.gameObject;
						_moveObject.GetObject(currentObject);
					}
				}
			}
		}
	}
}
