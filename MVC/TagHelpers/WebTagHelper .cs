using Microsoft.AspNetCore.Razor.TagHelpers;
namespace MVC.TagHelpers


{
    public class WebTagHelper: TagHelper
    {

        public string SitoWeb { get; set; }//= "https://www.google.com/";
        public string Lingua { get; set; } = " ";
        public string NomePulsante { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Content.SetContent($"{NomePulsante}");
            output.Attributes.SetAttribute("class", "btn btn-warning");
            output.Attributes.SetAttribute("href", $"{SitoWeb}{Lingua}");
        }
    }
}

