﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DForm.Business
{
    public abstract class QuestionBase
    {
        private IQuestionContainer _parent;
        private string _title;
        public bool IsAnswerSupported { get; set; }

        public QuestionBase(string title, bool isAnswerSupported)
        {
            _parent = null;
            _title = title;
            IsAnswerSupported = isAnswerSupported;
            //setIndex();
        }

        public IQuestionContainer Parent
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
