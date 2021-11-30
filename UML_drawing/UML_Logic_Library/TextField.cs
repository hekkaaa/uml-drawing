using System.Collections.Generic;
using System.Drawing;

namespace UML_Logic_Library
{
    public class TextField
    {
        public List<string> TextList = new List<string>();
        private string _textField;
        public Font Font => new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);

        public string TextFields
        {
            get => _textField;
            private set
            {
                if (TextList.Count < 1)
                    _textField = "Object";
                else
                    _textField = string.Join(" ", TextList.ToArray());
            }
        }
        
        public virtual StringFormat StringFormatTitle
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }
        
        public virtual StringFormat StringFormatField
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Far;
                return stringFormat;
            }
        }
    }
}