using UML_Database_Library.BlackBox;

namespace UML_Logic_Library
{
    public static class ComponentMapper
    {
        public static LiveDataElem ToLiveDataElem(this SingleBlock singleBlock)
        {
            return new LiveDataElem()
            {
                ItemId = singleBlock.ItemId,
                Color = singleBlock.Color,
                PenColor = singleBlock.PenColor,
                PenWidth = singleBlock.PenWidth,
                Text = singleBlock.Text,
                Location = singleBlock.Location,
                Size = singleBlock.Size
            };
        }
    }
}