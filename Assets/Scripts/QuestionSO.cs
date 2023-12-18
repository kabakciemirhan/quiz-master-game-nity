using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Question", menuName = "New Question", order = 0)]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question text here";

    public string GetQuestion()
    {
        return question; //string değeri ile açtığımız metot, buradan istediğimiz fonksiyona geri döndürebiliriz.
    }
}
/*
public class Test
{
    QuestionSO questionSO;

    void TestA()
    {
        string question = questionSO.GetQuestion(); //bunu zaten unity'nin hazır assetleri ile yapıyorduk hatırladın. şimdi, kendi class ımızı kendimiz oluşturup kendi belirlediğimiz değeri döndürüyoruz.
    }
}
*/
