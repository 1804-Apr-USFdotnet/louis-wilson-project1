using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Library;
using RestaurantReviews.Library.Models;
using RestaurantReviews.DataAccessLayer;
using RestaurantReviews.DataAccessLayer.Repositories;

namespace RestaurantReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
        IRepository<Restaurant> crud;
        IDbContext restDB;
        

        public RestaurantController()
        {
            restDB = new RestaurantContext();
            crud = new RestaurantCrud<Restaurant>(restDB);
        }

        public RestaurantController(IDbContext fakeDb)
        {
            //fakeDb = new FakeTapasContext();
            //fakeRestDb = new FakeRestaurantContext();
        }

        // GET: Restaurant
        [HttpGet]// default type of Action
        public ActionResult Index()
        {
            var restaurants = crud.Table.ToList();
            return View(restaurants); 

            /* var restaurants = from r in crud.Table.ToList()
                              orderby r.RestaurantName ascending
                              select r;
                              */
            /*
            var restaurants = from r in crud.Table.ToList()
                              orderby r.AvgRating descending
                              select r;
                              */
            /*
            var restaurants = from r in crud.Table.ToList()
                              orderby r.Reviews.Average(review => review.Rating) descending
                              select r;
                              */
            //return View(restaurants);
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {

            return View(crud.GetByID(id));
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                crud.Insert(restaurant);
                //restaurant.AddRestaurant(restaurant);
                // log that it worked
                return RedirectToAction("Index");
            }
            catch
            {
                // log some problem
                return View();
            }
        }

        /*
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            return View(crud.GetByID(id));
        }

        
      


        // POST: Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
 
        public ActionResult Edit(int id, Restaurant newRestaurant)
        {
            try
            {
                var oldRestaurant = crud.Table.ToList().First(x => x.Id == id);
                

                newRestaurant.Id = oldRestaurant.Id;
                crud.Delete(oldRestaurant);
                crud.Insert(newRestaurant);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(newRestaurant);
            }
        }

        //public ActionResult Edit([Bind(Include = "Id,RestaurantName,FoodType,Street1,Street2,City,State,Country,Zipcode,Phone,Created,Modified")] Restaurant newRestaurant)
        //{
        //    try
        //    {
        //        /*
        //        var oldRestaurant = _restaurants.First(x => x.Id == id);

        //        _restaurants.Remove(oldRestaurant);
        //        newRestaurant.Id = oldRestaurant.Id;
        //        _restaurants.Add(newRestaurant);
        //        */

        //        //var restaurantToEdit = (crud.Table.ToList()).First(restaurant => restaurant.Id == id);
        //        //newRestaurant.Id = restaurantToEdit.Id;

        //        /*
        //        newRestaurant = crud.GetByID(id);
        //        ViewData.Model = newRestaurant;
        //        crud.Update(newRestaurant);
        //        */
        //        newRestaurant.AvgRating = 0;
        //        //newRestaurant = crud.GetByID(id);
        //        crud.Update(newRestaurant);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(newRestaurant);
        //    }
        //}

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetByID(id));
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                crud.Delete(crud.GetByID(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
