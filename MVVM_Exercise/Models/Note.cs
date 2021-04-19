using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_Exercise.Models
{
    class Note
    {
        public string Text { get; set; }
        public Note(string text)
        {
            this.Text = text;
        }

        public Note() { }

        public override string ToString()
        {
            return Text;
        }
    }
}
