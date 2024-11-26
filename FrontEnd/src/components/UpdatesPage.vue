<template>
    <div id="app">
      <h1>User Posts</h1>
      <div v-if="loading">Loading posts...</div>
      <div v-if="error" class="error">{{ error }}</div>
      <ul v-if="posts.length">
        <li v-for="post in posts" :key="post.id">
          <h2>{{ post.content }}</h2>
          <p>{{ post.date }}</p>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        posts: [], // Holds the posts from the database
        loading: false, // Shows loading state
        error: null, // Captures any errors
      };
    },
    methods: {
      async fetchPosts() {
        this.loading = true; // Start loading
        this.error = null; // Clear any previous errors
        try {
          const response = await fetch("https://localhost:7119/userpost");
          if (!response.ok) {
            throw new Error(`Error: ${response.statusText}`);
          }
          const data = await response.json();
          this.posts = data; // Set the posts data
        } catch (err) {
          this.error = err.message; // Capture any errors
        } finally {
          this.loading = false; // Stop loading
        }
      },
    },
    created() {
      this.fetchPosts(); // Fetch posts when the component is created
    },
  };
  </script>
  
  <style>
  /* Add some basic styling */
  #error {
    color: red;
  }
  ul {
    list-style-type: none;
    padding: 0;
  }
  li {
    border: 1px solid #ddd;
    padding: 15px;
    margin: 10px 0;
    border-radius: 5px;
  }
  </style>