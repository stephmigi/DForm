using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class Form
    {
        public string Title { get; set; }

        private Dictionary<string, FormAnswer> _formAnswers;
        public IReadOnlyDictionary<string, FormAnswer> FormAnswers
        {
            get
            {
                return _formAnswers;
            }
        }

        private List<QuestionBase> _questions;
        public IReadOnlyList<QuestionBase> Questions
        {
            get
            {
                return _questions;
            }
        }

        public Form()
        {
            _formAnswers = new Dictionary<string, FormAnswer>();
            _questions = new List<QuestionBase>();
        }

        public FormAnswer FindOrCreateFormAnswer(string answerer)
        {
            if (!FormAnswers.ContainsKey(answerer))
            {
                _formAnswers.Add(answerer, new FormAnswer(answerer));
            }
            return _formAnswers[answerer];  
        }

        public QuestionBase AddNewQuestion(Type questionType, string title)
        {
            //check for compatible types
            if (typeof(QuestionBase).IsAssignableFrom(questionType))
            {
                var question = (QuestionBase)Activator.CreateInstance(questionType, title);
                _questions.Add(question);
                return question;
            }
            return null;
        }
    }
}
