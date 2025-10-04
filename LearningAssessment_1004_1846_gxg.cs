// 代码生成时间: 2025-10-04 18:46:52
using System;
using System.Collections.Generic;

/// <summary>
/// 学习效果评估程序
/// </summary>
public class LearningAssessment
{
    private List<Question> questions;
    private Random random;

    /// <summary>
    /// 初始化一个新的学习效果评估程序实例
    /// </summary>
    public LearningAssessment()
    {
        questions = new List<Question>();
        random = new Random();
        // 初始化问题库
        InitializeQuestions();
    }

    /// <summary>
    /// 初始化问题库
    /// </summary>
    private void InitializeQuestions()
    {
        questions.Add(new Question { QuestionId = 1, QuestionText = "What is the capital of France?", Answer = "Paris" });
        questions.Add(new Question { QuestionId = 2, QuestionText = "Who is the father of computer science?", Answer = "Alonzo Church" });
        // 添加更多问题
    }

    /// <summary>
    /// 随机选择一个问题并返回
    /// </summary>
    /// <returns>一个Question对象</returns>
    public Question GetRandomQuestion()
    {
        if (questions.Count == 0)
        {
            throw new InvalidOperationException("Question bank is empty.");
        }

        int index = random.Next(questions.Count);
        return questions[index];
    }

    /// <summary>
    /// 评估用户给出的答案
    /// </summary>
    /// <param name="userAnswer">用户的答案</param>
    /// <param name="question">问题</param>
    /// <returns>评估结果</returns>
    public bool AssessAnswer(string userAnswer, Question question)
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }

        return string.Equals(userAnswer, question.Answer, StringComparison.OrdinalIgnoreCase);
    }
}

/// <summary>
/// 表示一个问题
/// </summary>
public class Question
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; }
    public string Answer { get; set; }
}
