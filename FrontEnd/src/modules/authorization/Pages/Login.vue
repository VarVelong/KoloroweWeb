<template>
  <div id="middle-block">
    <h2>Login</h2>
    <form @submit.prevent="login">
      <div>
        <label for="username">Nazwa:</label>
        <input type="text" v-model="username" id="username" />
      </div>
      <div>
        <label for="password">Hasło:</label>
        <input type="password" v-model="password" id="password" />
      </div>
      <button type="submit">Login</button>
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
#middle-block {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 50%;
  transform: translateX(-50%);
  width: 700px;
  background-color: rgba(0, 0, 0, 0.5);
  border: none;
  margin-top: 125px;
  border-radius: 0px;
}

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

</style>