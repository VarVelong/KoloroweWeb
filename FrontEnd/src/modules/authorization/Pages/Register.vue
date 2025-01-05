<template>
  <div id="middle-block">
    <h2>Rejestracja</h2>
    <form @submit.prevent="register">
      <div>
        <label for="username">Nazwa:</label>
        <input type="text" v-model="username" id="username" />
      </div>
      <div>
        <label for="password">Hasło:</label>
        <input type="password" v-model="password" id="password" />
      </div>
      <button class="button-orange" type="submit">Zarejestruj się</button>
    </form>
    <p v-if="message">{{ message }}</p>
    <p v-if="errorMessage">{{ errorMessage }}</p>
  </div>
</template>

<script>
import AuthService from '../AuthService.js';

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

<style scoped>
div {
  background-color: #FFF9C4;
  border: 3px solid #FFD54F;
  border-radius: 15px;
  padding: 20px;
  margin: 30px auto;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
}

h2 {
  color: #FF6F61;
  font-size: 2em;
  margin-bottom: 10px;
  text-shadow: 1px 1px #FFD9E8;
}

p {
  font-size: 1.2em;
  line-height: 1.5;
  margin: 5px 0;
  color: #555;
}
</style>