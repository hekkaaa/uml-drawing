using System.Drawing;

namespace UML_Logic_Library.AdditionalClasses
{
    public sealed class TextField
    {
        private Font _font = SystemFonts.DefaultFont;
        private string _textField = "Object";
        private string _textFieldProp = "+ Property(Type) : Type";
        private string _textFieldMethods = "+ Method(Type) : Type";

        public Font Font
        {
            get => _font;
            set
            {
                _font = value;
            }
        }
        
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
        
        public StringFormat StringFormatTitle
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }
        
        public StringFormat StringFormatField
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