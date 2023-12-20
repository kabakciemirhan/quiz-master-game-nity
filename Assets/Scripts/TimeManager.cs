using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //soruyu çözmek için gereken zaman
    [SerializeField] float timeToCompleteQuestion = 30f;
    //doğru cevabı göstermek için gereken zaman - diğer soruya geçiş
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    //zamanı timervalue ile ölçelim. sprite ile eşleme burada yapılacak
    public bool isAnsweringQuestion = false;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion) //soru cevaplandıysa
        {
            if(timerValue <= 0) //soru cevaplandıysa ve geri sayım 0 ise
            {
                isAnsweringQuestion = false; //soru cevap boolean ı deaktive et 
                timerValue = timeToShowCorrectAnswer;   //zamanı doğru cevap gösterme süresinden geriye say
            }
        }
        else //eğer soru cevaplanmadıysa
        {
            if(timerValue <= 0) //soru cevaplanmadıysa ve süre 0'ı geçtiyse
            {
                isAnsweringQuestion = true; //soru cevap boolean aktifleştir
                timerValue = timeToCompleteQuestion; //zamanı soru cevaplama süresinden geriye say
            }
        }
        Debug.Log(timerValue);
    }
}
