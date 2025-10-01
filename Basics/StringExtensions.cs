using System.Text;

public static class StringExtensions
{
    private static StringBuilder _sb = new();

    public static string FormatThousands(this string s, char separator = ',')
    {
        _sb.Clear();
        for(int i = 0; i < s.Length; i++)
        {
            if(i > 0 && i % 3 == 0)
            {
                _sb.Insert(0, ',');
            }
            _sb.Insert(0, s[s.Length - i - 1]);
        }
        return _sb.ToString();
    }

    public static string FormatThousands(this int i, char separator = ',') => i.ToString().FormatThousands();
    public static string FormatThousands(this long i, char separator = ',') => i.ToString().FormatThousands();
}
