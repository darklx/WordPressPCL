﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressPCL.Models;
using WordPressPCL.Utility;

namespace WordPressPCL.Client
{
    /// <summary>
    /// Client class for interaction with Posts endpoint WP REST API
    /// </summary>
    public class Posts : CRUDOperation<Post, PostsQueryBuilder>
    {
        #region Init

        private new const string _methodPath = "posts";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="HttpHelper">reference to HttpHelper class for interaction with HTTP</param>
        /// <param name="defaultPath">path to site, EX. http://demo.com/wp-json/ </param>
        public Posts(ref HttpHelper HttpHelper, string defaultPath,string methodPath="posts") : base(ref HttpHelper, defaultPath, methodPath)
        {   
        }

        #endregion Init

        #region Custom

        /// <summary>
        /// Get sticky posts
        /// </summary>
        /// <param name="embed">includ embed info</param>
        /// <param name="useAuth">Send request with authenication header</param>
        /// <returns>List of posts</returns>
        public async Task<IEnumerable<Post>> GetStickyPosts(bool embed = false, bool useAuth = false)
        {
            // default values
            // int page = 1, int per_page = 10, int offset = 0, Post.OrderBy orderby = Post.OrderBy.date
            return await _httpHelper.GetRequest<IEnumerable<Post>>($"{_defaultPath}{_methodPath}?sticky=true", embed, useAuth).ConfigureAwait(false);
        }

        /// <summary>
        /// Get posts by category
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="embed">includ embed info</param>
        /// <param name="useAuth">Send request with authenication header</param>
        /// <returns>List of posts</returns>
        public async Task<IEnumerable<Post>> GetPostsByCategory(int categoryId, bool embed = false, bool useAuth = false)
        {
            // default values
            // int page = 1, int per_page = 10, int offset = 0, Post.OrderBy orderby = Post.OrderBy.date
            return await _httpHelper.GetRequest<IEnumerable<Post>>($"{_defaultPath}{_methodPath}?categories={categoryId}", embed, useAuth).ConfigureAwait(false);
        }

        /// <summary>
        /// Get posts by tag
        /// </summary>
        /// <param name="tagId">Tag Id</param>
        /// <param name="embed">includ embed info</param>
        /// <param name="useAuth">Send request with authenication header</param>
        /// <returns>List of posts</returns>
        public async Task<IEnumerable<Post>> GetPostsByTag(int tagId, bool embed = false, bool useAuth = false)
        {
            // default values
            // int page = 1, int per_page = 10, int offset = 0, Post.OrderBy orderby = Post.OrderBy.date
            return await _httpHelper.GetRequest<IEnumerable<Post>>($"{_defaultPath}{_methodPath}?tags={tagId}", embed, useAuth).ConfigureAwait(false);
        }

        /// <summary>
        /// Get posts by its author
        /// </summary>
        /// <param name="authorId">Author id</param>
        /// <param name="embed">includ embed info</param>
        /// <param name="useAuth">Send request with authenication header</param>
        /// <returns>List of posts</returns>
        public async Task<IEnumerable<Post>> GetPostsByAuthor(int authorId, bool embed = false, bool useAuth = false)
        {
            // default values
            // int page = 1, int per_page = 10, int offset = 0, Post.OrderBy orderby = Post.OrderBy.date
            return await _httpHelper.GetRequest<IEnumerable<Post>>($"{_defaultPath}{_methodPath}?author={authorId}", embed, useAuth).ConfigureAwait(false);
        }

        /// <summary>
        /// Get posts by search term
        /// </summary>
        /// <param name="searchTerm">Search term</param>
        /// <param name="embed">include embed info</param>
        /// <param name="useAuth">Send request with authenication header</param>
        /// <returns>List of posts</returns>
        public async Task<IEnumerable<Post>> GetPostsBySearch(string searchTerm, bool embed = false, bool useAuth = false)
        {
            // default values
            // int page = 1, int per_page = 10, int offset = 0, Post.OrderBy orderby = Post.OrderBy.date
            return await _httpHelper.GetRequest<IEnumerable<Post>>($"{_defaultPath}{_methodPath}?search={searchTerm}", embed, useAuth).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete post with force deletion
        /// </summary>
        /// <param name="ID">Post id</param>
        /// <param name="force">force deletion</param>
        /// <returns>Result of opertion</returns>
        public async Task<HttpResponseMessage> Delete(int ID, bool force = false)
        {
            return await _httpHelper.DeleteRequest($"{_defaultPath}{_methodPath}/{ID}?force={force.ToString().ToLower()}").ConfigureAwait(false);
        }

        /// <summary>
        /// Get instance ob object to manipulate with post revisions
        /// </summary>
        /// <param name="postId">ID of parent Post</param>
        /// <returns>Post revisions object</returns>
        public PostRevisions Revisions(int postId)
        {
            return new PostRevisions(ref _httpHelper, _defaultPath, postId);
        }

        #endregion Custom
    }
}