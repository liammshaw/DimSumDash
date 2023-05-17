using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameStartScene;
    public string credits;

    private void OnEnable(){
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startButton = root.Q<Button>("StartGame");
        Button creditsButton = root.Q<Button>("Credits");

        startButton.RegisterCallback<ClickEvent>(OnStartButtonClick);
        creditsButton.RegisterCallback<ClickEvent>(OnCreditsButtonClick);
    }

    public void OnStartButtonClick(ClickEvent evt){
        Debug.Log("Clicked Start Button");
        SceneManager.LoadScene(gameStartScene);
    }

    public void OnCreditsButtonClick(ClickEvent evt){
        Debug.Log("Clicked Start Button");
        SceneManager.LoadScene(credits);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
