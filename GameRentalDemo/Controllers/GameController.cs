using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalDemo.Data;
using GameRentalDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalDemo.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GameController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {

            var games = applicationDbContext.GameModel;

            return View(games);

        }


        public IActionResult ListGames()
        {
            var games = new List<GameModel>
            {
                new GameModel
                {
                    Genre = Genre.Action,
                    Name = "Viewtiful Joe",
                    InStockCount = 5,
                },
                new GameModel
                {
                    Genre = Genre.Action | Genre.SurvivalHorror,
                    Name = "Bioshock",
                    InStockCount = 5,
                }
            };

            return View(games);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            return View(applicationDbContext.GameModel.Find(id));
        }


        public IActionResult Delete(int id)
        {
            var entity = applicationDbContext.GameModel.Find(id); ;
            if (entity != null)
            {
                applicationDbContext.GameModel.Remove(entity);
                applicationDbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Save(GameModel model)
        {
            CreateOrUpdateModel(model);
            return RedirectToAction("Index");
        }

        private void CreateOrUpdateModel(GameModel model)
        {
            var dbModel = applicationDbContext.Find<GameModel>(model.Id);
            if (dbModel != null && dbModel.Id != 0)
            {
                dbModel.Genre = model.Genre;
                dbModel.Name = model.Name;
                dbModel.InStockCount = model.InStockCount;
            }
            else
            {
                applicationDbContext.Add(model);
            }

            applicationDbContext.SaveChanges();
        }
    }
}