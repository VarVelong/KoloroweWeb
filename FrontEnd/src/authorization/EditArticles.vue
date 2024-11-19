<template>
    <div>
      <h2>Edit Articles</h2>
  
      <form @submit.prevent="createArticle">
        <div>
          <label for="title">Title:</label>
          <input type="text" v-model="newArticle.title" id="title" />
        </div>
        <div>
          <label for="content">Content:</label>
          <textarea v-model="newArticle.content" id="content"></textarea>
        </div>
        <button type="submit">Create Article</button>
      </form>
  
      <h3>Existing Articles</h3>
      <div v-for="article in articles" :key="article.id">
        <h4>{{ article.title }}</h4>
        <p>{{ article.content }}</p>
        <button @click="editArticle(article)">Edit</button>
      </div>

      <div class="upload-section">
        <label for="file-upload" class="upload-icon">📷</label>
        <input type="file" id="file-upload" class="file-input" accept="image/*">
        <span>Select an image to upload</span>
      </div>
  
      <p v-if="errorMessage">{{ errorMessage }}</p>
    </div>
  </template>

<style scoped>

  .upload-section {
    display: flex;
    align-items: center;
    margin-top: 15px;
  }

  .upload-icon {
    font-size: 24px;
    color: #007bff;
    margin-right: 10px;
    cursor: pointer;
  }
        
  .file-input {
    display: none;
  }

</style>

  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        articles: [],
        newArticle: {
          title: '',
          content: ''
        },
        errorMessage: ''
      };
    },
    async created() {
      // Fetch articles when the component is mounted
      try {
        const response = await axios.get('https://localhost:7119/userpost', {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('user')}`
          }
        });
        this.articles = response.data;
      } catch (error) {
        this.errorMessage = 'Failed to fetch articles.';
      }
    },
    methods: {
      async createArticle() {
        try {
          await axios.post(
            'https://localhost:7119/api/articles',
            this.newArticle,
            {
              headers: {
                Authorization: `Bearer ${localStorage.getItem('user')}`
              }
            }
          );
          this.newArticle.title = '';
          this.newArticle.content = '';
          this.fetchArticles(); // Refresh articles after creation
        } catch (error) {
          this.errorMessage = 'Failed to create article.';
        }
      },
      async fetchArticles() {
        try {
          const response = await axios.get('https://localhost:7119/api/articles', {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('user')}`
            }
          });
          this.articles = response.data;
        } catch (error) {
          this.errorMessage = 'Failed to fetch articles.';
        }
      },
      editArticle(article) {
        // Open the article in an editing mode
        this.newArticle.title = article.title;
        this.newArticle.content = article.content;
        // You can add more logic to save changes to the article
      }
    }
  };
  </script>
  
  