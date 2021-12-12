using System;
using System.Drawing;
using NUnit.Framework;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.StructuralEntities;
using Arrows = UML_Logic_Library.Arrows;

namespace TestProject.LogicalTest.Mocks
{
    [Ignore("Mock")]
    public class ComponentMapperMock
    {
        public static object[] FromLiveData = new object[]
        {
            new object[]
            {
                new LiveDataElem()
                {
                    CompName = "RectangleTwoFields",
                    Rectangles = new RectangleF[3]
                    {
                        new Rectangle(0, 0, 160, 80),
                        new Rectangle(0, 80, 160, 80),
                        new Rectangle(0, 160, 160, 80)
                    },
                    Text = new string[3] {"Object", "+ Property : Type", "+ Method(Type) : Type"},
                    Font = new Font[3]
                    {
                        SystemFonts.DefaultFont,
                        SystemFonts.DefaultFont,
                        SystemFonts.DefaultFont
                    },
                    Color = Color.Chocolate,
                    PenWidth = 1,
                    PenColor = Color.Black,
                    Location = new PointF(30, 30),
                    TextRectangles = new RectangleF[3]
                    {
                        new Rectangle(3, 2, 154, 76),
                        new Rectangle(3, 82, 154, 76),
                        new Rectangle(3, 162, 154, 76)
                    }
                },
                new RectangleTwoFields()
                {
                    Location = new PointF(30, 30),
                    Color = Color.Chocolate
                }
            },
            new object[]
            {
                new LiveDataElem()
                {
                    CompName = "RectangleOneField",
                    Rectangles = new RectangleF[3]
                    {
                        new Rectangle(0, 0, 160, 80),
                        new Rectangle(0, 80, 160, 80),
                        new Rectangle()
                    },
                    Text = new string[3] {"Object", "+ Property : Type", ""},
                    Font = new Font[3]
                    {
                        SystemFonts.DefaultFont,
                        SystemFonts.DefaultFont,
                        null
                    },
                    Color = Color.Black,
                    PenWidth = 1,
                    PenColor = Color.Black,
                    Location = new PointF(30, 30),
                    TextRectangles = new RectangleF[3]
                    {
                        new Rectangle(3, 2, 154, 76),
                        new Rectangle(3, 82, 154, 76),
                        new RectangleF()
                    }
                },
                new RectangleOneField()
                {
                    Location = new PointF(30, 30),
                    Color = Color.Black
                }
            },
            new object[]
            {
                new LiveDataElem()
                {
                    CompName = "RectangleComponent",
                    Rectangles = new RectangleF[3]
                    {
                        new Rectangle(0, 0, 160, 80),
                        new Rectangle(),
                        new Rectangle()
                    },
                    Text = new string[3] {"Object", "", ""},
                    Font = new Font[3]
                    {
                        SystemFonts.DefaultFont,
                        null,
                        null
                    },
                    Color = Color.Wheat,
                    PenWidth = 1,
                    PenColor = Color.Black,
                    Location = new PointF(30, 30),
                    TextRectangles = new RectangleF[3]
                    {
                        new Rectangle(3, 2, 154, 76),
                        new Rectangle(),
                        new RectangleF()
                    }
                },
                new RectangleComponent()
                {
                    Location = new PointF(30, 30),
                    Color = Color.Wheat
                }
            },
            new object[]
            {
                new LiveDataElem()
                {
                    CompName = "Arrows",
                    LedgePositionX = -1,
                    Text = new string[3] {"Object", "", ""},
                    ArrowType = UML_Database_Library.BlackBox.Arrows.CompositionArrow,
                    PenWidth = 1,
                    PenColor = Color.Black,
                    From = new LiveDataElem(),
                    To = new LiveDataElem()
                },
                new UML_Logic_Library.Arrows.Arrows(ArrowsTypes.CompositionArrow)
                {
                }
            }
        };

        public static bool EqualComponents(Component element, Component component)
        {
            if (element is Arrows.Arrows)
            {
                var elem = (Arrows.Arrows) element;
                var comp = (Arrows.Arrows) component;
                if (
                    elem.Path.GetBounds().Equals(comp.Path.GetBounds())
                    && elem.TypesType == comp.TypesType
                    && elem.PenColor == comp.PenColor
                    && elem.PenWidth == comp.PenWidth
                    && elem.From == null && comp.From == null
                    && elem.To == null && comp.To == null
                )
                    return true;
            }
            
            if (element is RectangleComponent)
            {
                var elem = (RectangleComponent) element;
                var comp = (RectangleComponent) component;
                if (
                    elem.Path.GetBounds().Equals(comp.Path.GetBounds())
                    && elem.Color == comp.Color
                    && elem.Text.Font.Equals(comp.Text.Font)
                    && elem.Text.TextFields == comp.Text.TextFields
                    && elem.TextRect == comp.TextRect
                    && elem.Location == comp.Location
                )
                    return true;
            }

            if (element is RectangleOneField)
            {
                var elem = (RectangleOneField) element;
                var comp = (RectangleOneField) component;
                if (
                    elem.Path.GetBounds().Equals(comp.Path.GetBounds())
                    && elem.Color == comp.Color
                    && elem.Head.Text.Font.Equals(comp.Head.Text.Font)
                    && elem.FieldProp.Text.Font.Equals(comp.FieldProp.Text.Font)
                    && elem.Head.Text.TextFields == comp.Head.Text.TextFields
                    && elem.FieldProp.Text.TextFieldsProp == comp.FieldProp.Text.TextFieldsProp
                    && elem.Head.Rect == comp.Head.Rect
                    && elem.FieldProp.Rect == comp.FieldProp.Rect
                    && elem.Location == comp.Location
                )
                    return true;
            }

            if (element is RectangleTwoFields)
            {
                var elem2 = (RectangleTwoFields) element;
                var comp2 = (RectangleTwoFields) component;
                if (
                    elem2.Path.GetBounds().Equals(comp2.Path.GetBounds())
                    && elem2.Color == comp2.Color
                    && elem2.Head.Text.Font.Equals(comp2.Head.Text.Font)
                    && elem2.FieldProp.Text.Font.Equals(comp2.FieldProp.Text.Font)
                    && elem2.FieldMethods.Text.Font.Equals(comp2.FieldMethods.Text.Font)
                    && elem2.Head.Text.TextFields == comp2.Head.Text.TextFields
                    && elem2.FieldProp.Text.TextFieldsProp == comp2.FieldProp.Text.TextFieldsProp
                    && elem2.FieldMethods.Text.TextFieldsMethod == comp2.FieldMethods.Text.TextFieldsMethod
                    && elem2.Head.Rect == comp2.Head.Rect
                    && elem2.FieldProp.Rect == comp2.FieldProp.Rect
                    && elem2.FieldMethods.Rect == comp2.FieldMethods.Rect
                    && elem2.Location == comp2.Location
                )
                    return true;
            }

            return false;
        }
        
        public static bool EqualLiveData(LiveDataElem element, LiveDataElem component)
        {
            if (element.CompName == "Arrows")
            {
                if (
                    element.CompName == component.CompName
                    && element.ArrowType == component.ArrowType
                    && element.PenColor == component.PenColor
                    && Math.Abs(element.PenWidth - component.PenWidth) == 0
                )
                    return true;
            }
            
            if (element.CompName == "RectangleComponent")
            {
                if (
                    element.Color == component.Color
                    && element.Font[0].Equals(component.Font[0])
                    && element.Text[0] == component.Text[0]
                    && element.TextRectangles[0] == component.TextRectangles[0]
                    && element.Location == component.Location
                )
                    return true;
            }

            if (element.CompName == "RectangleOneField")
            {
                if (
                    element.Color == component.Color
                    && element.Font[0].Equals(component.Font[0])
                    && element.Font[1].Equals(component.Font[1])
                    && element.Text[0] == component.Text[0]
                    && element.Text[1] == component.Text[1]
                    && element.TextRectangles[0] == component.TextRectangles[0]
                    && element.TextRectangles[1] == component.TextRectangles[1]
                    && element.Location == component.Location
                )
                    return true;
            }

            if (element.CompName == "RectangleTwoFields")
            {
                if (
                    element.Color == component.Color
                    && element.Font[0].Equals(component.Font[0])
                    && element.Font[1].Equals(component.Font[1])
                    && element.Font[2].Equals(component.Font[2])
                    && element.Text[0] == component.Text[0]
                    && element.Text[1] == component.Text[1]
                    && element.Text[2] == component.Text[2]
                    && element.TextRectangles[0] == component.TextRectangles[0]
                    && element.TextRectangles[1] == component.TextRectangles[1]
                    && element.TextRectangles[2] == component.TextRectangles[2]
                    && element.Location == component.Location
                )
                    return true;
            }

            return false;
        }

    }
}