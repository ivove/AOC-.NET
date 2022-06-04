namespace AOChelper
{
    public class Helper
    {
        public static string GetFilePath(int day,bool test = false)
        {
            var folder = "Real";
            if (test) { folder = "Test"; }
            var path = $"Inputs/{folder}/Day{day}.txt";
            return path;
        }

        public static string ReadOneLine(int day,bool test = false)
        {
            FileStream fileStream = new(Helper.GetFilePath(day, test), FileMode.Open);
            using StreamReader reader = new(fileStream);
            string line = reader.ReadLine();
            return line;
        }

        public static List<string> ReadMultipleLines(int day,bool test = false)
        {
            List<string> lines = new();
            FileStream fileStream = new(Helper.GetFilePath(day, test), FileMode.Open);
            using StreamReader reader = new(fileStream);
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
            return lines;
        }
    }
}