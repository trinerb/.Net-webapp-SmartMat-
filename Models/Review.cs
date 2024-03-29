﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using smartmat.Data;

namespace smartmat.Models
{
    public class Review
    {
        public Review () {}

        public Review(int recipeId, string userId, int stars, string title, string description)
        {
            RecipeId = recipeId;
            ApplicationUserId = userId;
            Stars = stars;
            Title = title;
            Description = description;
        }

        public int Id { get; set; }
        
        
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

         
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        [Required]
        [Range(1,5)]
        public int Stars { get; set; }
        
        [Required]
        [StringLength(200)]
        [DisplayName("Tittel")]
        public string Title { get; set; }
        
        [Required]
        [StringLength(1000)]
        [DisplayName("Melding")]
        public string Description { get; set; }
        
    }
}