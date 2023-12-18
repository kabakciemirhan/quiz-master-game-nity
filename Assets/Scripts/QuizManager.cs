using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textmeshpro componentini çekiyoruz.

public class QuizManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;

    void Start()
    {
        questionText.text = questionSO.GetQuestion();
    }
}
