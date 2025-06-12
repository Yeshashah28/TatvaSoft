namespace MissionBackend.Dto
{
    public class DropDownResponseDto
    {
        public int Value { get; set; }

        public string Text { get; set; }

        public DropDownResponseDto(int value, string text)
        {
            Value = value;
            Text = text;
        }
    }
}
