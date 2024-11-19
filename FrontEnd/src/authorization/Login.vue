<template>
  <div>
    <h2>Login</h2>
    <form @submit.prevent="login">
      <div>
        <label for="username">Username:</label>
        <input type="text" v-model="username" id="username" />
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" v-model="password" id="password" />
      </div>
      <button type="submit">Login</button>
    </form>
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
      errorMessage: ''
    };
  },
  methods: {
    async login() {
      const response = await AuthService.login({
        username: this.username,
        password: this.password
      })
        .then((token) => {
          debugger;
          if (token) {  // Ensure the token is present in the response data
            localStorage.setItem('user', JSON.stringify(token));
            this.$router.push('/postcreation');
          }
          return token;
          debugger;
          //this.$router.push('/postcreation'); // Redirect to edit articles page after login
        })
        .catch((e) => {
          debugger;
          this.errorMessage = 'Invalid credentials. Please try again. ';
        });
    }
  }
};
</script>