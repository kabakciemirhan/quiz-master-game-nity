using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //textmeshpro componentini çekiyoruz.

public class QuizManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO questionSO;
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite; //varsayılan butonun arkaplan resmi
    [SerializeField] Sprite correctAnswerSprite; //doğru cevabın arkaplan resmi

    void Start()
    {
        //DisplayQuestion();
        GoNextQuestion();
    }

    //soruyu gösterme kodlarını metot içerisine aldık
    void DisplayQuestion()
    {
        questionText.text = questionSO.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>(); //butonu al, buton içindeki child objesini yani doğal olarak texti al ve değiştir.
            buttonText.text = questionSO.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if(index == questionSO.GetCorrectAnswerIndex()) //eğer cevap doğruysa
        {
            questionText.text = "Correct!"; //soru yazısını değiştir
            buttonImage = answerButtons[index].GetComponent<Image>(); //butonların arkaplan resmini çek
            buttonImage.sprite = correctAnswerSprite; //eğer doğru cevap index == questionso.getcorr.... şeklinde ise doğru cevap sprite'ını arkaplan yap.
        }
        else //eğer cevap yanlışsa
        {
            /*questionText.text ="False Answer!";
            Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>(); //doğru olan cevabı correctanswer sprite ı ile çevreliyoruz
            buttonImage.sprite = correctAnswerSprite; */
            //yukarıda yaptığım da doğru ama aşağıda kursta yapılan kod var o yüzden üst tarafı yorum satırına aldım.
            correctAnswerIndex = questionSO.GetCorrectAnswerIndex();
            string correctanswer = questionSO.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was;\n" + correctanswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        //cevap seçildikten sonra butonun kullanılabilirliğini kapatıyoruz.
        SetButtonState(false);
    }

    void GoNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    //yeni soruya geçince sprite lar sıfırlanmalı
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    //butonun açılıp kapanma durumunu kontrol altına aldık
    void SetButtonState(bool butonDurum)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = butonDurum;
        }
    }
}
