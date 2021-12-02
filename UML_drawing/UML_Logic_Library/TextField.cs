using System.Collections.Generic;
using System.Drawing;

namespace UML_Logic_Library
{
    public class TextField
    {
        public Font Font => new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular);
        private string _textField = "Object";
        private string _textFieldProp = "+ Property(Type) : Type";
        private string _textFieldMethods = "+ Method(Type) : Type";

        public string TextFields
        {
            get => _textField;
            set
            {
                if (value.Length < 1)
                    _textField = "Object";
                else
                    _textField = value;
            }
        }
        
        public string TextFieldsProp
        {
            get => _textFieldProp;
            set
            {
                if (value.Length < 1)
                    _textFieldProp = "+ Property(Type) : Type";
                else
                    _textFieldProp = value;
            }
        }
        
        public string TextFieldsMethod
        {
            get => _textFieldMethods;
            set
            {
                if (value.Length < 1)
                    _textFieldMethods = "+ Method(Type) : Type";
                else
                    _textFieldMethods = value;
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
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }
    }
}