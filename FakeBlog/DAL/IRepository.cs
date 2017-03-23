using FakeBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBlog.DAL
{
    interface IRepository
    {
        // List of methods to help deliver features
        // My FakeBlog assumes:
        /* 1. The overall Blog has many Posts.
         * 2. The overall Blog has many Authors.
         * 3. A single Post can only be written by one Author
         * 4. No comments, subscribers, etc. are considered.
         */

        //Create
        void AddPost(string postTitle, ApplicationUser postOwner);
        // ApplicationUser is contained in Models.IndentityModels
        // The ApplicationUser in this case is the author/writer of the Post

        //Read
        List<Post> GetPostsFromWriter(string writerId);
        Post GetPost(int postId);

        //Update
        bool EditPost(int postId);

        //Delete
        // Using bool here to confirm whether a delete was successful or not
        bool RemovePost(int postId);
    }
}
