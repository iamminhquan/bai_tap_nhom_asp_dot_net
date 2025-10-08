using Humanizer;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BaiTapNhom02_Lan_02.Models
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int ParentId { get; set; }
        public string? Content { get; set; }
        public string? Email { get; set; }
        public DateTime DateTimes { get; set; }
        public int ProductId { get; set; } // FK to Products
    }
}
