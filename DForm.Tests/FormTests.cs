﻿using DForm.Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Tests
{
    [TestFixture]
    public class FormTests
    {
        private const string FORM_NAME = "Test form";
        private const string ANSWERER_1 = "Bill";
        private const string ANSWERER_2 = "Hubdur";

        [Test]
        public void Form_Create()
        {
            Form f = new Form();

            Assert.IsNotNull(f);
            Assert.IsNullOrEmpty(f.Title);

            f.Title = FORM_NAME;

            Assert.AreEqual(f.Title, FORM_NAME);
        }

        [Test]
        public void Form_CreateFormAnswer()
        {
            Form f = new Form();
            f.Title = FORM_NAME;

            FormAnswer a = f.FindOrCreateFormAnswer(ANSWERER_1);

            Assert.IsNotNull(a);

            FormAnswer b = f.FindOrCreateFormAnswer(ANSWERER_1);

            Assert.AreSame(a, b);
            Assert.AreEqual(f.FormAnswers.Count(), 1);

            FormAnswer c = f.FindOrCreateFormAnswer(ANSWERER_2);

            Assert.AreNotSame(a, c);
            Assert.AreEqual(f.FormAnswers.Count(), 2);
            Assert.AreEqual(a.Answerer, ANSWERER_1);
            Assert.AreEqual(c.Answerer, ANSWERER_2);
        }

        [Test]
        public void Form_AddQuestion()
        {
            Form f = new Form();
            f.Title = FORM_NAME;

            Assert.AreEqual(f.Questions.NumberOfQuestions, 0);
            QuestionBase q1 = f.Questions.AddNewQuestion(typeof(MortalQuestion), "My mortal question", true);
            Assert.AreEqual(f.Questions.NumberOfQuestions, 1);
            Assert.AreEqual(q1.Title, "My mortal question");
            //Assert.IsTrue(f.Questions.Contains(q1));
            Assert.IsTrue(q1.GetType() == typeof(MortalQuestion));
        }

        [Test]
        public void Form_AddAnswerToQuestion()
        {
            Form f = new Form();
            f.Title = FORM_NAME;

            QuestionBase q1 = f.Questions.AddNewQuestion(typeof(MortalQuestion), "My mortal question", true);

            FormAnswer a = f.FindOrCreateFormAnswer(ANSWERER_1);

            var answerOfAnswerer1 = (MortalAnswer)a.FindOrCreateAnswerFor(q1);
            answerOfAnswerer1.MortalStringAnswer = "Bill's mortal answer";
        }

        [Test]
        public void Form_AddQuestionGroupWithOneQuestion()
        {
            Form f = new Form();
            f.Title = FORM_NAME;

            Assert.IsTrue(f.Questions.NumberOfQuestions == 0);
            var q1 = (QuestionGroup)f.Questions.AddNewQuestion(typeof(QuestionGroup), "My group", false);

            Assert.IsTrue(f.Questions.NumberOfQuestions == 1);
            Assert.IsTrue(q1.GetType() == typeof(QuestionGroup));
            Assert.IsTrue(q1.Parent == f);

            Assert.IsTrue(q1.Questions.NumberOfQuestions == 0);
            var q2 = q1.Questions.AddNewQuestion(typeof(MortalQuestion), "My mortal question", true);
            Assert.IsTrue(q2.Parent == q1);
            Assert.IsTrue(q1.Questions.NumberOfQuestions == 1);

            // todo : change parent should work:
            // add code to change parent (remove question from current parent then
            // add question in new parent) in QuestionList for example.
            q2.Parent = f;
            Assert.IsTrue(q2.Parent == f);
            Assert.IsTrue(q1.Parent == f);
            Assert.IsTrue(f.Questions.NumberOfQuestions == 2);
            Assert.IsTrue(q1.Questions.NumberOfQuestions == 0);
        }
    }
}
