using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textmeshpro componentini çekiyoruz.

public class QuizManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;
    [SerializeField] GameObject[] answerButtons;

    void Start()
    {
        questionText.text = questionSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>(); //butonu al, buton içindeki child objesini yani doğal olarak texti al ve değiştir.
            buttonText.text = questionSO.GetAnswer(i);
        }
    }
}
