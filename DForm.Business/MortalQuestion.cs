using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class MortalQuestion : QuestionBase
    {
        public MortalQuestion(IQuestionContainer parent, string title, bool isAnswerSupported) : base(parent, title, isAnswerSupported) { }
	
	    public string FreeAnswer {get; set;}

	    public override AnswerBase CreateAnswer()
	    {
		    return new MortalAnswer(this);
	    }
    }
}
