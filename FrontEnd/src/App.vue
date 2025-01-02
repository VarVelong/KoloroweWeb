<script setup>
import { RouterLink, RouterView } from 'vue-router'

</script>

<template>

  <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
  </head>

  <div v-if="this.$isLoggedIn()" class="status">Zalogowano jako Administrator.</div>

  <header>
    <div class="header-content">
      <button @click="$router.push('/')" class="image-button">
        <img src="../src/assets/logo.png" />
      </button>
      <nav>
        <ul>
          <button @click="$router.push({ name: 'about' })">O nas</button>
          <button @click="$router.push({ name: 'post-list' })">Aktualności</button>
          <button @click="$router.push({ name: 'offer' })">Oferta</button>
          <button @click="$router.push({ name: 'employees' })">Kadra</button>
          <button @click="$router.push({ name: 'contact' })">Kontakt</button>
          <button @click="$router.push({ name: 'gallery' })">Galeria</button>
        </ul>
      </nav>
    </div>
  </header>

  <RouterView />

  <footer>
    <p>&copy; 2024 Kolorowe Przedszkole.</p>
    <div id="clear">
      <button @click="$router.push({ name: 'login' })">Login</button>
      <button @click="$router.push({ name: 'adminpage' });">AdminPage</button>
      <button v-if="this.$isLoggedIn()" @click="logout"> Logout </button>
    </div>
  </footer>

</template>

<script>

export default {
  methods: {
    handleClick() {
    },
  },

  methods: {
    logout() {
      try {
        localStorage.removeItem('user');
        console.log('User has been logged out.');
        this.$router.go();
      } catch (error) {
        console.error('Error during logout:', error);
      }
    }
  }
};

</script>

<style scoped>
#app {
  padding-top: 10%;
  padding: 0px !important;
  max-width: 100%;
}

#clear {
  background: none;
  border: 0px;
  border-radius: 0px;
  padding: 0px;
  margin: 0px;
  box-shadow: 0px 0px 0px rgba(0, 0, 0, 0);
  text-align: center;
}

div {
  padding: 20px;
  margin: 10px;
}

/* .image-button {
  border: none;
  background: none;
  padding: 0;
  cursor: pointer;
} */

.header-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.image-button img {
  max-height: 75px;
  margin-bottom: 5px;
  margin-top: 5px;
}

nav ul {
  display: flex;
  gap: 10px;
  list-style: none;
  padding: 0;
  margin: 0;
}

button {
  background: none;
  border: none;
  color: rgb(0, 0, 0);
  font-size: 16px;
  cursor: pointer;
}

button:hover {
  text-decoration: underline;
}

.status {
  margin-top: 10px;
  color: rgb(0, 0, 0);
  font-size: 14px;
  justify-content: left;
  bottom: 0;
  left: 0;
}
</style>
