using TMPro;
using UnityEngine;

public class deathCount : MonoBehaviour
{

    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "You died "+PlayerPrefs.GetInt("deathcount").ToString() + " times";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
