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

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes); // .NET 5 +
        }

        public static void Permute(IEnumerable<string> source,List<string> permutations, string currentPath = "")
        {
            if (!source.Any())
            {
                if (permutations == null)
                {
                    permutations = new List<string>();
                }
                permutations.Add(currentPath.Substring(1));
            }
            foreach(var item in source)
            {
                var newPath = currentPath + "|" + item;
                var newSource = source.Where(x => x != item);
                Permute(newSource, permutations, newPath);
            }
        }
    }
}