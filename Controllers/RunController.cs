using Microsoft.AspNetCore.Mvc;
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
        var runs = _repo.GetRuns();
        return View(runs);
    }

    public IActionResult ViewRun(int id)
    {
        var run = _repo.GetRun(id);
        return View(run);
    }

    public IActionResult UpdateRun(int id)
    {
        Run runToUpdate = _repo.GetRun(id);
        if (runToUpdate == null) { return View("RunNotFound"); }

        return View(runToUpdate);
    }

    public IActionResult UpdateRunToDatabase(Run run)
    {
        _repo.UpdateRun(run);
        return RedirectToAction("ViewRun", new { id = run.ID });
    }

    public IActionResult LogRun()
    {
        var loggedRun = _repo.AssignRunType();
        return View(loggedRun);
    }

    public IActionResult LogRunToDatabase(Run runToLog)
    {
        _repo.LogRun(runToLog);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteRun(Run run)
    {
        _repo.DeleteRun(run);
        return RedirectToAction("Index");
    }


}