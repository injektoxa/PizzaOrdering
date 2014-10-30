using System.ComponentModel.DataAnnotations;

namespace Pizza.Model
{
    /// <summary>
    /// Email validation
    /// http://weblogs.asp.net/scottgu/archive/2010/01/15/asp-net-mvc-2-model-validation.aspx
    /// http://dotnet.dzone.com/news/building-aspnet-validator?utm_source=feedburner&utm_medium=feed&utm_campaign=Feed%3A+zones%2Fcss+%28CSS+Zone%29
    /// </summary>
    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute()
            : base(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        {
            ErrorMessage = "Your email doesn't seem to be correct";
        }
    }
}