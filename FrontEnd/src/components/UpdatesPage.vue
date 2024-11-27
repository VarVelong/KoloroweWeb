<template>
    <div id="app">
      <h1>Aktualności</h1>
      <div v-if="loading">Loading posts</div>
      <div v-if="error" class="error">{{ error }}</div>
      <ul v-if="posts.length">
        <li v-for="post in posts" :key="post.id">
          <h2>{{ post.content }}</h2>
          <p>{{ post.date }}</p>
          <button @click="goToPost(post.id)">View Details</button>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        posts: [], 
        loading: false, 
        error: null, 
      };
    },
    methods: {
      async fetchPosts() {
        this.loading = true;
        this.error = null; 
        try {
          const response = await fetch("https://localhost:7119/userpost");
          if (!response.ok) {
            throw new Error(`Error: ${response.statusText}`);
          }
          const data = await response.json();
          this.posts = data; 
        } catch (err) {
          this.error = err.message; 
        } finally {
          this.loading = false; 
        }
      },

      goToPost(id) {
      this.$router.push(`/post/${id}`); 
    },

    },
    created() {
      this.fetchPosts();
    },
  };
  </script>
  
  <style>
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