using System;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Gallery : MonoBehaviour
{
    private static int galleryOffset = 3;

    private static float galleryDistance = 0.75f;

    private static float galleryVarianceAlpha = 0.5f;

    private int entriesSize;

    public Data data;

    private int _state;

    private GameObject _unselectedAR;

    private GameObject _gallery;

    private bool _grabbing = false;

    private Vector3 _grabStart;

    // Start is called before the first frame update
    void Start()
    {
        InitializeGameObjectReferences();
        InitializeDataConnection();
        InitializeChildMaterials();
    }


    // Update is called once per frame
    void Update()
    {
        CheckKeyCodes();
        CheckHands();
    }

    private void CheckHands()
    {
        Hand hand = Hands.Right ?? Hands.Left;

        if (hand != null && !_grabbing && hand.GrabStrength > 0.8)
        {
            _grabbing = true;
            _grabStart = _gallery.transform.InverseTransformPoint(hand.PalmPosition.ToVector3());
        }

        if (hand != null && _grabbing && hand.GrabStrength < 0.6)
        {
            _grabbing = false;
            Vector3 grabEnd = _gallery.transform.InverseTransformPoint(hand.PalmPosition.ToVector3());

            Vector3 distance = grabEnd - _grabStart;

            Debug.Log(" Grab start:" + _grabStart);
            Debug.Log(" Grab End:" + grabEnd);


            if (distance.x > 0.15 && !IsGalleryMoving() && distance.y < 0.2)
            {
                if (data.selectedEntry > 0) data.selectedEntry--;
                else data.selectedEntry = entriesSize - 1;
                MoveGallery(galleryDistance);
                return;
            }

            if (distance.x < -0.15 && !IsGalleryMoving() && distance.y < 0.2)
            {
                data.selectedEntry = (data.selectedEntry + 1) % entriesSize;
                MoveGallery(-galleryDistance);
                return;
            }
        }
    }

    private void InitializeGameObjectReferences()
    {
        _gallery = transform.Find("Gallery").gameObject;
    }

    private void InitializeDataConnection()
    {
        data.selectedEntry = galleryOffset;
        entriesSize = data.GetEntriesSize();
    }

    private void InitializeChildMaterials()
    {
        int index = 0;
        foreach (Transform child in _gallery.transform)
        {
            var material = Resources.Load<Texture>(data.GetEntryIdValue(index));
            child.GetComponent<MeshRenderer>().material.mainTexture = material;
            index++;
        }
    }

    private void CheckKeyCodes()
    {
        if (_state == 0 && Input.GetKeyDown(KeyCode.RightArrow) && !IsGalleryMoving())
        {
            if (data.selectedEntry > 0) data.selectedEntry--;
            else data.selectedEntry = entriesSize - 1;
            MoveGallery(galleryDistance);
            return;
        }

        if (_state == 0 && Input.GetKeyDown(KeyCode.LeftArrow) && !IsGalleryMoving())
        {
            data.selectedEntry = (data.selectedEntry + 1) % entriesSize;
            MoveGallery(-galleryDistance);
            return;
        }
    }

    private bool IsGalleryMoving()
    {
        foreach (Transform child in _gallery.transform)
        {
            GalleryMoveAnimation moveScript = child.gameObject.GetComponent<GalleryMoveAnimation>();
            if (moveScript.isMoving) return true;
        }

        return false;
    }

    private void MoveGallery(float distance)
    {
        float hideDistance = (galleryOffset - 1) * distance;
        float resetDistance = (galleryOffset * distance);
        float resetPoint = galleryOffset * -distance;
        foreach (Transform child in _gallery.transform)
        {
            bool skipAnimation = false;
            Vector3 v3 = child.localPosition;
            float newAlpha = 0.8f;

            v3.x += distance;

            if (distance > 0 && v3.x > hideDistance + galleryVarianceAlpha ||
                distance < 0 && v3.x < hideDistance - galleryVarianceAlpha)
            {
                newAlpha = 0f;
            }


            if (distance > 0 && v3.x > resetDistance + galleryVarianceAlpha ||
                distance < 0 && v3.x < resetDistance - galleryVarianceAlpha)
            {
                v3.x = resetPoint;
                skipAnimation = true;
                newAlpha = 0f;
            }

            if (-galleryDistance + galleryVarianceAlpha < v3.x && v3.x < galleryDistance - galleryVarianceAlpha)
            {
                newAlpha = 1f;
            }

            if (skipAnimation)
            {
                child.transform.localPosition = v3;
                int newIndex;
                if (v3.x < 0)
                {
                    newIndex = data.selectedEntry - galleryOffset;
                    if (newIndex < 0) newIndex += entriesSize;
                }
                else
                {
                    newIndex = (data.selectedEntry + galleryOffset) % entriesSize;
                }

                var material = Resources.Load<Texture>(data.GetEntryIdValue(newIndex));
                child.GetComponent<MeshRenderer>().material.mainTexture = material;
            }

            GalleryMoveAnimation moveScript = child.gameObject.GetComponent<GalleryMoveAnimation>();
            moveScript.SetTargetDestination(v3);
            moveScript.SetTargetAlpha(newAlpha);
        }
    }
}