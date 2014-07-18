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
        private IQuestionContainer _parent;

        public QuestionsList(IQuestionContainer parent)
        {
            _parent = parent;
            _questions = new List<QuestionBase>();
        }

        public int NumberOfQuestions
        {
            get
            {
                return _questions.Count();
            }
        }

        public void AddNewQuestion(QuestionBase question)
        {
            _questions.Add(question);
        }

        public QuestionBase AddNewQuestion(Type questionType, string title, bool isAnswerSupported)
        {
            //check for compatible types
            if (typeof(QuestionBase).IsAssignableFrom(questionType))
            {
                var question = (QuestionBase)Activator.CreateInstance(questionType, _parent, title, isAnswerSupported);
                _questions.Add(question);
                return question;
            }
            return null;
        }

        public void Remove(QuestionBase question)
        {
            _questions.Remove(question);
        }
    }
}
