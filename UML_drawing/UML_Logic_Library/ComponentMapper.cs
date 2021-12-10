using System.Drawing;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.Markers;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library
{
    public static class ComponentMapper
    {
        public static Component FromLiveData(this LiveDataElem elem)
        {
            switch (elem.CompName)
            {
               case "RectangleComponent":
                   var comp = new RectangleComponent();
                   comp.Path = elem.SerializablePath.Value;
                   comp.Color = elem.Color;
                   comp.PenWidth = elem._penWidth;
                   comp.PenColor = elem._penColor;
                   comp.Text.TextFields = elem.Text[0];
                   comp.Text.Font = elem.Font[0];
                   comp.Location = elem.Location;
                   comp.textRect = elem.TextRectangles[0];
                   return comp;
               case "RectangleOneField":
                   var comp1 = new RectangleOneField();
                   comp1.Head = new RectangleField(elem.Rectangles[0], elem.TextRectangles[0]);
                   comp1.Head.Text.TextFields = elem.Text[0];
                   comp1.Head.Text.Font = elem.Font[0];
                   comp1.FieldRectangle = new RectangleField(elem.Rectangles[1], elem.TextRectangles[1]);
                   comp1.FieldRectangle.Text.TextFieldsProp = elem.Text[1];
                   comp1.FieldRectangle.Text.Font = elem.Font[1];
                   comp1.Path = elem.SerializablePath.Value;
                   comp1.Color = elem.Color;
                   comp1.PenWidth = elem._penWidth;
                   comp1.PenColor = elem._penColor;
                   // comp1.Text.TextFields = elem.Text[0];
                   // comp1.Text.Font = elem.Font[0];
                   comp1.Location = elem.Location;
                   //comp1.TextRect = elem.TextRectangles[0];
                   return comp1;
               case "RectangleTwoFields":
                   var comp2 = new RectangleTwoFields();
                   comp2.Head = new RectangleField(elem.Rectangles[0], elem.TextRectangles[0]);
                   comp2.Head.Text.TextFields = elem.Text[0];
                   comp2.Head.Text.Font = elem.Font[0];
                   comp2.FieldProp = new RectangleField(elem.Rectangles[1], elem.TextRectangles[1]);
                   comp2.FieldProp.Text.TextFieldsProp = elem.Text[1];
                   comp2.FieldProp.Text.Font = elem.Font[1];
                   comp2.FieldMethods = new RectangleField(elem.Rectangles[2], elem.TextRectangles[2]);
                   comp2.FieldMethods.Text.TextFieldsMethod = elem.Text[2];
                   comp2.FieldMethods.Text.Font = elem.Font[2];
                   comp2.Path = elem.SerializablePath.Value;
                   comp2.Color = elem.Color;
                   comp2.PenWidth = elem._penWidth;
                   comp2.PenColor = elem._penColor;
                   comp2.Text.TextFields = elem.Text[0];
                   comp2.Text.Font = elem.Font[0];
                   comp2.Location = elem.Location;
                   //comp2.TextRect = elem.TextRectangles[0];
                   return comp2;
               case "EndLineMarker":
                   return new SimpleRectangle()
                   {
                       Path = elem.SerializablePath.Value,
                       Color = elem.Color,
                       PenWidth = elem._penWidth,
                       PenColor = elem._penColor,
                       Location = elem.Location
                   };
               case "Arrows":
                   return new Arrows.Arrows((Arrows.ArrowsTypes) elem.ArrowType)
                   {
                       Path = elem.SerializablePath.Value,
                       PenWidth = elem._penWidth,
                       PenColor = elem._penColor,
                       LedgePositionX = elem.LedgePositionX,
                       TypesType = (Arrows.ArrowsTypes)elem.ArrowType,
                       From = FromLiveData(elem.From),
                       To = FromLiveData(elem.To)
                   };
               default: return null;
            }
        }
        
        public static LiveDataElem ToLiveData(this Component component)
        {
            var elem = new LiveDataElem();
            if (component is RectangleComponent)
            {
                var comp = component as RectangleComponent;
                elem.CompName = "RectangleComponent";
                elem.SerializablePath.Value = comp.Path;
                elem.Color = comp.Color;
                elem.Bounds = comp.Bounds;
                elem.TextBounds[0] = comp.TextBounds;
                elem._penWidth = comp.PenWidth;
                elem._penColor = comp.PenColor;
                elem.Text[0] = comp.Text.TextFields;
                elem.Font[0] = comp.Text.Font;
                elem.Location = comp.Location;
                elem.TextRectangles[0] = comp.textRect;
                return elem;
            }
        
            if (component is RectangleOneField)
            {
                var comp1 = component as RectangleOneField;
                elem.CompName = "RectangleOneField";
                elem.Rectangles[0] = comp1.Head.Rect;
                elem.Rectangles[1] = comp1.FieldRectangle.Rect;
                elem.TextRectangles[0] = comp1.Head.TextRect;
                elem.Rectangles[1] = comp1.FieldRectangle.TextRect;
                elem.Text[0] = comp1.Head.Text.TextFields;
                elem.Text[1] = comp1.FieldRectangle.Text.TextFieldsProp;
                elem.Font[0] = comp1.Head.Text.Font;
                elem.Font[1] = comp1.FieldRectangle.Text.Font;
                elem.SerializablePath.Value = comp1.Path;
                elem.Bounds = comp1.Bounds;
                elem.TextBounds[0] = comp1.Head.TextBounds;
                elem.TextBounds[1] = comp1.FieldRectangle.TextBounds;
                elem.Color = comp1.Color;
                elem._penWidth = comp1.PenWidth;
                elem._penColor = comp1.PenColor;
                elem.Location = comp1.Location;
                elem.TextRectangles[0] = comp1.Head.TextRect;
                elem.TextRectangles[1] = comp1.FieldRectangle.TextRect;
                return elem;
            }

            if (component is EndLineMarker)
            {
                var comp = component as EndLineMarker;
                elem.CompName = "EndLineMarker";
                elem.SerializablePath.Value = comp.Path;
                elem.Color = comp.Color;
                elem._penWidth = comp.PenWidth;
                elem._penColor = comp.PenColor;
                elem.Location = comp.Location;
                return elem;
            }
            if (component is RectangleTwoFields)
            {
                var comp1 = component as RectangleTwoFields;
                elem.CompName = "RectangleTwoFields";
                elem.Rectangles[0] = comp1.Head.Rect;
                elem.Rectangles[1] = comp1.FieldProp.Rect;
                elem.TextRectangles[0] = comp1.Head.TextRect;
                elem.Rectangles[1] = comp1.FieldProp.TextRect;
                elem.Text[0] = comp1.Head.Text.TextFields;
                elem.Text[1] = comp1.FieldProp.Text.TextFieldsProp;
                elem.Text[2] = comp1.FieldMethods.Text.TextFieldsMethod;
                elem.Font[0] = comp1.Head.Text.Font;
                elem.Font[1] = comp1.FieldProp.Text.Font;
                elem.Font[2] = comp1.FieldMethods.Text.Font;
                elem.SerializablePath.Value = comp1.Path;
                elem.Bounds = comp1.Bounds;
                elem.TextBounds[0] = comp1.Head.TextBounds;
                elem.TextBounds[1] = comp1.FieldProp.TextBounds;
                elem.TextBounds[2] = comp1.FieldMethods.TextBounds;
                elem.Color = comp1.Color;
                elem._penWidth = comp1.PenWidth;
                elem._penColor = comp1.PenColor;
                elem.Location = comp1.Location;
                elem.TextRectangles[0] = comp1.Head.TextRect;
                elem.TextRectangles[1] = comp1.FieldProp.TextRect;
                elem.TextRectangles[2] = comp1.FieldMethods.TextRect;
                return elem;
            }
        
            if (component is Arrows.Arrows)
            {
                var comp = component as Arrows.Arrows;
                elem.CompName = "Arrows";
                elem.SerializablePath.Value = comp.Path;
                elem.LedgePositionX = comp.LedgePositionX;
                elem._penWidth = comp.PenWidth;
                elem._penColor = comp.PenColor;
                elem.ArrowType = (UML_Database_Library.BlackBox.Arrows) comp.TypesType;
                elem.From = ToLiveData(comp.From);
                elem.To = ToLiveData(comp.To);
                return elem;
            }
            return null;
        }
    }
}