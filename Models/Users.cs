    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;


namespace weddingplan.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage="Please Input Your First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="Please Input Your Last Name")]
        public string LastName{get;set;}

        [Required(ErrorMessage="Please Input Your Email")]
        [EmailAddress]
        public string Email{get;set;}

        [Required(ErrorMessage="Please Input Your Password")]
        [DataType(DataType.Password)]
        public string Password{get;set;}

        [NotMapped]
        [Required(ErrorMessage="Please Input Confirmation Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public List<Response> Responses {get;set;}

        public string WeddingId {get;set;}


    }
    
    public class Wedding{
        [Key]
        public int WeddingId{get;set;}

        [Required(ErrorMessage="Please Input Your W1")]
        public string W1{get;set;}

        [Required(ErrorMessage="Please Input Your W2")]
        public string W2{get;set;}

        [Required(ErrorMessage="Please Input Your Date")]
        [DisplayFormat(DataFormatString = "{yyyyMMdd}")]
        [DataType(DataType.Date)]
        public DateTime Date{get;set;}

        [Required(ErrorMessage="Please Input Your Address")]
        public string WeddingAddress {get;set;}
        public List<Response> Guests {get;set;}

        public int UserId {get;set;}
    }
    public class Response{
    [Key]
    public int ResponseId {get;set;}
    
    public String Guests{get;set;}

    public Wedding MyWedding{get;set;}

    public User MyUser{get;set;}
    
    public int WeddingId{get;set;}
    public int UserId {get;set;}

    }
    public class Login{

        public string Email {get; set;}

        [DataType(DataType.Password)]
        public string Password { get; set; }

        }
}
