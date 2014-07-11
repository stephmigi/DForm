using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class FormAnswer
    {
        public string Answerer { get; set; }

        private List<AnswerBase> _answers;
        public List<AnswerBase> Answers { get; set; }

        public FormAnswer(string answerer)
        {
            Answerer = answerer;
            _answers = new List<AnswerBase>();
        }

        public AnswerBase FindOrCreateAnswerFor(QuestionBase question)
        {
            if (!_answers.Any(a => a.Question == question))
            {
                return question.CreateAnswer();
            }
            return _answers.First(a => a.Question == question);
        }
    }
}
