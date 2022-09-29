using Application.Features.AgreementManagement.Query;
using Application.Features.AgreementManagement.Requests;
using Application.Features.Group.Query;
using Application.Features.Product;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers;

[Authorize]
public class AgreementController : BaseController
{
    private readonly IMediator _mediator;
    private readonly ILogger<AgreementController> _logger;
    public AgreementController(IMediator mediator, ILogger<AgreementController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// List all agreement
    /// </summary>
    /// <returns></returns>
    public async  Task<IActionResult> Index()
    {
        try
        {
            var agreement = await _mediator.Send(new GetAllAgreementQuery());
            (List<GetGroupResponse> groups, List<GetProductResponse> products) = await LoadDropdowns();
            (List<AgreementResponse> Agreement, List<GetProductResponse> ProductList, IEnumerable<SelectListItem> Groups
                , IEnumerable<SelectListItem> Products)
                model =
                    (agreement,
                        products,
                        groups.Select(x => new SelectListItem(x.Code, x.Id.ToString())),
                        products.Select(x => new SelectListItem(x.Number, x.Id.ToString()))
                    );
            ViewBag.ProductList = new SelectListItem();
            return View(model);
        }
        catch (Exception e)
        {
            _logger.LogError("Error Occurred {Message}", e.Message);
        }

        return View();
    }


    /// <summary>
    /// Update agreement
    /// </summary>
    /// <param name="agreementRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateAgreementRequest agreementRequest)
    {
        try
        {
            var edit = await _mediator.Send(agreementRequest);
            if (edit.Succeed)
            {
                return Ok();
            }

            return BadRequest(edit.Error);
        }
        catch (Exception e)
        {
            _logger.LogError("Error Occurred {Message}", e.Message);
            return BadRequest();
        }


    }

    /// <summary>
    /// Get Edit agreement
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            if (!Guid.TryParse(id, out var agreeId)) return View();
            var itemToEdit = await _mediator.Send(new GetAgreementById(agreeId));
            (List<GetGroupResponse> groups, List<GetProductResponse> products) = await LoadDropdowns();
            return View((itemToEdit, products,  groups.Select(x => new SelectListItem(x.Code, x.Id.ToString())),
                products.Select(x => new SelectListItem(x.Number, x.Id.ToString())
                )));
        }
        catch (Exception e)
        {
            _logger.LogError("Error Occurred {Message}", e.Message);
        }

        return View();
    }

    /// <summary>
    /// Delete agreement
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var itemToDelete = await _mediator.Send(new DeleteAgreementRequest(id));
        return itemToDelete.Succeeded ? RedirectToAction("Index") : RedirectToAction("Delete", new { id });
    }
    /// <summary>
    /// Get delete view
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        if (!Guid.TryParse(id, out var agreeId)) return View();
        var itemToDelete = await _mediator.Send(new GetAgreementById(agreeId));
        return View(itemToDelete);
    }

    /// <summary>
    /// Create agreement
    /// </summary>
    /// <param name="agreementRequest"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateAgreementRequest agreementRequest)
    {
        try
        {
            agreementRequest.UserId = UserId;
            var saveAgreement = await _mediator.Send(agreementRequest);
            if (saveAgreement.Succeed)
            {
                return Ok("Agreement added successfully");
            }

            return BadRequest(saveAgreement.Errors);
        }
        catch (Exception e)
        {
            _logger.LogError("Error Occurred {Message}", e.Message);
            return BadRequest(new[] { "Unexpected Error" });
        }
        
    }

    #region Helper
    private async Task<(List<GetGroupResponse> Groups, List<GetProductResponse> Products)> LoadDropdowns()
    {
        var groups = await _mediator.Send(new GetAllGroupQuery());
        var products = await _mediator.Send(new GetAllProductQuery());
        return (groups, products);
    }
    

    #endregion
}