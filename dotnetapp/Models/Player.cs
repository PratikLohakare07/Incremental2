// Models/Player.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace dotnetapp.Models
{
    public class Player
    {
        [Key]
        
        public int Id{get;set;}


        [Required(ErrorMessage="Name is required.")]
        public string Name{get;set;}

        public string Category{get;set;}

        [ForeignKey("Group")]
        
        public int TeamId{get;set;}
       
       [Range(1,int.MaxValue,ErrorMessage="Bidding amount must be greater than 0.")]
        public decimal BiddingAmount{get;set;}

        public Team Teams{get;set;}


    }
}
