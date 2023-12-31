﻿using Esourcing.UI.Clients;
using Esourcing.UI.ViewModel;
using ESourcing.Core.Repositories;
using ESourcing.Core.ResultModels;
using Microsoft.AspNetCore.Mvc;

namespace Esourcing.UI.Controllers
{

    public class AuctionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ProductClient _productClient;
        private readonly AuctionClient _auctionClient;
        private readonly BidClient _bidClient;
        public AuctionController(IUserRepository userRepository, ProductClient productClient, AuctionClient auctionClient, BidClient bidClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
            _auctionClient = auctionClient;
            _bidClient = bidClient;
        }

        public async Task<IActionResult> Index()
        {
            var auctionList = await _auctionClient.GetAuctions();

            if(auctionList.IsSuccess) return View(auctionList.Data);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var productList = await _productClient.GetProducts();

            if (productList.IsSuccess)
            {
                ViewBag.ProductList = productList.Data;
            }
            else
            {
                ViewBag.ProductList = new List<ProductViewModel>(); // Varsayılan olarak boş bir liste atanabilir veya diğer bir işlem yapılabilir.
            }

            var userList = await _userRepository.GetAllAsync();
            ViewBag.UserList = userList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuctionViewModel auctionViewModel)
        {
            auctionViewModel.Status = default(int);
            auctionViewModel.CreatedAt = DateTime.Now;
            auctionViewModel.IncludedSellers.Add(auctionViewModel.SellerId);
            var createAuction = await _auctionClient.CreateAuction(auctionViewModel);

            if (createAuction.IsSuccess) return RedirectToAction("Index");

            return View(auctionViewModel);
        }

        public async Task<IActionResult> Detail(string id)
        {
            AuctionBidsViewModel model = new AuctionBidsViewModel();

            var auctionResponse = await _auctionClient.GetAuctionById(id);
            var bidsResponse = await _bidClient.GetAllBidsByAuctionId(id);

            model.SellerUserName = HttpContext.User?.Identity.Name;
            model.AuctionId = auctionResponse.Data.Id;
            model.ProductId = auctionResponse.Data.ProductId;
            model.Bids = bidsResponse.Data;
            var isAdmin = HttpContext.Session.GetString("IsAdmin");
            model.IsAdmin = Convert.ToBoolean(isAdmin);
            
            return View(model);
        }

        [HttpPost]
        public async Task<Result<string>> SendBid(BidViewModel model)
        {
            model.CreateAt = DateTime.Now;
            var sendBidResponse = await _bidClient.SendBind(model);

            return sendBidResponse;
        }

        [HttpPost]
        public async Task<Result<string>> CompleteBid(string id)
        {
            var completeBidResponse = await _auctionClient.CompleteBid(id);
            
            return completeBidResponse;
        }
    }
}
