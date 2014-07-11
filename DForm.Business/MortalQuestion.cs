using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class MortalQuestion : QuestionBase
    {
	    public MortalQuestion(string title) : base(title){}
	
	    public string FreeAnswer {get; set;}

	    public override AnswerBase CreateAnswer()
	    {
		    return new MortalAnswer(this);
	    }
    }
}
