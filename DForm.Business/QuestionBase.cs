using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public abstract class QuestionBase
    {
        private Form _parent;
        private string _title;

        public QuestionBase(string title)
        {
            _parent = null;
            _title = title;
            //setIndex();
        }

        public Form Parent
        {
            get 
            { 
                return _parent; 
            }
            set 
            { 
                _parent = value; 
            }
        }

        public string Title
        {
            get { return _title; }
        }

        public int Index { get; set; }

        private void setIndex()
        {
            throw new NotImplementedException();
        }

        public virtual void Display()
        {
            Console.WriteLine(_title);
        }

        public abstract AnswerBase CreateAnswer();
    }
}
