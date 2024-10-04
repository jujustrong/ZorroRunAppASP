using System;
using ZorroASP.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ZorroASP.Controllers;

public class AccountController : Controller
{
    private MySqlConnection _connection;
    
    public AccountController()
    {
        _connection = new MySqlConnection("connection");
    }

    public ActionResult Register()
    {
        return View();
    }
    
    public ActionResult Register(User model)
    {
        if (ModelState.IsValid)
        {
            var command = new MySqlCommand("INSERT INTO Users (Username, Email) VALUES (@Username, @Email)", _connection);
            command.Parameters.AddWithValue("@Username", model.Username);
            command.Parameters.AddWithValue("@Email", model.Email);
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }

        return RedirectToAction("Login");
    }
    
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(User model)
    {
        // Authenticate user
        return RedirectToAction("Dashboard", "Run");
    }





}