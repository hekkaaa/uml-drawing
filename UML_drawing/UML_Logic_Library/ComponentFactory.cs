using System;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    public static class ComponentFactory
    {
        public static SingleBlock CreateSingleBlock(SingleBlockRequest singleBlock) =>
            new SingleBlock
            {
                ItemId = singleBlock.ItemId,
                Color = singleBlock.Color,
                PenColor = singleBlock.PenColor,
                PenWidth = singleBlock.PenWidth,
                Text = singleBlock.Text,
                Location = singleBlock.Location,
                Size = singleBlock.Size
            };
        
        public static SingleBlock CreateSingleBlock(LiveDataElem liveDataElem) =>
            new SingleBlock
            {
                ItemId = liveDataElem.ItemId,
                Color = liveDataElem.Color,
                PenColor = liveDataElem.PenColor,
                PenWidth = liveDataElem.PenWidth,
                Text = liveDataElem.Text,
                Location = liveDataElem.Location,
                Size = liveDataElem.Size
            };
        
    }
}