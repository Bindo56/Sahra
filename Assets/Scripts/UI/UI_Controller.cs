using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public UnityEvent<int, int> OnNewGame = new UnityEvent<int, int>();
    public UnityEvent OnContinue = new UnityEvent();

    [SerializeField] Transform menuPanel;
    [SerializeField] Button continueLastGameBtn;

    SaveData saveData;

    public void NewGame_2x2() => OnNewGame.Invoke(2, 2);
    public void NewGame_3x3() => OnNewGame.Invoke(3, 3);
    public void NewGame_5x6() => OnNewGame.Invoke(5, 6);

    public void Back() => GameEvents.GameOver.Invoke();
     public void ContinueLastGame() => OnContinue.Invoke();



    private void OnEnable()
    {
        GameEvents.GameOver += ShowMainMenu;
        GameEvents.HideMenu += HideMainMenu;
        GameEvents.ShowMenu += ShowMainMenu;

    }

    private void OnDisable()
    {
        GameEvents.GameOver -= ShowMainMenu;
        GameEvents.HideMenu -= HideMainMenu;
        GameEvents.ShowMenu -= ShowMainMenu;
    }


    void ShowMainMenu()
    {
        menuPanel.gameObject.SetActive(true);
    }
    void HideMainMenu()
    {
        menuPanel.gameObject.SetActive(false);
    }

}
