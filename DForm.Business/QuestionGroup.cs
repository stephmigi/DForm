using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class QuestionGroup : QuestionBase, IQuestionContainer
    {
        public QuestionsList Questions { get; set; }

        public QuestionGroup(string title, bool isAnswerSupported)
            : base(title, isAnswerSupported) 
        {
            Questions = new QuestionsList();
        }

        public override AnswerBase CreateAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
