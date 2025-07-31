using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bloggie.Web.Models.ViewModels
{
    public class AddTagRequest
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
