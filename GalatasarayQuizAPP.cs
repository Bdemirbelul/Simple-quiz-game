using System;
using System.Collections.Generic;

class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public int CorrectOptionIndex { get; set; }

    public Question(string text, List<string> options, int correctOptionIndex)
    {
        Text = text;
        Options = options;
        CorrectOptionIndex = correctOptionIndex;
    }
}

class Quiz
{
    private List<Question> questions;
    private int score;




    public Quiz()
    {
        questions = new List<Question>
        {
            new Question("In which year was Galatasaray S.K. founded?", new List<string> { "1905", "1923", "1957", "1980" }, 0),
            new Question("How many times has Galatasaray won the Turkish Süper Lig?", new List<string> { "15", "21", "22", "27" }, 2),
            new Question("Which stadium is the home ground of Galatasaray?", new List<string> { "Ali Sami Yen Stadium", "Vodafone Park", "Şükrü Saracoğlu Stadium", "Türk Telekom Stadium" }, 3),
            new Question("Who is the all-time leading goal scorer for Galatasaray?", new List<string> { "Hakan Şükür", "Mete Bozkurt", "Arif Erdem", "Didier Drogba" }, 0),
            new Question("Which manager led Galatasaray to victory in the UEFA Cup and UEFA Super Cup in 2000?", new List<string> { "Fatih Terim", "Gheorghe Hagi", "Mircea Lucescu", "Eric Gerets" }, 0),
            new Question("Galatasaray became the first Turkish team to win a major European competition in 2000. Which competition was it?", new List<string> { "UEFA Champions League", "UEFA Cup", "Intertoto Cup", "UEFA Super Cup" }, 0),
            new Question("Who is known as the 'Emperor' and is considered one of the greatest players in Galatasaray's history?", new List<string> { "Gheorghe Hagi", "Arif Erdem", "Mete Bozkurt", "Didier Drogba" }, 0),
            new Question("Which country does Galatasaray's lion mascot symbolize?", new List<string> { "Turkey", "Italy", "Greece", "France" }, 2),
            new Question("What is the nickname of Galatasaray's passionate and dedicated fanbase?", new List<string> { "Aslanlar", "Cimbomlar", "UltrAslan", "GalaArmy" }, 2),
            new Question("Which Galatasaray player famously scored a hattrick against Real Madrid in the UEFA Champions League in 2013?", new List<string> { "Selçuk İnan", "Burak Yılmaz", "Wesley Sneijder", "Didier Drogba" }, 3),
            new Question("What color is traditionally associated with Galatasaray's home jersey?", new List<string> { "Yellow", "Red", "Orange", "White" }, 1),
            new Question("Who is the current president of Galatasaray S.K.?", new List<string> { "Mustafa Cengiz", "Fatih Terim", "Uğur Yıldırım", "Dursun Özbek" }, 0),
        };

            score = 0;
        

    }


    public void StartQuiz()
    {
        Console.WriteLine("Welcome to the Galatasaray Quiz!");
        Console.WriteLine("Answer the following questions:");

        foreach (var question in questions)
        {
            DisplayQuestion(question);
            int userAnswer = GetAnswerFromUser();
            CheckAnswer(question, userAnswer);
        }

        Console.WriteLine($"Quiz completed! Your score: {score}/{questions.Count}");
    }

    private void DisplayQuestion(Question question)
    {
        Console.WriteLine($"\n{question.Text}");
        for (int i = 0; i < question.Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Options[i]}");
        }
    }

    private int GetAnswerFromUser()
    {
        Console.Write("Enter the number of your answer: ");
        if (int.TryParse(Console.ReadLine(), out int userAnswer) && userAnswer >= 1 && userAnswer <= 4)
        {
            return userAnswer - 1; // Adjusting to match the zero-based index
        }
        else
        {
            Console.WriteLine("Invalid answer. Please enter a number between 1 and 4.");
            return GetAnswerFromUser();
        }
    }

    private void CheckAnswer(Question question, int userAnswer)
    {
        if (userAnswer == question.CorrectOptionIndex)
        {
            Console.WriteLine("Correct!\n");
            score++;
        }
        else
        {
            Console.WriteLine($"Incorrect. The correct answer is: {question.Options[question.CorrectOptionIndex]}\n");
        }
    }
}

class Program
{
    static void Main()
    {
        Quiz galatasarayQuiz = new Quiz();
        galatasarayQuiz.StartQuiz();
    }
}
