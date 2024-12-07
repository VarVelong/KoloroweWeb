<script setup>
import { RouterLink, RouterView } from 'vue-router'

</script>

<template>

  <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
  </head>

  <header>
    <button @click="$router.push('/')" class="image-button">
      <img src="../src/assets/logo.png" />
    </button>
    <nav>
      <ul>
        <button @click="$router.push({ name: 'about' })">O nas</button>
        <button @click="$router.push({ name: 'post-list' })">Aktualności</button>
        <button @click="$router.push({ name: 'offer' })">Oferta</button>
        <button @click="$router.push({ name: 'personnel' })">Kadra</button>
        <button @click="$router.push({ name: 'contact' })">Kontakt</button>
      </ul>
    </nav>
  </header>

  <RouterView />

  <footer>
    <p>&copy; 2024 Kolorowe Przedszkole.</p>
    <div>
      <button @click="$router.push({ name: 'postcreation' })">Posty</button>
      <button @click="$router.push({ name: 'login' })">Login</button>
      <button @click="$router.push({ name: 'register' })">Register</button>
      <button v-if="hasToken" @click="logout"> Logout </button>
    </div>
  </footer>

</template>

<script>

export default {
  methods: {
    handleClick() {
    },
  },

  coputed: {
    hasToken() {
      return localStorage.getItem(token) != null;
    }
  },

  methods: {
    logout() {
      try {
        localStorage.removeItem('user');
        console.log('User has been logged out.');
      } catch (error) {
        console.error('Error during logout:', error);
      }
    }
  }
};

</script>

<style scoped>
#app {
  padding: 0px !important;
  max-width: none;
}

header {
  background: #3B8A3E;
  color: white;
  padding: 10px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: max-content;
}

nav ul {
  list-style: none;
  display: flex;
  gap: 15px;
}

nav a {
  color: white;
  text-decoration: none;
}

div {
  padding: 20px;
  margin: 10px;
}

.program {
  border: 1px solid #ccc;
  padding: 10px;
  margin: 10px 0;
}

footer {
  background: #333;
  color: white;
  text-align: center;
  padding: 10px;
  position: relative;
  bottom: 0;
  width: 100%;
}

.image-button {
  border: none;
  background: none;
  padding: 0;
  cursor: pointer;
}
</style>
