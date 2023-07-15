﻿using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class PublisherController : Controller
{
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {
        this._service = service;
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Publisher model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = _service.Add(model);
        if (result)
        {
            TempData["msg"] = "Added successfully";
            return RedirectToAction(nameof(Add));
        }

        TempData["msg"] = "Unexpected error happened on the serverside";
        return View(model);
    }

    public IActionResult Update(int id)
    {
        var record = _service.FindById(id);
        return View(record);
    }

    [HttpPost]
    public IActionResult Update(Publisher model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = _service.Update(model);
        if (result)
        {
            return RedirectToAction("GetAll");
        }

        TempData["msg"] = "Unexpected error happened on the serverside";
        return View(model);
    }

    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        return RedirectToAction("GetAll");
    }

    public IActionResult GetAll()
    {
        var data = _service.GetAll();
        return View(data);
    }
}