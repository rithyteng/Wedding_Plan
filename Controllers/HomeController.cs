using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weddingplan.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace weddingplan.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("ID") !=null){
                ViewBag.Home = true;
                ViewBag.Id = HttpContext.Session.GetInt32("ID");
            }
            return View();
        }
        [HttpPost("/thewedding")]
        public IActionResult Wedding(Wedding mywedding){
            if(ModelState.IsValid){
                ViewBag.Id = HttpContext.Session.GetInt32("ID");
                mywedding.UserId = ViewBag.Id;
                dbContext.Add(mywedding);
                dbContext.SaveChanges();
                var stuff = dbContext.Weddings.FirstOrDefault(x=> x.W1 == mywedding.W1);
                var stuff2 = dbContext.Weddings.FirstOrDefault(x => x.W2 == mywedding.W2);
                if(stuff == stuff2){
                    HttpContext.Session.SetInt32("WID",stuff.WeddingId);
                    return RedirectToAction("WeddingDetail",new{id = stuff.WeddingId});
                }
                else{
                    //Error Code Here!
                    return View("MyWedding");
                }
                
            }
            else{
                return View("MyWedding");
            }
        }
        // [HttpGet("/weddingz")]
        // public IActionResult WeddingDetail(){
        //     int ? weddingId = HttpContext.Session.GetInt32("WID");
        //     Wedding stuff = dbContext.Weddings.FirstOrDefault(x=>x.WeddingId == weddingId);
        //     return View("WeddingDetail",stuff);
        // }
        [HttpGet("/delete/{id}")]
        public IActionResult Delete(int id){
            //id is WeddingId
            Wedding dodgebullet = dbContext.Weddings.FirstOrDefault(x=>x.WeddingId == id);
            dbContext.Remove(dodgebullet);
            dbContext.SaveChanges();
            int? myid = HttpContext.Session.GetInt32("ID");
            return RedirectToAction("Dashboard",new{id = myid });
        }
        [HttpGet("/addwedding/{id}")]
    
        public IActionResult AddWedding(int id){
            if(HttpContext.Session.GetInt32("ID") != id){
                return View("Index");
            }
            ViewBag.Id = HttpContext.Session.GetInt32("ID");
            
            return View("MyWedding");
        }
        [HttpPost("/Register")]
        public IActionResult Register(User adduser){
            if(ModelState.IsValid){
                if(dbContext.Users.Any(u => u.Email == adduser.Email))
        {
            // Manually add a ModelState error to the Email field, with provided
            // error message
            ModelState.AddModelError("Email", "Email already in use!");
            return View("Index");
            
            // You may consider returning to the View at this point
        }
         // Initializing a PasswordHasher object, providing our User class as its
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                adduser.Password = Hasher.HashPassword(adduser, adduser.Password);
                //Save your user object to the database
                dbContext.Add(adduser);
                dbContext.SaveChanges();

                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == adduser.Email);
                HttpContext.Session.SetInt32("ID",userInDb.UserId);
                return RedirectToAction("Dashboard",new{id = userInDb.UserId});
                
            }
            return View("Index");
        }
        [HttpPost("LogIn")]
        public IActionResult LogIn(Login thisuser){
        if(ModelState.IsValid)
        {
            // If inital ModelState is valid, query for a user with provided email
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == thisuser.Email);
            // If no user exists with provided email
            if(userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Index");
            }
            
            // Initialize hasher object
            var hasher = new PasswordHasher<Login>();
            
            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(thisuser, userInDb.Password, thisuser.Password);
            
            // result can be compared to 0 for failure
            if(result == 0)
            {
                ModelState.AddModelError("Password","Invalid Email/Passwordz");
                return View("Index");
                // handle failure (this should be similar to how "existing email" is handled)
            }
            else{
                HttpContext.Session.SetInt32("ID",userInDb.UserId);
                return RedirectToAction("Dashboard",new{id = userInDb.UserId});
            }
        }
        return View("Index");
        }
        [HttpGet("Dashboard/{id}")]
        public IActionResult Dashboard(int id){
        int? myid = HttpContext.Session.GetInt32("ID");
            if( myid != id ){
                return View("Index");
            }
            ViewBag.Id = myid;
            //Show All Weddings
            // List <Wedding> mystuff = dbContext.Weddings.Where(x => x.WeddingId !=0).ToList();
            List <Wedding> mystuff = dbContext.Weddings.Include(x => x.Guests).ThenInclude(p => p.MyUser).ToList();
    
            ViewBag.theId = id;
            // List<Response> abc = dbContext.Responses.Where(x=> x.UserId == id).ToList();

            // List<int> stuff = new List<int>();
            // foreach(var i in abc){
            //     if(i.UserId == id){
            //         stuff.Add(i.WeddingId);
            //     }
            // }
            // for(var i =0; i <stuff.Count;i ++){
            //     stuff.RemoveAt(i);
            // }
            
            
            return View("Dashboard",mystuff);
        }
        [HttpGet("unrsvp/{id}")]
        public IActionResult UNRSVP(int id){
            //id is Wedding Id
            int? myid = HttpContext.Session.GetInt32("ID");
            Response myresponse = dbContext.Responses.FirstOrDefault(x => x.WeddingId == id && x.UserId ==myid);
            dbContext.Remove(myresponse);
            dbContext.SaveChanges();

            return RedirectToAction("Dashboard",new{id = myid});
        }
        [HttpGet("rsvp/{id}")]
        public IActionResult RSVP(int id){
            // the id is the WeddingId
            int? myid = HttpContext.Session.GetInt32("ID");
            ViewBag.myidzz = myid;
            var myguy = dbContext.Users.FirstOrDefault(x => x.UserId ==myid);
            string myname = myguy.FirstName + " " +myguy.LastName;
            var theguy = dbContext.Weddings.FirstOrDefault(x => x.WeddingId ==id);
            int Userid = theguy.UserId;
            Response myresponse = new Response();
            myresponse.Guests = myname;
            myresponse.UserId = ViewBag.myidzz;
            myresponse.WeddingId = id;
            dbContext.Add(myresponse);
            dbContext.SaveChanges();

            return RedirectToAction("Dashboard",new{id = myid});
        }
        [HttpGet("logout")]
        public IActionResult LogOut(){
            HttpContext.Session.Clear();
            return View("Index");
        }
        [HttpGet("weddingdetail/{id}")]
        public IActionResult WeddingDetail(int id){
            ViewBag.Id = HttpContext.Session.GetInt32("ID");
            // List <Wedding> mystuff = dbContext.Weddings.Include(x => x.Guests).ThenInclude(p => p.MyUser).ToList();

            Wedding stuff = dbContext.Weddings.Include(x => x.Guests).FirstOrDefault(x=> x.WeddingId==id);
        return View("WeddingDetail",stuff);
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
