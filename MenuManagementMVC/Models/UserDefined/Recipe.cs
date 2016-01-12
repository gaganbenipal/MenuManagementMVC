using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MenuManagementMVC.Models.UserDefined
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int RecipeServes { get; set; }
        public string RecipeMethod { get; set; }
        public string RecipeImageURL { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public DateTime? LastUpdatedDate { get; set; }
        public string RecordStatus { get; set; }
    }
}