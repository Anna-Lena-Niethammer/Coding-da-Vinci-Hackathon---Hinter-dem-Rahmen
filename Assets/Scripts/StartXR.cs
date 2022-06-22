using System;
using UnityEngine;
using Varjo.XR;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;

public class StartXR : MonoBehaviour
{
    private int _state;

    public GameObject _unselectedAR;

    public GameObject _selectedAR;

    public GameObject _vr;

    public GameObject _bust;

    public GameObject letter;
    
    public InteractionBehaviour letterInteraction;

    public AnchorableBehaviour letterAnchorableBehaviour;
    
    private bool _grabbing = false;

    private Vector3 _grabStart;

    private float _moveDistance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        VarjoMixedReality.StartRender();
        SetStartVisibilities();
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyCodes();
        CheckHands();
    }


    private void CheckKeyCodes()
    {
        if (_state == 0 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            _state++;
            _unselectedAR.SetActive(false);
            _selectedAR.SetActive(true);
            Vector3 letterPosition = _bust.transform.position;
            letterPosition.x += -0.375f;
            letter.transform.position = letterPosition;
            letter.transform.rotation = Quaternion.Euler(30,0,0);
            letter.SetActive(true);
            _bust.SetActive(true);
            return;
        }

        if (_state == 1 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            _state++;
            _selectedAR.SetActive(false);
            _bust.SetActive(false);
            _vr.SetActive(true);
            return;
        }

        if (_state == 1 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _state--;
            _unselectedAR.SetActive(true);
            _selectedAR.SetActive(false);
            letter.SetActive(false);
            _bust.SetActive(false);
            return;
        }

        if (_state == 2 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _state--;
            _selectedAR.SetActive(true);
            letterAnchorableBehaviour.Detach();
            Vector3 letterPosition = _bust.transform.position;
            letterPosition.x += -0.375f;
            letter.transform.position = letterPosition;
            letter.transform.rotation = Quaternion.Euler(30,0,0);
            _bust.SetActive(true);
            _vr.SetActive(false);
            return;
        }
    }

    private void CheckHands()
    {
        Hand hand = Hands.Right ?? Hands.Left;

        if (hand != null && !_grabbing && hand.GrabStrength > 0.8)
        {
            _grabbing = true;
            _grabStart = transform.InverseTransformPoint(hand.PalmPosition.ToVector3());
        }

        if (hand != null && _grabbing && hand.GrabStrength < 0.6)
        {
            _grabbing = false;
            Vector3 grabEnd = transform.InverseTransformPoint(hand.PalmPosition.ToVector3());

            Vector3 distance = grabEnd - _grabStart;

            if (_state == 0 && distance.y < -_moveDistance)
            {
                _state++;
                _unselectedAR.SetActive(false);
                _bust.SetActive(true);
                Vector3 letterPosition = _bust.transform.position;
                letterPosition.x += -0.375f;
                letter.transform.position = letterPosition;
                letter.transform.rotation = Quaternion.Euler(30,0,0);
                letter.SetActive(true);
                _selectedAR.SetActive(true);
                return;
            }

            if (_state == 1 && distance.y > _moveDistance)
            {
                _state--;
                _unselectedAR.SetActive(true);
                _bust.SetActive(false);
                letter.SetActive(false);
                _selectedAR.SetActive(false);
                return;
            }
        }
    }

    public void letterPickedUp()
    {
        if (_state == 1)
        {
            _state++;
            _selectedAR.SetActive(false);
            _bust.SetActive(false);
            _vr.SetActive(true);
        }
    }
    
    public void letterAttached()
    {
        Debug.Log("attached");
        if (_state == 2)
        {
            _state--;
            _selectedAR.SetActive(true);
            _bust.SetActive(true);
            letterAnchorableBehaviour.Detach();
            Vector3 letterPosition = _bust.transform.position;
            letterPosition.x -= 0.375f;
            letter.transform.position = letterPosition;
            letter.transform.rotation = Quaternion.Euler(30,0,0);
            letterAnchorableBehaviour.Detach();
            _vr.SetActive(false);
        }
    }

    private void SetStartVisibilities()
    {
        _unselectedAR.SetActive(true);
        _selectedAR.SetActive(false);
        _vr.SetActive(false);
    }
}