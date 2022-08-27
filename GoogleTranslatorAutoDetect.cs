public static HttpClient hclient = new();

public static string LanguageDetector(string input, string inputlanguage = "auto", string outputlanguage = "en")
{
  string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", inputlanguage, outputlanguage, Uri.EscapeUriString(input));
  string args = hclient.GetStringAsync(url).Result;
  var detected = Regex.Match(args, @"],null,(.+?),null,null").Groups[1].Value;
  string result = detected.Replace('"', ' ');
  return result;
 }
