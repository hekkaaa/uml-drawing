using System;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    public static class ComponentFactory
    {
        public static SimpleRectangle CreateSingleBlock(BlockRequest block) =>
            new SimpleRectangle
            {
                ItemId = block.ItemId,
                //Color = block.Color,
                PenColor = block.PenColor,
                PenWidth = block.PenWidth,
                //Text = block.Text,
                Location = block.Location,
                Size = block.Size
            };
        
        //public static SimpleRectangle CreateSingleBlock(LiveDataElem liveDataElem) =>
        //    new SimpleRectangle
        //    {
        //        ItemId = liveDataElem.ItemId,
        //        Color = liveDataElem.Color,
        //        PenColor = liveDataElem.PenColor,
        //        PenWidth = liveDataElem.PenWidth,
        //        TextField = liveDataElem.TextField,
        //        Location = liveDataElem.Location,
        //        Size = liveDataElem.Size
        //    };
        
    }
}