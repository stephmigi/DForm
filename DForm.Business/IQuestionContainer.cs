using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public interface IQuestionContainer
    {
        QuestionsList Questions { get; }
    }
}