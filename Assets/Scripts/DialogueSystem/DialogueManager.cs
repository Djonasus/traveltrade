using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    // Текстовые поля
    public Text NameNpc;
    public Text DialogueText;
    public Text AnswerText;

    // Объявляем счетчик - iterator, answerOptions - массив с вариантами ответов, sentences - предложения диалогов.
    private static int iterator;
    private static string[] answerOptions;
    private static Queue<string> sentences;

    void Start()
    {
        // создаем объект Queue
        sentences = new Queue<string>();

    }

    public void StartDialogue (Dialogue dialogue)
    {

        Debug.Log("Stating conversation with " + dialogue.name);

        // Устанавливаем поле Name
        NameNpc.text = dialogue.name;

        // Очищаем Queue
        sentences.Clear();

        // Заполняем Queue
        foreach (string sentence in dialogue.sentences)
        {

            sentences.Enqueue(sentence);

        }

        // Запролняем answerOptions вариантами ответа
        answerOptions = dialogue.answerOptions;

        // Устанавливаем значение поле элементом по индексу 0
        AnswerText.text = answerOptions[0];

        // Вызываем метод переключения на след.предложение
        NextDisplaySentence();

    }

    public void NextDisplaySentence()
    {
        // Проверяем есть ли в Queue элементы
        if(sentences.Count != 0)
        {
            // В переменную вытаскиваем элементы из Queue
            string sentence = sentences.Dequeue();
            // Устанавливаем значение поля DialogueText
            DialogueText.text = sentence;

        }

    }

    /*
     * iterator - счетчик для списка Next Back
     */

    public void NextAnswer()
    {

        // Увеличиваем итератор на 1
        if(iterator != answerOptions.Length - 1)
        AnswerText.text = answerOptions[++ iterator];

    }

    public void BackAnswer()
    {

        // Уменьшаем итератор на 1
        if(iterator != 0)
        AnswerText.text = answerOptions[-- iterator];

    }




}
