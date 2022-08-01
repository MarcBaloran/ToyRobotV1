namespace ToyRobotV1
{
    public class Table : Surface
    {
        public override int Width { get; set; }
        public override int Length { get; set; }

        public Table(int width, int length)
        {
            this.Width = width;
            this.Length = length;
        }

        public override bool IsValidLocation(int east, int north)
        {
            return east >= 0 && east < Width && north >= 0 && north < Length;
        }
    }
}
