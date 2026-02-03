using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerDownHandler
{
    public CardDefinition Definition { get; private set; }
    public CardState State { get; private set; }
    RectTransform rectTransform;
    [SerializeField] Image frontImage;


    // public CardDefinition Definition;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void Initialize(CardDefinition definition)
    {
       // Debug.Log($"Card initialized with pairId: {definition.pairId}");
        Definition = definition;
        frontImage.sprite = Definition.frontSprite;
        State = CardState.Hidden;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"Card {Definition.pairId} clicked.");
        GameEvents.RequestCardFlip?.Invoke(this);
    }

    public void SetStateInstant(CardState state)
    {
        State = state;

        switch (state)
        {
            case CardState.Hidden:
                frontImage.enabled = true;
                break;

            case CardState.Revealed:
                frontImage.enabled = true;
                break;

            case CardState.Matched:
                frontImage.enabled = false;
                break;
        }
    }


    public void HideCard()
    {
        frontImage.enabled = false;
        // this.gameObject.SetActive(false);
    }


    public void SetState(CardState newState)
    {
        State = newState;
        // animation hook later
    }

    public CardState GetState()
    {
        return State;
    }

    public void SetSize(Vector2 size)
    {
        rectTransform.sizeDelta = size;
    }


}
