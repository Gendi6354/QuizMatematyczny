namespace QuizMatematyczny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gra gra1 = new Gra();
            gra1.RozpocznijGre(gra1.PobierzLiczbeRund());
        }
    }
}
