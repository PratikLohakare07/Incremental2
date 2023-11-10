// Models/Player.cs
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Player
    {
        public int Id{get;set;}


        [Required(Error Message:"Name should not be empty")]
        public string Name{get;set;}

        public string Category{get;set;}
       
       [Range(0,int.MaxValue)]
        public decimal BiddingAmount{get;set;}


    }
}
