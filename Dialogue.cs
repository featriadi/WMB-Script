using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] kalimat;
    private int index;
    public float typingSpeed;

    void Start(){
        StartCoroutine(Type());
    }

    IEnumerator Type(){
        foreach (char letter in kalimat[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void KalimatSelanjutnya(){
        if (index < kalimat.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else{
            textDisplay.text = "";
        }
    }
}
