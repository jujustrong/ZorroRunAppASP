using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Dapper;
using MySql.Data.MySqlClient;
using ZorroASP.Models;
using ZorroASP.data;

namespace ZorroASP.Controllers;

public class RunController : Controller
{
    private readonly IRunRepo _repo;

    public RunController(IRunRepo repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        var runs = _repo.GetAllRuns();
        return View(runs);
    }

    public IActionResult ViewRun(int id)
    {
        var run = _repo.GetRun(id);
        if (run == null)
        {
            return View("Error");
        }
        return View(run);
    }
    
    public IActionResult LogRun()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult LogRun(Run run)
    {
        _repo.LogRun(run); 
        return RedirectToAction("Index");
    }
    
    public IActionResult UpdateRun(int id)
    {
        Run run = _repo.GetRun(id);
        if (run == null)
        {
            return View("RunNotFound");
        }
        return View(run);
    }
    
    [HttpPost]
    public IActionResult UpdateRun(Run run)
    {
        _repo.UpdateRun(run);
        return RedirectToAction("ViewRun", new { id = run.Id});

        return View(run);
    }

    public IActionResult DeleteRun(int id)
    {
        _repo.DeleteRun(id);
        return RedirectToAction("Index");
    }


}