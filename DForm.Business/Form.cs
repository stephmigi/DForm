using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class Form : IQuestionContainer
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

        public QuestionsList Questions { get; set; }

        public Form()
        {
            _formAnswers = new Dictionary<string, FormAnswer>();
            Questions = new QuestionsList();
        }

        public FormAnswer FindOrCreateFormAnswer(string answerer)
        {
            if (!_formAnswers.ContainsKey(answerer))
            {
                _formAnswers.Add(answerer, new FormAnswer(answerer));
            }
            return _formAnswers[answerer];  
        }
    }
}
