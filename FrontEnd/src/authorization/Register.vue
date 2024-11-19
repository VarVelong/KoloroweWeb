<template>
    <div>
      <h2>Register</h2>
      <form @submit.prevent="register">
        <div>
          <label for="username">Username:</label>
          <input type="text" v-model="username" id="username" />
        </div>
        <div>
          <label for="password">Password:</label>
          <input type="password" v-model="password" id="password" />
        </div>
        <button type="submit">Register</button>
      </form>
      <p v-if="message">{{ message }}</p>
      <p v-if="errorMessage">{{ errorMessage }}</p>
    </div>
  </template>
  
  <script>
  import AuthService from '../authorization/AuthService.js';
  
  export default {
    data() {
      return {
        username: '',
        password: '',
        message: '',
        errorMessage: ''
      };
    },
    methods: {
      async register() {
        try {
          await AuthService.register({
            username: this.username,
            password: this.password
          });
          this.message = 'Registration successful! Please login.';
        } catch (error) {
          this.errorMessage = 'Registration failed. Please try again.';
        }
      }
    }
  };
  </script>
  