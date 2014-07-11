using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public class MortalAnswer : AnswerBase
    {
	    public MortalAnswer(MortalQuestion question) : base(question) {}
	
	    public string MortalStringAnswer { get; set; }
    }
}
