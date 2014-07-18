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

        public QuestionGroup(IQuestionContainer parent, string title, bool isAnswerSupported)
            : base(parent, title, isAnswerSupported) 
        {
            Questions = new QuestionsList(this);
        }

        public override AnswerBase CreateAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
