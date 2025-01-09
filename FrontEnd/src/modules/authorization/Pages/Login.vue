<template>
  <div id="middle-block">
    <h2>Login</h2>
    <form @submit.prevent="login">
      <div class="inside-blocks">
        <label for="username">Nazwa:</label>
        <input type="text" v-model="username" id="username" />
      </div>
      <div class="inside-blocks">
        <label for="password">Hasło:</label>
        <input type="password" v-model="password" id="password" />
      </div>
      <button class="button-orange" type="submit">Login</button>
    </form>
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
      errorMessage: ''
    };
  },
  methods: {
    async login() {
      await AuthService.login({
        username: this.username,
        password: this.password
      })
        .then((token) => {
          if (token) {
            localStorage.setItem('user', token);
          }
          this.$router.push('/adminpage').then(() => {
        window.location.reload();
      });
        })
        .catch((e) => {
          this.errorMessage = 'Invalid credentials. Please try again. ';
        });
    }
  }
};
</script>

<style scoped>
.inside-blocks {
  border: 3px solid #000000;
  border-radius: 20px;
  background-color: #ddd;
  padding: 15px;
  margin: 10px 0;
  border-radius: 5px;
}

#middle-block {
  background-color: rgba(0, 0, 0, 0.5);
  width: 80%;
  border: 3px solid black;
  border-radius: 15px;
  padding: 20px;
  margin: 30px auto;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center;
  min-height: 100%;
}

</style>