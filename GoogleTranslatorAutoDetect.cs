public static HttpClient hclient = new();

public static string LanguageDetector(string input)
{
  var inputlanguage = "auto";
  var outputlanguage = "en";
  var url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", inputlanguage, outputlanguage, Uri.EscapeUriString(input));
  var args = hclient.GetStringAsync(url).Result;
  var detected = Regex.Match(args, @"],null,(.+?),null,null").Groups[1].Value;
  var result = detected.Replace('"', ' ');
  return result;
 }
