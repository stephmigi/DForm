using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class QuestionsList
    {
        private List<QuestionBase> _questions;

        public QuestionsList()
        {
            _questions = new List<QuestionBase>();
        }

        public int NumberOfQuestions
        {
            get
            {
                return _questions.Count();
            }
        }

        public QuestionBase AddNewQuestion(Type questionType, string title, bool isAnswerSupported)
        {
            //check for compatible types
            if (typeof(QuestionBase).IsAssignableFrom(questionType))
            {
                var question = (QuestionBase)Activator.CreateInstance(questionType, title, isAnswerSupported);
                _questions.Add(question);
                return question;
            }
            return null;
        }


    }
}
