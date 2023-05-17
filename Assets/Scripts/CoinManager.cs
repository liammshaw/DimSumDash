using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=5GWRPwuWtsQ

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    // public Label ui;

    // void OnEnable(){
    //     VisualElement root = GetComponent<UIDocument>().rootVisualElement;

    //     ui = root.Q<Label>("CoinCount");
    // }
    void Update()
    {
        coinText.text = coinCount.ToString();
    }
}
