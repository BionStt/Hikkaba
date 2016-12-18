﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hikkaba.Common.Dto;
using Hikkaba.Service;
using Hikkaba.Service.Base;
using Hikkaba.Web.Filters;
using Hikkaba.Web.ViewModels.CategoriesViewModels;
using Hikkaba.Web.ViewModels.HomeViewModels;
using Hikkaba.Web.ViewModels.PostsViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// todo: add posts numeration
// todo: add cross-links to/from posts (>>234234 - convert to "post in this thread" link; otherwise - >>/a/Threads/35345#0000)

namespace Hikkaba.Web.Controllers.Mvc
{
    [TypeFilter(typeof(ExceptionLoggingFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IThreadService _threadService;
        private readonly IPostService _postService;

        public HomeController(
            ILogger<HomeController> logger,
            IMapper mapper,
            ICategoryService categoryService, 
            IThreadService threadService, 
            IPostService postService)
        {
            _logger = logger;
            _mapper = mapper;
            _categoryService = categoryService;
            _threadService = threadService;
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var page = new PageDto();
            var latestPostsDtoList = await _postService
                                        .PagedListAsync(
                                            post => (!post.IsDeleted) && (!post.Thread.Category.IsHidden),
                                            post => post.Created,
                                            true,
                                            page);
            var latestPostDetailsViewModels = _mapper.Map<List<PostDetailsViewModel>>(latestPostsDtoList.CurrentPageItems);
            foreach (var latestPostDetailsViewModel in latestPostDetailsViewModels)
            {
                var threadDto = await _threadService.GetAsync(latestPostDetailsViewModel.ThreadId);
                var categoryDto = await _categoryService.GetAsync(threadDto.CategoryId);
                latestPostDetailsViewModel.ThreadShowThreadLocalUserHash = threadDto.ShowThreadLocalUserHash;
                latestPostDetailsViewModel.CategoryAlias = categoryDto.Alias;
            }
            var categoriesDtoList = await _categoryService.ListAsync(category => !category.IsHidden && !category.IsDeleted, category => category.Alias);
            var categoryViewModels = _mapper.Map<List<CategoryViewModel>>(categoriesDtoList);
            var homeIndexViewModel = new HomeIndexViewModel()
            {
                Categories = categoryViewModels,
                Posts = new BasePagedList<PostDetailsViewModel>()
                {
                    CurrentPage = page,
                    CurrentPageItems = latestPostDetailsViewModels,
                    TotalItemsCount = latestPostsDtoList.TotalItemsCount,
                },
            };
            return View(homeIndexViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}