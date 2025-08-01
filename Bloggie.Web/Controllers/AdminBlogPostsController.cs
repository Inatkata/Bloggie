﻿using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloggie.Web.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public AdminBlogPostsController(ITagRepository tagRepository, IBlogPostRepository blogPostRepository)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagRepository.GetAllAsync();
            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            var blogPost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                Content = addBlogPostRequest.Content,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible
            };
            var selectedTags = new List<Tag>();
            //Map Tags from selected Tags
            foreach (var selectedTagId in addBlogPostRequest.SelectedTags)
            {
                var selectedTAgIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTAgIdAsGuid);
                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }

            // Mapping Tags back to the domain model
            blogPost.Tags = selectedTags;

            await blogPostRepository.AddAsync(blogPost);
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            // Call the Repository
            var blogPosts = await blogPostRepository.GetAllAsync();
            return View(blogPosts);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var blogPost = await blogPostRepository.GetAsync(id);
            var model = new EditBlogPostRequest
            {
                Id = blogPost.Id,
                Heading = blogPost.Heading,
                PageTitle = blogPost.PageTitle,
                Content = blogPost.Content,
                ShortDescription = blogPost.ShortDescription,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                Visible = blogPost.Visible,
                Tags = (await tagRepository.GetAllAsync()).Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                }),
                SelectedTags = blogPost.Tags.Select(t => t.Id.ToString()).ToArray()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBlogPostRequest editBlogPostRequest)
        {
            var blogPost = new BlogPost
            {
                Id = editBlogPostRequest.Id,
                Heading = editBlogPostRequest.Heading,
                PageTitle = editBlogPostRequest.PageTitle,
                Content = editBlogPostRequest.Content,
                ShortDescription = editBlogPostRequest.ShortDescription,
                FeaturedImageUrl = editBlogPostRequest.FeaturedImageUrl,
                UrlHandle = editBlogPostRequest.UrlHandle,
                PublishedDate = editBlogPostRequest.PublishedDate,
                Author = editBlogPostRequest.Author,
                Visible = editBlogPostRequest.Visible
            };
            var selectedTags = new List<Tag>();
            //Map Tags from selected Tags
            foreach (var selectedTag in editBlogPostRequest.SelectedTags)
            {
               
                if (Guid.TryParse(selectedTag, out var tag))
                {
                    var foundTag = await tagRepository.GetAsync(tag);
                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            // Mapping Tags back to the domain model
            blogPost.Tags = selectedTags;
            var updatedBlog = await blogPostRepository.UpdateAsync(blogPost);
            if (updatedBlog != null)
            {
                return RedirectToAction("Edit");
            }
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditBlogPostRequest editBlogPostRequest)
        {
           var deletedBlogPost =  await blogPostRepository.DeleteAsync(editBlogPostRequest.Id);
           if (deletedBlogPost != null)
           {
               return RedirectToAction("List");
           }

           return RedirectToAction("Edit", new {id = editBlogPostRequest.Id});
        }
    }
} 
