using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MenuManagementMVC.Models.UserDefined
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [DisplayName("Recipe Name")]
        public string RecipeName { get; set; }

        [DisplayName("Recipe Description")]
        public string RecipeDescription { get; set; }

        [DisplayName("Recipe Serves")]
        public int RecipeServes { get; set; }

        [DisplayName("Recipe Method")]
        public string RecipeMethod { get; set; }

        [DisplayName("Recipe Image")]
        public string RecipeImageURL { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public DateTime? LastUpdatedDate { get; set; }
        public string RecordStatus { get; set; }
    }
}