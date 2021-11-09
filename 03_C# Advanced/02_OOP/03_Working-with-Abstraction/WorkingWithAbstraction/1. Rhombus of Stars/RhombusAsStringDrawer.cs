namespace _1._Rhombus_of_Stars
{
    using System.Text;
    public  class RhombusAsStringDrawer
    {
        public string Draw(int countOfStars)
        {
            StringBuilder figure = new StringBuilder();
            this.DrawRhombus(countOfStars, figure);
            return figure.ToString();
        }
        private void DrawRhombus(int stars, StringBuilder figure)
        {
            DrawUperPartOfRhombus(stars, figure);
            DrawDownPartOfRhombus(stars, figure);
        }
        private void DrawUperPartOfRhombus(int stars, StringBuilder figure)
        {
            for (int i = 0; i < stars - 1; i++)
            {
                figure.Append(new string(' ', stars - i - 1));
                for (int star = 0; star < i + 1; star++)
                {
                    figure.Append('*');
                    if (star < i)
                    {
                        figure.Append(' ');
                    }
                }

                figure.AppendLine();
            }
        }
        private void DrawDownPartOfRhombus(int stars, StringBuilder figure)
        {
            for (int i = stars - 1; i >= 0; i--)
            {
                figure.Append(new string(' ', stars - i - 1));
                for (int star = 0; star < i + 1; star++)
                {
                    figure.Append('*');
                    if (star < i)
                    {
                        figure.Append(' ');
                    }
                }

                figure.AppendLine();
            }
        }
    }
}
