using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public string MainMenu;

    private void OnEnable(){
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button MainMenu = root.Q<Button>("MainMenu");

        MainMenu.RegisterCallback<ClickEvent>(OnMenuButtonClick);
    }

    public void OnMenuButtonClick(ClickEvent evt){
        Debug.Log("Clicked Start Button");
        SceneManager.LoadScene(MainMenu);
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