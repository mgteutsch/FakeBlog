using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeBlog.Models;

namespace FakeBlog.DAL
{
    public class FakeBlogRepository : IRepository
    {
        public FakeBlogContext Context { get; set; }

        public FakeBlogRepository()
        {
            Context = new FakeBlogContext();
        }

        public FakeBlogRepository(FakeBlogContext context)
        {
            Context = context;
        }

        public void AddPost(string postTitle, ApplicationUser authorName, DateTime datePostedToPublic, string postBodyContent)
        {
            Post blogPost = new Post { Title = postTitle, Author = authorName, PublishedAt = datePostedToPublic, Body = postBodyContent };
            Context.Posts.Add(blogPost);
            Context.SaveChanges(); 
        }

        public bool EditPost(int postId, string newTitle, string newBody)
        {
            Post found_post = GetPost(postId);
            if (found_post != null)
            {
                found_post.Title = newTitle;
                found_post.Body = newBody;
                return true;
            }
            return false;
        }

        public Post GetPost(int postId)
        {
            Post found_post = Context.Posts.FirstOrDefault(b => b.PostId == postId); // returns null if nothing is found
            return found_post;
        }

        public List<Post> GetPostsFromWriter(string writerId)
        {
            return Context.Posts.Where(b => b.Author.Id == writerId).ToList();
        }

        public bool RemovePost(int postId)
        {
            Post found_post = GetPost(postId);
            if (found_post != null)
            {
                Context.Posts.Remove(found_post);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}