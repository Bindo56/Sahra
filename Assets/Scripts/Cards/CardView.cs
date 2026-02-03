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
    [SerializeField] Image backImage;
    [SerializeField] Animator anim;


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
        Debug.Log($"Card {Definition.pairId} state set instantly to {state}.");
        State = state;

        switch (state)
        {
            case CardState.Hidden:
                backImage.enabled = true;
                frontImage.enabled = false;
                break;

            case CardState.Revealed:
                frontImage.enabled = true;
                backImage.enabled = false;
                anim.SetBool("Flip", true);
                break;

            case CardState.Matched:
                frontImage.enabled = true;
                backImage.enabled = false;
                anim.SetBool("Flip", true);
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

        switch (State)
        {
            case CardState.Hidden:
                /* backImage.enabled = true;
                 frontImage.enabled = false;*/
                break;

            case CardState.Resolving:

                // Could add some resolving animation here
                break;


            case CardState.Revealed:
                /*frontImage.enabled = true;
                backImage.enabled = false;*/
                anim.SetBool("Flip", true);
                anim.SetBool("Back", false);
                break;

            case CardState.BackToHidden:

                StartCoroutine(Delay());
                //
               /* anim.SetBool("Back", true);
                anim.SetBool("Flip", false);
                SetState(CardState.Hidden);*/
                /* backImage.enabled = true;
                 frontImage.enabled = false;*/
                break;

            case CardState.Matched:
                frontImage.enabled = true;
                backImage.enabled = false;
                break;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Back", true);
        anim.SetBool("Flip", false);

        yield return new WaitForSeconds(0.5f);

        SetState(CardState.Hidden);
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
