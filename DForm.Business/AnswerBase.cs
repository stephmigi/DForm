using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public abstract class AnswerBase
    {
	    private QuestionBase _question;

        public QuestionBase Question
        {
            get
            {
                return _question;
            }
        }
	
	    public AnswerBase(QuestionBase question)
	    {
		    _question = question; 
        }
    }
}
